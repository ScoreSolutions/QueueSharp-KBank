Imports Engine.Common
Imports Cen = CenLinqDB.TABLE
Imports System.Windows.Forms
Imports System.Globalization

Public Class CSISurveyENG
    Dim _err As String = ""
    Dim _TXT_LOG As TextBox

    Public Property ErrorMessage() As String
        Get
            Return _err
        End Get
        Set(ByVal value As String)
            _err = value
        End Set
    End Property

    Public Sub SetTextLog(ByVal txtLog As TextBox)
        _TXT_LOG = txtLog
    End Sub

    Dim _OldLog As String = ""
    Private Sub PrintLog(ByVal LogDesc As String)
        If _OldLog <> LogDesc Then
            _TXT_LOG.Text += DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") & "  " & LogDesc & vbNewLine & _TXT_LOG.Text
            _OldLog = LogDesc
            Application.DoEvents()
        End If
    End Sub

#Region "Filter Set"
    Private Function GetFilterTimeNoDate(ByVal DateNow As DateTime, ByVal TimeFrom As String, ByVal TimeTo As String) As Boolean
        'กรณี DateFrom และ DateTo ไม่เท่ากับค่าว่าง
        Dim ret As Boolean = False
        If TimeFrom <> "" And TimeTo <> "" Then
            If TimeFrom <= DateNow.ToString("HH:mm") And TimeTo >= DateNow.ToString("HH:mm") Then
                ret = True
            End If
        ElseIf TimeFrom <> "" And TimeTo = "" Then
            If TimeFrom <= DateNow.ToString("HH:mm") Then
                ret = True
            End If
        ElseIf TimeFrom = "" And TimeTo <> "" Then
            If TimeTo >= DateNow.ToString("HH:mm") Then
                ret = True
            End If
        Else
            ret = True
        End If

        Return ret
    End Function

    Private Function GetFilterAllDay(ByVal fLnq As Cen.TbFilterCenLinqDB, ByVal DateNow As DateTime) As Boolean
        Dim ret As Boolean = False
        Dim DateFrom As String = fLnq.PREIOD_DATEFROM.Value.ToString("yyyy-MM-dd", New CultureInfo("en-US"))
        Dim DateTo As String = fLnq.PREIOD_DATETO.Value.ToString("yyyy-MM-dd", New CultureInfo("en-US"))
        Dim TimeFrom As String = fLnq.PREIOD_TIMEFROM
        Dim TimeTo As String = fLnq.PREIOD_TIMETO

        If fLnq.PREIOD_DATEFROM.Value.Year <> 1 And fLnq.PREIOD_DATETO.Value.Year <> 1 Then
            If DateFrom <= DateNow.ToString("yyyy-MM-dd", New CultureInfo("en-US")) And DateTo >= DateNow.ToString("yyyy-MM-dd", New CultureInfo("en-US")) Then
                ret = GetFilterTimeNoDate(DateNow, TimeFrom, TimeTo)
            Else
                ret = False
            End If
        ElseIf fLnq.PREIOD_DATEFROM.Value.Year <> 1 And fLnq.PREIOD_DATETO.Value.Year = 1 Then
            If DateFrom <= DateNow.ToString("yyyy-MM-dd", New CultureInfo("en-US")) Then
                ret = GetFilterTimeNoDate(DateNow, TimeFrom, TimeTo)
            Else
                ret = False
            End If
        ElseIf fLnq.PREIOD_DATEFROM.Value.Year = 1 And fLnq.PREIOD_DATETO.Value.Year <> 1 Then
            If DateFrom <= DateNow.ToString("yyyy-MM-dd", New CultureInfo("en-US")) Then
                ret = GetFilterTimeNoDate(DateNow, TimeFrom, TimeTo)
            Else
                ret = False
            End If
        ElseIf fLnq.PREIOD_DATEFROM.Value.Year = 1 And fLnq.PREIOD_DATETO.Value.Year = 1 Then
            ret = GetFilterTimeNoDate(DateNow, TimeFrom, TimeTo)
        Else
            ret = True
        End If

        Return ret
    End Function

    Private Function GetFilterByDay(ByVal fLnq As Cen.TbFilterCenLinqDB, ByVal DateNow As DateTime) As Boolean
        Dim ret As Boolean = GetFilterAllDay(fLnq, DateNow)
        If ret = True Then
            ret = False
            Dim CaseDay As Integer = DatePart(DateInterval.Weekday, DateTime.Now)
            Select Case CaseDay
                Case 1
                    ret = (fLnq.SCHEDULESUNDAY = "Y")
                Case 2
                    ret = (fLnq.SCHEDULEMONDAY = "Y")
                Case 3
                    ret = (fLnq.SCHEDULETUEDAY = "Y")
                Case 4
                    ret = (fLnq.SCHEDULEWEDDAY = "Y")
                Case 5
                    ret = (fLnq.SCHEDULETHUDAY = "Y")
                Case 6
                    ret = (fLnq.SCHEDULEFRIDAY = "Y")
                Case 7
                    ret = (fLnq.SCHEDULESATDAY = "Y")
            End Select
        End If

        Return ret
    End Function

    Private Sub SetFilterActiveStatus(ByVal lblTime As Label)
        Dim trans As New CenLinqDB.Common.Utilities.TransactionDB
        If trans.Trans IsNot Nothing Then
            Dim fLnq As New Cen.TbFilterCenLinqDB
            Dim fDt As DataTable = fLnq.GetDataList("active_status = 'Y'", "", trans.Trans)
            trans.CommitTransaction()
            If fDt.Rows.Count > 0 Then
                For Each fDr As DataRow In fDt.Rows
                    trans = New CenLinqDB.Common.Utilities.TransactionDB
                    If trans.Trans IsNot Nothing Then
                        Dim ret As Boolean = False
                        fLnq.GetDataByPK(fDr("id"), trans.Trans)
                        If fLnq.ID <> 0 Then
                            Dim DateNow As DateTime = DateTime.Now
                            Dim TimeNow As String = CenLinqDB.Common.Utilities.SqlDB.GetDateNow("T", trans.Trans)
                            If fLnq.SCHEDULETYPEDAY = "0" Then
                                'สำรวจทุกวัน
                                ret = GetFilterAllDay(fLnq, DateNow)
                            ElseIf fLnq.SCHEDULETYPEDAY = "1" Then
                                'สำรวจตามวัน
                                ret = GetFilterByDay(fLnq, DateNow)
                            End If

                            If ret = True Then
                                'duration_type (ประเภทเวลาการ Filter)
                                '0 = สำรวจหลังบริการเสร็จ
                                '1 = สำรวจทุกๆ
                                Dim ChkTime As DateTime
                                Select Case fLnq.DURATION_TYPE
                                    Case "0"
                                        ChkTime = DateAdd(DateInterval.Minute, (0 - fLnq.DURATION_AFTER_MIN.Value), DateTime.Now)
                                    Case "1"
                                        ChkTime = DateAdd(DateInterval.Minute, (0 - fLnq.DURATION_EVERY_MIN.Value), DateTime.Now)
                                End Select

                                If ChkTime < fLnq.LAST_SAVE_FILTER Then
                                    fLnq.PROCESS_STATUS = "N"
                                Else
                                    fLnq.PROCESS_STATUS = "Y"
                                End If
                            Else
                                fLnq.PROCESS_STATUS = "N"
                            End If

                            If fLnq.UpdateByPK("CSISurveyENG.SetFilterActiveStatus", trans.Trans) = True Then
                                trans.CommitTransaction()
                            Else
                                trans.RollbackTransaction()
                                FunctionEng.SaveErrorLog("CSISurveyENG.SetFilterActiveStatus", "FilterName : " & fLnq.FILTER_NAME & " " & fLnq.ErrorMessage)
                                PrintLog("CSISurveyENG.SetFilterActiveStatus : " & " FilterName : " & fLnq.FILTER_NAME & " " & fLnq.ErrorMessage)
                            End If
                        End If
                    End If
                    lblTime.Text = DateTime.Now.ToString("HH:mm:ss")
                    Application.DoEvents()
                Next
                fDt = Nothing
            End If
            fLnq = Nothing
        Else
            PrintLog("CSISurveyENG.SetFilterActiveStatus : " & trans.ErrorMessage)
        End If
    End Sub

    Private Sub UpdateLastProcTime(ByVal FilterLnq As Cen.TbFilterCenLinqDB)
        Dim fTrans As New CenLinqDB.Common.Utilities.TransactionDB
        If FilterLnq.UpdateBySql("update tb_filter set last_proc_time=getdate() where id = " & FilterLnq.ID, fTrans.Trans) = True Then
            fTrans.CommitTransaction()
        Else
            fTrans.RollbackTransaction()
            PrintLog("CSISurverENG.SendCSI : " & "update tb_filter set lase_proc_time=getdate() where id = " & FilterLnq.ID & " ###ErrorMsg=" & FilterLnq.ErrorMessage)
            FunctionEng.SaveErrorLog("CSISurverENG.SendCSI", "update tb_filter set lase_proc_time=getdate() where id = " & FilterLnq.ID & " ###ErrorMsg=" & FilterLnq.ErrorMessage)
        End If
    End Sub

    Public Sub FilterData(ByVal lblTime As Label)
        SetFilterActiveStatus(lblTime)
        Dim trans As New CenLinqDB.Common.Utilities.TransactionDB
        If trans.Trans IsNot Nothing Then
            Dim fLnq As New Cen.TbFilterCenLinqDB
            Dim fSql As String = "process_status='Y' and active_status = 'Y'"
            Dim fDt As DataTable = fLnq.GetDataList(fSql, "", trans.Trans)
            trans.CommitTransaction()
            If fDt.Rows.Count > 0 Then
                For Each fDr As DataRow In fDt.Rows
                    trans = New CenLinqDB.Common.Utilities.TransactionDB
                    If trans.Trans IsNot Nothing Then
                        Dim FilterLnq As New Cen.TbFilterCenLinqDB
                        FilterLnq.GetDataByPK(fDr("id"), trans.Trans)
                        If FilterLnq.ID <> 0 Then
                            'หา Shop ที่จะต้องทำการสำรวจโดย Filter นี้
                            Dim shLnq As New Cen.TbFilterShopCenLinqDB
                            Dim shDt As DataTable = shLnq.GetDataList("tb_filter_id = " & fDr("id"), "", trans.Trans)
                            trans.CommitTransaction()
                            If shDt.Rows.Count > 0 Then
                                For Each shDr As DataRow In shDt.Rows
                                    trans = New CenLinqDB.Common.Utilities.TransactionDB
                                    If trans.Trans IsNot Nothing Then
                                        Dim ShopLnq As Cen.TbShopCenLinqDB = FunctionEng.GetTbShopCenLinqDB(shDr("tb_shop_id"))
                                        If ShopLnq.ACTIVE = "Y" Then
                                            Dim dt As New DataTable
                                            If FilterLnq.DURATION_TYPE = "0" Then
                                                'สำรวจหลัง End Queue ไปแล้ว X นาที
                                                Dim WhText As String = " DATEADD(MINUTE, " & FilterLnq.DURATION_AFTER_MIN.Value & " ,end_time)<= GETDATE()"
                                                WhText += " and convert(varchar(8),service_date,112)=convert(varchar(8),getdate(),112)"
                                                WhText += " and CONVERT(varchar(19), DATEADD(MINUTE, " & (0 - FilterLnq.DURATION_AFTER_MIN.Value) & " , end_time),120) >= '" & FilterLnq.LAST_SAVE_FILTER.ToString("yyyy-MM-dd HH:mm:ss", New Globalization.CultureInfo("en-US")) & "'"
                                                dt = GetQData(FilterLnq, ShopLnq, trans, WhText)
                                            ElseIf FilterLnq.DURATION_TYPE = "1" Then
                                                'สำรวจทุกๆ X นาที
                                                Dim LastTime As DateTime
                                                If FilterLnq.LAST_PROC_TIME.Value.Year = 1 Then
                                                    FilterLnq.LAST_PROC_TIME = DateTime.Now
                                                    UpdateLastProcTime(FilterLnq)
                                                Else
                                                    LastTime = FilterLnq.LAST_PROC_TIME
                                                End If

                                                If DateAdd(DateInterval.Minute, FilterLnq.DURATION_EVERY_MIN.Value, LastTime) <= DateTime.Now Then
                                                    Dim whText As String = " convert(varchar(16),end_time,120) between '" & LastTime.ToString("yyyy-MM-dd HH:mm", New Globalization.CultureInfo("en-US")) & "' and CONVERT(varchar(16),getdate(),120) "
                                                    whText += " and convert(varchar(8), service_date,112)=convert(varchar(8),getdate(),112) "
                                                    whText += " and CONVERT(varchar(19), DATEADD(MINUTE, " & (0 - FilterLnq.DURATION_EVERY_MIN.Value) & " , end_time),120) >= '" & FilterLnq.LAST_SAVE_FILTER.ToString("yyyy-MM-dd HH:mm:ss", New Globalization.CultureInfo("en-US")) & "'"
                                                    dt = GetQData(FilterLnq, ShopLnq, trans, whText)
                                                    UpdateLastProcTime(FilterLnq)
                                                End If
                                            End If
                                            lblTime.Text = DateTime.Now.ToString("HH:mm:ss")
                                            Application.DoEvents()

                                            'เพิ่มข้อมูลลงใน TB_FILTER_DATA
                                            If dt.Rows.Count > 0 Then
                                                'dt = GetFilterMobileNo2Month(dt, trans)
                                                'trans.CommitTransaction()
                                                If dt.Rows.Count > 0 Then
                                                    lblTime.Text = DateTime.Now.ToString("HH:mm:ss")
                                                    Application.DoEvents()

                                                    Dim vDateNow As DateTime = DateTime.Now
                                                    For i As Integer = 0 To dt.Rows.Count - 1
                                                        Dim ItemID As Long = IIf(Convert.IsDBNull(dt.Rows(i)("master_itemid")) = False, Convert.ToInt64(dt.Rows(i)("master_itemid")), 0)
                                                        Dim fSV As DataView = FilterLnq.CHILD_TB_FILTER_SERVICE_tb_filter_id.DefaultView
                                                        If FilterLnq.TARGET_UNLIMITED = "N" Then
                                                            fSV.RowFilter = "tb_item_id = '" & ItemID & "' and target_percent > 0"
                                                        End If
                                                        If fSV.Count > 0 Then
                                                            trans = New CenLinqDB.Common.Utilities.TransactionDB
                                                            'ตรวจสอบ Target ถ้าได้ผลลัพธ์ตามจำนวน Target ที่ต้องการแล้วก็ไม่ต้องส่งอีก
                                                            If ChkTarget(FilterLnq, ShopLnq.ID, ItemID, Convert.ToDateTime(dt.Rows(i)("end_time")), trans) = False Then
                                                                lblTime.Text = DateTime.Now.ToString("HH:mm:ss")
                                                                Application.DoEvents()
                                                                If ChkJustInsert(dt.Rows(i)("customer_id"), Convert.ToDateTime(dt.Rows(i)("end_time")), trans) = False Then
                                                                    'Queue_unique_id Format = QueueNo + ShopAbb+yyyyMMddHHmmss  EX. A104PK25550326172423
                                                                    Dim lnq As New Cen.TbFilterDataCenLinqDB
                                                                    lnq.SHOP_ID = ShopLnq.ID
                                                                    lnq.SERVICE_DATE = dt.Rows(i)("service_date")
                                                                    lnq.QUEUE_NO = dt.Rows(i)("queue_no")
                                                                    lnq.QUEUE_UNIQUE_ID = dt.Rows(i)("queue_no") & ShopLnq.SHOP_ABB & Convert.ToDateTime(dt.Rows(i)("service_date")).ToString("yyyyMMddHHmmss", New CultureInfo("en-US"))
                                                                    lnq.MOBILE_NO = dt.Rows(i)("customer_id")
                                                                    lnq.USERNAME = dt.Rows(i)("username")
                                                                    If Convert.IsDBNull(dt.Rows(i)("customer_name")) = False Then lnq.CUSTOMER_NAME = dt.Rows(i)("customer_name")
                                                                    lnq.TB_FILTER_ID = FilterLnq.ID
                                                                    lnq.TB_ITEM_ID = ItemID
                                                                    lnq.TEMPLATE_CODE = FilterLnq.TEMPLATE_CODE
                                                                    lnq.FILTER_TIME = vDateNow
                                                                    lnq.RESULT_STATUS = "0"
                                                                    lnq.END_TIME = dt.Rows(i)("end_time")
                                                                    If Convert.IsDBNull(dt.Rows(i)("network_type")) = False Then lnq.NETWORK_TYPE = dt.Rows(i)("network_type")
                                                                    lnq.NPS_SCORE = -1

                                                                    If lnq.InsertData("CSISurverENG.SendCSI", trans.Trans) Then
                                                                        trans.CommitTransaction()
                                                                    Else
                                                                        trans.RollbackTransaction()
                                                                        FunctionEng.SaveErrorLog("CSISurverENG.SendCSI", ShopLnq.SHOP_NAME_EN & " " & lnq.MOBILE_NO & " " & lnq.QUEUE_NO & " " & lnq.SERVICE_DATE & lnq.ErrorMessage)
                                                                        PrintLog("CSISurverENG.SendCSI : " & ShopLnq.SHOP_NAME_EN & " " & lnq.MOBILE_NO & " " & lnq.QUEUE_NO & " " & lnq.SERVICE_DATE & lnq.ErrorMessage)
                                                                    End If
                                                                    lnq = Nothing
                                                                Else
                                                                    trans.CommitTransaction()
                                                                End If
                                                            Else
                                                                trans.CommitTransaction()
                                                            End If
                                                        End If
                                                        lblTime.Text = DateTime.Now.ToString("HH:mm:ss")
                                                        Application.DoEvents()
                                                    Next
                                                End If
                                                dt.Dispose()
                                            Else
                                                trans.CommitTransaction()
                                            End If
                                        End If
                                        ShopLnq = Nothing
                                    End If
                                Next
                                shDt.Dispose()
                            End If
                        End If
                    End If
                Next
                fDt.Dispose()
            End If
        Else
            PrintLog("CSISurverENG.FilterData : " & trans.ErrorMessage)
        End If
    End Sub

    Private Function ChkTarget(ByVal FilterLnq As Cen.TbFilterCenLinqDB, ByVal ShopID As Long, ByVal ServiceID As Long, ByVal EndServiceTime As DateTime, ByVal trans As CenLinqDB.Common.Utilities.TransactionDB) As Boolean
        Dim ret As Boolean = False
        If FilterLnq.TARGET_UNLIMITED = "N" Then
            Dim sql As String = "select [target],[username],end_time_from,end_time_to "
            sql += " from TB_FILTER_TEMP_TARGET"
            sql += " where tb_filter_id = '" & FilterLnq.ID & "'"
            sql += " and tb_item_id = '" & ServiceID & "'"
            sql += " and tb_shop_id = '" & ShopID & "'"
            sql += " and convert(varchar(8),service_date,112)='" & DateTime.Now.ToString("yyyyMMdd", New CultureInfo("en-US")) & "'"
            sql += " and '" & EndServiceTime.ToString("HH:mm") & "' between end_time_from and end_time_to"

            Dim tDt As New DataTable
            Dim tLnq As New Cen.TbFilterTempTargetCenLinqDB
            tDt = tLnq.GetListBySql(sql, trans.Trans)
            If tDt.Rows.Count > 0 Then

                sql = "select count(fd.id) filter"
                sql += " from tb_filter_data fd"
                sql += " where fd.tb_filter_id='" & FilterLnq.ID & "'"
                sql += " and fd.tb_item_id='" & ServiceID & "'"
                sql += " and fd.shop_id = '" & ShopID & "'"
                sql += " and fd.result_status='2' "
                sql += " and convert(varchar(8),fd.end_time,112)='" & DateTime.Now.ToString("yyyyMMdd", New CultureInfo("en-US")) & "'"
                sql += " and CONVERT(varchar(5),fd.end_time,114) between '" & Convert.ToDateTime(tDt.Rows(0)("end_time_from")).ToString("HH:mm") & "' and '" & Convert.ToDateTime(tDt.Rows(0)("end_time_to")).ToString("HH:mm") & "'"
                If Convert.IsDBNull(tDt.Rows(0)("username")) = False Then
                    sql += " and fd.username in (" & tDt.Rows(0)("username").ToString & ")"
                End If

                Dim dt As New DataTable
                Dim lnq As New Cen.TbFilterDataCenLinqDB
                dt = lnq.GetListBySql(sql, trans.Trans)
                If dt.Rows.Count > 0 Then
                    If Convert.ToDouble(dt.Rows(0)("filter")) >= Convert.ToDouble(tDt.Rows(0)("target")) Then
                        ret = True
                    End If
                    dt.Dispose()
                End If
                lnq = Nothing
            End If
            tDt.Dispose()
            tLnq = Nothing
        End If

        Return ret
    End Function

    Private Function ChkJustInsert(ByVal MobileNo As String, EndServiceTime As DateTime, ByVal trans As CenLinqDB.Common.Utilities.TransactionDB) As Boolean
        Dim ret As Boolean = False
        Dim lnq As New Cen.TbFilterDataCenLinqDB
        Dim wh As String = "mobile_no = '" & MobileNo & "' "
        'wh += " and result_status <> '2' "
        wh += " and convert(varchar(8),filter_time,112)='" & DateTime.Now.ToString("yyyyMMdd", New CultureInfo("en-US")) & "' "
        wh += " and convert(varchar(19),end_time,120)='" & EndServiceTime.ToString("yyyy-MM-dd HH:mm:ss", New Globalization.CultureInfo("en-US")) & "'"
        Dim dt As DataTable = lnq.GetDataList(wh, "", trans.Trans)
        If dt.Rows.Count > 0 Then
            ret = True
        End If
        dt.Dispose()
        lnq = Nothing

        Return ret
    End Function

    Private Function GetFilterMobileNo2Month(ByVal dt As DataTable, ByVal trans As CenLinqDB.Common.Utilities.TransactionDB) As DataTable
        Dim FilterLastDay As String = FunctionEng.GetQisDBConfig("CSI_FILTER_LASTDAY")
        If FilterLastDay.Trim = "" Then
            FilterLastDay = "60"
        End If

        Dim lnq As New Cen.TbFilterDataCenLinqDB
        Dim WhText As String = "result_status >= '1' "
        WhText += " and  convert(varchar(10),send_time,120) >= convert(varchar(10),DATEADD(DAY, " & (0 - Convert.ToInt16(FilterLastDay)) & " , getdate()),120) "

        Dim fDt As DataTable = lnq.GetDataList(WhText, "", trans.Trans)
        If fDt.Rows.Count > 0 Then
            For i As Integer = dt.Rows.Count - 1 To 0 Step -1
                fDt.DefaultView.RowFilter = "mobile_no = '" & dt.Rows(i)("customer_id").ToString & "'"
                If fDt.DefaultView.Count > 0 Then
                    dt.Rows.RemoveAt(i)
                End If
                fDt.DefaultView.RowFilter = ""
            Next
            fDt.Dispose()
        End If
        lnq = Nothing

        Return dt
    End Function

    Private Function GetCategoryDesc(ByVal CategoryCode As String, ByVal trans As CenLinqDB.Common.Utilities.TransactionDB) As String
        Dim ret As String = ""
        Dim lnq As New CenLinqDB.TABLE.TbCustomerMappingLinq
        Dim dt As New DataTable
        dt = lnq.GetDataList("mapping_code = '" & CategoryCode & "' and field_name = 'GROUP_CODE' ", "", trans.Trans)
        If dt.Rows.Count > 0 Then
            ret = dt.Rows(0)("display_value").ToString
        End If
        dt.Dispose()
        lnq = Nothing

        Return ret
    End Function

    Private Function GetContactClassDesc(ByVal ContactClassCode As String, ByVal trans As CenLinqDB.Common.Utilities.TransactionDB) As String
        Dim ret As String = ""
        Dim lnq As New CenLinqDB.TABLE.TbCustomerMappingLinq
        Dim dt As New DataTable
        dt = lnq.GetDataList("mapping_code = '" & ContactClassCode & "' and field_name = 'CUST_CLASS' ", "", trans.Trans)
        If dt.Rows.Count > 0 Then
            ret = dt.Rows(0)("display_value").ToString
        End If
        dt.Dispose()
        lnq = Nothing

        Return ret
    End Function

    Private Function GetQData(ByVal FilterLnq As Cen.TbFilterCenLinqDB, ByVal ShopLnq As Cen.TbShopCenLinqDB, ByVal trans As CenLinqDB.Common.Utilities.TransactionDB, ByVal whText As String, Optional ByVal TimeType As String = "H") As DataTable
        'TimeType = H (Current Hour)
        'TimeType = D (All By Date)


        'หาข้อมูล Q ที่ End
        'Dim vCategory As String = GetCategoryDesc(FilterLnq.CATEGORY, trans)
        'Dim vContactClass As String = GetContactClassDesc(FilterLnq.CONTACT_CLASS, trans)

        Dim sql As String = ""
        sql += " SELECT  * FROM [v_csi_filter_data]" & vbNewLine
        sql += " Where " & whText & vbNewLine
        If TimeType = "H" Then
            'เอาคิวที่ End มาแล้วในแต่ละชั่วโมง
            sql += " and end_time >= DATEADD(hour,-1,getdate())" & vbNewLine
        ElseIf TimeType = "D" Then
            sql += " and convert(varchar(10),end_time,120)=convert(varchar(10),getdate(),120)" & vbNewLine
        End If

        ''Category
        'If FilterLnq.BLANK_CATEGORY = "Y" Then
        '    sql += " and isnull(category,'') in ('" & vCategory & "','') " & vbNewLine
        'Else
        '    sql += " and category = '" & vCategory & "' " & vbNewLine
        'End If

        ''ContactClass
        'If FilterLnq.BLANK_CONTACT_CLASS = "Y" Then
        '    sql += " and isnull(contact_class,'') in ('" & vContactClass & "','') " & vbNewLine
        'Else
        '    sql += " and contact_class = '" & vContactClass & "' " & vbNewLine
        'End If

        'Nationality
        If FilterLnq.NATIONALITY.Trim <> "" Then
            Dim vNation As String = ""
            Dim IsCheckThai As Boolean = False
            Dim IsCheckEng As Boolean = False
            Dim IsCheckOther As Boolean = False
            Dim IsCheckBlank As Boolean = False

            If FilterLnq.NATIONALITY.Trim.IndexOf("THAI") > -1 Then
                IsCheckThai = True
            End If
            If FilterLnq.NATIONALITY.Trim.IndexOf("ENG") > -1 Then
                IsCheckEng = True
            End If
            If FilterLnq.NATIONALITY.Trim.IndexOf("OTHER") > -1 Then
                IsCheckOther = True
            End If
            If FilterLnq.NATIONALITY.Trim.IndexOf("BLANK") > -1 Then
                IsCheckBlank = True
            End If

            If IsCheckOther = True Then
                If IsCheckThai = False And IsCheckEng = False Then
                    vNation += " and UPPER(prefer_lang) not in ('THAILAND','THAI','ENGLAND','ENG')" & vbNewLine
                Else
                    If IsCheckThai = False Then
                        vNation += " and UPPER(prefer_lang) not in ('THAILAND','THAI')" & vbNewLine
                    End If
                    If IsCheckEng = False Then
                        vNation += " and UPPER(prefer_lang) not in ('ENGLAND','ENG')" & vbNewLine
                    End If
                End If
            Else
                If IsCheckThai = True And IsCheckEng = True Then
                    vNation += " and UPPER(prefer_lang) in ('THAILAND','THAI','ENGLAND','ENG')" & vbNewLine
                Else
                    If IsCheckThai = True Then
                        vNation += " and UPPER(prefer_lang) in ('THAILAND','THAI')" & vbNewLine
                    ElseIf IsCheckEng = True Then
                        vNation += " and UPPER(prefer_lang) in ('ENGLAND','ENG')"
                    End If
                End If
            End If
            If IsCheckBlank = False Then
                vNation += " and isnull(prefer_lang,'')<>''" & vbNewLine
            Else
                'ถ้า Tick Checkbox Nationality ทั้ง 4 ค่าเลย ก็ไม่ต้อง ตรวจสอบ Nationality
                If IsCheckThai = True And IsCheckEng = True And IsCheckOther = True And IsCheckBlank = True Then

                Else
                    vNation = " and (" & vNation.Substring(4) & " or isnull(prefer_lang,'')='')" & vbNewLine
                End If
            End If
            sql += vNation
        End If

        'If FilterLnq.SEGMENT <> "0" Then
        '    Dim tmp As String = ""
        '    For Each seg As String In Split(FilterLnq.SEGMENT, ",")
        '        If tmp = "" Then
        '            tmp = "'" & seg & "'"
        '        Else
        '            tmp += "," & "'" & seg & "'"
        '        End If
        '    Next
        '    sql += " and segment in (" & tmp & ") " & vbNewLine
        'End If

        'หา Service ของ Filter
        Dim sDt As New DataTable
        sDt = FilterLnq.CHILD_TB_FILTER_SERVICE_tb_filter_id
        If sDt.Rows.Count > 0 Then
            sDt.DefaultView.RowFilter = "target_percent > 0"
            If sDt.DefaultView.Count > 0 Then
                Dim ServiceID As String = ""
                For Each sDr As DataRowView In sDt.DefaultView
                    If ServiceID = "" Then
                        ServiceID = sDr("tb_item_id")
                    Else
                        ServiceID += "," & sDr("tb_item_id")
                    End If
                Next
                sql += " and master_itemid in (" & ServiceID & ")" & vbNewLine
            End If
            sDt.Dispose()
        End If

        'If FilterLnq.NETWORK_TYPE.ToUpper <> "ALL" Then
        '    sql += " and network_type = '" & FilterLnq.NETWORK_TYPE & "'" & vbNewLine
        'End If

        Dim dt As New DataTable
        Dim shTrans As New ShLinqDB.Common.Utilities.TransactionDB
        shTrans = FunctionEng.GetShTransction(shTrans, trans, ShopLnq, "CSISurveyENG.GetQData")
        If shTrans.Trans IsNot Nothing Then
            Dim Qlnq As New ShLinqDB.TABLE.TbCounterQueueShLinqDB
            dt = Qlnq.GetListBySql(sql, shTrans.Trans)
            shTrans.CommitTransaction()
            Qlnq = Nothing
        End If


        'หา User ของ Filter
        If dt.Rows.Count > 0 Then
            Dim uDt As New DataTable
            uDt = FilterLnq.CHILD_TB_FILTER_STAFF_tb_filter_id
            If uDt.Rows.Count > 0 Then
                uDt.DefaultView.RowFilter = " shop_id = '" & ShopLnq.ID & "'"
                uDt = uDt.DefaultView.ToTable
                For i As Integer = dt.Rows.Count - 1 To 0 Step -1
                    uDt.DefaultView.RowFilter = "username = '" & dt.Rows(i)("username") & "'"
                    If uDt.DefaultView.Count = 0 Then
                        dt.Rows.RemoveAt(i)
                    End If
                    uDt.DefaultView.RowFilter = ""
                Next
                uDt.Dispose()
            End If
        End If

        If dt.Rows.Count > 0 Then
            Dim bDt As New DataTable
            Dim bSql As String = "select mobile_no "
            bSql += " from TB_FILTER_ATT_BACKLIST_MOBILE bm "
            bDt = FilterLnq.GetListBySql(bSql, trans.Trans)
            If bDt.Rows.Count > 0 Then
                For i As Integer = dt.Rows.Count - 1 To 0 Step -1
                    bDt.DefaultView.RowFilter = "mobile_no = '" & dt.Rows(i)("customer_id").ToString & "'"
                    If bDt.DefaultView.Count > 0 Then
                        dt.Rows.RemoveAt(i)
                    End If
                    bDt.DefaultView.RowFilter = ""
                Next
            End If
            bDt.Dispose()
        End If

        Return dt
    End Function
#End Region


#Region "Sent ATSR"
    Public Sub SendATSR(ByVal lblTime As Label)
        Dim trans As New CenLinqDB.Common.Utilities.TransactionDB
        If trans.Trans IsNot Nothing Then
            Dim lnq As New Cen.TbFilterDataCenLinqDB
            Dim dt As DataTable = lnq.GetDataList("send_time is null and result_status='0' and convert(varchar(8),filter_time,112)='" & DateTime.Now.ToString("yyyyMMdd", New CultureInfo("en-US")) & "'", "", trans.Trans)
            trans.CommitTransaction()
            If dt.Rows.Count > 0 Then
                For Each dr As DataRow In dt.Rows
                    Dim eng As New Engine.GeteWay.GateWayServiceENG
                    Dim shLnq As Cen.TbShopCenLinqDB = FunctionEng.GetTbShopCenLinqDB(dr("shop_id"))
                    If eng.SendATSR(dr("mobile_no"), dr("queue_unique_id"), shLnq.SHOP_ABB, dr("template_code")) = True Then
                        trans = New CenLinqDB.Common.Utilities.TransactionDB
                        Dim iLnq As New Cen.TbFilterDataCenLinqDB
                        iLnq.GetDataByPK(dr("id"), trans.Trans)
                        iLnq.SEND_TIME = DateTime.Now
                        iLnq.RESULT_STATUS = "1"

                        If iLnq.UpdateByPK("CSISurverENG.SendATSR", trans.Trans) = True Then
                            trans.CommitTransaction()
                        Else
                            trans.RollbackTransaction()
                            Dim _errDesc As String = "ID= " & lnq.ID & " MobileNO=" & iLnq.MOBILE_NO & " " & iLnq.ErrorMessage
                            FunctionEng.SaveErrorLog("CSISurverENG.SendATSR", _errDesc)
                        End If



                        'Dim sieRet As New CenParaDB.CSI.SiebelResponsePara
                        'sieRet = CreateSiebelActivityAllSurvey(shLnq.SHOP_CODE, shLnq.SHOP_NAME_EN, dr("mobile_no"))
                        'If sieRet.RESULT = False Then
                        '    Dim _errDesc As String = "Error CreateSiebelActivity ID= " & lnq.ID & " MobileNO=" & dr("mobile_no") & " " & sieRet.ErrorMessage
                        '    FunctionEng.SaveErrorLog("CSISurverENG.SendATSR", _errDesc)
                        'Else
                        '    trans = New CenLinqDB.Common.Utilities.TransactionDB
                        '    iLnq = New Cen.TbFilterDataCenLinqDB
                        '    iLnq.GetDataByPK(dr("id"), trans.Trans)
                        '    iLnq.ACTIVITY_ID_SURVEY = sieRet.ACTIVITY_ID

                        '    If iLnq.UpdateByPK("CSISurverENG.SendATSR", trans.Trans) = True Then
                        '        trans.CommitTransaction()
                        '    Else
                        '        trans.RollbackTransaction()
                        '        Dim _errDesc As String = "Error Update ACTIVITY_ID_SURVEY ID= " & lnq.ID & " MobileNO=" & iLnq.MOBILE_NO & " " & iLnq.ErrorMessage
                        '        FunctionEng.SaveErrorLog("CSISurverENG.SendATSR", _errDesc)
                        '    End If
                        'End If
                        'sieRet = Nothing
                        iLnq = Nothing
                    End If
                    eng = Nothing
                    shLnq = Nothing

                    lblTime.Text = DateTime.Now.ToString("HH:mm:ss")
                    Application.DoEvents()
                Next
                dt.Dispose()
            End If
        Else
            PrintLog("CSISurverENG.SendATSR : " & trans.ErrorMessage)
        End If
    End Sub

    Private Function CreateSiebelActivityResult3(ByVal ShopCode As String, ByVal ShopNameEn As String, ByVal MobileNo As String, ByVal RegionCode As String) As CenParaDB.CSI.SiebelResponsePara
        Dim data As New CenParaDB.CSI.SiebelReqPara
        data.SIEBEL_TYPE = "Leave Voice Survey CSI"
        If RegionCode.ToUpper = "BKK" Then
            data.ACTIVITYCATEGORY = "ร้องเรียน-ชมพนักงาน / สำนักงาน AIS Outlet (กรุงเทพ)"
        Else
            data.ACTIVITYCATEGORY = "ร้องเรียน-ชมพนักงาน / สำนักงาน AIS Branch (ต่างจังหวัด)"
        End If
        data.ACTIVITYSUBCATEGORY = "ข้อควรปรับปรุงจากการสำรวจ CSI"
        data.DESCRIPTION = "1. ข้อความที่ลูกค้าฝากไว้ " & vbNewLine & vbNewLine & _
        "2.Location / สาขา ที่ร้องเรียน    " & ShopCode & "/" & ShopNameEn & vbNewLine & _
        "3.กรณี Verify เรียบร้อยแล้ว ระบุข้อมูลใน Resolution กรณีเรื่องที่ให้ปรับปรุงไม่ตรงกับ Sub-cat ให้ดำเนินการระบุใน Reason ด้วย" & vbNewLine & _
        "4.QAI Team/ลูกค้า Leave Voice จากการสำรวจ CSI"
        data.STATUS = "Open"
        data.MOBILE_NO = MobileNo

        Dim sieRet As New CenParaDB.CSI.SiebelResponsePara
        Dim gw As New Engine.GeteWay.GateWayServiceENG
        sieRet = gw.CreateSiebelActivity(data)
        gw = Nothing
        data = Nothing

        Return sieRet
    End Function

    Private Function CreateSiebelActivityAllSurvey(ByVal ShopCode As String, ByVal ShopNameEn As String, ByVal MobileNo As String) As CenParaDB.CSI.SiebelResponsePara
        Dim data As New CenParaDB.CSI.SiebelReqPara
        data.SIEBEL_TYPE = "Survey CSI"
        data.ACTIVITYCATEGORY = "Survey"
        data.ACTIVITYSUBCATEGORY = "CSI Survey AIS Retail Shop"
        data.DESCRIPTION = ShopCode & "/" & ShopNameEn
        data.STATUS = "Done"
        data.MOBILE_NO = MobileNo

        Dim sieRet As New CenParaDB.CSI.SiebelResponsePara
        Dim gw As New Engine.GeteWay.GateWayServiceENG
        sieRet = gw.CreateSiebelActivity(data)
        gw = Nothing
        data = Nothing

        Return sieRet
    End Function

    Private Function GetATSRCallTime(ByVal DateIN As String) As DateTime
        Dim ret As New DateTime(1, 1, 1, 1, 1, 1)
        '07/01/2013 14:16:09:000

        If DateIN.Trim <> "" Then
            If DateIN.Substring(10, 1) = " " Then
                Dim vDT() As String = Split(DateIN, " ")
                Dim vDate() As String = Split(vDT(0), "/")
                Dim vTime() As String = Split(vDT(1), ":")

                If vDate.Length = 3 And vTime.Length = 4 Then
                    Dim yy As Integer = vDate(2)
                    Dim mm As Integer = vDate(1)
                    Dim dd As Integer = vDate(0)
                    Dim hh As Integer = vTime(0)
                    Dim mi As Integer = vTime(1)
                    Dim ss As Integer = vTime(2)
                    ret = New DateTime(yy, mm, dd, hh, mi, ss)

                    'System.IO.Directory.GetFiles("", "ABC*.txt")
                End If
            End If
        End If

        Return ret
    End Function

    Private Function GetShopDetail(ByVal ShopID As Long, ByVal trans As SqlClient.SqlTransaction) As DataTable
        Dim ret As New DataTable
        Dim sql As String = "select sh.shop_code, sh.shop_name_en, r.region_code "
        sql += " from tb_shop sh "
        sql += " inner join tb_region r on r.id=sh.region_id"
        sql += " where sh.id='" & ShopID & "'"

        ret = CenLinqDB.Common.Utilities.SqlDB.ExecuteTable(sql, trans)
        Return ret
    End Function

    Public Sub GetATSRResult(ByVal lblTime As Label)
        Dim trans As New CenLinqDB.Common.Utilities.TransactionDB
        If trans.Trans IsNot Nothing Then
            Dim lnq As New Cen.TbFilterDataCenLinqDB
            Dim dt As DataTable = lnq.GetDataList("result_time is null and result_status='1' and convert(varchar(8),send_time,112)='" & DateTime.Now.ToString("yyyyMMdd", New CultureInfo("en-US")) & "'", "", trans.Trans)
            trans.CommitTransaction()
            If dt.Rows.Count > 0 Then
                For Each dr As DataRow In dt.Rows
                    lnq = New Cen.TbFilterDataCenLinqDB
                    Dim eng As New Engine.GeteWay.GateWayServiceENG
                    Dim res As New CenParaDB.GateWay.ATSRResultPara
                    res = eng.GetATSRSurveyResult(dr("queue_unique_id"))
                    If res.RESULT_VALUE.Trim <> "" Then
                        trans = New CenLinqDB.Common.Utilities.TransactionDB
                        lnq.GetDataByPK(dr("id"), trans.Trans)
                        lnq.RESULT_TIME = DateTime.Now
                        lnq.RESULT_STATUS = "2"
                        lnq.RESULT = res.RESULT_VALUE
                        lnq.ATSR_CALL_TIME = GetATSRCallTime(res.ATSR_CALL_TIME)

                        If res.NPS_SCORE <> "" Then
                            lnq.NPS_SCORE = res.NPS_SCORE
                        Else
                            lnq.NPS_SCORE = -1
                        End If

                        If lnq.UpdateByPK("CSISurveyENG.GetATSRResult", trans.Trans) = True Then
                            trans.CommitTransaction()

                            'If res.RESULT_VALUE.Trim = "ควรปรับปรุง" And res.HAVE_LEAVE_VOICE = True Then
                            '    trans = New CenLinqDB.Common.Utilities.TransactionDB
                            '    Dim shDt As New DataTable
                            '    shDt = GetShopDetail(lnq.SHOP_ID, trans.Trans)
                            '    If shDt.Rows.Count > 0 Then
                            '        trans.CommitTransaction()
                            '        Dim shDr As DataRow = shDt.Rows(0)
                            '        Dim sieRet As New CenParaDB.CSI.SiebelResponsePara
                            '        sieRet = CreateSiebelActivityResult3(shDr("shop_code"), shDr("shop_name_en"), lnq.MOBILE_NO, shDr("region_code"))
                            '        If sieRet.RESULT = False Then
                            '            FunctionEng.SaveErrorLog("CSISurveyENG.GetATSRResult", "Error CreateSiebelActivityResult3  QuqID=" & dr("queue_unique_id") & " $$$ " & lnq.ErrorMessage)
                            '        Else
                            '            lnq = New Cen.TbFilterDataCenLinqDB
                            '            trans = New CenLinqDB.Common.Utilities.TransactionDB
                            '            lnq.GetDataByPK(dr("id"), trans.Trans)
                            '            lnq.ACTIVITY_ID_LEAVE_VOICE = sieRet.ACTIVITY_ID
                            '            If lnq.UpdateByPK("CSISurveyENG.GetATSRResult", trans.Trans) = True Then
                            '                trans.CommitTransaction()
                            '            Else
                            '                trans.RollbackTransaction()
                            '                FunctionEng.SaveErrorLog("CSISurveyENG.GetATSRResult", "Error UPDATE ACTIVITY_ID_LEAVE_VOICE  QuqID=" & dr("queue_unique_id"))
                            '            End If
                            '        End If
                            '        sieRet = Nothing
                            '    Else
                            '        trans.RollbackTransaction()
                            '        FunctionEng.SaveErrorLog("CSISurveyENG.GetATSRResult", "Error GetShopDetail  QuqID=" & dr("queue_unique_id"))
                            '    End If
                            '    shDt.Dispose()
                            'End If
                        Else
                            trans.RollbackTransaction()
                            FunctionEng.SaveErrorLog("CSISurveyENG.GetATSRResult", "QuqID=" & dr("queue_unique_id") & " $$$ " & lnq.ErrorMessage)
                        End If


                        
                    Else
                        Select Case res.RESULT_STATE
                            Case "UNKNOWN", "UNSUCCESS"
                                trans = New CenLinqDB.Common.Utilities.TransactionDB
                                lnq.GetDataByPK(dr("id"), trans.Trans)
                                lnq.RESULT_TIME = DateTime.Now
                                lnq.RESULT_STATUS = "3"
                                lnq.RESULT = res.RESULT_STATE
                                lnq.ATSR_CALL_TIME = GetATSRCallTime(res.ATSR_CALL_TIME)

                                If lnq.UpdateByPK("CSISurveyENG.GetATSRResult", trans.Trans) = True Then
                                    trans.CommitTransaction()
                                Else
                                    trans.RollbackTransaction()
                                    'PrintLog("CSISurveyENG.GetATSRResult : QuqID=" & dr("queue_unique_id") & " $$$ " & lnq.ErrorMessage)
                                    FunctionEng.SaveErrorLog("CSISurveyENG.GetATSRResult", "QuqID=" & dr("queue_unique_id") & " $$$ " & lnq.ErrorMessage)
                                End If

                        End Select
                    End If
                    eng = Nothing
                    res = Nothing
                    lnq = Nothing

                    lblTime.Text = DateTime.Now.ToString("HH:mm:ss")
                    Application.DoEvents()
                Next
                dt.Dispose()
            End If
        Else
            PrintLog("CSISurverENG.GetATSRResult : " & trans.ErrorMessage)
        End If
    End Sub

    Public Sub SendResultToShop(ByVal lblTime As Label)
        Dim sDt As DataTable = FunctionEng.GetActiveShop()
        If sDt.Rows.Count > 0 Then
            For Each sDr As DataRow In sDt.Rows
                Dim trans As New CenLinqDB.Common.Utilities.TransactionDB
                Dim fLnq As New CenLinqDB.TABLE.TbFilterDataCenLinqDB

                Dim dt As DataTable = fLnq.GetDataList("send_to_shop_time is null and result_status = '2' and shop_id = '" & sDr("id") & "' and convert(varchar(8),result_time,112)='" & DateTime.Now.ToString("yyyyMMdd", New CultureInfo("en-US")) & "'", "result_time", trans.Trans)
                trans.CommitTransaction()
                fLnq = Nothing

                If dt.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows
                        trans = New CenLinqDB.Common.Utilities.TransactionDB

                        Dim lnq As New CenLinqDB.TABLE.TbFilterDataCenLinqDB
                        lnq.GetDataByPK(dr("id"), trans.Trans)

                        Dim shTrans As New ShLinqDB.Common.Utilities.TransactionDB
                        shTrans = FunctionEng.GetShTransction(shTrans, trans, FunctionEng.GetTbShopCenLinqDB(sDr("id")), "CSISurveyENG.SendResultToShop")
                        If shTrans.Trans IsNot Nothing Then
                            Dim CsiLnq As New ShLinqDB.TABLE.TbCsiShLinqDB
                            CsiLnq.SERVICE_DATE = lnq.SERVICE_DATE
                            CsiLnq.ITEM_ID = lnq.TB_ITEM_ID
                            If lnq.RESULT = "ดีมาก" Then
                                CsiLnq.RESULT_VALUE = 3
                            ElseIf lnq.RESULT = "ดี" Then
                                CsiLnq.RESULT_VALUE = 2
                            ElseIf lnq.RESULT = "ควรปรับปรุง" Then
                                CsiLnq.RESULT_VALUE = 1
                            ElseIf lnq.RESULT = "ตามคาดหวัง" Then
                                CsiLnq.RESULT_VALUE = 1
                            ElseIf lnq.RESULT = "มากกว่าคาดหวัง" Then
                                CsiLnq.RESULT_VALUE = 2
                            Else
                                CsiLnq.RESULT_VALUE = 0
                            End If

                            Dim ret As Boolean = CsiLnq.InsertData("CSISurveyENG.SendResultToShop", shTrans.Trans)
                            If ret = True Then
                                shTrans.CommitTransaction()

                                lnq.SEND_TO_SHOP_TIME = DateTime.Now
                                If lnq.UpdateByPK("CSISurveyENG.SendResultToShop", trans.Trans) = True Then
                                    trans.CommitTransaction()
                                Else
                                    trans.RollbackTransaction()
                                End If
                            Else
                                shTrans.RollbackTransaction()
                            End If
                            CsiLnq = Nothing
                        End If
                        trans.CommitTransaction()
                        lnq = Nothing

                        lblTime.Text = DateTime.Now.ToString("HH:mm:ss")
                        Application.DoEvents()
                    Next
                    dt.Dispose()
                End If
            Next
            sDt.Dispose()
        End If
    End Sub
#End Region

#Region "Send Email"
    Public Sub CSISendEmail(ByVal ServiceDate As DateTime, ByVal ShopID As Long)
        Dim shLinq As CenLinqDB.TABLE.TbShopCenLinqDB = FunctionEng.GetTbShopCenLinqDB(ShopID)
        Dim MailMsg As String = FilterDataForSendEmail(ServiceDate, shLinq)
        If MailMsg.Trim <> "" Then
            Dim gw As New GeteWay.GateWayServiceENG
            gw.SendEmail("nattapol@scoresolutions.co.th;akkarawat@scoresolutions.co.th", "CSI Data at shop " & shLinq.SHOP_NAME_TH & " " & ServiceDate.ToString("dd/MM/yyyy"), MailMsg)
            shLinq = Nothing
        End If
        shLinq = Nothing
    End Sub
    Private Function FilterDataForSendEmail(ByVal ServiceDate As DateTime, ByVal shLinq As CenLinqDB.TABLE.TbShopCenLinqDB) As String
        Dim MailMsg As New System.Text.StringBuilder

        Dim trans As New CenLinqDB.Common.Utilities.TransactionDB
        Dim dt As New DataTable
        Dim fLnq As New CenLinqDB.TABLE.TbFilterCenLinqDB
        dt = fLnq.GetDataList("active_status='Y'", "", trans.Trans)
        trans.CommitTransaction()
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Dim dr As DataRow = dt.Rows(i)

                trans = New CenLinqDB.Common.Utilities.TransactionDB
                Dim shLnq As New Cen.TbFilterShopCenLinqDB
                Dim shDt As DataTable = shLnq.GetDataList("tb_filter_id = " & dr("id") & " and tb_shop_id = '" & shLinq.ID & "'", "", trans.Trans)
                trans.CommitTransaction()
                If shDt.Rows.Count > 0 Then
                    For Each shDr As DataRow In shDt.Rows
                        trans = New CenLinqDB.Common.Utilities.TransactionDB
                        If trans.Trans IsNot Nothing Then
                            fLnq.GetDataByPK(dr("id"), trans.Trans)
                            If fLnq.HaveData = True Then
                                Dim ret As Boolean = False
                                If fLnq.SCHEDULETYPEDAY = "0" Then
                                    'สำรวจทุกวัน
                                    ret = True
                                ElseIf fLnq.SCHEDULETYPEDAY = "1" Then
                                    'สำรวจตามวัน
                                    Dim CaseDay As Integer = DatePart(DateInterval.Weekday, DateTime.Now)
                                    Select Case CaseDay
                                        Case 1
                                            ret = (fLnq.SCHEDULESUNDAY = "Y")
                                        Case 2
                                            ret = (fLnq.SCHEDULEMONDAY = "Y")
                                        Case 3
                                            ret = (fLnq.SCHEDULETUEDAY = "Y")
                                        Case 4
                                            ret = (fLnq.SCHEDULEWEDDAY = "Y")
                                        Case 5
                                            ret = (fLnq.SCHEDULETHUDAY = "Y")
                                        Case 6
                                            ret = (fLnq.SCHEDULEFRIDAY = "Y")
                                        Case 7
                                            ret = (fLnq.SCHEDULESATDAY = "Y")
                                    End Select
                                End If

                                If ret = True Then
                                    Dim qDt As DataTable = GetQData(fLnq, shLinq, trans, "1=1", "D")
                                    If qDt.Rows.Count > 0 Then

                                        'ใช้ ชั่วคราวก่อน 2013-01-12
                                        Dim bSql As String = "select b.mobile_no"
                                        bSql += " from TB_FILTER_BACKLIST_FILE f "
                                        bSql += " inner join TB_FILTER_BACKLIST_MOBILE b on b.tb_filter_backlist_file_id=f.id"
                                        bSql += " where f.tb_filter_id='" & fLnq.ID & "'"
                                        Dim bDt As DataTable = fLnq.GetListBySql(bSql, trans.Trans)
                                        If bDt.Rows.Count > 0 Then
                                            For j As Integer = qDt.Rows.Count - 1 To 0 Step -1
                                                bDt.DefaultView.RowFilter = "mobile_no = '" & qDt.Rows(j)("customer_id").ToString & "'"
                                                If bDt.DefaultView.Count > 0 Then
                                                    qDt.Rows.RemoveAt(j)
                                                End If
                                                bDt.DefaultView.RowFilter = ""
                                            Next
                                        End If
                                        bDt = Nothing




                                        If qDt.Rows.Count > 0 Then
                                            MailMsg.Append("<table border='0' cellpadding='0' cellspacing='0' width='100%'> ")
                                            MailMsg.Append("    <tr>")
                                            MailMsg.Append("        <td>Template Name</td>")
                                            MailMsg.Append("        <td>Mobile No</td>")
                                            MailMsg.Append("        <td>Customer Name</td>")
                                            MailMsg.Append("        <td>End Service Time</td>")
                                            MailMsg.Append("        <td>Username</td>")
                                            MailMsg.Append("        <td>Service Name</td>")
                                            MailMsg.Append("    </tr>")
                                            Dim tmpMsg As String = ""
                                            For Each qDr As DataRow In qDt.Rows
                                                MailMsg.Append("    <tr>")
                                                MailMsg.Append("        <td>" & fLnq.FILTER_NAME & "</td>")
                                                MailMsg.Append("        <td>" & qDr("customer_id") & "</td>")
                                                If Convert.IsDBNull(qDr("customer_name")) = False Then
                                                    MailMsg.Append("        <td>" & qDr("customer_name") & "</td>")
                                                Else
                                                    MailMsg.Append("        <td>&nbsp;</td>")
                                                End If
                                                MailMsg.Append("        <td>" & Convert.ToDateTime(qDr("end_time")).ToString("dd/MM/yyyy HH:mm:ss", New Globalization.CultureInfo("th-TH")) & "</td>")
                                                MailMsg.Append("        <td>" & qDr("username") & "</td>")
                                                MailMsg.Append("        <td>" & qDr("item_name") & "</td>")
                                                MailMsg.Append("    </tr>")
                                            Next
                                            MailMsg.Append("</table>")
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    Next
                End If
            Next
            dt = Nothing
        End If
        fLnq = Nothing

        Return MailMsg.ToString
    End Function
#End Region

#Region "Calulate Filter Target"
    Public Sub CalTarget()
        Try
            Dim trans As New CenLinqDB.Common.Utilities.TransactionDB
            If trans.Trans IsNot Nothing Then
                Dim fLnq As New Cen.TbFilterCenLinqDB
                Dim fDt As DataTable = fLnq.GetDataList("cal_target = 'N' and active_status='Y'", "", trans.Trans)
                trans.CommitTransaction()
                If fDt.Rows.Count > 0 Then
                    For Each fDr As DataRow In fDt.Rows
                        If SaveFilterTempTarget(fDr("id"), "AisCSIAgent") = False Then
                            FunctionEng.SaveErrorLog("CSISurveyENG.CalTarget", _err)
                        End If
                    Next
                    fDt.Dispose()
                End If
            End If
        Catch ex As Exception
            FunctionEng.SaveErrorLog("CSISurveyENG.CalTarget", "Exception : " & ex.Message)
        End Try
    End Sub

    Public Function SaveFilterTempTarget(ByVal FilterID As Long, ByVal LoginName As String) As Boolean
        'สูตรคำนวณ Target ต่อ Shop ต่อ Service = (Target/(จำนวนวัน * จำนวนชั่วโมง))* % ของแต่ละ Service

        Dim trans As New CenLinqDB.Common.Utilities.TransactionDB
        Dim fLnq As New CenLinqDB.TABLE.TbFilterCenLinqDB
        fLnq.GetDataByPK(FilterID, trans.Trans)

        Dim DayQty As Integer = 0
        Dim HourQty As Integer = CInt(Split(fLnq.PREIOD_TIMETO, ":")(0)) - CInt(Split(fLnq.PREIOD_TIMEFROM, ":")(0))

        If fLnq.SCHEDULETYPEDAY = "0" Then
            DayQty = DateDiff(DateInterval.Day, fLnq.PREIOD_DATEFROM.Value, fLnq.PREIOD_DATETO.Value) + 1
        ElseIf fLnq.SCHEDULETYPEDAY = "1" Then
            Dim CurrDate As DateTime = fLnq.PREIOD_DATEFROM.Value
            Do
                If fLnq.SCHEDULESUNDAY = "Y" And CurrDate.DayOfWeek = DayOfWeek.Sunday Then
                    DayQty += 1
                End If
                If fLnq.SCHEDULEMONDAY = "Y" And CurrDate.DayOfWeek = DayOfWeek.Monday Then
                    DayQty += 1
                End If
                If fLnq.SCHEDULETUEDAY = "Y" And CurrDate.DayOfWeek = DayOfWeek.Tuesday Then
                    DayQty += 1
                End If
                If fLnq.SCHEDULEWEDDAY = "Y" And CurrDate.DayOfWeek = DayOfWeek.Wednesday Then
                    DayQty += 1
                End If
                If fLnq.SCHEDULETHUDAY = "Y" And CurrDate.DayOfWeek = DayOfWeek.Thursday Then
                    DayQty += 1
                End If
                If fLnq.SCHEDULEFRIDAY = "Y" And CurrDate.DayOfWeek = DayOfWeek.Friday Then
                    DayQty += 1
                End If
                If fLnq.SCHEDULESATDAY = "Y" And CurrDate.DayOfWeek = DayOfWeek.Saturday Then
                    DayQty += 1
                End If

                CurrDate = DateAdd(DateInterval.Day, 1, CurrDate)
            Loop While CurrDate <= fLnq.PREIOD_DATETO.Value
        End If

        Dim ret As Boolean = False
        Dim shDt As DataTable = fLnq.CHILD_TB_FILTER_SHOP_tb_filter_id
        If shDt.Rows.Count > 0 Then
            Dim svLnq As New CenLinqDB.TABLE.TbFilterServiceCenLinqDB
            Dim svDt As DataTable = svLnq.GetDataList("tb_filter_id='" & fLnq.ID & "' and target_percent > 0", "", trans.Trans)
            If svDt.Rows.Count > 0 Then
                For Each shDr As DataRow In shDt.Rows
                    For Each svDr As DataRow In svDt.Rows
                        Dim tmp As Double = ((fLnq.TARGET * Convert.ToDouble(svDr("target_percent"))) / 100) / (DayQty * HourQty)
                        Dim Target As Integer = Math.Ceiling(tmp)

                        'Update Target Per Hour สำหรับแต่ละ Service
                        Dim sLnq As New CenLinqDB.TABLE.TbFilterServiceCenLinqDB
                        sLnq.GetDataByPK(svDr("id"), trans.Trans)
                        sLnq.TARGET_PERHOUR = Target

                        If sLnq.UpdateByPK(LoginName, trans.Trans) = True Then
                            'Loop ตามวันที่
                            Dim CurrDate As DateTime = fLnq.PREIOD_DATEFROM.Value
                            Do
                                If GetSelectedDateOfWeek(fLnq, CurrDate) = True Then
                                    For i As Integer = CInt(Split(fLnq.PREIOD_TIMEFROM, ":")(0)) To CInt(Split(fLnq.PREIOD_TIMETO, ":")(0)) - 1
                                        Dim lnq As New CenLinqDB.TABLE.TbFilterTempTargetCenLinqDB
                                        lnq.TB_FILTER_ID = fLnq.ID
                                        lnq.TB_SHOP_ID = Convert.ToInt64(shDr("tb_shop_id"))
                                        lnq.SERVICE_DATE = CurrDate
                                        lnq.END_TIME_FROM = i.ToString.PadLeft(2, "0") & ":00"
                                        lnq.END_TIME_TO = (i + 1).ToString.PadLeft(2, "0") & ":00"
                                        lnq.TB_ITEM_ID = Convert.ToInt64(svDr("tb_item_id"))
                                        lnq.USERNAME = GetFilterUserName(fLnq, Convert.ToInt64(svDr("tb_item_id")), Convert.ToInt64(shDr("tb_shop_id")), trans)
                                        lnq.TARGET = Target


                                        ret = lnq.InsertData(LoginName, trans.Trans)
                                        If ret = False Then
                                            _err = lnq.ErrorMessage
                                            Exit For
                                        End If
                                    Next
                                    If ret = False Then
                                        Exit Do
                                    End If
                                End If

                                CurrDate = DateAdd(DateInterval.Day, 1, CurrDate)
                            Loop While CurrDate <= fLnq.PREIOD_DATETO.Value
                        Else
                            ret = False
                            _err = sLnq.ErrorMessage
                            Exit For
                        End If
                        If ret = False Then
                            Exit For
                        End If
                    Next
                    If ret = False Then
                        Exit For
                    End If
                Next
            Else
                _err = "Service Not Found"
            End If

            If ret = True Then
                fLnq.CAL_TARGET = "Y"
                If fLnq.UpdateByPK(LoginName, trans.Trans) = True Then
                    trans.CommitTransaction()
                Else
                    trans.RollbackTransaction()
                    _err = fLnq.ErrorMessage
                End If
            Else
                trans.RollbackTransaction()
            End If
        Else
            _err = "Shop Not Found"
        End If

        Return ret
    End Function

    Private Function GetSelectedDateOfWeek(ByVal fLnq As CenLinqDB.TABLE.TbFilterCenLinqDB, ByVal CurrDate As DateTime) As Boolean
        Dim ret As Boolean = False
        If fLnq.SCHEDULETYPEDAY = "0" Then
            ret = True
        ElseIf fLnq.SCHEDULETYPEDAY = "1" Then
            If fLnq.SCHEDULESUNDAY = "Y" And CurrDate.DayOfWeek = DayOfWeek.Sunday Then
                ret = True
            ElseIf fLnq.SCHEDULEMONDAY = "Y" And CurrDate.DayOfWeek = DayOfWeek.Monday Then
                ret = True
            ElseIf fLnq.SCHEDULETUEDAY = "Y" And CurrDate.DayOfWeek = DayOfWeek.Tuesday Then
                ret = True
            ElseIf fLnq.SCHEDULEWEDDAY = "Y" And CurrDate.DayOfWeek = DayOfWeek.Wednesday Then
                ret = True
            ElseIf fLnq.SCHEDULETHUDAY = "Y" And CurrDate.DayOfWeek = DayOfWeek.Thursday Then
                ret = True
            ElseIf fLnq.SCHEDULEFRIDAY = "Y" And CurrDate.DayOfWeek = DayOfWeek.Friday Then
                ret = True
            ElseIf fLnq.SCHEDULESATDAY = "Y" And CurrDate.DayOfWeek = DayOfWeek.Saturday Then
                ret = True
            End If
        End If

        Return ret
    End Function

    Private Function GetFilterUserName(ByVal fLnq As CenLinqDB.TABLE.TbFilterCenLinqDB, ByVal ServiceID As Long, ByVal ShopID As Long, ByVal trans As CenLinqDB.Common.Utilities.TransactionDB) As String
        Dim ret As String = ""
        Dim fuDt As New DataTable
        fuDt = fLnq.CHILD_TB_FILTER_STAFF_tb_filter_id
        fuDt.DefaultView.RowFilter = "shop_id = '" & ShopID & "'"
        fuDt = fuDt.DefaultView.ToTable
        If fuDt.Rows.Count > 0 Then
            Dim shLnq As CenLinqDB.TABLE.TbShopCenLinqDB = Engine.Common.FunctionEng.GetTbShopCenLinqDB(ShopID)
            Dim shTrans As New ShLinqDB.Common.Utilities.TransactionDB
            shTrans = Engine.Common.FunctionEng.GetShTransction(shTrans, trans, shLnq, "CSISurveyENG.GetFilterUserName")

            Dim sql As String = ""
            sql += " select distinct  u.username "
            sql += " from tb_user u"
            sql += " left join TB_TITLE t on t.id=u.title_id"
            sql += " inner join TB_USER_SKILL us on u.id=us.user_id"
            sql += " inner join TB_SKILL s on s.id=us.skill_id"
            sql += " inner join TB_SKILL_ITEM si on s.id=si.skill_id"
            sql += " inner join TB_ITEM i on i.id=si.item_id"
            sql += " where u.active_status = '1' and s.active_status='1' "
            sql += " and i.master_itemid = '" & ServiceID & "'"

            Dim uDt As DataTable = ShLinqDB.Common.Utilities.SqlDB.ExecuteTable(sql, shTrans.Trans)
            shTrans.CommitTransaction()
            If uDt.Rows.Count > 0 Then
                For i As Integer = fuDt.Rows.Count - 1 To 0 Step -1
                    uDt.DefaultView.RowFilter = "username = '" & fuDt.Rows(i)("username") & "'"
                    If uDt.DefaultView.Count > 0 Then
                        If ret.Trim = "" Then
                            ret = "'" & fuDt.Rows(i)("username") & "'"
                        Else
                            ret += ",'" & fuDt.Rows(i)("username") & "'"
                        End If
                    End If
                    uDt.DefaultView.RowFilter = ""
                Next
            End If
            uDt = Nothing
        End If
        fuDt = Nothing

        Return ret
    End Function
#End Region
End Class
