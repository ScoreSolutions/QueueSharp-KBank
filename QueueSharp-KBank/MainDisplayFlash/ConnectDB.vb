﻿Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports Microsoft.Win32
Imports System.Configuration
Imports MainDisplayFlash.Org.Mentalis.Files
'Summary description for DBClass
'Class สำหรับ connect database สามารถ ใช้งานได้กับ ACCESS,SQL Server,Oracle
'เขียนขึ้นโดย Pheak Email manop.muangpia@hotmail.com
'มีข้อสงสัย,bug แจ้งได้ทาง Email ครับ

#Region "ตัวอย่างการใช้งาน"
'ดึงข้อมูล
'string sql1 = "Select * from Employees";
'DataSet dsEmp1 = new DBClass().SqlGet(sql1,"tblEmployee");

'command insert,delete,update
'string sql3 = "Insert into Employees(empId,empName) " +
'" Values(1,'pheak')";
'int i = new DBClass().SqlExecute(sql3);

'สามารถใช้งาน Parameters ได้ เช่น
'string sql4 = "Insert into Employees(empId,empName) " +
'" Values(@empId,@empName) ";
'SqlParameterCollection param2 = new SqlCommand().Parameters;
'param2.AddWithValue("empId", SqlDbType.Int).Value = 1;
'param2.AddWithValue("empName",SqlDbType.VarChar).Value = "pheak";
'int i2 = new DBClass().SqlExecute(sql4, param2);
#End Region

'ประกาศ Connection ของแต่ละ Database

Public Class ConnectDB
    Dim iniReader As New IniReader(Application.StartupPath & "\Maindisplay.ini")
    'Access
    Public Function AccessStrCon() As OleDbConnection
        Return New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\xxxx.mdb")
    End Function

    Public Function GetConn(Optional ByVal msg As Boolean = True) As SqlConnection
        Dim conn As New SqlConnection
        'แก้ไขเรื่อง Fail Over ในขั้นตอนที่ Connect DB
        If Engine.Common.ShopConnectDBENG.CheckDBConn(conn, iniReader.Filename, "MainDisplayFlash", "ConnectDB_GetConn", "") = True Then
            Return conn
        Else
            Return Nothing
        End If
    End Function
End Class
Public Class DBClass
    'SQL Server Class
#Region ""
    Public Function SqlGet(ByVal sql As String, ByVal tblName As String) As DataSet
        Dim conn As SqlConnection
        conn = New ConnectDB().GetConn
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If

        Dim da As New SqlDataAdapter(sql, conn)
        Dim ds As New DataSet()
        da.Fill(ds, tblName)
        Return ds
    End Function
    Public Function SqlGet(ByVal sql As String, ByVal tblName As String, ByVal parameters As SqlParameterCollection) As DataSet
        Dim conn As SqlConnection
        conn = New ConnectDB().GetConn
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        Dim da As New SqlDataAdapter(sql, conn)
        Dim ds As New DataSet()
        For Each param As SqlParameter In parameters
            da.SelectCommand.Parameters.AddWithValue(param.ParameterName, param.SqlDbType).Value = param.Value
        Next
        da.Fill(ds, tblName)
        Return ds
    End Function
    Public Function SqlExecuteScalar(ByVal sql As String) As Integer
        Dim i As Integer
        Dim conn As SqlConnection
        conn = New ConnectDB().GetConn
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        Dim cmd As New SqlCommand(sql, conn)

        Try
            conn.Open()
            i = cmd.ExecuteScalar
        Catch ex As Exception
            i = 0
        End Try
        conn.Close()
        Return i
    End Function
    Public Function SqlExecute(ByVal sql As String) As Integer
        Dim i As Integer
        Dim conn As SqlConnection
        conn = New ConnectDB().GetConn
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        Dim cmd As New SqlCommand(sql, conn)

        Try
            conn.Open()
            i = cmd.ExecuteNonQuery()
        Catch ex As Exception
            i = 0
        End Try
        conn.Close()
        Return i
    End Function
    Public Function SqlExecute(ByVal sql As String, ByVal parameters As SqlParameterCollection) As Integer
        Dim i As Integer
        Dim conn As SqlConnection
        conn = New ConnectDB().GetConn
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        Dim cmd As New SqlCommand(sql, conn)
        For Each param As SqlParameter In parameters
            cmd.Parameters.AddWithValue(param.ParameterName, param.SqlDbType).Value = param.Value
        Next

        Try
            conn.Open()
            i = cmd.ExecuteNonQuery()
        Catch ex As Exception
            i = 0
        End Try

        conn.Close()
        Return i
    End Function
    Public Function SqlExcSto(ByVal stpName As String, ByVal tblName As String, ByVal parameters As SqlParameterCollection) As DataSet
        Dim conn As SqlConnection
        conn = New ConnectDB().GetConn
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        Dim cmd As New SqlCommand()
        cmd.Connection = conn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = stpName
        For Each param As SqlParameter In parameters
            cmd.Parameters.AddWithValue(param.ParameterName, param.SqlDbType).Value = param.Value
        Next
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet()
        da.Fill(ds, tblName)
        Return ds
    End Function
#End Region

    'Access Class
#Region ""
    Public Function AccGet(ByVal sql As String, ByVal tblName As String) As DataSet
        Dim conn As OleDbConnection = New ConnectDB().AccessStrCon()
        Dim da As New OleDbDataAdapter(sql, conn)
        Dim ds As New DataSet()
        da.Fill(ds, tblName)
        Return ds
    End Function
    Public Function AccGet(ByVal sql As String, ByVal tblName As String, ByVal parameters As OleDbParameterCollection) As DataSet
        Dim conn As OleDbConnection = New ConnectDB().AccessStrCon()
        Dim da As New OleDbDataAdapter(sql, conn)
        Dim ds As New DataSet()
        For Each param As OleDbParameter In parameters
            da.SelectCommand.Parameters.AddWithValue(param.ParameterName, param.OleDbType).Value = param.Value
        Next
        da.Fill(ds, tblName)
        Return ds
    End Function
    Public Function AccExecute(ByVal sql As String) As Integer
        Dim i As Integer
        Dim conn As OleDbConnection = New ConnectDB().AccessStrCon()
        Dim cmd As New OleDbCommand(sql, conn)
        conn.Open()
        i = cmd.ExecuteNonQuery()
        conn.Close()
        Return i
    End Function
    Public Function AccExecute(ByVal sql As String, ByVal parameters As OleDbParameterCollection) As Integer
        Dim i As Integer
        Dim conn As OleDbConnection = New ConnectDB().AccessStrCon()
        Dim cmd As New OleDbCommand(sql, conn)
        For Each param As OleDbParameter In parameters
            cmd.Parameters.AddWithValue(param.ParameterName, param.OleDbType).Value = param.Value
        Next
        conn.Open()
        i = cmd.ExecuteNonQuery()
        conn.Close()
        Return i
    End Function
#End Region

    Public Shared Function CheckDatabaseExists() As Boolean

        'Dim connString As String = ("Data Source=" & r.pServer & ";Initial Catalog=master;Integrated Security=True;")
        ''Dim connString As String = ("Data Source=" & r.pServer & ";Initial Catalog=" & r.pDBName & ";Persist Security Info=True;User ID=" & r.pUserName & ";Password=" & r.pPassword)
        'Dim cmdText As String = ("select * from master.dbo.sysdatabases where name='" & r.pDBName & "'")
        'Dim bRet As Boolean = False
        'Using sqlConnection As SqlConnection = New SqlConnection(connString)
        '    sqlConnection.Open()
        '    Using sqlCmd As SqlCommand = New SqlCommand(cmdText, sqlConnection)
        '        Using reader As SqlDataReader = sqlCmd.ExecuteReader
        '            bRet = reader.HasRows
        '        End Using
        '    End Using
        'End Using
        'Return bRet
    End Function
  
End Class