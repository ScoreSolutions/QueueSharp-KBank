Imports System
Imports System.Data 
Imports System.Data.SQLClient
Imports System.Data.Linq 
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports System.Linq.Expressions 
Imports DB = CenLinqDB.Common.Utilities.SQLDB
Imports CenParaDB.TABLE
Imports CenParaDB.Common.Utilities

Namespace TABLE
    'Represents a transaction for TB_FILTER_DATA table CenLinqDB.
    '[Create by  on November, 21 2013]
    Public Class TbFilterDataCenLinqDB
        Public sub TbFilterDataCenLinqDB()

        End Sub 
        ' TB_FILTER_DATA
        Const _tableName As String = "TB_FILTER_DATA"
        Dim _deletedRow As Int16 = 0

        'Set Common Property
        Dim _error As String = ""
        Dim _information As String = ""
        Dim _haveData As Boolean = False

        Public ReadOnly Property TableName As String
            Get
                Return _tableName
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
        Dim _CREATE_BY As String = ""
        Dim _CREATE_DATE As DateTime = New DateTime(1,1,1)
        Dim _UPDATE_BY As  String  = ""
        Dim _UPDATE_DATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _SHOP_ID As Long = 0
        Dim _SERVICE_DATE As DateTime = New DateTime(1,1,1)
        Dim _QUEUE_NO As String = ""
        Dim _QUEUE_UNIQUE_ID As String = ""
        Dim _MOBILE_NO As String = ""
        Dim _CUSTOMER_NAME As  String  = ""
        Dim _USERNAME As String = ""
        Dim _TB_FILTER_ID As Long = 0
        Dim _TB_ITEM_ID As  System.Nullable(Of Long)  = 0
        Dim _TEMPLATE_CODE As String = ""
        Dim _FILTER_TIME As DateTime = New DateTime(1,1,1)
        Dim _SEND_TIME As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _RESULT_TIME As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _RESULT_STATUS As Char = "0"
        Dim _RESULT As  String  = ""
        Dim _SEND_TO_SHOP_TIME As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _ATSR_CALL_TIME As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _END_TIME As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _NETWORK_TYPE As String = "ALL"
        Dim _NPS_SCORE As Long = 0
        Dim _ACTIVITY_ID_SURVEY As  String  = ""
        Dim _ACTIVITY_ID_LEAVE_VOICE As  String  = ""

        'Generate Field Property 
        <Column(Storage:="_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property ID() As Long
            Get
                Return _ID
            End Get
            Set(ByVal value As Long)
               _ID = value
            End Set
        End Property 
        <Column(Storage:="_CREATE_BY", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property CREATE_BY() As String
            Get
                Return _CREATE_BY
            End Get
            Set(ByVal value As String)
               _CREATE_BY = value
            End Set
        End Property 
        <Column(Storage:="_CREATE_DATE", DbType:="DateTime NOT NULL ",CanBeNull:=false)>  _
        Public Property CREATE_DATE() As DateTime
            Get
                Return _CREATE_DATE
            End Get
            Set(ByVal value As DateTime)
               _CREATE_DATE = value
            End Set
        End Property 
        <Column(Storage:="_UPDATE_BY", DbType:="VarChar(50)")>  _
        Public Property UPDATE_BY() As  String 
            Get
                Return _UPDATE_BY
            End Get
            Set(ByVal value As  String )
               _UPDATE_BY = value
            End Set
        End Property 
        <Column(Storage:="_UPDATE_DATE", DbType:="DateTime")>  _
        Public Property UPDATE_DATE() As  System.Nullable(Of DateTime) 
            Get
                Return _UPDATE_DATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _UPDATE_DATE = value
            End Set
        End Property 
        <Column(Storage:="_SHOP_ID", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property SHOP_ID() As Long
            Get
                Return _SHOP_ID
            End Get
            Set(ByVal value As Long)
               _SHOP_ID = value
            End Set
        End Property 
        <Column(Storage:="_SERVICE_DATE", DbType:="DateTime NOT NULL ",CanBeNull:=false)>  _
        Public Property SERVICE_DATE() As DateTime
            Get
                Return _SERVICE_DATE
            End Get
            Set(ByVal value As DateTime)
               _SERVICE_DATE = value
            End Set
        End Property 
        <Column(Storage:="_QUEUE_NO", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property QUEUE_NO() As String
            Get
                Return _QUEUE_NO
            End Get
            Set(ByVal value As String)
               _QUEUE_NO = value
            End Set
        End Property 
        <Column(Storage:="_QUEUE_UNIQUE_ID", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property QUEUE_UNIQUE_ID() As String
            Get
                Return _QUEUE_UNIQUE_ID
            End Get
            Set(ByVal value As String)
               _QUEUE_UNIQUE_ID = value
            End Set
        End Property 
        <Column(Storage:="_MOBILE_NO", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property MOBILE_NO() As String
            Get
                Return _MOBILE_NO
            End Get
            Set(ByVal value As String)
               _MOBILE_NO = value
            End Set
        End Property 
        <Column(Storage:="_CUSTOMER_NAME", DbType:="VarChar(255)")>  _
        Public Property CUSTOMER_NAME() As  String 
            Get
                Return _CUSTOMER_NAME
            End Get
            Set(ByVal value As  String )
               _CUSTOMER_NAME = value
            End Set
        End Property 
        <Column(Storage:="_USERNAME", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property USERNAME() As String
            Get
                Return _USERNAME
            End Get
            Set(ByVal value As String)
               _USERNAME = value
            End Set
        End Property 
        <Column(Storage:="_TB_FILTER_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property TB_FILTER_ID() As Long
            Get
                Return _TB_FILTER_ID
            End Get
            Set(ByVal value As Long)
               _TB_FILTER_ID = value
            End Set
        End Property 
        <Column(Storage:="_TB_ITEM_ID", DbType:="Int")>  _
        Public Property TB_ITEM_ID() As  System.Nullable(Of Long) 
            Get
                Return _TB_ITEM_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _TB_ITEM_ID = value
            End Set
        End Property 
        <Column(Storage:="_TEMPLATE_CODE", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property TEMPLATE_CODE() As String
            Get
                Return _TEMPLATE_CODE
            End Get
            Set(ByVal value As String)
               _TEMPLATE_CODE = value
            End Set
        End Property 
        <Column(Storage:="_FILTER_TIME", DbType:="DateTime NOT NULL ",CanBeNull:=false)>  _
        Public Property FILTER_TIME() As DateTime
            Get
                Return _FILTER_TIME
            End Get
            Set(ByVal value As DateTime)
               _FILTER_TIME = value
            End Set
        End Property 
        <Column(Storage:="_SEND_TIME", DbType:="DateTime")>  _
        Public Property SEND_TIME() As  System.Nullable(Of DateTime) 
            Get
                Return _SEND_TIME
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _SEND_TIME = value
            End Set
        End Property 
        <Column(Storage:="_RESULT_TIME", DbType:="DateTime")>  _
        Public Property RESULT_TIME() As  System.Nullable(Of DateTime) 
            Get
                Return _RESULT_TIME
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _RESULT_TIME = value
            End Set
        End Property 
        <Column(Storage:="_RESULT_STATUS", DbType:="Char(1) NOT NULL ",CanBeNull:=false)>  _
        Public Property RESULT_STATUS() As Char
            Get
                Return _RESULT_STATUS
            End Get
            Set(ByVal value As Char)
               _RESULT_STATUS = value
            End Set
        End Property 
        <Column(Storage:="_RESULT", DbType:="VarChar(255)")>  _
        Public Property RESULT() As  String 
            Get
                Return _RESULT
            End Get
            Set(ByVal value As  String )
               _RESULT = value
            End Set
        End Property 
        <Column(Storage:="_SEND_TO_SHOP_TIME", DbType:="DateTime")>  _
        Public Property SEND_TO_SHOP_TIME() As  System.Nullable(Of DateTime) 
            Get
                Return _SEND_TO_SHOP_TIME
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _SEND_TO_SHOP_TIME = value
            End Set
        End Property 
        <Column(Storage:="_ATSR_CALL_TIME", DbType:="DateTime")>  _
        Public Property ATSR_CALL_TIME() As  System.Nullable(Of DateTime) 
            Get
                Return _ATSR_CALL_TIME
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _ATSR_CALL_TIME = value
            End Set
        End Property 
        <Column(Storage:="_END_TIME", DbType:="DateTime")>  _
        Public Property END_TIME() As  System.Nullable(Of DateTime) 
            Get
                Return _END_TIME
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _END_TIME = value
            End Set
        End Property 
        <Column(Storage:="_NETWORK_TYPE", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property NETWORK_TYPE() As String
            Get
                Return _NETWORK_TYPE
            End Get
            Set(ByVal value As String)
               _NETWORK_TYPE = value
            End Set
        End Property 
        <Column(Storage:="_NPS_SCORE", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property NPS_SCORE() As Long
            Get
                Return _NPS_SCORE
            End Get
            Set(ByVal value As Long)
               _NPS_SCORE = value
            End Set
        End Property 
        <Column(Storage:="_ACTIVITY_ID_SURVEY", DbType:="VarChar(50)")>  _
        Public Property ACTIVITY_ID_SURVEY() As  String 
            Get
                Return _ACTIVITY_ID_SURVEY
            End Get
            Set(ByVal value As  String )
               _ACTIVITY_ID_SURVEY = value
            End Set
        End Property 
        <Column(Storage:="_ACTIVITY_ID_LEAVE_VOICE", DbType:="VarChar(50)")>  _
        Public Property ACTIVITY_ID_LEAVE_VOICE() As  String 
            Get
                Return _ACTIVITY_ID_LEAVE_VOICE
            End Get
            Set(ByVal value As  String )
               _ACTIVITY_ID_LEAVE_VOICE = value
            End Set
        End Property 


        'Clear All Data
        Private Sub ClearData()
            _ID = 0
            _CREATE_BY = ""
            _CREATE_DATE = New DateTime(1,1,1)
            _UPDATE_BY = ""
            _UPDATE_DATE = New DateTime(1,1,1)
            _SHOP_ID = 0
            _SERVICE_DATE = New DateTime(1,1,1)
            _QUEUE_NO = ""
            _QUEUE_UNIQUE_ID = ""
            _MOBILE_NO = ""
            _CUSTOMER_NAME = ""
            _USERNAME = ""
            _TB_FILTER_ID = 0
            _TB_ITEM_ID = 0
            _TEMPLATE_CODE = ""
            _FILTER_TIME = New DateTime(1,1,1)
            _SEND_TIME = New DateTime(1,1,1)
            _RESULT_TIME = New DateTime(1,1,1)
            _RESULT_STATUS = ""
            _RESULT = ""
            _SEND_TO_SHOP_TIME = New DateTime(1,1,1)
            _ATSR_CALL_TIME = New DateTime(1,1,1)
            _END_TIME = New DateTime(1,1,1)
            _NETWORK_TYPE = ""
            _NPS_SCORE = 0
            _ACTIVITY_ID_SURVEY = ""
            _ACTIVITY_ID_LEAVE_VOICE = ""
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


        '/// Returns an indication whether the current data is inserted into TB_FILTER_DATA table successfully.
        '/// <param name=userID>The current user.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if insert data successfully; otherwise, false.</returns>
        Public Function InsertData(LoginName As String,trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                _ID = DB.GetNextID("ID",tableName, trans)
                _CREATE_BY = LoginName
                _CREATE_DATE = DateTime.Now
                Return doInsert(trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is updated to TB_FILTER_DATA table successfully.
        '/// <param name=userID>The current user.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateByPK(LoginName As String,trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                _UPDATE_BY = LoginName
                _UPDATE_DATE = DateTime.Now
                Return doUpdate("ID = " & DB.SetDouble(_ID), trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is updated to TB_FILTER_DATA table successfully.
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateBySql(Sql As String, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                Return DB.ExecuteNonQuery(Sql, trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is deleted from TB_FILTER_DATA table successfully.
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if delete data successfully; otherwise, false.</returns>
        Public Function DeleteByPK(cID As Long, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                Return doDelete("ID = " & DB.SetDouble(cID), trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the record of TB_FILTER_DATA by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cID As Long, trans As SQLTransaction) As Boolean
            Return doChkData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of TB_FILTER_DATA by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cID As Long, trans As SQLTransaction) As TbFilterDataCenLinqDB
            Return doGetData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Para Class of TB_FILTER_DATA by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetParameter(cID As Long, trans As SQLTransaction) As TbFilterDataCenParaDB
            Return doMappingParameter("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record of TB_FILTER_DATA by specified SHOP_ID key is retrieved successfully.
        '/// <param name=cSHOP_ID>The SHOP_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataBySHOP_ID(cSHOP_ID As Integer, trans As SQLTransaction) As Boolean
            Return doChkData("SHOP_ID = " & DB.SetDouble(cSHOP_ID) & " ", trans)
        End Function

        '/// Returns an duplicate data record of TB_FILTER_DATA by specified SHOP_ID key is retrieved successfully.
        '/// <param name=cSHOP_ID>The SHOP_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateBySHOP_ID(cSHOP_ID As Integer, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("SHOP_ID = " & DB.SetDouble(cSHOP_ID) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of TB_FILTER_DATA by specified SERVICE_DATE key is retrieved successfully.
        '/// <param name=cSERVICE_DATE>The SERVICE_DATE key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataBySERVICE_DATE(cSERVICE_DATE As DateTime, trans As SQLTransaction) As Boolean
            Return doChkData("SERVICE_DATE = " & DB.SetDateTime(cSERVICE_DATE) & " ", trans)
        End Function

        '/// Returns an duplicate data record of TB_FILTER_DATA by specified SERVICE_DATE key is retrieved successfully.
        '/// <param name=cSERVICE_DATE>The SERVICE_DATE key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateBySERVICE_DATE(cSERVICE_DATE As DateTime, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("SERVICE_DATE = " & DB.SetDateTime(cSERVICE_DATE) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of TB_FILTER_DATA by specified MOBILE_NO key is retrieved successfully.
        '/// <param name=cMOBILE_NO>The MOBILE_NO key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByMOBILE_NO(cMOBILE_NO As String, trans As SQLTransaction) As Boolean
            Return doChkData("MOBILE_NO = " & DB.SetString(cMOBILE_NO) & " ", trans)
        End Function

        '/// Returns an duplicate data record of TB_FILTER_DATA by specified MOBILE_NO key is retrieved successfully.
        '/// <param name=cMOBILE_NO>The MOBILE_NO key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByMOBILE_NO(cMOBILE_NO As String, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("MOBILE_NO = " & DB.SetString(cMOBILE_NO) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of TB_FILTER_DATA by specified TEMPLATE_CODE key is retrieved successfully.
        '/// <param name=cTEMPLATE_CODE>The TEMPLATE_CODE key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByTEMPLATE_CODE(cTEMPLATE_CODE As String, trans As SQLTransaction) As Boolean
            Return doChkData("TEMPLATE_CODE = " & DB.SetString(cTEMPLATE_CODE) & " ", trans)
        End Function

        '/// Returns an duplicate data record of TB_FILTER_DATA by specified TEMPLATE_CODE key is retrieved successfully.
        '/// <param name=cTEMPLATE_CODE>The TEMPLATE_CODE key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByTEMPLATE_CODE(cTEMPLATE_CODE As String, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("TEMPLATE_CODE = " & DB.SetString(cTEMPLATE_CODE) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of TB_FILTER_DATA by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the current data is inserted into TB_FILTER_DATA table successfully.
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if insert data successfully; otherwise, false.</returns>
        Private Function doInsert(trans As SQLTransaction) As Boolean
            Dim ret As Boolean = True
            If _haveData = False Then
                Try

                    ret = (DB.ExecuteNonQuery(SqlInsert, trans) > 0)
                    If ret = False Then
                        _error = DB.ErrorMessage
                    Else
                        _haveData = True
                    End If
                    _information = MessageResources.MSGIN001
                Catch ex As ApplicationException
                    ret = false
                    _error = ex.Message & "ApplicationException :" & ex.ToString() & "### SQL:" & SqlInsert
                Catch ex As Exception
                    ret = False
                    _error = MessageResources.MSGEC101 & " Exception :" & ex.ToString() & "### SQL: " & SqlInsert
                End Try
            Else
                ret = False
                _error = MessageResources.MSGEN002 & "### SQL: " & SqlInsert
            End If

            Return ret
        End Function


        '/// Returns an indication whether the current data is updated to TB_FILTER_DATA table successfully.
        '/// <param name=whText>The condition specify the updating record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Private Function doUpdate(whText As String, trans As SQLTransaction) As Boolean
            Dim ret As Boolean = True
            Dim tmpWhere As String = " Where " & whText
            If _haveData = True Then
                If whText.Trim() <> ""
                    Try

                        ret = (DB.ExecuteNonQuery(SqlUpdate & tmpWhere, trans) > 0)
                        If ret = False Then
                            _error = DB.ErrorMessage
                        End If
                        _information = MessageResources.MSGIU001
                    Catch ex As ApplicationException
                        ret = False
                        _error = ex.Message & "ApplicationException :" & ex.ToString() & "### SQL:" & SqlUpdate & tmpWhere
                    Catch ex As Exception
                        ret = False
                        _error = MessageResources.MSGEC102 & " Exception :" & ex.ToString() & "### SQL: " & SqlUpdate & tmpWhere
                    End Try
                Else
                    ret = False
                    _error = MessageResources.MSGEU003 & "### SQL: " & SqlUpdate & tmpWhere
                End If
            Else
                ret = False
                _error = MessageResources.MSGEU002 & "### SQL: " & SqlUpdate & tmpWhere
            End If

            Return ret
        End Function


        '/// Returns an indication whether the current data is deleted from TB_FILTER_DATA table successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if delete data successfully; otherwise, false.</returns>
        Private Function doDelete(whText As String, trans As SQLTransaction) As Boolean
            Dim ret As Boolean = True
            Dim tmpWhere As String = " Where " & whText
            If doChkData(whText, trans) = True Then
                If whText.Trim() <> ""
                    Try
                        ret = (DB.ExecuteNonQuery(SqlDelete & tmpWhere, trans) > 0)
                        If ret = False Then
                            _error = MessageResources.MSGED001
                        End If
                        _information = MessageResources.MSGID001
                    Catch ex As ApplicationException
                        ret = False
                        _error = ex.Message & "ApplicationException :" & ex.ToString() & "### SQL:" & SqlDelete & tmpWhere
                    Catch ex As Exception
                        ret = False
                        _error = MessageResources.MSGEC103 & " Exception :" & ex.ToString() & "### SQL: " & SqlDelete & tmpWhere
                    End Try
                Else
                    ret = False
                    _error = MessageResources.MSGED003 & "### SQL: " & SqlDelete & tmpWhere
                End If
            Else
                ret = False
                _error = MessageResources.MSGEU002 & "### SQL: " & SqlDelete & tmpWhere
            End If

            Return ret
        End Function


        '/// Returns an indication whether the record of TB_FILTER_DATA by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doChkData(whText As String, trans As SQLTransaction) As Boolean
            Dim ret As Boolean = True
            Dim tmpWhere As String = " WHERE " & whText
            ClearData()
            _haveData  = False
            If whText.Trim() <> "" Then
                Dim Rdr As SQLDataReader
                Try
                    Rdr = DB.ExecuteReader(SqlSelect() & tmpWhere, trans)
                    If Rdr.Read() Then
                        _haveData = True
                        If Convert.IsDBNull(Rdr("id")) = False Then _id = Convert.ToInt64(Rdr("id"))
                        If Convert.IsDBNull(Rdr("create_by")) = False Then _create_by = Rdr("create_by").ToString()
                        If Convert.IsDBNull(Rdr("create_date")) = False Then _create_date = Convert.ToDateTime(Rdr("create_date"))
                        If Convert.IsDBNull(Rdr("update_by")) = False Then _update_by = Rdr("update_by").ToString()
                        If Convert.IsDBNull(Rdr("update_date")) = False Then _update_date = Convert.ToDateTime(Rdr("update_date"))
                        If Convert.IsDBNull(Rdr("shop_id")) = False Then _shop_id = Convert.ToInt32(Rdr("shop_id"))
                        If Convert.IsDBNull(Rdr("service_date")) = False Then _service_date = Convert.ToDateTime(Rdr("service_date"))
                        If Convert.IsDBNull(Rdr("queue_no")) = False Then _queue_no = Rdr("queue_no").ToString()
                        If Convert.IsDBNull(Rdr("queue_unique_id")) = False Then _queue_unique_id = Rdr("queue_unique_id").ToString()
                        If Convert.IsDBNull(Rdr("mobile_no")) = False Then _mobile_no = Rdr("mobile_no").ToString()
                        If Convert.IsDBNull(Rdr("customer_name")) = False Then _customer_name = Rdr("customer_name").ToString()
                        If Convert.IsDBNull(Rdr("username")) = False Then _username = Rdr("username").ToString()
                        If Convert.IsDBNull(Rdr("tb_filter_id")) = False Then _tb_filter_id = Convert.ToInt64(Rdr("tb_filter_id"))
                        If Convert.IsDBNull(Rdr("tb_item_id")) = False Then _tb_item_id = Convert.ToInt32(Rdr("tb_item_id"))
                        If Convert.IsDBNull(Rdr("template_code")) = False Then _template_code = Rdr("template_code").ToString()
                        If Convert.IsDBNull(Rdr("filter_time")) = False Then _filter_time = Convert.ToDateTime(Rdr("filter_time"))
                        If Convert.IsDBNull(Rdr("send_time")) = False Then _send_time = Convert.ToDateTime(Rdr("send_time"))
                        If Convert.IsDBNull(Rdr("result_time")) = False Then _result_time = Convert.ToDateTime(Rdr("result_time"))
                        If Convert.IsDBNull(Rdr("result_status")) = False Then _result_status = Rdr("result_status").ToString()
                        If Convert.IsDBNull(Rdr("result")) = False Then _result = Rdr("result").ToString()
                        If Convert.IsDBNull(Rdr("send_to_shop_time")) = False Then _send_to_shop_time = Convert.ToDateTime(Rdr("send_to_shop_time"))
                        If Convert.IsDBNull(Rdr("atsr_call_time")) = False Then _atsr_call_time = Convert.ToDateTime(Rdr("atsr_call_time"))
                        If Convert.IsDBNull(Rdr("end_time")) = False Then _end_time = Convert.ToDateTime(Rdr("end_time"))
                        If Convert.IsDBNull(Rdr("network_type")) = False Then _network_type = Rdr("network_type").ToString()
                        If Convert.IsDBNull(Rdr("nps_score")) = False Then _nps_score = Convert.ToInt32(Rdr("nps_score"))
                        If Convert.IsDBNull(Rdr("activity_id_survey")) = False Then _activity_id_survey = Rdr("activity_id_survey").ToString()
                        If Convert.IsDBNull(Rdr("activity_id_leave_voice")) = False Then _activity_id_leave_voice = Rdr("activity_id_leave_voice").ToString()
                    Else
                        ret = False
                        _error = MessageResources.MSGEV002
                    End If

                    Rdr.Close()
                Catch ex As Exception
                    ex.ToString()
                    ret = False
                    _error = MessageResources.MSGEC104 & " #### " & ex.ToString()
                End Try
            Else
                ret = False
                _error = MessageResources.MSGEV001
            End If

            Return ret
        End Function


        '/// Returns an indication whether the record of TB_FILTER_DATA by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction) As TbFilterDataCenLinqDB
            ClearData()
            _haveData  = False
            If whText.Trim() <> "" Then
                Dim tmpWhere As String = " WHERE " & whText
                Dim Rdr As SQLDataReader
                Try
                    Rdr = DB.ExecuteReader(SqlSelect() & tmpWhere, trans)
                    If Rdr.Read() Then
                        _haveData = True
                        If Convert.IsDBNull(Rdr("id")) = False Then _id = Convert.ToInt64(Rdr("id"))
                        If Convert.IsDBNull(Rdr("create_by")) = False Then _create_by = Rdr("create_by").ToString()
                        If Convert.IsDBNull(Rdr("create_date")) = False Then _create_date = Convert.ToDateTime(Rdr("create_date"))
                        If Convert.IsDBNull(Rdr("update_by")) = False Then _update_by = Rdr("update_by").ToString()
                        If Convert.IsDBNull(Rdr("update_date")) = False Then _update_date = Convert.ToDateTime(Rdr("update_date"))
                        If Convert.IsDBNull(Rdr("shop_id")) = False Then _shop_id = Convert.ToInt32(Rdr("shop_id"))
                        If Convert.IsDBNull(Rdr("service_date")) = False Then _service_date = Convert.ToDateTime(Rdr("service_date"))
                        If Convert.IsDBNull(Rdr("queue_no")) = False Then _queue_no = Rdr("queue_no").ToString()
                        If Convert.IsDBNull(Rdr("queue_unique_id")) = False Then _queue_unique_id = Rdr("queue_unique_id").ToString()
                        If Convert.IsDBNull(Rdr("mobile_no")) = False Then _mobile_no = Rdr("mobile_no").ToString()
                        If Convert.IsDBNull(Rdr("customer_name")) = False Then _customer_name = Rdr("customer_name").ToString()
                        If Convert.IsDBNull(Rdr("username")) = False Then _username = Rdr("username").ToString()
                        If Convert.IsDBNull(Rdr("tb_filter_id")) = False Then _tb_filter_id = Convert.ToInt64(Rdr("tb_filter_id"))
                        If Convert.IsDBNull(Rdr("tb_item_id")) = False Then _tb_item_id = Convert.ToInt32(Rdr("tb_item_id"))
                        If Convert.IsDBNull(Rdr("template_code")) = False Then _template_code = Rdr("template_code").ToString()
                        If Convert.IsDBNull(Rdr("filter_time")) = False Then _filter_time = Convert.ToDateTime(Rdr("filter_time"))
                        If Convert.IsDBNull(Rdr("send_time")) = False Then _send_time = Convert.ToDateTime(Rdr("send_time"))
                        If Convert.IsDBNull(Rdr("result_time")) = False Then _result_time = Convert.ToDateTime(Rdr("result_time"))
                        If Convert.IsDBNull(Rdr("result_status")) = False Then _result_status = Rdr("result_status").ToString()
                        If Convert.IsDBNull(Rdr("result")) = False Then _result = Rdr("result").ToString()
                        If Convert.IsDBNull(Rdr("send_to_shop_time")) = False Then _send_to_shop_time = Convert.ToDateTime(Rdr("send_to_shop_time"))
                        If Convert.IsDBNull(Rdr("atsr_call_time")) = False Then _atsr_call_time = Convert.ToDateTime(Rdr("atsr_call_time"))
                        If Convert.IsDBNull(Rdr("end_time")) = False Then _end_time = Convert.ToDateTime(Rdr("end_time"))
                        If Convert.IsDBNull(Rdr("network_type")) = False Then _network_type = Rdr("network_type").ToString()
                        If Convert.IsDBNull(Rdr("nps_score")) = False Then _nps_score = Convert.ToInt32(Rdr("nps_score"))
                        If Convert.IsDBNull(Rdr("activity_id_survey")) = False Then _activity_id_survey = Rdr("activity_id_survey").ToString()
                        If Convert.IsDBNull(Rdr("activity_id_leave_voice")) = False Then _activity_id_leave_voice = Rdr("activity_id_leave_voice").ToString()
                    Else
                        _error = MessageResources.MSGEV002
                    End If

                    Rdr.Close()
                Catch ex As Exception
                    ex.ToString()
                    _error = MessageResources.MSGEC104 & " #### " & ex.ToString()
                End Try
            Else
                _error = MessageResources.MSGEV001
            End If
            Return Me
        End Function


        '/// Returns an indication whether the Class Data of TB_FILTER_DATA by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doMappingParameter(whText As String, trans As SQLTransaction) As TbFilterDataCenParaDB
            ClearData()
            _haveData  = False
            Dim ret As New TbFilterDataCenParaDB
            If whText.Trim() <> "" Then
                Dim tmpWhere As String = " WHERE " & whText
                Dim Rdr As SQLDataReader
                Try
                    Rdr = DB.ExecuteReader(SqlSelect() & tmpWhere, trans)
                    If Rdr.Read() Then
                        _haveData = True
                        If Convert.IsDBNull(Rdr("id")) = False Then ret.id = Convert.ToInt64(Rdr("id"))
                        If Convert.IsDBNull(Rdr("create_by")) = False Then ret.create_by = Rdr("create_by").ToString()
                        If Convert.IsDBNull(Rdr("create_date")) = False Then ret.create_date = Convert.ToDateTime(Rdr("create_date"))
                        If Convert.IsDBNull(Rdr("update_by")) = False Then ret.update_by = Rdr("update_by").ToString()
                        If Convert.IsDBNull(Rdr("update_date")) = False Then ret.update_date = Convert.ToDateTime(Rdr("update_date"))
                        If Convert.IsDBNull(Rdr("shop_id")) = False Then ret.shop_id = Convert.ToInt32(Rdr("shop_id"))
                        If Convert.IsDBNull(Rdr("service_date")) = False Then ret.service_date = Convert.ToDateTime(Rdr("service_date"))
                        If Convert.IsDBNull(Rdr("queue_no")) = False Then ret.queue_no = Rdr("queue_no").ToString()
                        If Convert.IsDBNull(Rdr("queue_unique_id")) = False Then ret.queue_unique_id = Rdr("queue_unique_id").ToString()
                        If Convert.IsDBNull(Rdr("mobile_no")) = False Then ret.mobile_no = Rdr("mobile_no").ToString()
                        If Convert.IsDBNull(Rdr("customer_name")) = False Then ret.customer_name = Rdr("customer_name").ToString()
                        If Convert.IsDBNull(Rdr("username")) = False Then ret.username = Rdr("username").ToString()
                        If Convert.IsDBNull(Rdr("tb_filter_id")) = False Then ret.tb_filter_id = Convert.ToInt64(Rdr("tb_filter_id"))
                        If Convert.IsDBNull(Rdr("tb_item_id")) = False Then ret.tb_item_id = Convert.ToInt32(Rdr("tb_item_id"))
                        If Convert.IsDBNull(Rdr("template_code")) = False Then ret.template_code = Rdr("template_code").ToString()
                        If Convert.IsDBNull(Rdr("filter_time")) = False Then ret.filter_time = Convert.ToDateTime(Rdr("filter_time"))
                        If Convert.IsDBNull(Rdr("send_time")) = False Then ret.send_time = Convert.ToDateTime(Rdr("send_time"))
                        If Convert.IsDBNull(Rdr("result_time")) = False Then ret.result_time = Convert.ToDateTime(Rdr("result_time"))
                        If Convert.IsDBNull(Rdr("result_status")) = False Then ret.result_status = Rdr("result_status").ToString()
                        If Convert.IsDBNull(Rdr("result")) = False Then ret.result = Rdr("result").ToString()
                        If Convert.IsDBNull(Rdr("send_to_shop_time")) = False Then ret.send_to_shop_time = Convert.ToDateTime(Rdr("send_to_shop_time"))
                        If Convert.IsDBNull(Rdr("atsr_call_time")) = False Then ret.atsr_call_time = Convert.ToDateTime(Rdr("atsr_call_time"))
                        If Convert.IsDBNull(Rdr("end_time")) = False Then ret.end_time = Convert.ToDateTime(Rdr("end_time"))
                        If Convert.IsDBNull(Rdr("network_type")) = False Then ret.network_type = Rdr("network_type").ToString()
                        If Convert.IsDBNull(Rdr("nps_score")) = False Then ret.nps_score = Convert.ToInt32(Rdr("nps_score"))
                        If Convert.IsDBNull(Rdr("activity_id_survey")) = False Then ret.activity_id_survey = Rdr("activity_id_survey").ToString()
                        If Convert.IsDBNull(Rdr("activity_id_leave_voice")) = False Then ret.activity_id_leave_voice = Rdr("activity_id_leave_voice").ToString()

                    Else
                        _error = MessageResources.MSGEV002
                    End If

                    Rdr.Close()
                Catch ex As Exception
                    ex.ToString()
                    _error = MessageResources.MSGEC104 & " #### " & ex.ToString()
                End Try
            Else
                _error = MessageResources.MSGEV001
            End If
            Return ret
        End Function

        ' SQL Statements


        'Get Insert Statement for table TB_FILTER_DATA
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & tableName  & " (ID, CREATE_BY, CREATE_DATE, UPDATE_BY, UPDATE_DATE, SHOP_ID, SERVICE_DATE, QUEUE_NO, QUEUE_UNIQUE_ID, MOBILE_NO, CUSTOMER_NAME, USERNAME, TB_FILTER_ID, TB_ITEM_ID, TEMPLATE_CODE, FILTER_TIME, SEND_TIME, RESULT_TIME, RESULT_STATUS, RESULT, SEND_TO_SHOP_TIME, ATSR_CALL_TIME, END_TIME, NETWORK_TYPE, NPS_SCORE, ACTIVITY_ID_SURVEY, ACTIVITY_ID_LEAVE_VOICE)"
                Sql += " VALUES("
                sql += DB.SetDouble(_ID) & ", "
                sql += DB.SetString(_CREATE_BY) & ", "
                sql += DB.SetDateTime(_CREATE_DATE) & ", "
                sql += DB.SetString(_UPDATE_BY) & ", "
                sql += DB.SetDateTime(_UPDATE_DATE) & ", "
                sql += DB.SetDouble(_SHOP_ID) & ", "
                sql += DB.SetDateTime(_SERVICE_DATE) & ", "
                sql += DB.SetString(_QUEUE_NO) & ", "
                sql += DB.SetString(_QUEUE_UNIQUE_ID) & ", "
                sql += DB.SetString(_MOBILE_NO) & ", "
                sql += DB.SetString(_CUSTOMER_NAME) & ", "
                sql += DB.SetString(_USERNAME) & ", "
                sql += DB.SetDouble(_TB_FILTER_ID) & ", "
                sql += DB.SetDouble(_TB_ITEM_ID) & ", "
                sql += DB.SetString(_TEMPLATE_CODE) & ", "
                sql += DB.SetDateTime(_FILTER_TIME) & ", "
                sql += DB.SetDateTime(_SEND_TIME) & ", "
                sql += DB.SetDateTime(_RESULT_TIME) & ", "
                sql += DB.SetString(_RESULT_STATUS) & ", "
                sql += DB.SetString(_RESULT) & ", "
                sql += DB.SetDateTime(_SEND_TO_SHOP_TIME) & ", "
                sql += DB.SetDateTime(_ATSR_CALL_TIME) & ", "
                sql += DB.SetDateTime(_END_TIME) & ", "
                sql += DB.SetString(_NETWORK_TYPE) & ", "
                sql += DB.SetDouble(_NPS_SCORE) & ", "
                sql += DB.SetString(_ACTIVITY_ID_SURVEY) & ", "
                sql += DB.SetString(_ACTIVITY_ID_LEAVE_VOICE)
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table TB_FILTER_DATA
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "CREATE_BY = " & DB.SetString(_CREATE_BY) & ", "
                Sql += "CREATE_DATE = " & DB.SetDateTime(_CREATE_DATE) & ", "
                Sql += "UPDATE_BY = " & DB.SetString(_UPDATE_BY) & ", "
                Sql += "UPDATE_DATE = " & DB.SetDateTime(_UPDATE_DATE) & ", "
                Sql += "SHOP_ID = " & DB.SetDouble(_SHOP_ID) & ", "
                Sql += "SERVICE_DATE = " & DB.SetDateTime(_SERVICE_DATE) & ", "
                Sql += "QUEUE_NO = " & DB.SetString(_QUEUE_NO) & ", "
                Sql += "QUEUE_UNIQUE_ID = " & DB.SetString(_QUEUE_UNIQUE_ID) & ", "
                Sql += "MOBILE_NO = " & DB.SetString(_MOBILE_NO) & ", "
                Sql += "CUSTOMER_NAME = " & DB.SetString(_CUSTOMER_NAME) & ", "
                Sql += "USERNAME = " & DB.SetString(_USERNAME) & ", "
                Sql += "TB_FILTER_ID = " & DB.SetDouble(_TB_FILTER_ID) & ", "
                Sql += "TB_ITEM_ID = " & DB.SetDouble(_TB_ITEM_ID) & ", "
                Sql += "TEMPLATE_CODE = " & DB.SetString(_TEMPLATE_CODE) & ", "
                Sql += "FILTER_TIME = " & DB.SetDateTime(_FILTER_TIME) & ", "
                Sql += "SEND_TIME = " & DB.SetDateTime(_SEND_TIME) & ", "
                Sql += "RESULT_TIME = " & DB.SetDateTime(_RESULT_TIME) & ", "
                Sql += "RESULT_STATUS = " & DB.SetString(_RESULT_STATUS) & ", "
                Sql += "RESULT = " & DB.SetString(_RESULT) & ", "
                Sql += "SEND_TO_SHOP_TIME = " & DB.SetDateTime(_SEND_TO_SHOP_TIME) & ", "
                Sql += "ATSR_CALL_TIME = " & DB.SetDateTime(_ATSR_CALL_TIME) & ", "
                Sql += "END_TIME = " & DB.SetDateTime(_END_TIME) & ", "
                Sql += "NETWORK_TYPE = " & DB.SetString(_NETWORK_TYPE) & ", "
                Sql += "NPS_SCORE = " & DB.SetDouble(_NPS_SCORE) & ", "
                Sql += "ACTIVITY_ID_SURVEY = " & DB.SetString(_ACTIVITY_ID_SURVEY) & ", "
                Sql += "ACTIVITY_ID_LEAVE_VOICE = " & DB.SetString(_ACTIVITY_ID_LEAVE_VOICE) + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table TB_FILTER_DATA
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table TB_FILTER_DATA
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT ID, CREATE_BY, CREATE_DATE, UPDATE_BY, UPDATE_DATE, SHOP_ID, SERVICE_DATE, QUEUE_NO, QUEUE_UNIQUE_ID, MOBILE_NO, CUSTOMER_NAME, USERNAME, TB_FILTER_ID, TB_ITEM_ID, TEMPLATE_CODE, FILTER_TIME, SEND_TIME, RESULT_TIME, RESULT_STATUS, RESULT, SEND_TO_SHOP_TIME, ATSR_CALL_TIME, END_TIME, NETWORK_TYPE, NPS_SCORE, ACTIVITY_ID_SURVEY, ACTIVITY_ID_LEAVE_VOICE FROM " & tableName
                Return Sql
            End Get
        End Property


    End Class
End Namespace
