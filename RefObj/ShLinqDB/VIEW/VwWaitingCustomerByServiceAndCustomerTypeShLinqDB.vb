Imports System
Imports System.Data 
Imports System.Data.SQLClient
Imports System.Data.Linq 
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports System.Linq.Expressions 
Imports DB = ShLinqDB.Common.Utilities.SQLDB
Imports ShParaDB.VIEW
Imports ShParaDB.Common.Utilities

Namespace VIEW
    'Represents a transaction for VW_Waiting_Customer_by_service_and_customer_type view ShLinqDB.
    '[Create by  on Febuary, 27 2012]
    Public Class VwWaitingCustomerByServiceAndCustomerTypeShLinqDB
        Public sub VwWaitingCustomerByServiceAndCustomerTypeShLinqDB()

        End Sub 
        ' VW_Waiting_Customer_by_service_and_customer_type
        Const _viewName As String = "VW_Waiting_Customer_by_service_and_customer_type"

        'Set Common Property
        Dim _error As String = ""
        Dim _information As String = ""
        Dim _haveData As Boolean = False

        Public ReadOnly Property ViewName As String
            Get
                Return _viewName
            End Get
        End Property
        Public ReadOnly Property ErrorMessage As String
            Get
                Return _error
            End Get
        End Property
        Public ReadOnly Property InfoMessage As String
            Get
                Return _information
            End Get
        End Property
        Public ReadOnly Property HaveData As Boolean
            Get
                Return _haveData
            End Get
        End Property


        'Generate Field List
        Dim _ID As Long = 0
        Dim _ITEM_NAME As  String  = ""
        Dim _ITEM_NAME_TH As  String  = ""
        Dim _ITEM_ORDER As  System.Nullable(Of Long)  = 0
        Dim _ITEM_TIME As  System.Nullable(Of Long)  = 0
        Dim _ITEM_WAIT As  System.Nullable(Of Long)  = 0
        Dim _COUNT_QUEUE As Long = 0
        Dim _APP_QUEUE As Long = 0
        Dim _COUNT_AGENT As Long = 0
        Dim _WAIT_TIME As  String  = ""
        Dim _TIME As  System.Nullable(Of Long)  = 0

        'Generate Field Property 
        <Column(Storage:="_ID", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property ID() As Long
            Get
                Return _ID
            End Get
            Set(ByVal value As Long)
               _ID = value
            End Set
        End Property 
        <Column(Storage:="_ITEM_NAME", DbType:="VarChar(50)")>  _
        Public Property ITEM_NAME() As  String 
            Get
                Return _ITEM_NAME
            End Get
            Set(ByVal value As  String )
               _ITEM_NAME = value
            End Set
        End Property 
        <Column(Storage:="_ITEM_NAME_TH", DbType:="VarChar(50)")>  _
        Public Property ITEM_NAME_TH() As  String 
            Get
                Return _ITEM_NAME_TH
            End Get
            Set(ByVal value As  String )
               _ITEM_NAME_TH = value
            End Set
        End Property 
        <Column(Storage:="_ITEM_ORDER", DbType:="SmallInt")>  _
        Public Property ITEM_ORDER() As  System.Nullable(Of Long) 
            Get
                Return _ITEM_ORDER
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _ITEM_ORDER = value
            End Set
        End Property 
        <Column(Storage:="_ITEM_TIME", DbType:="Int")>  _
        Public Property ITEM_TIME() As  System.Nullable(Of Long) 
            Get
                Return _ITEM_TIME
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _ITEM_TIME = value
            End Set
        End Property 
        <Column(Storage:="_ITEM_WAIT", DbType:="Int")>  _
        Public Property ITEM_WAIT() As  System.Nullable(Of Long) 
            Get
                Return _ITEM_WAIT
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _ITEM_WAIT = value
            End Set
        End Property 
        <Column(Storage:="_COUNT_QUEUE", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property COUNT_QUEUE() As Long
            Get
                Return _COUNT_QUEUE
            End Get
            Set(ByVal value As Long)
               _COUNT_QUEUE = value
            End Set
        End Property 
        <Column(Storage:="_APP_QUEUE", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property APP_QUEUE() As Long
            Get
                Return _APP_QUEUE
            End Get
            Set(ByVal value As Long)
               _APP_QUEUE = value
            End Set
        End Property 
        <Column(Storage:="_COUNT_AGENT", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property COUNT_AGENT() As Long
            Get
                Return _COUNT_AGENT
            End Get
            Set(ByVal value As Long)
               _COUNT_AGENT = value
            End Set
        End Property 
        <Column(Storage:="_WAIT_TIME", DbType:="VarChar(5)")>  _
        Public Property WAIT_TIME() As  String 
            Get
                Return _WAIT_TIME
            End Get
            Set(ByVal value As  String )
               _WAIT_TIME = value
            End Set
        End Property 
        <Column(Storage:="_TIME", DbType:="Int")>  _
        Public Property TIME() As  System.Nullable(Of Long) 
            Get
                Return _TIME
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _TIME = value
            End Set
        End Property 


        'Clear All Data
        Private Sub ClearData()
            _ID = 0
            _ITEM_NAME = ""
            _ITEM_NAME_TH = ""
            _ITEM_ORDER = 0
            _ITEM_TIME = 0
            _ITEM_WAIT = 0
            _COUNT_QUEUE = 0
            _APP_QUEUE = 0
            _COUNT_AGENT = 0
            _WAIT_TIME = ""
            _TIME = 0
        End Sub

       'Define Public Method 
        'Execute the select statement with the specified condition and return a System.Data.DataTable.
        '/// <param name=whereClause>The condition for execute select statement.</param>
        '/// <param name=orderBy>The fields for sort data.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>The System.Data.DataTable object for specified condition.</returns>
        Public Function GetDataList(whClause As String, orderBy As String, trans As SQLTransaction) As DataTable
            Return DB.ExecuteTable(SqlSelect & IIf(whClause = "", "", " WHERE " & whClause) & IIF(orderBy = "", "", " ORDER BY  " & orderBy), trans)
        End Function


        'Execute the select statement with the specified condition and return a System.Data.DataTable.
        '/// <param name=whereClause>The condition for execute select statement.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>The System.Data.DataTable object for specified condition.</returns>
        Public Function GetListBySql(Sql As String, trans As SQLTransaction) As DataTable
            Return DB.ExecuteTable(Sql, trans)
        End Function


        '/// Returns an indication whether the record of VW_Waiting_Customer_by_service_and_customer_type by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the record of VW_Waiting_Customer_by_service_and_customer_type by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doChkData(whText As String, trans As SQLTransaction) As Boolean
            Dim ret As Boolean = True
            ClearData()
            _haveData  = False
            If whText.Trim() <> "" Then
                Dim tmpWhere As String = " WHERE " & whText
                Dim Rdr As SQLDataReader
                Try
                    Rdr = DB.ExecuteReader(SqlSelect() & tmpWhere, trans)
                    If Rdr.Read() Then
                        _haveData = True
                        If Convert.IsDBNull(Rdr("id")) = False Then _id = Convert.ToInt32(Rdr("id"))
                        If Convert.IsDBNull(Rdr("item_name")) = False Then _item_name = Rdr("item_name").ToString()
                        If Convert.IsDBNull(Rdr("item_name_th")) = False Then _item_name_th = Rdr("item_name_th").ToString()
                        If Convert.IsDBNull(Rdr("item_order")) = False Then _item_order = Convert.ToInt16(Rdr("item_order"))
                        If Convert.IsDBNull(Rdr("item_time")) = False Then _item_time = Convert.ToInt32(Rdr("item_time"))
                        If Convert.IsDBNull(Rdr("item_wait")) = False Then _item_wait = Convert.ToInt32(Rdr("item_wait"))
                        If Convert.IsDBNull(Rdr("count_queue")) = False Then _count_queue = Convert.ToInt32(Rdr("count_queue"))
                        If Convert.IsDBNull(Rdr("app_queue")) = False Then _app_queue = Convert.ToInt32(Rdr("app_queue"))
                        If Convert.IsDBNull(Rdr("count_agent")) = False Then _count_agent = Convert.ToInt32(Rdr("count_agent"))
                        If Convert.IsDBNull(Rdr("wait_time")) = False Then _wait_time = Rdr("wait_time").ToString()
                        If Convert.IsDBNull(Rdr("time")) = False Then _time = Convert.ToInt32(Rdr("time"))
                    Else
                        ret = False
                        _error = MessageResources.MSGEV002
                    End If

                    Rdr.Close()
                Catch ex As Exception
                    ex.ToString()
                    ret = False
                    _error = MessageResources.MSGEC104
                    If Rdr IsNot Nothing And Rdr.IsClosed=False Then
                        Rdr.Close()
                    End If
                End Try
            Else
                ret = False
                _error = MessageResources.MSGEV001
            End If

            Return ret
        End Function


        '/// Returns an indication whether the record of VW_Waiting_Customer_by_service_and_customer_type by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction) As VwWaitingCustomerByServiceAndCustomerTypeShLinqDB
            ClearData()
            _haveData  = False
            If whText.Trim() <> "" Then
                Dim tmpWhere As String = " WHERE " & whText
                Dim Rdr As SQLDataReader
                Try
                    Rdr = DB.ExecuteReader(SqlSelect() & tmpWhere, trans)
                    If Rdr.Read() Then
                        _haveData = True
                        If Convert.IsDBNull(Rdr("id")) = False Then _id = Convert.ToInt32(Rdr("id"))
                        If Convert.IsDBNull(Rdr("item_name")) = False Then _item_name = Rdr("item_name").ToString()
                        If Convert.IsDBNull(Rdr("item_name_th")) = False Then _item_name_th = Rdr("item_name_th").ToString()
                        If Convert.IsDBNull(Rdr("item_order")) = False Then _item_order = Convert.ToInt16(Rdr("item_order"))
                        If Convert.IsDBNull(Rdr("item_time")) = False Then _item_time = Convert.ToInt32(Rdr("item_time"))
                        If Convert.IsDBNull(Rdr("item_wait")) = False Then _item_wait = Convert.ToInt32(Rdr("item_wait"))
                        If Convert.IsDBNull(Rdr("count_queue")) = False Then _count_queue = Convert.ToInt32(Rdr("count_queue"))
                        If Convert.IsDBNull(Rdr("app_queue")) = False Then _app_queue = Convert.ToInt32(Rdr("app_queue"))
                        If Convert.IsDBNull(Rdr("count_agent")) = False Then _count_agent = Convert.ToInt32(Rdr("count_agent"))
                        If Convert.IsDBNull(Rdr("wait_time")) = False Then _wait_time = Rdr("wait_time").ToString()
                        If Convert.IsDBNull(Rdr("time")) = False Then _time = Convert.ToInt32(Rdr("time"))

                        'Generate Item For Child Table
                    Else
                        _error = MessageResources.MSGEV002
                    End If

                    Rdr.Close()
                Catch ex As Exception
                    ex.ToString()
                    _error = MessageResources.MSGEC104
                    If Rdr IsNot Nothing And Rdr.IsClosed=False Then
                        Rdr.Close()
                    End If
                End Try
            Else
                _error = MessageResources.MSGEV001
            End If
            Return Me
        End Function


        '/// Returns an indication whether the Class Data of VW_Waiting_Customer_by_service_and_customer_type by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doMappingParameter(whText As String, trans As SQLTransaction) As VwWaitingCustomerByServiceAndCustomerTypeShParaDB
            ClearData()
            _haveData  = False
            Dim ret As New VwWaitingCustomerByServiceAndCustomerTypeShParaDB
            If whText.Trim() <> "" Then
                Dim tmpWhere As String = " WHERE " & whText
                Dim Rdr As SQLDataReader
                Try
                    Rdr = DB.ExecuteReader(SqlSelect() & tmpWhere, trans)
                    If Rdr.Read() Then
                        _haveData = True
                        If Convert.IsDBNull(Rdr("id")) = False Then ret.id = Convert.ToInt32(Rdr("id"))
                        If Convert.IsDBNull(Rdr("item_name")) = False Then ret.item_name = Rdr("item_name").ToString()
                        If Convert.IsDBNull(Rdr("item_name_th")) = False Then ret.item_name_th = Rdr("item_name_th").ToString()
                        If Convert.IsDBNull(Rdr("item_order")) = False Then ret.item_order = Convert.ToInt16(Rdr("item_order"))
                        If Convert.IsDBNull(Rdr("item_time")) = False Then ret.item_time = Convert.ToInt32(Rdr("item_time"))
                        If Convert.IsDBNull(Rdr("item_wait")) = False Then ret.item_wait = Convert.ToInt32(Rdr("item_wait"))
                        If Convert.IsDBNull(Rdr("count_queue")) = False Then ret.count_queue = Convert.ToInt32(Rdr("count_queue"))
                        If Convert.IsDBNull(Rdr("app_queue")) = False Then ret.app_queue = Convert.ToInt32(Rdr("app_queue"))
                        If Convert.IsDBNull(Rdr("count_agent")) = False Then ret.count_agent = Convert.ToInt32(Rdr("count_agent"))
                        If Convert.IsDBNull(Rdr("wait_time")) = False Then ret.wait_time = Rdr("wait_time").ToString()
                        If Convert.IsDBNull(Rdr("time")) = False Then ret.time = Convert.ToInt32(Rdr("time"))

                        'Generate Item For Child Table

                    Else
                        _error = MessageResources.MSGEV002
                    End If

                    Rdr.Close()
                Catch ex As Exception
                    ex.ToString()
                    _error = MessageResources.MSGEC104
                    If Rdr IsNot Nothing And Rdr.IsClosed=False Then
                        Rdr.Close()
                    End If
                End Try
            Else
                _error = MessageResources.MSGEV001
            End If
            Return ret
        End Function

        ' SQL Statements


        'Get Select Statement for table VW_Waiting_Customer_by_service_and_customer_type
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT * FROM " & viewName
                Return Sql
            End Get
        End Property


    End Class
End Namespace
