Imports System.IO
Imports System.Text
Imports CenLinqDB.TABLE
Imports CenParaDB.TABLE
Imports CenLinqDB.Common.Utilities
Imports System.Security.Cryptography
'Imports CenLinqDB.TABLE
Imports System.Web

Namespace Common
    Public Class FunctionEng
        Private Shared _err As String
        Public Shared ReadOnly Property ErrorMessage() As String
            Get
                Return _err
            End Get
        End Property

        Public Shared Function GetShopConfig(ByVal ParaName As String) As String
            Dim ret As Boolean = False
            Dim trans As New ShLinqDB.Common.Utilities.TransactionDB
            Dim lnq As New ShLinqDB.TABLE.TbSettingShLinqDB
            trans.CreateTransaction()
            ret = lnq.ChkDataByWhere("config_name = '" & ParaName & "'", trans.Trans)
            trans.CommitTransaction()
            If ret = True Then
                Return lnq.CONFIG_VALUE
            Else
                Return ""
            End If
        End Function

        Public Shared Function GetQisDBConfig(ByVal ParaName As String) As String
            Dim ret As Boolean = False
            Dim trans As New CenLinqDB.Common.Utilities.TransactionDB
            Dim lnq As New CenLinqDB.TABLE.SysconfigCenLinqDB

            ret = lnq.ChkDataByWhere("config_name = '" & ParaName & "'", trans.Trans)
            trans.CommitTransaction()
            Dim r As String = lnq.CONFIG_VALUE
            lnq = Nothing
            If ret = True Then
                Return r
            Else
                Return ""
            End If
        End Function

        'Public Shared Function GetStartUpPath() As String
        '    Return SqlDB.GetStartupPath
        'End Function

        Public Shared Function SaveShopTransLog(ByVal ClassName As String, ByVal transDesc As String) As Boolean
            Dim ret As Boolean = False
            Dim lnq As New ShLinqDB.TABLE.TbErrorLogShLinqDB
            Dim trans As New ShLinqDB.Common.Utilities.TransactionDB()
            trans.CreateTransaction()
            lnq.LOG_DATE = DateTime.Now
            lnq.ERROR_MESSAGE = "TransLog : " & ClassName & transDesc
            lnq.CLIENT_IP = GetIPAddress()
            ret = lnq.InsertData(0, trans.Trans)
            If ret = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
            End If

            Return ret
        End Function

        Public Shared Function SaveShopErrorLog(ByVal ClassName As String, ByVal ErrorDesc As String) As Boolean
            Dim ret As Boolean = False
            Dim lnq As New ShLinqDB.TABLE.TbErrorLogShLinqDB
            Dim trans As New ShLinqDB.Common.Utilities.TransactionDB()
            trans.CreateTransaction()
            lnq.LOG_DATE = DateTime.Now
            lnq.ERROR_MESSAGE = ClassName & " : " & ErrorDesc
            lnq.CLIENT_IP = GetIPAddress()
            ret = lnq.InsertData(0, trans.Trans)
            If ret = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
            End If

            Return ret
        End Function

        Public Shared Function GetShopDataTable(ByVal sql As String) As DataTable
            Dim shTrans As New ShLinqDB.Common.Utilities.TransactionDB
            shTrans.CreateTransaction()
            Dim dt As New DataTable
            Dim lnq As New ShLinqDB.TABLE.TbCounterQueueShLinqDB
            dt = lnq.GetListBySql(sql, shTrans.Trans)
            shTrans.CommitTransaction()
            lnq = Nothing

            Return dt
        End Function

        Public Shared Function ExecuteShopNonQuery(ByVal sql As String) As Boolean
            Dim ret As Boolean = False
            Dim shTrans As New ShLinqDB.Common.Utilities.TransactionDB
            shTrans.CreateTransaction()
            Try
                ShLinqDB.Common.Utilities.SqlDB.ExecuteNonQuery(sql)
                shTrans.CommitTransaction()
                ret = True
            Catch ex As Exception
                shTrans.RollbackTransaction()
            End Try

            Return ret
        End Function

        Public Shared Function ExecuteShopNonQuery(ByVal sql As String, ByVal shTrans As ShLinqDB.Common.Utilities.TransactionDB) As Boolean
            Dim ret As Boolean = False
            Try
                ret = (ShLinqDB.Common.Utilities.SqlDB.ExecuteNonQuery(sql, shTrans.Trans) > 0)
            Catch ex As Exception

            End Try

            Return ret
        End Function

        Public Shared Function GetQueueWaitTime() As DataTable
            Dim sql As String = ""
            sql = "  	select q.customer_id, q.queue_no,q.item_id,q.status,t.txt_queue,q.customertype_id,c.prefer_lang  " & vbNewLine
            sql += "    from TB_COUNTER_QUEUE q " & vbNewLine
            sql += "    left join TB_ITEM t on q.item_id = t.id" & vbNewLine
            sql += "    left join TB_CUSTOMER c on c.mobile_no=q.customer_id"
            sql += "    where DateDiff(D, q.service_date, GETDATE()) = 0 " & vbNewLine
            sql += "    and q.customertype_id<>3" 'ไม่เอา คิวจอง
            sql += "    order by q.service_date"

            Dim dt As New DataTable
            dt = GetShopDataTable(sql)

            Return dt
        End Function
        Public Shared Function GetCurrentLogonAgent(ByVal ItemID As Integer, ByVal CustomertypeID As Integer) As Long
            Dim ret As Long = 0
            Dim sql As String = ""
            sql = "select count(u.id) id" & vbNewLine
            sql += " from tb_user u " & vbNewLine
            sql += " inner join tb_counter c on c.id=u.counter_id" & vbNewLine
            sql += " where u.counter_id>0 " & vbNewLine
            sql += " and (select item_id "
            sql += "        from TB_USER_SERVICE_SCHEDULE "
            sql += "        where user_id=u.id and priority='1' "
            sql += "        and item_id='" & ItemID & "'"
            sql += "        and DATEDIFF(D,GETDATE(),service_date)=0)>0 " & vbNewLine
            sql += " and u.counter_id not in (select id from TB_COUNTER where active_status = 1 and back_office= 1 or counter_manager = 1 or available = 0 or speed_lane = 1) " & vbNewLine
            If ItemID = 2 Then  'Customer Service
                sql += " and u.counter_id in (select counter_id from TB_COUNTER_CUSTOMERTYPE where customertype_id='" & CustomertypeID & "')" & vbNewLine
            End If

            Dim dt As New DataTable
            dt = GetShopDataTable(sql)
            If dt.Rows.Count > 0 Then
                If Convert.IsDBNull(dt.Rows(0)("id")) = False Then
                    ret = Convert.ToInt64(dt.Rows(0)("id"))
                End If
                dt.Dispose()
            End If

            Return ret
        End Function

        Public Shared Function GetQueueForSendSMSNotify(ByVal ItemID As Integer, ByVal CustomertypeID As Integer, ByVal TxtQueue As String, ByVal CountAgent As Integer) As DataTable
            Dim ret As New DataTable
            ret.Columns.Add("customer_id")
            ret.Columns.Add("queue_no")
            ret.Columns.Add("prefer_lang")

            Dim wDt As New DataTable
            wDt = GetQueueWaitTime()
            If wDt.Rows.Count > 0 Then
                If ItemID = 2 Then 'Customer Service
                    wDt.DefaultView.RowFilter = "status=1 and item_id='" & ItemID & "' and substring(queue_no,1,1)='" & TxtQueue & "' and customertype_id='" & CustomertypeID & "'"
                Else
                    wDt.DefaultView.RowFilter = "status=1 and item_id='" & ItemID & "' and substring(queue_no,1,1)='" & TxtQueue & "' "
                End If

                For i As Integer = 0 To wDt.DefaultView.Count - 1
                    If (i + 1) = (CountAgent * 2) + 1 Then
                        Dim rDr As DataRow = ret.NewRow
                        rDr("customer_id") = wDt.DefaultView(i)("customer_id")
                        rDr("queue_no") = wDt.DefaultView(i)("queue_no")
                        rDr("prefer_lang") = wDt.DefaultView(i)("prefer_lang")
                        ret.Rows.Add(rDr)
                        Exit For
                    End If
                Next
            End If
            wDt.Dispose()

            Return ret
        End Function

        Public Shared Function GetAvgHT(ByVal ServiceDateNow As DateTime) As DataTable
            Dim LastMonth As DateTime = DateAdd(DateInterval.Month, -1, ServiceDateNow)
            Dim FirstDate As String = LastMonth.ToString("yyyyMM", New Globalization.CultureInfo("en-US")) & "01"
            Dim LastDate As String = LastMonth.ToString("yyyyMM", New Globalization.CultureInfo("en-US")) & DateTime.DaysInMonth(LastMonth.Year, LastMonth.Month).ToString.PadLeft(2, "0")

            Dim sql As String = "select a.item_id,a.item_name, " & vbNewLine
            sql += " case when sum(a.count_ht)>0 then sum(a.sum_ht)/sum(a.count_ht) else 0 end avg_ht" & vbNewLine
            sql += " from (" & vbNewLine
            sql += " 	select q.item_id,t.item_name, sum(CASE WHEN isnull(DATEDIFF(SECOND, assign_time, call_time), 0) < 0 THEN 0 ELSE isnull(DATEDIFF(SECOND, start_time, end_time), 0) END) AS sum_ht," & vbNewLine
            sql += " 	sum(CASE WHEN isnull(DATEDIFF(SECOND, start_time, end_time), 0) > 0 THEN 1 ELSE 0 END) AS count_ht" & vbNewLine
            sql += " 	from TB_COUNTER_QUEUE q " & vbNewLine
            sql += " 	inner join tb_item t on t.id=q.item_id" & vbNewLine
            sql += " 	where t.active_status='1'" & vbNewLine
            sql += " 	and CONVERT(varchar(8),service_date,112) between '" & FirstDate & "' and '" & LastDate & "'" & vbNewLine
            sql += " 	and q.status='3'" & vbNewLine
            sql += " 	group by q.item_id,t.item_name" & vbNewLine
            sql += "    union all" & vbNewLine
            sql += " 	select q.item_id,t.item_name, sum(CASE WHEN isnull(DATEDIFF(SECOND, assign_time, call_time), 0) < 0 THEN 0 ELSE isnull(DATEDIFF(SECOND, start_time, end_time), 0) END) AS sum_ht," & vbNewLine
            sql += " 	sum(CASE WHEN isnull(DATEDIFF(SECOND, start_time, end_time), 0) > 0 THEN 1 ELSE 0 END) AS count_ht" & vbNewLine
            sql += " 	from TB_COUNTER_QUEUE_HISTORY q " & vbNewLine
            sql += " 	inner join tb_item t on t.id=q.item_id" & vbNewLine
            sql += " 	where t.active_status='1'" & vbNewLine
            sql += " 	and CONVERT(varchar(8),service_date,112) between '" & FirstDate & "' and '" & LastDate & "' " & vbNewLine
            sql += " 	and q.status='3'" & vbNewLine
            sql += " 	group by q.item_id,t.item_name) a" & vbNewLine
            sql += " group by a.item_id,a.item_name" & vbNewLine


            Dim dt As New DataTable
            dt = GetShopDataTable(sql)
            Return dt
        End Function

        Public Shared Function GetShopServiceList() As DataTable
            Dim shTrans As New ShLinqDB.Common.Utilities.TransactionDB
            shTrans.CreateTransaction()
            Dim dt As New DataTable
            Dim lnq As New ShLinqDB.TABLE.TbItemShLinqDB
            dt = lnq.GetDataList("active_status='1'", "id", shTrans.Trans)
            shTrans.CommitTransaction()
            lnq = Nothing

            Return dt
        End Function


        Public Shared Function GetIPAddress() As String
            Dim oAddr As System.Net.IPAddress
            Dim sAddr As String
            With System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName())
                oAddr = New System.Net.IPAddress(.AddressList(0).Address)
                sAddr = oAddr.ToString
            End With
            GetIPAddress = sAddr
        End Function

        Public Shared Sub CreateLogFile(ByVal TextMsg As String)
            'Dim FILE_NAME As String = System.Windows.Forms.Application.StartupPath & "\" & DateTime.Now.ToString("yyyyyMMddHH") & ".sql"
            Dim FILE_NAME As String = "D:\Encrypt" & DateTime.Now.ToString("yyyyyMMddHH") & ".txt"
            Dim objWriter As New System.IO.StreamWriter(FILE_NAME, True)
            objWriter.WriteLine(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff") & " " & TextMsg & Chr(13) & Chr(13))
            objWriter.Close()
        End Sub

        Public Shared Function GetDiffMillisec(ByVal StartTime As DateTime) As Long
            Dim TimeSec As Long = GetSecFromTimeFormat(StartTime.ToString("HH:mm:ss", New Globalization.CultureInfo("en-US"))) * 1000
            TimeSec += Convert.ToInt16(StartTime.ToString("fff"))

            Dim TimeNow As Long = (GetSecFromTimeFormat(DateTime.Now.ToString("HH:mm:ss", New Globalization.CultureInfo("en-US"))) * 1000) + DateTime.Now.ToString("fff")

            Return TimeNow - TimeSec
        End Function

        Public Shared Function GetFormatTimeFromSec(ByVal TimeSec As Integer) As String
            'แปลงเวลาจากวินาทีไปเป็น HH:mm:ss
            Dim tHour As Integer = 0
            Dim tMin As Integer = 0
            Dim tSec As Integer = 0
            If TimeSec >= 3600 Then
                tHour = Math.Floor(TimeSec / 3600) 'ชม.
                tMin = Math.Floor((TimeSec - (tHour * 3600)) / 60) ' นาที
                tSec = (TimeSec - (tHour * 3600)) Mod 60
            Else
                tMin = Math.Floor(TimeSec / 60)
                tSec = TimeSec Mod 60
            End If

            Return tHour.ToString.PadLeft(2, "0") & ":" & tMin.ToString.PadLeft(2, "0") & ":" & tSec.ToString.PadLeft(2, "0")
        End Function

        Public Shared Function GetSecFromTimeFormat(ByVal TimeFormat As String) As Integer
            'แปลงเวลาในรูปแบบ HH:mm:ss ไปเป็นวินาที

            Dim ret As Int32 = 0
            If TimeFormat.Trim <> "" Then
                Dim tmp() As String = Split(TimeFormat, ":")
                Dim TimeSec As Integer = 0
                If Convert.ToInt64(tmp(0)) > 0 Then
                    TimeSec += (Convert.ToInt64(tmp(0)) * 60 * 60)
                End If
                If Convert.ToInt64(tmp(1)) > 0 Then
                    TimeSec += (Convert.ToInt64(tmp(1)) * 60)
                End If
                ret = TimeSec + Convert.ToInt32(tmp(2))
            End If
            Return ret
        End Function

        Public Shared Function CheckShopConnect() As Boolean
            Return SqlDB.ChkConnection()
        End Function

        Public Shared Function CheckShopConnect(ByVal ServerName As String, ByVal UserID As String, ByVal Passwd As String, ByVal DBName As String) As Boolean
            Return ShLinqDB.Common.Utilities.SqlDB.ChkConnection(ServerName, UserID, Passwd, DBName)
        End Function

        Public Shared Function SaveQisDBLoginHistory(ByVal UserName As String, ByVal req As HttpRequest, ByVal ModuleName As String, ByVal ShopAbb As String) As Long

            Dim ret As Long = 0
            Dim trans As New CenLinqDB.Common.Utilities.TransactionDB
            Try
                Dim lnq As New CenLinqDB.TABLE.LoginHistoryCenLinqDB
                lnq.CUSTOMER_ID = UserName
                lnq.LOGIN_TIME = DateTime.Now
                lnq.SESSION_ID = HttpContext.Current.Session.SessionID
                Dim browser As String = " Type:" + req.Browser.Type + " Version:" + req.Browser.Version + " Browser:" + req.Browser.Browser
                lnq.IP_ADDRESS = req.UserHostAddress 'Get Client IP ADDRESS
                lnq.BROWSER = browser
                lnq.LOGIN_MODULE = ModuleName
                lnq.SERVER_URL = req.Url.AbsoluteUri
                lnq.USER_SHOP = ShopAbb

                If lnq.InsertData(UserName, trans.Trans) = True Then
                    trans.CommitTransaction()
                    ret = lnq.ID
                Else
                    trans.RollbackTransaction()
                    _err = "QueueSharp.Engine.Common.FunctionEng.SaveQisDBLoginHistory : " & lnq.ErrorMessage
                End If
                lnq = Nothing
            Catch ex As Exception
                trans.RollbackTransaction()
                _err = "QueueSharp.Engine.Common.FunctionEng.SaveQisDBLoginHistory Exception : " & ex.Message
            End Try

            Return ret
        End Function

        Public Shared Sub SaveQisDBLogOut(ByVal LoginHistoryID As Long)
            Dim trans As New CenLinqDB.Common.Utilities.TransactionDB(True)
            Dim lnq As New CenLinqDB.TABLE.LoginHistoryCenLinqDB
            lnq.GetDataByPK(LoginHistoryID, trans.Trans)
            lnq.LOGOUT_TIME = DateTime.Now

            If lnq.ID > 0 Then
                If lnq.UpdateByPK(lnq.CUSTOMER_ID, trans.Trans) = True Then
                    trans.CommitTransaction()
                Else
                    trans.RollbackTransaction()
                End If
            Else
                trans.RollbackTransaction()
            End If
            lnq = Nothing
        End Sub

        Public Shared Function SaveQisDBTransLog(ByVal LoginHisID As Long, ByVal ClassName As String, ByVal transDesc As String) As Boolean
            Dim ret As Boolean = False
            Dim lnq As New LogTransCenLinqDB
            Dim trans As New CenLinqDB.Common.Utilities.TransactionDB(True)
            lnq.LOGIN_HIS_ID = LoginHisID
            lnq.TRANS_DESC = transDesc
            lnq.TRANS_DATE = DateTime.Now

            ret = lnq.InsertData(ClassName, trans.Trans)
            If ret = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
                SaveQisDBErrorLog(LoginHisID, ClassName, lnq.ErrorMessage)
            End If
            lnq = Nothing

            Return ret
        End Function

        Public Shared Function SaveQisDBErrorLog(ByVal LoginHisID As Long, ByVal ClassName As String, ByVal ErrorDesc As String) As Boolean
            Dim ret As Boolean = False
            Dim lnq As New LogErrorCenLinqDB
            Dim trans As New CenLinqDB.Common.Utilities.TransactionDB(True)
            lnq.LOGIN_HIS_ID = LoginHisID
            lnq.ERROR_DESC = ErrorDesc
            lnq.ERROR_TIME = DateTime.Now
            ret = lnq.InsertData(ClassName, trans.Trans)
            If ret = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
            End If
            lnq = Nothing

            Return ret
        End Function

        Public Shared Function SaveErrorLog(ByVal ClassName As String, ByVal ErrorDesc As String) As Boolean
            Dim ret As Boolean = False
            Dim lnq As New LogErrorCenLinqDB
            Dim trans As New CenLinqDB.Common.Utilities.TransactionDB(True)
            lnq.LOGIN_HIS_ID = 0
            lnq.ERROR_DESC = ErrorDesc
            lnq.ERROR_TIME = DateTime.Now
            ret = lnq.InsertData(ClassName, trans.Trans)
            If ret = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
            End If
            lnq = Nothing

            Return ret
        End Function

        Public Shared Function GetShTransction(ByVal shTrans As ShLinqDB.Common.Utilities.TransactionDB, ByVal trans As CenLinqDB.Common.Utilities.TransactionDB, ByVal shLnq As CenLinqDB.TABLE.TbShopCenLinqDB, ByVal ClassName As String) As ShLinqDB.Common.Utilities.TransactionDB
            Dim retTrans As Boolean = False

            Dim ConnShopDB As String = GetQisDBConfig("ConnShopDB")
            If ConnShopDB.Trim = "" Then
                ConnShopDB = "MAIN"
            End If

            shTrans = New ShLinqDB.Common.Utilities.TransactionDB

            If ConnShopDB = "MAIN" Then
                retTrans = shTrans.CreateTransaction(shLnq.MAIN_SERVERNAME, shLnq.MAIN_DB_USERID, shLnq.MAIN_DB_PWD, shLnq.MAIN_DB_NAME)
            ElseIf ConnShopDB = "DC" Then
                retTrans = shTrans.CreateTransaction(shLnq.SHOP_DB_SERVER, shLnq.SHOP_DB_USERID, shLnq.SHOP_DB_PWD, shLnq.SHOP_DB_NAME)
            ElseIf ConnShopDB = "DR" Then
                retTrans = shTrans.CreateTransaction(shLnq.SHOP_DR_SERVER, shLnq.SHOP_DR_USERID, shLnq.SHOP_DR_PWD, shLnq.SHOP_DR_NAME)
            End If

            If retTrans = False Then
                FunctionEng.SaveErrorLog("FunctionENG.GetShTransction", ClassName & " : Connect to DR Site " & shTrans.ErrorMessage & "#### :" & shLnq.SHOP_ABB)
                retTrans = shTrans.CreateTransaction(shLnq.SHOP_DR_SERVER, shLnq.SHOP_DR_USERID, shLnq.SHOP_DR_PWD, shLnq.SHOP_DR_NAME)
            End If

            Return shTrans
        End Function

        Public Shared Function GetTbShopCenLinqDB(ByVal ShopID As Long) As TbShopCenLinqDB
            Dim trans As New CenLinqDB.Common.Utilities.TransactionDB
            Dim lnq As New TbShopCenLinqDB
            lnq.GetDataByPK(ShopID, trans.Trans)

            trans.CommitTransaction()

            Return lnq
        End Function

        Public Shared Function GetActiveShop() As DataTable
            
            Dim dt As DataTable = GetShopDtByWhere("active='Y'")
            Return dt
        End Function

        Public Shared Function GetShopDtByWhere(ByVal wh As String) As DataTable
            Dim trans As New CenLinqDB.Common.Utilities.TransactionDB
            Dim lnq As New TbShopCenLinqDB
            Dim dt As DataTable = lnq.GetDataList(wh, "", trans.Trans)
            trans.CommitTransaction()
            lnq = Nothing

            Return dt
        End Function

        Public Shared Function SaveTransLog(ByVal ClassName As String, ByVal transDesc As String) As Boolean
            Dim ret As Boolean = False
            Dim lnq As New LogTransCenLinqDB
            Dim trans As New CenLinqDB.Common.Utilities.TransactionDB(True)
            lnq.LOGIN_HIS_ID = 0
            lnq.TRANS_DESC = transDesc
            lnq.TRANS_DATE = DateTime.Now

            ret = lnq.InsertData(ClassName, trans.Trans)
            If ret = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
                SaveErrorLog("FunctionEng.SaveTransLog", lnq.ErrorMessage & " TransDesc :" & transDesc)
            End If
            lnq = Nothing

            Return ret
        End Function

        Public Shared Function GetDatatable(ByVal Sql As String) As DataTable
            Dim trans As New CenLinqDB.Common.Utilities.TransactionDB
            Dim dt As New DataTable
            If trans.Trans IsNot Nothing Then
                dt = SqlDB.ExecuteTable(Sql, trans.Trans)
            End If
            trans.CommitTransaction()

            Return dt
        End Function

        Public Shared Function GetShTransction(ByVal ShopID As Long, ByVal ClassName As String) As ShLinqDB.Common.Utilities.TransactionDB
            Dim trans As New CenLinqDB.Common.Utilities.TransactionDB
            Dim shLnq As New CenLinqDB.TABLE.TbShopCenLinqDB
            shLnq = Engine.Common.FunctionEng.GetTbShopCenLinqDB(ShopID)
            Dim shTrans As New ShLinqDB.Common.Utilities.TransactionDB

            Dim retTrans As Boolean = False
            'retTrans = shTrans.CreateTransaction(shLnq.MAIN_SERVERNAME, shLnq.MAIN_DB_USERID, shLnq.MAIN_DB_PWD, shLnq.MAIN_DB_NAME)
            'If retTrans = False Then
            '    FunctionEng.SaveErrorLog("FunctionENG.GetShTransction", "Connect to DR Site")
            '    retTrans = shTrans.CreateTransaction(trans.conn.DataSource, shLnq.SHOP_DR_USERID, shLnq.SHOP_DR_PWD, shLnq.SHOP_DR_NAME)
            'End If
            shTrans = GetShTransction(shTrans, trans, shLnq, ClassName)
            trans.CommitTransaction()
            shLnq = Nothing

            Return shTrans
        End Function

        Public Shared Function GetShopConfig(ByVal ParaName As String, ByVal ShTrans As ShLinqDB.Common.Utilities.TransactionDB) As String
            Dim ret As Boolean = False
            Dim lnq As New ShLinqDB.TABLE.TbSettingShLinqDB
            ret = lnq.ChkDataByWhere("config_name = '" & ParaName & "'", ShTrans.Trans)
            If ret = True Then
                Return lnq.CONFIG_VALUE
            Else
                Return ""
            End If
        End Function

        Public Shared Function GetShopItemPara(ByVal ItemID As Integer, ByVal ShTrans As ShLinqDB.Common.Utilities.TransactionDB) As ShLinqDB.TABLE.TbItemShLinqDB
            Dim lnq As New ShLinqDB.TABLE.TbItemShLinqDB
            Return lnq.GetDataByPK(ItemID, ShTrans.Trans)
        End Function
        Public Shared Function cStrToDateTime(ByVal StrDate As String, ByVal StrTime As String) As DateTime 'Convert วันที่จาก yyyy-MM-dd HH:mm:ss เป็น DateTime
            Dim ret As New Date(1, 1, 1)
            If StrDate.Trim <> "" Then
                Dim vDate() As String = Split(StrDate, "-")
                If StrTime.Trim <> "" Then
                    Dim vTime() As String = Split(StrTime, ":")
                    ret = New Date(vDate(0), vDate(1), vDate(2), vTime(0), vTime(1), vTime(2))
                Else
                    ret = New Date(vDate(0), vDate(1), vDate(2))
                End If
            End If
            Return ret
        End Function

        Public Shared Function GetShopConfig(ByVal ParaName As String, ByVal shLnq As CenLinqDB.TABLE.TbShopCenLinqDB) As String
            Dim tmp As String = ""
            Try
                Dim ret As Boolean = False
                Dim lnq As New ShLinqDB.TABLE.TbSettingShLinqDB
                Dim shTrans As New ShLinqDB.Common.Utilities.TransactionDB
                shTrans.CreateTransaction(shLnq.SHOP_DB_SERVER, shLnq.SHOP_DB_USERID, shLnq.SHOP_DB_PWD, shLnq.SHOP_DB_NAME)
                If shTrans.Trans IsNot Nothing Then
                    ret = lnq.ChkDataByWhere("config_name = '" & ParaName & "'", shTrans.Trans)
                    shTrans.CommitTransaction()
                Else
                    shTrans.CreateTransaction(shLnq.SHOP_DR_SERVER, shLnq.SHOP_DR_USERID, shLnq.SHOP_DR_PWD, shLnq.SHOP_DR_NAME)
                    If shTrans.Trans IsNot Nothing Then
                        ret = lnq.ChkDataByWhere("config_name = '" & ParaName & "'", shTrans.Trans)
                        shTrans.CommitTransaction()
                    End If
                End If

                If ret = True Then
                    tmp = lnq.CONFIG_VALUE
                End If
                'lnq = Nothing
            Catch ex As Exception
                FunctionEng.SaveErrorLog("FunctionEng.GetShopConfig", "Exception :" & ex.Message)
            End Try

            Return tmp
        End Function

        Public Shared Function GetItem(ByVal cID As Long, ByVal shTrans As ShLinqDB.Common.Utilities.TransactionDB) As ShParaDB.TABLE.TbItemShParaDB
            Dim lnq As New ShLinqDB.TABLE.TbItemShLinqDB
            Dim para As New ShParaDB.TABLE.TbItemShParaDB
            para = lnq.GetParameter(cID, shTrans.Trans)
            lnq = Nothing
            Return para
        End Function

        Public Shared Function GetQisDBCustomer(ByVal MobileNo As String, ByVal trans As CenLinqDB.Common.Utilities.TransactionDB) As CenParaDB.TABLE.TbCustomerCenParaDB
            Dim lnq As New TbCustomerCenLinqDB
            Dim para As New CenParaDB.TABLE.TbCustomerCenParaDB
            para = lnq.GetParameterByMobileNo(MobileNo, trans.Trans)
            lnq = Nothing
            Return para
        End Function

        Public Shared Function GetShTransction(ByVal shTrans As ShLinqDB.Common.Utilities.TransactionDB, ByVal trans As CenLinqDB.Common.Utilities.TransactionDB, ByVal shLnq As CenLinqDB.TABLE.TbShopCenLinqDB) As ShLinqDB.Common.Utilities.TransactionDB
            Dim retTrans As Boolean = False
            shTrans = New ShLinqDB.Common.Utilities.TransactionDB
            retTrans = shTrans.CreateTransaction(shLnq.MAIN_SERVERNAME, shLnq.MAIN_DB_USERID, shLnq.MAIN_DB_PWD, shLnq.MAIN_DB_NAME)
            If retTrans = False Then
                FunctionEng.SaveErrorLog("FunctionENG.GetShTransction", "Connect to DR Site")
                retTrans = shTrans.CreateTransaction(shLnq.SHOP_DR_SERVER, shLnq.SHOP_DR_USERID, shLnq.SHOP_DR_PWD, shLnq.SHOP_DR_NAME)
            End If

            Return shTrans
        End Function

        Public Shared Function GetDateNowFromDB() As Date
            Dim ret As String
            Dim dt As DataTable = SqlDB.ExecuteTable("select getdate() date_now")
            ret = dt.Rows(0)("date_now")
            Return ret
        End Function

        Public Shared Function ExecuteShopSQL(ByVal Sql As String, ByVal ShopID As Long, ByVal ClassName As String) As DataTable
            Dim shTrans As New ShLinqDB.Common.Utilities.TransactionDB
            shTrans = GetShTransction(ShopID, ClassName)
            Dim dt As New DataTable
            If shTrans IsNot Nothing Then
                dt = ShLinqDB.Common.Utilities.SqlDB.ExecuteTable(Sql, shTrans.Trans)
            End If
            shTrans.CommitTransaction()

            Return dt
        End Function

        Public Shared Function ExecuteDataTable(ByVal sql As String) As DataTable
            Dim dt As New DataTable
            dt = SqlDB.ExecuteTable(sql)
            Return dt
        End Function


        Public Shared Function GetMonthNameEN(ByVal MonthNo As Integer) As String
            Dim month As String = ""
            Select Case MonthNo
                Case 1
                    month = "January"
                Case 2
                    month = "February"
                Case 3
                    month = "March"
                Case 4
                    month = "April"
                Case 5
                    month = "May"
                Case 6
                    month = "June"
                Case 7
                    month = "July"
                Case 8
                    month = "August"
                Case 9
                    month = "September"
                Case 10
                    month = "October"
                Case 11
                    month = "November"
                Case 12
                    month = "December"
            End Select
            Return month
        End Function

        Public Shared Function GetUploadPath() As String
            Dim fldPath As String = System.Configuration.ConfigurationSettings.AppSettings("UploadPath").ToString
            If System.IO.Directory.Exists(fldPath) = False Then
                System.IO.Directory.CreateDirectory(fldPath)
            End If
            Return fldPath
        End Function

        Public Shared Function GetActiveShopDDL() As DataTable
            Dim trans As New CenLinqDB.Common.Utilities.TransactionDB
            Dim lnq As New CenLinqDB.TABLE.TbShopCenLinqDB
            Dim sql As String = " select id, shop_code + ' ' + shop_name_en shop_name from tb_shop where active='Y' order by shop_code"
            Dim dt As DataTable = lnq.GetListBySql(sql, trans.Trans)
            trans.CommitTransaction()
            lnq = Nothing

            Return dt
        End Function

#Region " Encrypt/Decrypt "
        Private Shared EncryptionKey As String = "scoresolutions12"
        Public Shared Function EnCripPwd(ByVal passString As String) As String
            Return ShLinqDB.Common.Utilities.SqlDB.EnCripPwd(passString)
        End Function

        Public Shared Function DeCripPwd(ByVal passString As String) As String
            Return ShLinqDB.Common.Utilities.SqlDB.DeCripPwd(passString)
        End Function
#End Region
    End Class
End Namespace

