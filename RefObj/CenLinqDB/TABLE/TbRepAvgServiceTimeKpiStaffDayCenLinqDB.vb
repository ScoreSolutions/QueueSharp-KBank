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
    'Represents a transaction for TB_REP_AVG_SERVICE_TIME_KPI_STAFF_DAY table CenLinqDB.
    '[Create by  on June, 8 2012]
    Public Class TbRepAvgServiceTimeKpiStaffDayCenLinqDB
        Public sub TbRepAvgServiceTimeKpiStaffDayCenLinqDB()

        End Sub 
        ' TB_REP_AVG_SERVICE_TIME_KPI_STAFF_DAY
        Const _tableName As String = "TB_REP_AVG_SERVICE_TIME_KPI_STAFF_DAY"
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
        Dim _SHOP_NAME_TH As String = ""
        Dim _SHOP_NAME_EN As String = ""
        Dim _USER_ID As Long = 0
        Dim _USER_CODE As String = ""
        Dim _USER_NAME As String = ""
        Dim _STAFF_NAME As String = ""
        Dim _SERVICE_ID As Long = 0
        Dim _SERVICE_NAME As String = ""
        Dim _SERVICE_DATE As DateTime = New DateTime(1,1,1)
        Dim _SHOW_DATE As String = ""
        Dim _SHOW_DAY As String = ""
        Dim _SHOW_WEEK As String = ""
        Dim _SHOW_YEAR As Long = 0
        Dim _REGIS As Long = 0
        Dim _SERVED As Long = 0
        Dim _MISSED_CALL As Long = 0
        Dim _CANCEL As Long = 0
        Dim _WAIT_WITH_KPI As Long = 0
        Dim _SERVE_WITH_KPI As Long = 0
        Dim _NOTCALL As Long = 0
        Dim _NOTCON As Long = 0
        Dim _NOTEND As Long = 0
        Dim _ACONT As Long = 0
        Dim _SCONT As Long = 0
        Dim _CCONT As Long = 0
        Dim _MAX_WT As String = ""
        Dim _MAX_HT As String = ""

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
        <Column(Storage:="_CREATE_BY", DbType:="VarChar(20) NOT NULL ",CanBeNull:=false)>  _
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
        <Column(Storage:="_UPDATE_BY", DbType:="VarChar(20)")>  _
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
        <Column(Storage:="_SHOP_NAME_TH", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property SHOP_NAME_TH() As String
            Get
                Return _SHOP_NAME_TH
            End Get
            Set(ByVal value As String)
               _SHOP_NAME_TH = value
            End Set
        End Property 
        <Column(Storage:="_SHOP_NAME_EN", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property SHOP_NAME_EN() As String
            Get
                Return _SHOP_NAME_EN
            End Get
            Set(ByVal value As String)
               _SHOP_NAME_EN = value
            End Set
        End Property 
        <Column(Storage:="_USER_ID", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property USER_ID() As Long
            Get
                Return _USER_ID
            End Get
            Set(ByVal value As Long)
               _USER_ID = value
            End Set
        End Property 
        <Column(Storage:="_USER_CODE", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property USER_CODE() As String
            Get
                Return _USER_CODE
            End Get
            Set(ByVal value As String)
               _USER_CODE = value
            End Set
        End Property 
        <Column(Storage:="_USER_NAME", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property USER_NAME() As String
            Get
                Return _USER_NAME
            End Get
            Set(ByVal value As String)
               _USER_NAME = value
            End Set
        End Property 
        <Column(Storage:="_STAFF_NAME", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property STAFF_NAME() As String
            Get
                Return _STAFF_NAME
            End Get
            Set(ByVal value As String)
               _STAFF_NAME = value
            End Set
        End Property 
        <Column(Storage:="_SERVICE_ID", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property SERVICE_ID() As Long
            Get
                Return _SERVICE_ID
            End Get
            Set(ByVal value As Long)
               _SERVICE_ID = value
            End Set
        End Property 
        <Column(Storage:="_SERVICE_NAME", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property SERVICE_NAME() As String
            Get
                Return _SERVICE_NAME
            End Get
            Set(ByVal value As String)
               _SERVICE_NAME = value
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
        <Column(Storage:="_SHOW_DATE", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property SHOW_DATE() As String
            Get
                Return _SHOW_DATE
            End Get
            Set(ByVal value As String)
               _SHOW_DATE = value
            End Set
        End Property 
        <Column(Storage:="_SHOW_DAY", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property SHOW_DAY() As String
            Get
                Return _SHOW_DAY
            End Get
            Set(ByVal value As String)
               _SHOW_DAY = value
            End Set
        End Property 
        <Column(Storage:="_SHOW_WEEK", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property SHOW_WEEK() As String
            Get
                Return _SHOW_WEEK
            End Get
            Set(ByVal value As String)
               _SHOW_WEEK = value
            End Set
        End Property 
        <Column(Storage:="_SHOW_YEAR", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property SHOW_YEAR() As Long
            Get
                Return _SHOW_YEAR
            End Get
            Set(ByVal value As Long)
               _SHOW_YEAR = value
            End Set
        End Property 
        <Column(Storage:="_REGIS", DbType:="Int NOT NULL ", CanBeNull:=False)> _
        Public Property REGIS() As Long
            Get
                Return _REGIS
            End Get
            Set(ByVal value As Long)
                _REGIS = value
            End Set
        End Property
        <Column(Storage:="_SERVED", DbType:="Int NOT NULL ", CanBeNull:=False)> _
        Public Property SERVED() As Long
            Get
                Return _SERVED
            End Get
            Set(ByVal value As Long)
                _SERVED = value
            End Set
        End Property
        <Column(Storage:="_MISSED_CALL", DbType:="Int NOT NULL ", CanBeNull:=False)> _
        Public Property MISSED_CALL() As Long
            Get
                Return _MISSED_CALL
            End Get
            Set(ByVal value As Long)
                _MISSED_CALL = value
            End Set
        End Property
        <Column(Storage:="_CANCEL", DbType:="Int NOT NULL ", CanBeNull:=False)> _
        Public Property CANCEL() As Long
            Get
                Return _CANCEL
            End Get
            Set(ByVal value As Long)
                _CANCEL = value
            End Set
        End Property
        <Column(Storage:="_SERVE_WITH_KPI", DbType:="Int NOT NULL ", CanBeNull:=False)> _
        Public Property SERVE_WITH_KPI() As Long
            Get
                Return _SERVE_WITH_KPI
            End Get
            Set(ByVal value As Long)
                _SERVE_WITH_KPI = value
            End Set
        End Property
        <Column(Storage:="_NOTCALL", DbType:="Int NOT NULL ", CanBeNull:=False)> _
         Public Property NOTCALL() As Long
            Get
                Return _NOTCALL
            End Get
            Set(ByVal value As Long)
                _NOTCALL = value
            End Set
        End Property
        <Column(Storage:="_NOTCON", DbType:="Int NOT NULL ", CanBeNull:=False)> _
        Public Property NOTCON() As Long
            Get
                Return _NOTCON
            End Get
            Set(ByVal value As Long)
                _NOTCON = value
            End Set
        End Property
        <Column(Storage:="_NOTEND", DbType:="Int NOT NULL ", CanBeNull:=False)> _
        Public Property NOTEND() As Long
            Get
                Return _NOTEND
            End Get
            Set(ByVal value As Long)
                _NOTEND = value
            End Set
        End Property
        <Column(Storage:="_WAIT_WITH_KPI", DbType:="Int NOT NULL ", CanBeNull:=False)> _
        Public Property WAIT_WITH_KPI() As Long
            Get
                Return _WAIT_WITH_KPI
            End Get
            Set(ByVal value As Long)
                _WAIT_WITH_KPI = value
            End Set
        End Property
        <Column(Storage:="_MAX_WT", DbType:="VarChar(50)")> _
        Public Property MAX_WT() As String
            Get
                Return _MAX_WT
            End Get
            Set(ByVal value As String)
                _MAX_WT = value
            End Set
        End Property
        <Column(Storage:="_MAX_HT", DbType:="VarChar(50)")> _
        Public Property MAX_HT() As String
            Get
                Return _MAX_HT
            End Get
            Set(ByVal value As String)
                _MAX_HT = value
            End Set
        End Property
        <Column(Storage:="_ACONT", DbType:="Int NOT NULL ", CanBeNull:=False)> _
        Public Property ACONT() As Long
            Get
                Return _ACONT
            End Get
            Set(ByVal value As Long)
                _ACONT = value
            End Set
        End Property
        <Column(Storage:="_SCONT", DbType:="Int NOT NULL ", CanBeNull:=False)> _
        Public Property SCONT() As Long
            Get
                Return _SCONT
            End Get
            Set(ByVal value As Long)
                _SCONT = value
            End Set
        End Property
        <Column(Storage:="_CCONT", DbType:="Int NOT NULL ", CanBeNull:=False)> _
        Public Property CCONT() As Long
            Get
                Return _CCONT
            End Get
            Set(ByVal value As Long)
                _CCONT = value
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
            _SHOP_NAME_TH = ""
            _SHOP_NAME_EN = ""
            _USER_ID = 0
            _USER_CODE = ""
            _USER_NAME = ""
            _STAFF_NAME = ""
            _SERVICE_ID = 0
            _SERVICE_NAME = ""
            _SERVICE_DATE = New DateTime(1,1,1)
            _SHOW_DATE = ""
            _SHOW_DAY = ""
            _SHOW_WEEK = ""
            _SHOW_YEAR = 0
            _REGIS = 0
            _SERVED = 0
            _MISSED_CALL = 0
            _CANCEL = 0
            _SERVE_WITH_KPI = 0
            _NOTCALL = 0
            _NOTCON = 0
            _NOTEND = 0
            _WAIT_WITH_KPI = 0
            _MAX_WT = ""
            _MAX_HT = ""
            _ACONT = 0
            _SCONT = 0
            _CCONT = 0
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


        '/// Returns an indication whether the current data is inserted into TB_REP_AVG_SERVICE_TIME_KPI_STAFF_DAY table successfully.
        '/// <param name=userID>The current user.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if insert data successfully; otherwise, false.</returns>
        Public Function InsertData(LoginName As String,trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                _id = DB.GetNextID("id",tableName, trans)
                _CREATE_BY = LoginName
                _CREATE_DATE = DateTime.Now
                Return doInsert(trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is updated to TB_REP_AVG_SERVICE_TIME_KPI_STAFF_DAY table successfully.
        '/// <param name=userID>The current user.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateByPK(LoginName As String,trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                _UPDATE_BY = LoginName
                _UPDATE_DATE = DateTime.Now
                Return doUpdate("id = " & DB.SetDouble(_id) & " ", trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is updated to TB_REP_AVG_SERVICE_TIME_KPI_STAFF_DAY table successfully.
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateBySql(Sql As String, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                Return DB.ExecuteNonQuery(Sql, trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is deleted from TB_REP_AVG_SERVICE_TIME_KPI_STAFF_DAY table successfully.
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if delete data successfully; otherwise, false.</returns>
        Public Function DeleteByPK(cPK As Long, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                Return doDelete("id = " & cPK, trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the record of TB_REP_AVG_SERVICE_TIME_KPI_STAFF_DAY by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of TB_REP_AVG_SERVICE_TIME_KPI_STAFF_DAY by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cid As Long, trans As SQLTransaction) As TbRepAvgServiceTimeKpiStaffDayCenLinqDB
            Return doGetData("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Para Class of TB_REP_AVG_SERVICE_TIME_KPI_STAFF_DAY by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetParameter(cid As Long, trans As SQLTransaction) As TbRepAvgServiceTimeKpiStaffDayCenParaDB
            Return doMappingParameter("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of TB_REP_AVG_SERVICE_TIME_KPI_STAFF_DAY by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the current data is inserted into TB_REP_AVG_SERVICE_TIME_KPI_STAFF_DAY table successfully.
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
                    _error = ex.Message
                Catch ex As Exception
                    ex.ToString()
                    ret = False
                    _error = MessageResources.MSGEC101
                End Try
            Else
                ret = False
                _error = MessageResources.MSGEN002
            End If

            Return ret
        End Function


        '/// Returns an indication whether the current data is updated to TB_REP_AVG_SERVICE_TIME_KPI_STAFF_DAY table successfully.
        '/// <param name=whText>The condition specify the updating record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Private Function doUpdate(whText As String, trans As SQLTransaction) As Boolean
            Dim ret As Boolean = True
            If _haveData = True Then
                If whText.Trim() <> ""
                    Dim tmpWhere As String = " Where " & whText
                    Try

                        ret = (DB.ExecuteNonQuery(SqlUpdate & tmpWhere, trans) > 0)
                        If ret = False Then
                            _error = DB.ErrorMessage
                        End If
                        _information = MessageResources.MSGIU001
                    Catch ex As ApplicationException
                        ret = False
                        _error = ex.Message
                    Catch ex As Exception
                        ex.ToString()
                        ret = False
                        _error = MessageResources.MSGEC102
                    End Try
                Else
                    ret = False
                    _error = MessageResources.MSGEU003
                End If
            Else
                ret = False
                _error = MessageResources.MSGEU002
            End If

            Return ret
        End Function


        '/// Returns an indication whether the current data is deleted from TB_REP_AVG_SERVICE_TIME_KPI_STAFF_DAY table successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if delete data successfully; otherwise, false.</returns>
        Private Function doDelete(whText As String, trans As SQLTransaction) As Boolean
            Dim ret As Boolean = True
            If doChkData(whText, trans) = True Then
                If whText.Trim() <> ""
                    Dim tmpWhere As String = " Where " & whText
                    Try
                        ret = (DB.ExecuteNonQuery(SqlDelete & tmpWhere, trans) > 0)
                        If ret = False Then
                            _error = MessageResources.MSGED001
                        End If
                        _information = MessageResources.MSGID001
                    Catch ex As ApplicationException
                        ret = False
                        _error = ex.Message
                    Catch ex As Exception
                        ex.ToString()
                        ret = False
                        _error = MessageResources.MSGEC103
                    End Try
                Else
                    ret = False
                    _error = MessageResources.MSGED003
                End If
            Else
                ret = False
                _error = MessageResources.MSGEU002
            End If

            Return ret
        End Function


        '/// Returns an indication whether the record of TB_REP_AVG_SERVICE_TIME_KPI_STAFF_DAY by specified condition is retrieved successfully.
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
                        If Convert.IsDBNull(Rdr("id")) = False Then _id = Convert.ToInt64(Rdr("id"))
                        If Convert.IsDBNull(Rdr("create_by")) = False Then _create_by = Rdr("create_by").ToString()
                        If Convert.IsDBNull(Rdr("create_date")) = False Then _create_date = Convert.ToDateTime(Rdr("create_date"))
                        If Convert.IsDBNull(Rdr("update_by")) = False Then _update_by = Rdr("update_by").ToString()
                        If Convert.IsDBNull(Rdr("update_date")) = False Then _update_date = Convert.ToDateTime(Rdr("update_date"))
                        If Convert.IsDBNull(Rdr("shop_id")) = False Then _shop_id = Convert.ToInt32(Rdr("shop_id"))
                        If Convert.IsDBNull(Rdr("shop_name_th")) = False Then _shop_name_th = Rdr("shop_name_th").ToString()
                        If Convert.IsDBNull(Rdr("shop_name_en")) = False Then _shop_name_en = Rdr("shop_name_en").ToString()
                        If Convert.IsDBNull(Rdr("user_id")) = False Then _user_id = Convert.ToInt32(Rdr("user_id"))
                        If Convert.IsDBNull(Rdr("user_code")) = False Then _user_code = Rdr("user_code").ToString()
                        If Convert.IsDBNull(Rdr("user_name")) = False Then _user_name = Rdr("user_name").ToString()
                        If Convert.IsDBNull(Rdr("staff_name")) = False Then _staff_name = Rdr("staff_name").ToString()
                        If Convert.IsDBNull(Rdr("service_id")) = False Then _service_id = Convert.ToInt32(Rdr("service_id"))
                        If Convert.IsDBNull(Rdr("service_name")) = False Then _service_name = Rdr("service_name").ToString()
                        If Convert.IsDBNull(Rdr("service_date")) = False Then _service_date = Convert.ToDateTime(Rdr("service_date"))
                        If Convert.IsDBNull(Rdr("show_date")) = False Then _show_date = Rdr("show_date").ToString()
                        If Convert.IsDBNull(Rdr("show_day")) = False Then _show_day = Rdr("show_day").ToString()
                        If Convert.IsDBNull(Rdr("show_week")) = False Then _show_week = Rdr("show_week").ToString()
                        If Convert.IsDBNull(Rdr("show_year")) = False Then _show_year = Convert.ToInt32(Rdr("show_year"))
                        If Convert.IsDBNull(Rdr("regis")) = False Then _REGIS = Convert.ToInt32(Rdr("regis"))
                        If Convert.IsDBNull(Rdr("served")) = False Then _SERVED = Convert.ToInt32(Rdr("served"))
                        If Convert.IsDBNull(Rdr("missed_call")) = False Then _MISSED_CALL = Convert.ToInt32(Rdr("missed_call"))
                        If Convert.IsDBNull(Rdr("cancel")) = False Then _CANCEL = Convert.ToInt32(Rdr("cancel"))
                        If Convert.IsDBNull(Rdr("serve_with_kpi")) = False Then _SERVE_WITH_KPI = Convert.ToInt32(Rdr("serve_with_kpi"))
                        If Convert.IsDBNull(Rdr("not_call")) = False Then _NOTCALL = Convert.ToInt32(Rdr("not_call"))
                        If Convert.IsDBNull(Rdr("not_con")) = False Then _NOTCON = Convert.ToInt32(Rdr("not_con"))
                        If Convert.IsDBNull(Rdr("not_end")) = False Then _NOTEND = Convert.ToInt32(Rdr("not_end"))
                        If Convert.IsDBNull(Rdr("wait_with_kpi")) = False Then _WAIT_WITH_KPI = Convert.ToInt32(Rdr("wait_with_kpi"))
                        If Convert.IsDBNull(Rdr("max_wt")) = False Then _MAX_WT = Rdr("max_wt").ToString()
                        If Convert.IsDBNull(Rdr("max_ht")) = False Then _MAX_HT = Rdr("max_ht").ToString()
                        If Convert.IsDBNull(Rdr("acont")) = False Then _ACONT = Convert.ToInt32(Rdr("acont"))
                        If Convert.IsDBNull(Rdr("scont")) = False Then _SCONT = Convert.ToInt32(Rdr("scont"))
                        If Convert.IsDBNull(Rdr("ccont")) = False Then _CCONT = Convert.ToInt32(Rdr("ccont"))
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


        '/// Returns an indication whether the record of TB_REP_AVG_SERVICE_TIME_KPI_STAFF_DAY by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction) As TbRepAvgServiceTimeKpiStaffDayCenLinqDB
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
                        If Convert.IsDBNull(Rdr("shop_name_th")) = False Then _shop_name_th = Rdr("shop_name_th").ToString()
                        If Convert.IsDBNull(Rdr("shop_name_en")) = False Then _shop_name_en = Rdr("shop_name_en").ToString()
                        If Convert.IsDBNull(Rdr("user_id")) = False Then _user_id = Convert.ToInt32(Rdr("user_id"))
                        If Convert.IsDBNull(Rdr("user_code")) = False Then _user_code = Rdr("user_code").ToString()
                        If Convert.IsDBNull(Rdr("user_name")) = False Then _user_name = Rdr("user_name").ToString()
                        If Convert.IsDBNull(Rdr("staff_name")) = False Then _staff_name = Rdr("staff_name").ToString()
                        If Convert.IsDBNull(Rdr("service_id")) = False Then _service_id = Convert.ToInt32(Rdr("service_id"))
                        If Convert.IsDBNull(Rdr("service_name")) = False Then _service_name = Rdr("service_name").ToString()
                        If Convert.IsDBNull(Rdr("service_date")) = False Then _service_date = Convert.ToDateTime(Rdr("service_date"))
                        If Convert.IsDBNull(Rdr("show_date")) = False Then _show_date = Rdr("show_date").ToString()
                        If Convert.IsDBNull(Rdr("show_day")) = False Then _show_day = Rdr("show_day").ToString()
                        If Convert.IsDBNull(Rdr("show_week")) = False Then _show_week = Rdr("show_week").ToString()
                        If Convert.IsDBNull(Rdr("show_year")) = False Then _show_year = Convert.ToInt32(Rdr("show_year"))
                        If Convert.IsDBNull(Rdr("regis")) = False Then _REGIS = Convert.ToInt32(Rdr("regis"))
                        If Convert.IsDBNull(Rdr("served")) = False Then _SERVED = Convert.ToInt32(Rdr("served"))
                        If Convert.IsDBNull(Rdr("missed_call")) = False Then _MISSED_CALL = Convert.ToInt32(Rdr("missed_call"))
                        If Convert.IsDBNull(Rdr("cancel")) = False Then _CANCEL = Convert.ToInt32(Rdr("cancel"))
                        If Convert.IsDBNull(Rdr("serve_with_kpi")) = False Then _SERVE_WITH_KPI = Convert.ToInt32(Rdr("serve_with_kpi"))
                        If Convert.IsDBNull(Rdr("not_call")) = False Then _NOTCALL = Convert.ToInt32(Rdr("not_call"))
                        If Convert.IsDBNull(Rdr("not_con")) = False Then _NOTCON = Convert.ToInt32(Rdr("not_con"))
                        If Convert.IsDBNull(Rdr("not_end")) = False Then _NOTEND = Convert.ToInt32(Rdr("not_end"))
                        If Convert.IsDBNull(Rdr("wait_with_kpi")) = False Then _WAIT_WITH_KPI = Convert.ToInt32(Rdr("wait_with_kpi"))
                        If Convert.IsDBNull(Rdr("max_wt")) = False Then _MAX_WT = Rdr("max_wt").ToString()
                        If Convert.IsDBNull(Rdr("max_ht")) = False Then _MAX_HT = Rdr("max_ht").ToString()
                        If Convert.IsDBNull(Rdr("acont")) = False Then _ACONT = Convert.ToInt32(Rdr("acont"))
                        If Convert.IsDBNull(Rdr("scont")) = False Then _SCONT = Convert.ToInt32(Rdr("scont"))
                        If Convert.IsDBNull(Rdr("ccont")) = False Then _CCONT = Convert.ToInt32(Rdr("ccont"))
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


        '/// Returns an indication whether the Class Data of TB_REP_AVG_SERVICE_TIME_KPI_STAFF_DAY by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doMappingParameter(whText As String, trans As SQLTransaction) As TbRepAvgServiceTimeKpiStaffDayCenParaDB
            ClearData()
            _haveData  = False
            Dim ret As New TbRepAvgServiceTimeKpiStaffDayCenParaDB
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
                        If Convert.IsDBNull(Rdr("shop_name_th")) = False Then ret.shop_name_th = Rdr("shop_name_th").ToString()
                        If Convert.IsDBNull(Rdr("shop_name_en")) = False Then ret.shop_name_en = Rdr("shop_name_en").ToString()
                        If Convert.IsDBNull(Rdr("user_id")) = False Then ret.user_id = Convert.ToInt32(Rdr("user_id"))
                        If Convert.IsDBNull(Rdr("user_code")) = False Then ret.user_code = Rdr("user_code").ToString()
                        If Convert.IsDBNull(Rdr("user_name")) = False Then ret.user_name = Rdr("user_name").ToString()
                        If Convert.IsDBNull(Rdr("staff_name")) = False Then ret.staff_name = Rdr("staff_name").ToString()
                        If Convert.IsDBNull(Rdr("service_id")) = False Then ret.service_id = Convert.ToInt32(Rdr("service_id"))
                        If Convert.IsDBNull(Rdr("service_name")) = False Then ret.service_name = Rdr("service_name").ToString()
                        If Convert.IsDBNull(Rdr("service_date")) = False Then ret.service_date = Convert.ToDateTime(Rdr("service_date"))
                        If Convert.IsDBNull(Rdr("show_date")) = False Then ret.show_date = Rdr("show_date").ToString()
                        If Convert.IsDBNull(Rdr("show_day")) = False Then ret.show_day = Rdr("show_day").ToString()
                        If Convert.IsDBNull(Rdr("show_week")) = False Then ret.show_week = Rdr("show_week").ToString()
                        If Convert.IsDBNull(Rdr("show_year")) = False Then ret.show_year = Convert.ToInt32(Rdr("show_year"))
                        If Convert.IsDBNull(Rdr("regis")) = False Then ret.REGIS = Convert.ToInt32(Rdr("regis"))
                        If Convert.IsDBNull(Rdr("served")) = False Then ret.SERVED = Convert.ToInt32(Rdr("served"))
                        If Convert.IsDBNull(Rdr("missed_call")) = False Then ret.MISSED_CALL = Convert.ToInt32(Rdr("missed_call"))
                        If Convert.IsDBNull(Rdr("cancel")) = False Then ret.CANCEL = Convert.ToInt32(Rdr("cancel"))
                        If Convert.IsDBNull(Rdr("serve_with_kpi")) = False Then ret.serve_with_kpi = Convert.ToInt32(Rdr("serve_with_kpi"))
                        If Convert.IsDBNull(Rdr("per_awt_with_kpi")) = False Then ret.per_awt_with_kpi = Convert.ToDouble(Rdr("per_awt_with_kpi"))
                        If Convert.IsDBNull(Rdr("per_awt_over_kpi")) = False Then ret.per_awt_over_kpi = Convert.ToDouble(Rdr("per_awt_over_kpi"))
                        If Convert.IsDBNull(Rdr("per_aht_with_kpi")) = False Then ret.per_aht_with_kpi = Convert.ToDouble(Rdr("per_aht_with_kpi"))
                        If Convert.IsDBNull(Rdr("per_aht_over_kpi")) = False Then ret.per_aht_over_kpi = Convert.ToDouble(Rdr("per_aht_over_kpi"))
                        If Convert.IsDBNull(Rdr("per_missed_call")) = False Then ret.per_missed_call = Convert.ToDouble(Rdr("per_missed_call"))
                        If Convert.IsDBNull(Rdr("per_cancel")) = False Then ret.per_cancel = Convert.ToDouble(Rdr("per_cancel"))
                        If Convert.IsDBNull(Rdr("not_call")) = False Then ret.NOTCALL = Convert.ToInt32(Rdr("not_call"))
                        If Convert.IsDBNull(Rdr("not_con")) = False Then ret.NOTCON = Convert.ToInt32(Rdr("not_con"))
                        If Convert.IsDBNull(Rdr("not_end")) = False Then ret.NOTEND = Convert.ToInt32(Rdr("not_end"))
                        If Convert.IsDBNull(Rdr("wait_with_kpi")) = False Then ret.WAIT_WITH_KPI = Convert.ToInt32(Rdr("wait_with_kpi"))
                        If Convert.IsDBNull(Rdr("max_wt")) = False Then ret.max_wt = Rdr("max_wt").ToString()
                        If Convert.IsDBNull(Rdr("max_ht")) = False Then ret.MAX_HT = Rdr("max_ht").ToString()
                        If Convert.IsDBNull(Rdr("acont")) = False Then ret.ACONT = Convert.ToInt32(Rdr("acont"))
                        If Convert.IsDBNull(Rdr("scont")) = False Then ret.SCONT = Convert.ToInt32(Rdr("scont"))
                        If Convert.IsDBNull(Rdr("ccont")) = False Then ret.CCONT = Convert.ToInt32(Rdr("ccont"))
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


        'Get Insert Statement for table TB_REP_AVG_SERVICE_TIME_KPI_STAFF_DAY
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & TableName & " (ID, CREATE_BY, CREATE_DATE, UPDATE_BY, UPDATE_DATE, SHOP_ID, SHOP_NAME_TH, SHOP_NAME_EN, USER_ID, USER_CODE, USER_NAME, STAFF_NAME, SERVICE_ID, SERVICE_NAME, SERVICE_DATE, SHOW_DATE, SHOW_DAY, SHOW_WEEK, SHOW_YEAR, REGIS, SERVED, MISSED_CALL, CANCEL, SERVE_WITH_KPI, NOT_CALL, NOT_CON, NOT_END, WAIT_WITH_KPI, MAX_WT, MAX_HT,ACONT,SCONT,CCONT)"
                Sql += " VALUES("
                sql += DB.SetDouble(_ID) & ", "
                sql += DB.SetString(_CREATE_BY) & ", "
                sql += DB.SetDateTime(_CREATE_DATE) & ", "
                sql += DB.SetString(_UPDATE_BY) & ", "
                sql += DB.SetDateTime(_UPDATE_DATE) & ", "
                sql += DB.SetDouble(_SHOP_ID) & ", "
                sql += DB.SetString(_SHOP_NAME_TH) & ", "
                sql += DB.SetString(_SHOP_NAME_EN) & ", "
                sql += DB.SetDouble(_USER_ID) & ", "
                sql += DB.SetString(_USER_CODE) & ", "
                sql += DB.SetString(_USER_NAME) & ", "
                sql += DB.SetString(_STAFF_NAME) & ", "
                sql += DB.SetDouble(_SERVICE_ID) & ", "
                sql += DB.SetString(_SERVICE_NAME) & ", "
                sql += DB.SetDateTime(_SERVICE_DATE) & ", "
                sql += DB.SetString(_SHOW_DATE) & ", "
                sql += DB.SetString(_SHOW_DAY) & ", "
                sql += DB.SetString(_SHOW_WEEK) & ", "
                sql += DB.SetDouble(_SHOW_YEAR) & ", "
                Sql += DB.SetDouble(_REGIS) & ", "
                Sql += DB.SetDouble(_SERVED) & ", "
                Sql += DB.SetDouble(_MISSED_CALL) & ", "
                Sql += DB.SetDouble(_CANCEL) & ", "
                Sql += DB.SetDouble(_SERVE_WITH_KPI) & ", "
                Sql += DB.SetDouble(_NOTCALL) & ", "
                Sql += DB.SetDouble(_NOTCON) & ", "
                Sql += DB.SetDouble(_NOTEND) & ", "
                Sql += DB.SetDouble(_WAIT_WITH_KPI) & ", "
                Sql += DB.SetString(_MAX_WT) & ", "
                Sql += DB.SetString(_MAX_HT) & ", "
                Sql += DB.SetDouble(_ACONT) & ", "
                Sql += DB.SetDouble(_SCONT) & ", "
                Sql += DB.SetDouble(_CCONT)
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table TB_REP_AVG_SERVICE_TIME_KPI_STAFF_DAY
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "ID = " & DB.SetDouble(_ID) & ", "
                Sql += "CREATE_BY = " & DB.SetString(_CREATE_BY) & ", "
                Sql += "CREATE_DATE = " & DB.SetDateTime(_CREATE_DATE) & ", "
                Sql += "UPDATE_BY = " & DB.SetString(_UPDATE_BY) & ", "
                Sql += "UPDATE_DATE = " & DB.SetDateTime(_UPDATE_DATE) & ", "
                Sql += "SHOP_ID = " & DB.SetDouble(_SHOP_ID) & ", "
                Sql += "SHOP_NAME_TH = " & DB.SetString(_SHOP_NAME_TH) & ", "
                Sql += "SHOP_NAME_EN = " & DB.SetString(_SHOP_NAME_EN) & ", "
                Sql += "USER_ID = " & DB.SetDouble(_USER_ID) & ", "
                Sql += "USER_CODE = " & DB.SetString(_USER_CODE) & ", "
                Sql += "USER_NAME = " & DB.SetString(_USER_NAME) & ", "
                Sql += "STAFF_NAME = " & DB.SetString(_STAFF_NAME) & ", "
                Sql += "SERVICE_ID = " & DB.SetDouble(_SERVICE_ID) & ", "
                Sql += "SERVICE_NAME = " & DB.SetString(_SERVICE_NAME) & ", "
                Sql += "SERVICE_DATE = " & DB.SetDateTime(_SERVICE_DATE) & ", "
                Sql += "SHOW_DATE = " & DB.SetString(_SHOW_DATE) & ", "
                Sql += "SHOW_DAY = " & DB.SetString(_SHOW_DAY) & ", "
                Sql += "SHOW_WEEK = " & DB.SetString(_SHOW_WEEK) & ", "
                Sql += "SHOW_YEAR = " & DB.SetDouble(_SHOW_YEAR) & ", "
                Sql += "REGIS = " & DB.SetDouble(_REGIS) & ", "
                Sql += "SERVED = " & DB.SetDouble(_SERVED) & ", "
                Sql += "MISSED_CALL = " & DB.SetDouble(_MISSED_CALL) & ", "
                Sql += "CANCEL = " & DB.SetDouble(_CANCEL) & ", "
                Sql += "SERVE_WITH_KPI = " & DB.SetDouble(_SERVE_WITH_KPI) & ", "
                Sql += "NOT_CALL = " & DB.SetDouble(_NOTCALL) & ", "
                Sql += "NOT_CON = " & DB.SetDouble(_NOTCON) & ", "
                Sql += "NOT_END = " & DB.SetDouble(_NOTEND) & ", "
                Sql += "WAIT_WITH_KPI = " & DB.SetDouble(_WAIT_WITH_KPI) & ", "
                Sql += "MAX_WT = " & DB.SetString(_MAX_WT) & ", "
                Sql += "MAX_HT = " & DB.SetString(_MAX_HT) & ", "
                Sql += "ACONT = " & DB.SetDouble(ACONT) & ", "
                Sql += "SCONT = " & DB.SetDouble(SCONT) & ", "
                Sql += "CCONT = " & DB.SetDouble(CCONT) + " "
                Return Sql
            End Get
        End Property


        'Get Delete Record in table TB_REP_AVG_SERVICE_TIME_KPI_STAFF_DAY
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table TB_REP_AVG_SERVICE_TIME_KPI_STAFF_DAY
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT * FROM " & tableName
                Return Sql
            End Get
        End Property


    End Class
End Namespace