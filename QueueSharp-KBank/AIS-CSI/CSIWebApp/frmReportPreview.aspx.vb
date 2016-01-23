﻿Imports System.Data
Imports System.Globalization
Imports System.IO

Partial Class CSIWebApp_frmReportPreview
    Inherits System.Web.UI.Page

    Private Function GetWhText() As String
        Dim whText As String = "1=1"
        If Request("DateFrom") IsNot Nothing Then
            whText += " and convert(varchar(8),fd.send_time,112)>='" & Request("DateFrom").Trim & "'"
        End If
        If Request("DateTo") IsNot Nothing Then
            whText += " and convert(varchar(8),fd.send_time,112)<='" & Request("DateTo").Trim & "'"
        End If
        If Request("ShopID") IsNot Nothing Then
            whText += " and s.id='" & Request("ShopID") & "'"

            If Request("ShopUserName") IsNot Nothing Then
                whText += " and fd.username = '" & Request("ShopUserName") & "'"
            End If
        End If

        If Request("ServiceID") IsNot Nothing Then
            whText += " and fd.tb_item_id = '" & Request("ServiceID") & "'"
        End If
        If Request("BuildingID") IsNot Nothing Then
            whText += " and s.building_id = '" & Request("BuildingID") & "'"
        End If
        If Request("TemplateID") IsNot Nothing Then
            whText += " and fd.tb_filter_id in (" & Request("TemplateID") & ")"
        End If
        If Request("Status") IsNot Nothing Then
            Dim tmpSt() As String = Split(Request("Status"), ",")
            Dim tmp As String = ""
            For Each t As String In tmpSt
                If tmp = "" Then
                    tmp = "'" & t & "'"
                Else
                    tmp += ",'" & t & "'"
                End If
            Next
            whText += " and fd.result_status in (" & tmp & ")"
        End If
        If Request("NetworkType") IsNot Nothing Then
            whText += " and fd.network_type = '" & Request("NetworkType") & "'"
        End If
        Return whText
    End Function

    Private Sub SearchDetailData()
        Dim eng As New Engine.CSI.CSIReportsENG
        Dim dt As New DataTable
        dt = eng.GetDetailDataList(GetWhText)
        If dt.Rows.Count > 0 Then
            Dim ret As New StringBuilder

            ret.Append("<table border='1' cellspacing='0' cellpadding='0' width='100%' class='mGrid' >")
            ret.Append("    <tr style='background: yellowgreen repeat-x top;font-weight: bold;'>")
            ret.Append("        <td align='center' width='80px' style='color: #ffffff;' >Date</td>")
            ret.Append("        <td align='center' width='100px' style='color: #ffffff;' >End Service Time</td>")
            ret.Append("        <td align='center' width='80px' style='color: #ffffff;' >Sent Time</td>")
            ret.Append("        <td align='center' width='80px' style='color: #ffffff;' >ATSR Call Time</td>")
            ret.Append("        <td align='center' width='60px' style='color: #ffffff;' >Mobile No</td>")
            ret.Append("        <td align='center' width='60px' style='color: #ffffff;' >Result</td>")
            ret.Append("        <td align='center' width='60px' style='color: #ffffff;' >Location Code</td>")
            ret.Append("        <td align='center' width='120px' style='color: #ffffff;' >Location Name</td>")
            ret.Append("        <td align='center' width='150px' style='color: #ffffff;' >Name</td>")
            ret.Append("        <td align='center' width='100px' style='color: #ffffff;' >Service Type</td>")
            ret.Append("        <td align='center' width='80px' style='color: #ffffff;' >Username</td>")
            ret.Append("        <td align='center' width='60px' style='color: #ffffff;' >Template</td>")
            ret.Append("        <td align='center' width='60px' style='color: #ffffff;' >NPS Score</td>")
            ret.Append("        <td align='center' width='60px' style='color: #ffffff;' >Network Type</td>")
            ret.Append("    </tr>")

            For Each dr As DataRow In dt.Rows
                ret.Append("    <tr>")
                If Convert.IsDBNull(dr("send_time")) = False Then
                    ret.Append("        <td align='left' >&nbsp;" & Convert.ToDateTime(dr("send_time")).ToString("dd/MM/yyyy", New CultureInfo("th-TH")) & "</td>")
                Else
                    ret.Append("        <td align='left' >&nbsp;</td>")
                End If
                If Convert.IsDBNull(dr("end_time")) = False Then
                    ret.Append("        <td align='left' >&nbsp;" & Convert.ToDateTime(dr("end_time")).ToString("HH:mm:ss") & "</td>")
                Else
                    ret.Append("        <td align='left' >&nbsp;</td>")
                End If
                If Convert.IsDBNull(dr("send_time")) = False Then
                    ret.Append("        <td align='left' >&nbsp;" & Convert.ToDateTime(dr("send_time")).ToString("HH:mm:ss", New CultureInfo("th-TH")) & "</td>")
                Else
                    ret.Append("        <td align='left' >&nbsp;</td>")
                End If
                If Convert.IsDBNull(dr("atsr_call_time")) = False Then
                    ret.Append("        <td align='left' >&nbsp;" & Convert.ToDateTime(dr("atsr_call_time")).ToString("HH:mm:ss") & "</td>")
                Else
                    ret.Append("        <td align='left' >&nbsp;</td>")
                End If
                ret.Append("        <td align='left' >&nbsp;" & dr("mobile_no") & "</td>")
                ret.Append("        <td align='center' >" & dr("result") & "</td>")
                ret.Append("        <td align='left' >" & dr("shop_code") & "</td>")
                ret.Append("        <td align='left' >" & dr("shop_name_en") & "</td>")
                ret.Append("        <td align='left' >" & dr("customer_name") & "</td>")
                ret.Append("        <td align='left' >" & dr("item_name") & "</td>")
                ret.Append("        <td align='left' >" & dr("username") & "</td>")
                ret.Append("        <td align='left' >" & dr("filter_name") & "</td>")
                If Convert.ToInt16(dr("nps_score")) > -1 Then
                    ret.Append("        <td align='center' >" & dr("nps_score") & "</td>")
                Else
                    ret.Append("        <td align='left' >&nbsp;</td>")
                End If
                If Convert.IsDBNull(dr("network_type")) = False Then
                    ret.Append("        <td align='center' >" & dr("network_type") & "</td>")
                Else
                    ret.Append("        <td align='left' >&nbsp;</td>")
                End If
                ret.Append("    </tr>")
            Next
            ret.Append("</table>")
            lblRowCount.Text = "ค้นพบ " & dt.Rows.Count & " รายการ"

            lblReportDesc.Text = ret.ToString
            ret = Nothing
            dt = Nothing
            lblerror.Visible = False
        Else
            lblReportDesc.Text = ""
        End If
    End Sub

    Private Sub SearchCSIData()
        Dim sEng As New Engine.Configuration.MasterENG
        Dim sDt As New DataTable
        Dim sWh As String = " 1 = 1 "
        If Request("ServiceID") IsNot Nothing Then
            sWh += " and id= '" & Request("ServiceID") & "'"
        End If

        sDt = sEng.GetServiceActiveList(sWh)
        Dim shWh As String = " 1=1 "
        If Request("ShopID") IsNot Nothing Then
            shWh += " and sh.id = '" & Request("ShopID") & "'"
        End If
        Dim shDt As New DataTable
        Dim shEng As New Engine.Configuration.MasterENG
        shDt = shEng.GetShopList(shWh)

        If sDt.Rows.Count > 0 Then
            Dim ret As New StringBuilder
            Dim ServQty As Long = sDt.Rows.Count    'จำนวน Service +2(คือ Overall และ Customer Service)
            ret.Append("<table border='1' cellspacing='0' cellpadding='0' width='2000px' class='mGrid' >")

            'สร้างชื่อคอลัมน์ก่อน
            Dim DateFrom As Date = CDate(Request("DateFrom"))
            Dim DateTo As Date = CDate(Request("DateTo"))
            Dim CurrMonth As Date = DateFrom
            Dim tmpHRow As String = "        <td colspan='2'>&nbsp;</td>"
            Dim tmpSRow As String = "        <td colspan='2'>&nbsp;</td>"
            Dim tmpReRow As String = ""
            tmpReRow += "       <td align='center' style='color: #ffffff;' width='50px' >Location Code</td>"
            tmpReRow += "       <td align='center' style='color: #ffffff;' width='250px' >Location Name</td>"

            Do
                Dim StartDate As Date = IIf(CurrMonth = DateFrom, DateFrom, New Date(CurrMonth.Year, CurrMonth.Month, 1))
                Dim EndDate As Date = IIf(CurrMonth.ToString("MMyyyy") = DateTo.ToString("MMyyyy"), DateTo, New Date(CurrMonth.Year, CurrMonth.Month, CurrMonth.DaysInMonth(CurrMonth.Year, CurrMonth.Month)))
                tmpHRow += "        <td colspan='" & (ServQty * 7) & "' align='center' >&nbsp;" & CurrMonth.ToString("MMMM yyyy", New CultureInfo("en-US")) & "</td>"
                For Each sDr As DataRow In sDt.Rows
                    tmpSRow += "        <td align='center' colspan='7' style='color: #ffffff;' >" & sDr("item_name") & "</td>"

                    tmpReRow += "       <td align='center' colspan='2' style='color: #ffffff;' >ดีมาก</td>"
                    tmpReRow += "       <td align='center' colspan='2' style='color: #ffffff;' >ดี</td>"
                    tmpReRow += "       <td align='center' colspan='2' style='color: #ffffff;' >ควรปรับปรุง</td>"
                    tmpReRow += "       <td align='center' style='color: #ffffff;' >%CSI <br />" & sDr("item_name") & "</td>"
                Next
                CurrMonth = DateAdd(DateInterval.Month, 1, CurrMonth)
            Loop While CurrMonth.ToString("yyyyMM") <= DateTo.ToString("yyyyMM")
            '#### ตั้ม เพิ่ม Header ####
            'Overall

            tmpHRow += "        <td  rowspan='1' colspan='" & (ServQty * 7) & "'align='center'  ></td>"
            tmpSRow += "        <td align='center' colspan='7' style='color: #ffffff;' >Overall</td>"
            tmpReRow += "       <td align='center' colspan='2' style='color: #ffffff;' >ดีมาก</td>"
            tmpReRow += "       <td align='center' colspan='2' style='color: #ffffff;' >ดี</td>"
            tmpReRow += "       <td align='center' colspan='2' style='color: #ffffff;' >ควรปรับปรุง</td>"
            tmpReRow += "       <td align='center' style='color: #ffffff;' >%CSI <br />Overall</td>"

            ''Customer Service
            tmpSRow += "        <td align='center' colspan='7' style='color: #ffffff;' >Customer Service (Include SIM Change & Upgrade to AIS 3G)</td>"
            tmpReRow += "       <td align='center' colspan='2' style='color: #ffffff;' >ดีมาก</td>"
            tmpReRow += "       <td align='center' colspan='2' style='color: #ffffff;' >ดี</td>"
            tmpReRow += "       <td align='center' colspan='2' style='color: #ffffff;' >ควรปรับปรุง</td>"
            tmpReRow += "       <td align='center' style='color: #ffffff;' >%CSI <br />Customer Service</td>"
            ''####################


            Dim tmpDataRow As New StringBuilder

            Dim reDt As New DataTable
            reDt = shDt.DefaultView.ToTable(True, "region_id", "region_name_en").Copy
            If reDt.Rows.Count > 0 Then
                Dim GTotVeryGood(sDt.Rows.Count * (DateDiff(DateInterval.Month, DateFrom, DateTo) + 1)) As Double
                Dim GTotGood(sDt.Rows.Count * (DateDiff(DateInterval.Month, DateFrom, DateTo) + 1)) As Double
                Dim GTotAdjust(sDt.Rows.Count * (DateDiff(DateInterval.Month, DateFrom, DateTo) + 1)) As Double
                Dim GTotTotal(sDt.Rows.Count * (DateDiff(DateInterval.Month, DateFrom, DateTo) + 1)) As Double
                '### ตั้มเพิ่ม ไว้เก็บค่า Grand Total ######
                'Customer Service
                Dim GTotVeryGood_Customer_Service As Double
                Dim GTotGood_Customer_Service As Double
                Dim GTotAdjust_Customer_Service As Double
                Dim GTotTotal_Customer_Service As Double
                'Overall
                Dim GTotVeryGood_Overall As Double
                Dim GTotGood_Overall As Double
                Dim GTotAdjust_Overall As Double
                Dim GTotTotal_Overall As Double
                '##################################

                For Each reDr As DataRow In reDt.Rows     'Loop by Region
                    Dim TotVeryGood(sDt.Rows.Count * (DateDiff(DateInterval.Month, DateFrom, DateTo) + 1)) As Double
                    Dim TotGood(sDt.Rows.Count * (DateDiff(DateInterval.Month, DateFrom, DateTo) + 1)) As Double
                    Dim TotAdjust(sDt.Rows.Count * (DateDiff(DateInterval.Month, DateFrom, DateTo) + 1)) As Double
                    Dim TotTotal(sDt.Rows.Count * (DateDiff(DateInterval.Month, DateFrom, DateTo) + 1)) As Double
                    '### ตั้มเพิ่ม ไว้เก็บค่า Total และ Clear ค่า ######
                    'Customer Service
                    Dim TotVeryGood_Customer_Service As Double = 0
                    Dim TotGood_Customer_Service As Double = 0
                    Dim TotAdjust_Customer_Service As Double = 0
                    Dim TotTotal_Customer_Service As Double = 0
                    'Over all
                    Dim TotVeryGood_Overall As Double = 0
                    Dim TotGood_Overall As Double = 0
                    Dim TotAdjust_Overall As Double = 0
                    Dim TotTotal_Overall As Double = 0

                    'Customer Service
                    Dim vVeryGood_Customer_Service As Double = 0
                    Dim vGood_Customer_Service As Double = 0
                    Dim vAdjust_Customer_Service As Double = 0
                    Dim vTotal_Customer_Service As Double = 0
                    'Overall
                    Dim vVeryGood_Overall As Double = 0
                    Dim vGood_Overall As Double = 0
                    Dim vAdjust_Overall As Double = 0
                    Dim vTotal_Overall As Double = 0
                    '##################################
               


                    shDt.DefaultView.RowFilter = "region_id='" & reDr("region_id") & "'"
                    For Each shDr As DataRowView In shDt.DefaultView
                        tmpDataRow.Append("     <tr style='background-color:white' >")
                        tmpDataRow.Append("         <td width='50px'>" & shDr("shop_code") & "</td>")
                        tmpDataRow.Append("         <td width='150px'>" & shDr("shop_name_en") & "</td>")

                        Dim s As Integer = 0
                        Dim tt As Integer = 0
                        CurrMonth = DateFrom


                        Do
                            Dim StartDate As Date = IIf(CurrMonth = DateFrom, DateFrom, New Date(CurrMonth.Year, CurrMonth.Month, 1))
                            Dim EndDate As Date = IIf(CurrMonth.ToString("MMyyyy") = DateTo.ToString("MMyyyy"), DateTo, New Date(CurrMonth.Year, CurrMonth.Month, CurrMonth.DaysInMonth(CurrMonth.Year, CurrMonth.Month)))

                            For Each sDr As DataRow In sDt.Rows
                                Dim whText As String = " convert(varchar(8),fd.send_time, 112) between '" & StartDate.ToString("yyyyMMdd", New CultureInfo("en-US")) & "' and '" & EndDate.ToString("yyyyMMdd", New CultureInfo("en-US")) & "'"
                                whText += " and fd.tb_item_id = '" & sDr("id") & "'"
                                whText += " and fd.shop_id = '" & shDr("id") & "'"
                                If Request("TemplateID") IsNot Nothing Then
                                    whText += " and fd.tb_filter_id in (" & Request("TemplateID") & ")"
                                End If
                                'If Request("ShopUserName") IsNot Nothing Then
                                '    whText += " and fd.username='" & Request("ShopUserName") & "'"
                                'End If
                                If Request("Status") IsNot Nothing Then
                                    Dim tmpSt() As String = Split(Request("Status"), ",")
                                    Dim tmp As String = ""
                                    For Each t As String In tmpSt
                                        If tmp = "" Then
                                            tmp = "'" & t & "'"
                                        Else
                                            tmp += ",'" & t & "'"
                                        End If
                                    Next
                                    whText += " and fd.result_status in (" & tmp & ")"
                                End If

                                If Request("NetworkType") IsNot Nothing Then
                                    whText += " and fd.network_type ='" & Request("NetworkType") & "'"
                                End If

                                Dim eng As New Engine.CSI.CSIReportsENG
                                Dim dt As New DataTable
                                dt = eng.GetCSIDataList(whText)
                                If dt.Rows.Count > 0 Then
                                    Dim tmpShop As String = ""
                                    Dim dr As DataRow = dt.Rows(0)
                                    Dim vVeryGood As Double = Convert.ToDouble(dr("result_very_good"))
                                    Dim vGood As Double = Convert.ToDouble(dr("result_good"))
                                    Dim vAdjust As Double = Convert.ToDouble(dr("result_adjust"))
                                    Dim vTotal As Double = vVeryGood + vGood + vAdjust

                                    '### ตั้มเพิ่ม ไว้เก็บค่า Detail ไว้แสดง ######
                                    'Customer Service
                                    If sDr("id") = 6 Or sDr("id") = 8 Or sDr("id") = 2 Then '2 Customer Service,6 SimChage,8 Upgrad To 3g
                                        vVeryGood_Customer_Service += Convert.ToDouble(dr("result_very_good"))
                                        vGood_Customer_Service += Convert.ToDouble(dr("result_good"))
                                        vAdjust_Customer_Service += Convert.ToDouble(dr("result_adjust"))
                                        ' vTotal_Customer_Service += vVeryGood_Customer_Service + vGood_Customer_Service + vAdjust_Customer_Service
                                        vTotal_Customer_Service += Convert.ToDouble(dr("result_very_good")) + Convert.ToDouble(dr("result_good")) + Convert.ToDouble(dr("result_adjust"))
                                    End If
                                    'Overall
                                    vVeryGood_Overall += Convert.ToDouble(dr("result_very_good"))
                                    vGood_Overall += Convert.ToDouble(dr("result_good"))
                                    vAdjust_Overall += Convert.ToDouble(dr("result_adjust"))
                                    'vTotal_Overall += vVeryGood_Overall + vGood_Overall + vAdjust_Overall
                                    vTotal_Overall += Convert.ToDouble(dr("result_very_good")) + Convert.ToDouble(dr("result_good")) + Convert.ToDouble(dr("result_adjust"))
                                    '### ตั้มเพิ่ม ไว้เก็บค่า Detail ไว้แสดง ######

                                    Dim vVeryGoodP As Double = 0
                                    Dim vGoodP As Double = 0
                                    Dim vAdjustP As Double = 0
                                    Dim vTotalP As Double = 0
                                    If vTotal <> 0 Then
                                        vVeryGoodP = ((vVeryGood * 100) / vTotal)
                                        vGoodP = ((vGood * 100) / vTotal)
                                        vAdjustP = ((vAdjust * 100) / vTotal)
                                        vTotalP = (((vVeryGood + (vGood / 2)) * 100) / vTotal)
                                    End If
                                    tmpDataRow.Append("       <td align='center' width='30px'>" & vVeryGood & "</td>")
                                    tmpDataRow.Append("       <td align='center' width='30px'>" & Math.Round(vVeryGoodP, MidpointRounding.AwayFromZero) & "%</td>")
                                    tmpDataRow.Append("       <td align='center' width='30px'>" & vGood & "</td>")
                                    tmpDataRow.Append("       <td align='center' width='30px'>" & Math.Round(vGoodP, MidpointRounding.AwayFromZero) & "%</td>")
                                    tmpDataRow.Append("       <td align='center' width='50px'>" & vAdjust & "</td>")
                                    tmpDataRow.Append("       <td align='center' width='80px'>" & Math.Round(vAdjustP, MidpointRounding.AwayFromZero) & "%</td>")
                                    tmpDataRow.Append("       <td align='center' width='120px'>" & Math.Ceiling(vTotalP) & "%</td>")
                                    dt = Nothing

                                    TotVeryGood(s) += vVeryGood
                                    TotGood(s) += vGood
                                    TotAdjust(s) += vAdjust
                                    TotTotal(s) += vTotal

                                    GTotVeryGood(tt) += vVeryGood
                                    GTotGood(tt) += vGood
                                    GTotAdjust(tt) += vAdjust
                                    GTotTotal(tt) += vTotal
                                Else
                                    tmpDataRow.Append("       <td align='center' width='30px'></td>")
                                    tmpDataRow.Append("       <td align='center' width='30px'></td>")
                                    tmpDataRow.Append("       <td align='center' width='30px'></td>")
                                    tmpDataRow.Append("       <td align='center' width='30px'></td>")
                                    tmpDataRow.Append("       <td align='center' width='50px'></td>")
                                    tmpDataRow.Append("       <td align='center' width='80px'></td>")
                                    tmpDataRow.Append("       <td align='center' width='120px'></td>")
                                End If
                                s += 1
                                tt += 1
                            Next
                            CurrMonth = DateAdd(DateInterval.Month, 1, CurrMonth)
                        Loop While CurrMonth.ToString("yyyyMM") <= DateTo.ToString("yyyyMM")
                        '### ตั้มเพิ่ม นำค่า Detail ที่เก็บไว้มาแสดง ######
                        'Overall
                        Dim vVeryGoodP_Overall As Double = 0
                        Dim vGoodP_Overall As Double = 0
                        Dim vAdjustP_Overall As Double = 0
                        Dim vTotalP_Overall As Double = 0


                        If vTotal_Overall <> 0 Then
                            vVeryGoodP_Overall = ((vVeryGood_Overall * 100) / vTotal_Overall)
                            vGoodP_Overall = ((vGood_Overall * 100) / vTotal_Overall)
                            vAdjustP_Overall = ((vAdjust_Overall * 100) / vTotal_Overall)
                            vTotalP_Overall = (((vVeryGood_Overall + (vGood_Overall / 2)) * 100) / vTotal_Overall)
                        End If

                        If vTotal_Overall <> 0 Then
                            tmpDataRow.Append("       <td align='center' width='30px'>" & vVeryGood_Overall & "</td>")
                            tmpDataRow.Append("       <td align='center' width='30px'>" & Math.Round(vVeryGoodP_Overall, MidpointRounding.AwayFromZero) & "%</td>")
                            tmpDataRow.Append("       <td align='center' width='30px'>" & vGood_Overall & "</td>")
                            tmpDataRow.Append("       <td align='center' width='30px'>" & Math.Round(vGoodP_Overall, MidpointRounding.AwayFromZero) & "%</td>")
                            tmpDataRow.Append("       <td align='center' width='50px'>" & vAdjust_Overall & "</td>")
                            tmpDataRow.Append("       <td align='center' width='80px'>" & Math.Round(vAdjustP_Overall, MidpointRounding.AwayFromZero) & "%</td>")
                            tmpDataRow.Append("       <td align='center' width='120px'>" & Math.Ceiling(vTotalP_Overall) & "%</td>")

                            TotVeryGood_Overall += vVeryGood_Overall
                            TotGood_Overall += vGood_Overall
                            TotAdjust_Overall += vAdjust_Overall
                            TotTotal_Overall += vTotal_Overall

                            GTotVeryGood_Overall += vVeryGood_Overall
                            GTotGood_Overall += vGood_Overall
                            GTotAdjust_Overall += vAdjust_Overall
                            GTotTotal_Overall += vTotal_Overall
                            '## Clear ค่า ###
                            vVeryGood_Overall = 0
                            vGood_Overall = 0
                            vAdjust_Overall = 0
                            vTotal_Overall = 0
                            '##############
                        Else
                            tmpDataRow.Append("       <td align='center' width='30px'></td>")
                            tmpDataRow.Append("       <td align='center' width='30px'></td>")
                            tmpDataRow.Append("       <td align='center' width='30px'></td>")
                            tmpDataRow.Append("       <td align='center' width='30px'></td>")
                            tmpDataRow.Append("       <td align='center' width='50px'></td>")
                            tmpDataRow.Append("       <td align='center' width='80px'></td>")
                            tmpDataRow.Append("       <td align='center' width='120px'></td>")
                        End If

                        'customer service
                        Dim vVeryGoodP_Customer_Service As Double = 0
                        Dim vGoodP_Customer_Service As Double = 0
                        Dim vAdjustP_Customer_Service As Double = 0
                        Dim vTotalP_Customer_Service As Double = 0

                        If vTotal_Customer_Service <> 0 Then
                            vVeryGoodP_Customer_Service = ((vVeryGood_Customer_Service * 100) / vTotal_Customer_Service)
                            vGoodP_Customer_Service = ((vGood_Customer_Service * 100) / vTotal_Customer_Service)
                            vAdjustP_Customer_Service = ((vAdjust_Customer_Service * 100) / vTotal_Customer_Service)
                            vTotalP_Customer_Service = (((vVeryGood_Customer_Service + (vGood_Customer_Service / 2)) * 100) / vTotal_Customer_Service)
                        End If

                        If vTotal_Customer_Service <> 0 Then
                            tmpDataRow.Append("       <td align='center' width='30px'>" & vVeryGood_Customer_Service & "</td>")
                            tmpDataRow.Append("       <td align='center' width='30px'>" & Math.Round(vVeryGoodP_Customer_Service, MidpointRounding.AwayFromZero) & "%</td>")
                            tmpDataRow.Append("       <td align='center' width='30px'>" & vGood_Customer_Service & "</td>")
                            tmpDataRow.Append("       <td align='center' width='30px'>" & Math.Round(vGoodP_Customer_Service, MidpointRounding.AwayFromZero) & "%</td>")
                            tmpDataRow.Append("       <td align='center' width='50px'>" & vAdjust_Customer_Service & "</td>")
                            tmpDataRow.Append("       <td align='center' width='80px'>" & Math.Round(vAdjustP_Customer_Service, MidpointRounding.AwayFromZero) & "%</td>")
                            tmpDataRow.Append("       <td align='center' width='120px'>" & Math.Ceiling(vTotalP_Customer_Service) & "%</td>")

                            TotVeryGood_Customer_Service += vVeryGood_Customer_Service
                            TotGood_Customer_Service += vGood_Customer_Service
                            TotAdjust_Customer_Service += vAdjust_Customer_Service
                            TotTotal_Customer_Service += vTotal_Customer_Service

                            GTotVeryGood_Customer_Service += vVeryGood_Customer_Service
                            GTotGood_Customer_Service += vGood_Customer_Service
                            GTotAdjust_Customer_Service += vAdjust_Customer_Service
                            GTotTotal_Customer_Service += vTotal_Customer_Service
                            '## Clear ค่า ###
                            vVeryGood_Customer_Service = 0
                            vGood_Customer_Service = 0
                            vAdjust_Customer_Service = 0
                            vTotal_Customer_Service = 0
                            '##############
                        Else
                            tmpDataRow.Append("       <td align='center' width='30px'></td>")
                            tmpDataRow.Append("       <td align='center' width='30px'></td>")
                            tmpDataRow.Append("       <td align='center' width='30px'></td>")
                            tmpDataRow.Append("       <td align='center' width='30px'></td>")
                            tmpDataRow.Append("       <td align='center' width='50px'></td>")
                            tmpDataRow.Append("       <td align='center' width='80px'></td>")
                            tmpDataRow.Append("       <td align='center' width='120px'></td>")
                        End If
                        '##############################



                    Next
                    shDt.DefaultView.RowFilter = ""




                    '#### Total by Region
                    tmpDataRow.Append("    <tr style='background: yellowgreen repeat-x top;font-weight: bold;'>")
                    tmpDataRow.Append("         <td colspan='2' align='Center' >Total " & reDr("region_name_en") & "</td>")
                    Dim i As Integer = 0
                    CurrMonth = DateFrom

                    Do
                        Dim StartDate As Date = IIf(CurrMonth = DateFrom, DateFrom, New Date(CurrMonth.Year, CurrMonth.Month, 1))
                        Dim EndDate As Date = IIf(CurrMonth.ToString("MMyyyy") = DateTo.ToString("MMyyyy"), DateTo, New Date(CurrMonth.Year, CurrMonth.Month, CurrMonth.DaysInMonth(CurrMonth.Year, CurrMonth.Month)))
                        For Each sDr As DataRow In sDt.Rows
                            Dim TotVeryGoodP As Double = 0
                            Dim TotGoodP As Double = 0
                            Dim TotAdjustP As Double = 0
                            Dim TotTotalP As Double = 0
                            If TotTotal(i) <> 0 Then
                                TotVeryGoodP = (TotVeryGood(i) * 100) / TotTotal(i)
                                TotGoodP = (TotGood(i) * 100) / TotTotal(i)
                                TotAdjustP = (TotAdjust(i) * 100) / TotTotal(i)
                                TotTotalP = (((TotVeryGood(i) + (TotGood(i) / 2)) * 100) / TotTotal(i))
                            End If

                            tmpDataRow.Append("       <td align='center' width='30px'>" & TotVeryGood(i) & "</td>")
                            tmpDataRow.Append("       <td align='center' width='30px'>" & Math.Round(TotVeryGoodP, MidpointRounding.AwayFromZero) & "%</td>")
                            tmpDataRow.Append("       <td align='center' width='30px'>" & TotGood(i) & "</td>")
                            tmpDataRow.Append("       <td align='center' width='30px'>" & Math.Round(TotGoodP, MidpointRounding.AwayFromZero) & "%</td>")
                            tmpDataRow.Append("       <td align='center' width='50px'>" & TotAdjust(i) & "</td>")
                            tmpDataRow.Append("       <td align='center' width='80px'>" & Math.Round(TotAdjustP, MidpointRounding.AwayFromZero) & "%</td>")
                            tmpDataRow.Append("       <td align='center' width='120px'>" & Math.Ceiling(TotTotalP) & "%</td>")
                            i += 1
                        Next
                        CurrMonth = DateAdd(DateInterval.Month, 1, CurrMonth)
                    Loop While CurrMonth.ToString("yyyyMM") <= DateTo.ToString("yyyyMM")

                    '### ตั้มเพิ่ม นำค่า Toal ที่เก็ยไว้มาแสดง ######
                    'Overall
                    Dim TotVeryGoodP_Overall As Double = 0
                    Dim TotGoodP_Overall As Double = 0
                    Dim TotAdjustP_Overall As Double = 0
                    Dim TotTotalP_Overall As Double = 0
                    If TotTotal_Overall <> 0 Then
                        TotVeryGoodP_Overall = (TotVeryGood_Overall * 100) / TotTotal_Overall
                        TotGoodP_Overall = (TotGood_Overall * 100) / TotTotal_Overall
                        TotAdjustP_Overall = (TotAdjust_Overall * 100) / TotTotal_Overall
                        TotTotalP_Overall = (((TotVeryGood_Overall + (TotGood_Overall / 2)) * 100) / TotTotal_Overall)
                    End If
                    tmpDataRow.Append("       <td align='center' width='30px'>" & TotVeryGood_Overall & "</td>")
                    tmpDataRow.Append("       <td align='center' width='30px'>" & Math.Round(TotVeryGoodP_Overall, MidpointRounding.AwayFromZero) & "%</td>")
                    tmpDataRow.Append("       <td align='center' width='30px'>" & TotGood_Overall & "</td>")
                    tmpDataRow.Append("       <td align='center' width='30px'>" & Math.Round(TotGoodP_Overall, MidpointRounding.AwayFromZero) & "%</td>")
                    tmpDataRow.Append("       <td align='center' width='50px'>" & TotAdjust_Overall & "</td>")
                    tmpDataRow.Append("       <td align='center' width='80px'>" & Math.Round(TotAdjustP_Overall, MidpointRounding.AwayFromZero) & "%</td>")
                    tmpDataRow.Append("       <td align='center' width='120px'>" & Math.Ceiling(TotTotalP_Overall) & "%</td>")
                    'Customer Service
                    Dim TotVeryGoodP_Customer_Service As Double = 0
                    Dim TotGoodP_Customer_Service As Double = 0
                    Dim TotAdjustP_Customer_Service As Double = 0
                    Dim TotTotalP_Customer_Service As Double = 0
                    If TotTotal_Customer_Service <> 0 Then
                        TotVeryGoodP_Customer_Service = (TotVeryGood_Customer_Service * 100) / TotTotal_Customer_Service
                        TotGoodP_Customer_Service = (TotGood_Customer_Service * 100) / TotTotal_Customer_Service
                        TotAdjustP_Customer_Service = (TotAdjust_Customer_Service * 100) / TotTotal_Customer_Service
                        TotTotalP_Customer_Service = (((TotVeryGood_Customer_Service + (TotGood_Customer_Service / 2)) * 100) / TotTotal_Customer_Service)
                    End If
                    tmpDataRow.Append("       <td align='center' width='30px'>" & TotVeryGood_Customer_Service & "</td>")
                    tmpDataRow.Append("       <td align='center' width='30px'>" & Math.Round(TotVeryGoodP_Customer_Service, MidpointRounding.AwayFromZero) & "%</td>")
                    tmpDataRow.Append("       <td align='center' width='30px'>" & TotGood_Customer_Service & "</td>")
                    tmpDataRow.Append("       <td align='center' width='30px'>" & Math.Round(TotGoodP_Customer_Service, MidpointRounding.AwayFromZero) & "%</td>")
                    tmpDataRow.Append("       <td align='center' width='50px'>" & TotAdjust_Customer_Service & "</td>")
                    tmpDataRow.Append("       <td align='center' width='80px'>" & Math.Round(TotAdjustP_Customer_Service, MidpointRounding.AwayFromZero) & "%</td>")
                    tmpDataRow.Append("       <td align='center' width='120px'>" & Math.Ceiling(TotTotalP_Customer_Service) & "%</td>")

                    '############################


                    tmpDataRow.Append("</tr>")
                Next


                '#### Grand Total
                tmpDataRow.Append("<tr style='background: Orange repeat-x top;font-weight: bold;'>")
                tmpDataRow.Append("       <td colspan='2' align='Center' >Grand Total</td>")
                CurrMonth = DateFrom
                Dim m As Integer = 0
                Do
                    Dim StartDate As Date = IIf(CurrMonth = DateFrom, DateFrom, New Date(CurrMonth.Year, CurrMonth.Month, 1))
                    Dim EndDate As Date = IIf(CurrMonth.ToString("MMyyyy") = DateTo.ToString("MMyyyy"), DateTo, New Date(CurrMonth.Year, CurrMonth.Month, CurrMonth.DaysInMonth(CurrMonth.Year, CurrMonth.Month)))
                    For Each sDr As DataRow In sDt.Rows
                        Dim GTotVeryGoodP As Double = 0
                        Dim GTotGoodP As Double = 0
                        Dim GTotAdjustP As Double = 0
                        Dim GTotTotalP As Double = 0
                        If GTotTotal(m) <> 0 Then
                            GTotVeryGoodP = (GTotVeryGood(m) * 100) / GTotTotal(m)
                            GTotGoodP = (GTotGood(m) * 100) / GTotTotal(m)
                            GTotAdjustP = (GTotAdjust(m) * 100) / GTotTotal(m)
                            GTotTotalP = (((GTotVeryGood(m) + (GTotGood(m) / 2)) * 100) / GTotTotal(m))
                        End If

                        tmpDataRow.Append("       <td align='center' >" & GTotVeryGood(m) & "</td>")
                        tmpDataRow.Append("       <td align='center' >" & Math.Round(GTotVeryGoodP, MidpointRounding.AwayFromZero) & "%</td>")
                        tmpDataRow.Append("       <td align='center' >" & GTotGood(m) & "</td>")
                        tmpDataRow.Append("       <td align='center' >" & Math.Round(GTotGoodP, MidpointRounding.AwayFromZero) & "%</td>")
                        tmpDataRow.Append("       <td align='center' >" & GTotAdjust(m) & "</td>")
                        tmpDataRow.Append("       <td align='center' >" & Math.Round(GTotAdjustP, MidpointRounding.AwayFromZero) & "%</td>")
                        tmpDataRow.Append("       <td align='center' >" & Math.Ceiling(GTotTotalP) & "%</td>")
                        m += 1
                    Next
                    CurrMonth = DateAdd(DateInterval.Month, 1, CurrMonth)
                Loop While CurrMonth.ToString("yyyyMM") <= DateTo.ToString("yyyyMM")

                '### ตั้มเพิ่ม นำค่า GrandToal ที่เก็ยไว้มาแสดง ######
                'Overall
                Dim GTotVeryGoodP_Overall As Double = 0
                Dim GTotGoodP_Overall As Double = 0
                Dim GTotAdjustP_Overall As Double = 0
                Dim GTotTotalP_Overall As Double = 0
                If GTotTotal_Overall <> 0 Then
                    GTotVeryGoodP_Overall = (GTotVeryGood_Overall * 100) / GTotTotal_Overall
                    GTotGoodP_Overall = (GTotGood_Overall * 100) / GTotTotal_Overall
                    GTotAdjustP_Overall = (GTotAdjust_Overall * 100) / GTotTotal_Overall
                    GTotTotalP_Overall = (((GTotVeryGood_Overall + (GTotGood_Overall / 2)) * 100) / GTotTotal_Overall)
                End If
                tmpDataRow.Append("       <td align='center' >" & GTotVeryGood_Overall & "</td>")
                tmpDataRow.Append("       <td align='center' >" & Math.Round(GTotVeryGoodP_Overall, MidpointRounding.AwayFromZero) & "%</td>")
                tmpDataRow.Append("       <td align='center' >" & GTotGood_Overall & "</td>")
                tmpDataRow.Append("       <td align='center' >" & Math.Round(GTotGoodP_Overall, MidpointRounding.AwayFromZero) & "%</td>")
                tmpDataRow.Append("       <td align='center' >" & GTotAdjust_Overall & "</td>")
                tmpDataRow.Append("       <td align='center' >" & Math.Round(GTotAdjustP_Overall, MidpointRounding.AwayFromZero) & "%</td>")
                tmpDataRow.Append("       <td align='center' >" & Math.Ceiling(GTotTotalP_Overall) & "%</td>")
                'Customer Service
                Dim GTotVeryGoodP_Customer_Service As Double = 0
                Dim GTotGoodP_Customer_Service As Double = 0
                Dim GTotAdjustP_Customer_Service As Double = 0
                Dim GTotTotalP_Customer_Service As Double = 0
                If GTotTotal_Customer_Service <> 0 Then
                    GTotVeryGoodP_Customer_Service = (GTotVeryGood_Customer_Service * 100) / GTotTotal_Customer_Service
                    GTotGoodP_Customer_Service = (GTotGood_Customer_Service * 100) / GTotTotal_Customer_Service
                    GTotAdjustP_Customer_Service = (GTotAdjust_Customer_Service * 100) / GTotTotal_Customer_Service
                    GTotTotalP_Customer_Service = (((GTotVeryGood_Customer_Service + (GTotGood_Customer_Service / 2)) * 100) / GTotTotal_Customer_Service)
                End If
                tmpDataRow.Append("       <td align='center' >" & GTotVeryGood_Customer_Service & "</td>")
                tmpDataRow.Append("       <td align='center' >" & Math.Round(GTotVeryGoodP_Customer_Service, MidpointRounding.AwayFromZero) & "%</td>")
                tmpDataRow.Append("       <td align='center' >" & GTotGood_Customer_Service & "</td>")
                tmpDataRow.Append("       <td align='center' >" & Math.Round(GTotGoodP_Customer_Service, MidpointRounding.AwayFromZero) & "%</td>")
                tmpDataRow.Append("       <td align='center' >" & GTotAdjust_Customer_Service & "</td>")
                tmpDataRow.Append("       <td align='center' >" & Math.Round(GTotAdjustP_Customer_Service, MidpointRounding.AwayFromZero) & "%</td>")
                tmpDataRow.Append("       <td align='center' >" & Math.Ceiling(GTotTotalP_Customer_Service) & "%</td>")
                '######################################

                tmpDataRow.Append("</tr>")
            End If


            ret.Append("    <tr >" & tmpHRow & "</tr>")
            ret.Append("    <tr style='background: yellowgreen repeat-x top;font-weight: bold;'>" & tmpSRow & "</tr>")
            ret.Append("    <tr style='background: yellowgreen repeat-x top;font-weight: bold;'>" & tmpReRow & "</tr>")
            ret.Append(tmpDataRow)
            ret.Append("</table>")
            lblReportDesc.Text = ret.ToString

            ret = Nothing
            sDt = Nothing
        End If

        If lblReportDesc.Text <> "" Then
            lblerror.Visible = False
            'lblRowCount.Text = "ค้นพบ " & dt.Rows.Count & " รายการ"
        End If
    End Sub

    Private Sub SearchCSIByAgentData()
        Dim sEng As New Engine.Configuration.MasterENG
        Dim sDt As New DataTable
        Dim sWh As String = " 1 = 1 "
        If Request("ServiceID") IsNot Nothing Then
            sWh += " and id= '" & Request("ServiceID") & "'"
        End If

        sDt = sEng.GetServiceActiveList(sWh)
        Dim shWh As String = " 1=1 "
        If Request("ShopID") IsNot Nothing Then
            shWh += " and sh.id = '" & Request("ShopID") & "'"
        End If
        Dim shDt As New DataTable
        Dim shEng As New Engine.Configuration.MasterENG
        shDt = shEng.GetShopList(shWh)

        If sDt.Rows.Count > 0 Then
            Dim ret As New StringBuilder
            Dim ServQty As Long = sDt.Rows.Count    'จำนวน Service +2(คือ Overall และ Customer Service)
            ret.Append("<table border='1' cellspacing='0' cellpadding='0' width='2000px' class='mGrid' >")

            'สร้างชื่อคอลัมน์ก่อน
            Dim DateFrom As Date = CDate(Request("DateFrom"))
            Dim DateTo As Date = CDate(Request("DateTo"))
            Dim CurrMonth As Date = DateFrom
            Dim tmpHRow As String = "        <td colspan='3'>&nbsp;</td>"
            Dim tmpSRow As String = "        <td colspan='3'>&nbsp;</td>"
            Dim tmpReRow As String = ""
            tmpReRow += "       <td align='center' style='color: #ffffff;' width='50px' >Location Code</td>"
            tmpReRow += "       <td align='center' style='color: #ffffff;' width='250px' >Location Name</td>"
            tmpReRow += "       <td align='center' style='color: #ffffff;' width='250px' >Agent</td>"

            Do
                Dim StartDate As Date = IIf(CurrMonth = DateFrom, DateFrom, New Date(CurrMonth.Year, CurrMonth.Month, 1))
                Dim EndDate As Date = IIf(CurrMonth.ToString("MMyyyy") = DateTo.ToString("MMyyyy"), DateTo, New Date(CurrMonth.Year, CurrMonth.Month, CurrMonth.DaysInMonth(CurrMonth.Year, CurrMonth.Month)))
                tmpHRow += "        <td colspan='" & (ServQty * 7) & "' align='center' >&nbsp;" & CurrMonth.ToString("MMMM yyyy", New CultureInfo("en-US")) & "</td>"
                For Each sDr As DataRow In sDt.Rows
                    tmpSRow += "        <td align='center' colspan='7' style='color: #ffffff;' >" & sDr("item_name") & "</td>"

                    tmpReRow += "       <td align='center' colspan='2' style='color: #ffffff;' >ดีมาก</td>"
                    tmpReRow += "       <td align='center' colspan='2' style='color: #ffffff;' >ดี</td>"
                    tmpReRow += "       <td align='center' colspan='2' style='color: #ffffff;' >ควรปรับปรุง</td>"
                    tmpReRow += "       <td align='center' style='color: #ffffff;' >%CSI <br />" & sDr("item_name") & "</td>"
                Next
                CurrMonth = DateAdd(DateInterval.Month, 1, CurrMonth)
            Loop While CurrMonth.ToString("yyyyMM") <= DateTo.ToString("yyyyMM")
            '#### ตั้ม เพิ่ม Header ####
            'Overall

            tmpHRow += "        <td  rowspan='1' colspan='" & (ServQty * 7) & "'align='center'  ></td>"
            tmpSRow += "        <td align='center' colspan='7' style='color: #ffffff;' >Overall</td>"
            tmpReRow += "       <td align='center' colspan='2' style='color: #ffffff;' >ดีมาก</td>"
            tmpReRow += "       <td align='center' colspan='2' style='color: #ffffff;' >ดี</td>"
            tmpReRow += "       <td align='center' colspan='2' style='color: #ffffff;' >ควรปรับปรุง</td>"
            tmpReRow += "       <td align='center' style='color: #ffffff;' >%CSI <br />Overall</td>"

            ''Customer Service
            tmpSRow += "        <td align='center' colspan='7' style='color: #ffffff;' >Customer Service (Include SIM Change & Upgrade to AIS 3G)</td>"
            tmpReRow += "       <td align='center' colspan='2' style='color: #ffffff;' >ดีมาก</td>"
            tmpReRow += "       <td align='center' colspan='2' style='color: #ffffff;' >ดี</td>"
            tmpReRow += "       <td align='center' colspan='2' style='color: #ffffff;' >ควรปรับปรุง</td>"
            tmpReRow += "       <td align='center' style='color: #ffffff;' >%CSI <br />Customer Service</td>"
            ''####################


            Dim tmpDataRow As New StringBuilder

            Dim reDt As New DataTable
            reDt = shDt.DefaultView.ToTable(True, "region_id", "region_name_en").Copy
            If reDt.Rows.Count > 0 Then
                Dim GTotVeryGood(sDt.Rows.Count * (DateDiff(DateInterval.Month, DateFrom, DateTo) + 1)) As Double
                Dim GTotGood(sDt.Rows.Count * (DateDiff(DateInterval.Month, DateFrom, DateTo) + 1)) As Double
                Dim GTotAdjust(sDt.Rows.Count * (DateDiff(DateInterval.Month, DateFrom, DateTo) + 1)) As Double
                Dim GTotTotal(sDt.Rows.Count * (DateDiff(DateInterval.Month, DateFrom, DateTo) + 1)) As Double
                '### ตั้มเพิ่ม ไว้เก็บค่า Grand Total ######
                'Customer Service
                Dim GTotVeryGood_Customer_Service As Double
                Dim GTotGood_Customer_Service As Double
                Dim GTotAdjust_Customer_Service As Double
                Dim GTotTotal_Customer_Service As Double
                'Overall
                Dim GTotVeryGood_Overall As Double
                Dim GTotGood_Overall As Double
                Dim GTotAdjust_Overall As Double
                Dim GTotTotal_Overall As Double
                '##################################

                For Each reDr As DataRow In reDt.Rows     'Loop by Region
                    Dim TotVeryGood(sDt.Rows.Count * (DateDiff(DateInterval.Month, DateFrom, DateTo) + 1)) As Double
                    Dim TotGood(sDt.Rows.Count * (DateDiff(DateInterval.Month, DateFrom, DateTo) + 1)) As Double
                    Dim TotAdjust(sDt.Rows.Count * (DateDiff(DateInterval.Month, DateFrom, DateTo) + 1)) As Double
                    Dim TotTotal(sDt.Rows.Count * (DateDiff(DateInterval.Month, DateFrom, DateTo) + 1)) As Double
                    '### ตั้มเพิ่ม ไว้เก็บค่า Total และ Clear ค่า ######
                    'Customer Service
                    Dim TotVeryGood_Customer_Service As Double = 0
                    Dim TotGood_Customer_Service As Double = 0
                    Dim TotAdjust_Customer_Service As Double = 0
                    Dim TotTotal_Customer_Service As Double = 0
                    'Over all
                    Dim TotVeryGood_Overall As Double = 0
                    Dim TotGood_Overall As Double = 0
                    Dim TotAdjust_Overall As Double = 0
                    Dim TotTotal_Overall As Double = 0

                    'Customer Service
                    Dim vVeryGood_Customer_Service As Double = 0
                    Dim vGood_Customer_Service As Double = 0
                    Dim vAdjust_Customer_Service As Double = 0
                    Dim vTotal_Customer_Service As Double = 0
                    'Overall
                    Dim vVeryGood_Overall As Double = 0
                    Dim vGood_Overall As Double = 0
                    Dim vAdjust_Overall As Double = 0
                    Dim vTotal_Overall As Double = 0
                    '##################################




                    shDt.DefaultView.RowFilter = "region_id='" & reDr("region_id") & "'"
                    For Each shDr As DataRowView In shDt.DefaultView

                        Dim userDT As New DataTable
                        Dim UserEng As New Engine.Configuration.ShopUserENG
                        Dim pUsername As String = ""
                        If Request("ShopUserName") IsNot Nothing Then
                            pUsername = Request("ShopUserName")
                        End If
                        userDT = UserEng.GetShopUserByUserName(shDr("id"), pUsername)

                        For Each uDr As DataRow In userDT.Rows
                            tmpDataRow.Append("     <tr style='background-color:white' >")
                            tmpDataRow.Append("         <td width='50px'>" & shDr("shop_code") & "</td>")
                            tmpDataRow.Append("         <td width='150px'>" & shDr("shop_name_en") & "</td>")
                            tmpDataRow.Append("         <td width='150px'>" & uDr("username") & "</td>")

                            Dim s As Integer = 0
                            Dim tt As Integer = 0
                            CurrMonth = DateFrom


                            Do
                                Dim StartDate As Date = IIf(CurrMonth = DateFrom, DateFrom, New Date(CurrMonth.Year, CurrMonth.Month, 1))
                                Dim EndDate As Date = IIf(CurrMonth.ToString("MMyyyy") = DateTo.ToString("MMyyyy"), DateTo, New Date(CurrMonth.Year, CurrMonth.Month, CurrMonth.DaysInMonth(CurrMonth.Year, CurrMonth.Month)))

                                For Each sDr As DataRow In sDt.Rows
                                    Dim whText As String = " convert(varchar(8),fd.send_time, 112) between '" & StartDate.ToString("yyyyMMdd", New CultureInfo("en-US")) & "' and '" & EndDate.ToString("yyyyMMdd", New CultureInfo("en-US")) & "'"
                                    whText += " and fd.tb_item_id = '" & sDr("id") & "'"
                                    whText += " and fd.shop_id = '" & shDr("id") & "'"
                                    If Request("TemplateID") IsNot Nothing Then
                                        whText += " and fd.tb_filter_id in (" & Request("TemplateID") & ")"
                                    End If
                                    'If Request("ShopUserName") IsNot Nothing Then
                                    whText += " and fd.username='" & uDr("username") & "'"
                                    'End If
                                    If Request("Status") IsNot Nothing Then
                                        Dim tmpSt() As String = Split(Request("Status"), ",")
                                        Dim tmp As String = ""
                                        For Each t As String In tmpSt
                                            If tmp = "" Then
                                                tmp = "'" & t & "'"
                                            Else
                                                tmp += ",'" & t & "'"
                                            End If
                                        Next
                                        whText += " and fd.result_status in (" & tmp & ")"
                                    End If

                                    If Request("NetworkType") IsNot Nothing Then
                                        whText += " and fd.network_type ='" & Request("NetworkType") & "'"
                                    End If

                                    Dim eng As New Engine.CSI.CSIReportsENG
                                    Dim dt As New DataTable
                                    dt = eng.GetCSIByAgentDataList(whText)
                                    If dt.Rows.Count > 0 Then
                                        'For cnt As Integer = 0 To dt.Rows.Count - 1

                                        Dim tmpShop As String = ""
                                        Dim dr As DataRow = dt.Rows(0)
                                        Dim vVeryGood As Double = Convert.ToDouble(dr("result_very_good"))
                                        Dim vGood As Double = Convert.ToDouble(dr("result_good"))
                                        Dim vAdjust As Double = Convert.ToDouble(dr("result_adjust"))
                                        Dim vTotal As Double = vVeryGood + vGood + vAdjust

                                        '### ตั้มเพิ่ม ไว้เก็บค่า Detail ไว้แสดง ######
                                        'Customer Service
                                        If sDr("id") = 6 Or sDr("id") = 8 Or sDr("id") = 2 Then '2 Customer Service,6 SimChage,8 Upgrad To 3g
                                            vVeryGood_Customer_Service += Convert.ToDouble(dr("result_very_good"))
                                            vGood_Customer_Service += Convert.ToDouble(dr("result_good"))
                                            vAdjust_Customer_Service += Convert.ToDouble(dr("result_adjust"))
                                            ' vTotal_Customer_Service += vVeryGood_Customer_Service + vGood_Customer_Service + vAdjust_Customer_Service
                                            vTotal_Customer_Service += Convert.ToDouble(dr("result_very_good")) + Convert.ToDouble(dr("result_good")) + Convert.ToDouble(dr("result_adjust"))
                                        End If
                                        'Overall
                                        vVeryGood_Overall += Convert.ToDouble(dr("result_very_good"))
                                        vGood_Overall += Convert.ToDouble(dr("result_good"))
                                        vAdjust_Overall += Convert.ToDouble(dr("result_adjust"))
                                        'vTotal_Overall += vVeryGood_Overall + vGood_Overall + vAdjust_Overall
                                        vTotal_Overall += Convert.ToDouble(dr("result_very_good")) + Convert.ToDouble(dr("result_good")) + Convert.ToDouble(dr("result_adjust"))
                                        '### ตั้มเพิ่ม ไว้เก็บค่า Detail ไว้แสดง ######

                                        Dim vVeryGoodP As Double = 0
                                        Dim vGoodP As Double = 0
                                        Dim vAdjustP As Double = 0
                                        Dim vTotalP As Double = 0
                                        If vTotal <> 0 Then
                                            vVeryGoodP = ((vVeryGood * 100) / vTotal)
                                            vGoodP = ((vGood * 100) / vTotal)
                                            vAdjustP = ((vAdjust * 100) / vTotal)
                                            vTotalP = (((vVeryGood + (vGood / 2)) * 100) / vTotal)
                                        End If
                                        tmpDataRow.Append("       <td align='center' width='30px'>" & vVeryGood & "</td>")
                                        tmpDataRow.Append("       <td align='center' width='30px'>" & Math.Round(vVeryGoodP, MidpointRounding.AwayFromZero) & "%</td>")
                                        tmpDataRow.Append("       <td align='center' width='30px'>" & vGood & "</td>")
                                        tmpDataRow.Append("       <td align='center' width='30px'>" & Math.Round(vGoodP, MidpointRounding.AwayFromZero) & "%</td>")
                                        tmpDataRow.Append("       <td align='center' width='50px'>" & vAdjust & "</td>")
                                        tmpDataRow.Append("       <td align='center' width='80px'>" & Math.Round(vAdjustP, MidpointRounding.AwayFromZero) & "%</td>")
                                        tmpDataRow.Append("       <td align='center' width='120px'>" & Math.Ceiling(vTotalP) & "%</td>")


                                        TotVeryGood(s) += vVeryGood
                                        TotGood(s) += vGood
                                        TotAdjust(s) += vAdjust
                                        TotTotal(s) += vTotal

                                        GTotVeryGood(tt) += vVeryGood
                                        GTotGood(tt) += vGood
                                        GTotAdjust(tt) += vAdjust
                                        GTotTotal(tt) += vTotal
                                        'Next
                                        dt.Dispose()




                                    Else
                                        tmpDataRow.Append("       <td align='center' width='30px'></td>")
                                        tmpDataRow.Append("       <td align='center' width='30px'></td>")
                                        tmpDataRow.Append("       <td align='center' width='30px'></td>")
                                        tmpDataRow.Append("       <td align='center' width='30px'></td>")
                                        tmpDataRow.Append("       <td align='center' width='50px'></td>")
                                        tmpDataRow.Append("       <td align='center' width='80px'></td>")
                                        tmpDataRow.Append("       <td align='center' width='120px'></td>")
                                    End If
                                    s += 1
                                    tt += 1


                                Next
                                CurrMonth = DateAdd(DateInterval.Month, 1, CurrMonth)
                            Loop While CurrMonth.ToString("yyyyMM") <= DateTo.ToString("yyyyMM")




                            '### ตั้มเพิ่ม นำค่า Detail ที่เก็บไว้มาแสดง ######
                            'Overall
                            Dim vVeryGoodP_Overall As Double = 0
                            Dim vGoodP_Overall As Double = 0
                            Dim vAdjustP_Overall As Double = 0
                            Dim vTotalP_Overall As Double = 0


                            If vTotal_Overall <> 0 Then
                                vVeryGoodP_Overall = ((vVeryGood_Overall * 100) / vTotal_Overall)
                                vGoodP_Overall = ((vGood_Overall * 100) / vTotal_Overall)
                                vAdjustP_Overall = ((vAdjust_Overall * 100) / vTotal_Overall)
                                vTotalP_Overall = (((vVeryGood_Overall + (vGood_Overall / 2)) * 100) / vTotal_Overall)
                            End If

                            If vTotal_Overall <> 0 Then
                                tmpDataRow.Append("       <td align='center' width='30px'>" & vVeryGood_Overall & "</td>")
                                tmpDataRow.Append("       <td align='center' width='30px'>" & Math.Round(vVeryGoodP_Overall, MidpointRounding.AwayFromZero) & "%</td>")
                                tmpDataRow.Append("       <td align='center' width='30px'>" & vGood_Overall & "</td>")
                                tmpDataRow.Append("       <td align='center' width='30px'>" & Math.Round(vGoodP_Overall, MidpointRounding.AwayFromZero) & "%</td>")
                                tmpDataRow.Append("       <td align='center' width='50px'>" & vAdjust_Overall & "</td>")
                                tmpDataRow.Append("       <td align='center' width='80px'>" & Math.Round(vAdjustP_Overall, MidpointRounding.AwayFromZero) & "%</td>")
                                tmpDataRow.Append("       <td align='center' width='120px'>" & Math.Ceiling(vTotalP_Overall) & "%</td>")

                                TotVeryGood_Overall += vVeryGood_Overall
                                TotGood_Overall += vGood_Overall
                                TotAdjust_Overall += vAdjust_Overall
                                TotTotal_Overall += vTotal_Overall

                                GTotVeryGood_Overall += vVeryGood_Overall
                                GTotGood_Overall += vGood_Overall
                                GTotAdjust_Overall += vAdjust_Overall
                                GTotTotal_Overall += vTotal_Overall
                                '## Clear ค่า ###
                                vVeryGood_Overall = 0
                                vGood_Overall = 0
                                vAdjust_Overall = 0
                                vTotal_Overall = 0
                                '##############
                            Else
                                tmpDataRow.Append("       <td align='center' width='30px'></td>")
                                tmpDataRow.Append("       <td align='center' width='30px'></td>")
                                tmpDataRow.Append("       <td align='center' width='30px'></td>")
                                tmpDataRow.Append("       <td align='center' width='30px'></td>")
                                tmpDataRow.Append("       <td align='center' width='50px'></td>")
                                tmpDataRow.Append("       <td align='center' width='80px'></td>")
                                tmpDataRow.Append("       <td align='center' width='120px'></td>")
                            End If

                            'customer service
                            Dim vVeryGoodP_Customer_Service As Double = 0
                            Dim vGoodP_Customer_Service As Double = 0
                            Dim vAdjustP_Customer_Service As Double = 0
                            Dim vTotalP_Customer_Service As Double = 0

                            If vTotal_Customer_Service <> 0 Then
                                vVeryGoodP_Customer_Service = ((vVeryGood_Customer_Service * 100) / vTotal_Customer_Service)
                                vGoodP_Customer_Service = ((vGood_Customer_Service * 100) / vTotal_Customer_Service)
                                vAdjustP_Customer_Service = ((vAdjust_Customer_Service * 100) / vTotal_Customer_Service)
                                vTotalP_Customer_Service = (((vVeryGood_Customer_Service + (vGood_Customer_Service / 2)) * 100) / vTotal_Customer_Service)
                            End If

                            If vTotal_Customer_Service <> 0 Then
                                tmpDataRow.Append("       <td align='center' width='30px'>" & vVeryGood_Customer_Service & "</td>")
                                tmpDataRow.Append("       <td align='center' width='30px'>" & Math.Round(vVeryGoodP_Customer_Service, MidpointRounding.AwayFromZero) & "%</td>")
                                tmpDataRow.Append("       <td align='center' width='30px'>" & vGood_Customer_Service & "</td>")
                                tmpDataRow.Append("       <td align='center' width='30px'>" & Math.Round(vGoodP_Customer_Service, MidpointRounding.AwayFromZero) & "%</td>")
                                tmpDataRow.Append("       <td align='center' width='50px'>" & vAdjust_Customer_Service & "</td>")
                                tmpDataRow.Append("       <td align='center' width='80px'>" & Math.Round(vAdjustP_Customer_Service, MidpointRounding.AwayFromZero) & "%</td>")
                                tmpDataRow.Append("       <td align='center' width='120px'>" & Math.Ceiling(vTotalP_Customer_Service) & "%</td>")

                                TotVeryGood_Customer_Service += vVeryGood_Customer_Service
                                TotGood_Customer_Service += vGood_Customer_Service
                                TotAdjust_Customer_Service += vAdjust_Customer_Service
                                TotTotal_Customer_Service += vTotal_Customer_Service

                                GTotVeryGood_Customer_Service += vVeryGood_Customer_Service
                                GTotGood_Customer_Service += vGood_Customer_Service
                                GTotAdjust_Customer_Service += vAdjust_Customer_Service
                                GTotTotal_Customer_Service += vTotal_Customer_Service
                                '## Clear ค่า ###
                                vVeryGood_Customer_Service = 0
                                vGood_Customer_Service = 0
                                vAdjust_Customer_Service = 0
                                vTotal_Customer_Service = 0
                                '##############
                            Else
                                tmpDataRow.Append("       <td align='center' width='30px'></td>")
                                tmpDataRow.Append("       <td align='center' width='30px'></td>")
                                tmpDataRow.Append("       <td align='center' width='30px'></td>")
                                tmpDataRow.Append("       <td align='center' width='30px'></td>")
                                tmpDataRow.Append("       <td align='center' width='50px'></td>")
                                tmpDataRow.Append("       <td align='center' width='80px'></td>")
                                tmpDataRow.Append("       <td align='center' width='120px'></td>")
                            End If
                            '##############################



                        Next
                        shDt.DefaultView.RowFilter = ""


                            tmpDataRow.Append("</tr>")


                        Next



                    '#### Total by Region
                    tmpDataRow.Append("    <tr style='background: yellowgreen repeat-x top;font-weight: bold;'>")
                    tmpDataRow.Append("         <td colspan='3' align='Center' >Total " & reDr("region_name_en") & "</td>")
                    Dim i As Integer = 0
                    CurrMonth = DateFrom

                    Do
                        Dim StartDate As Date = IIf(CurrMonth = DateFrom, DateFrom, New Date(CurrMonth.Year, CurrMonth.Month, 1))
                        Dim EndDate As Date = IIf(CurrMonth.ToString("MMyyyy") = DateTo.ToString("MMyyyy"), DateTo, New Date(CurrMonth.Year, CurrMonth.Month, CurrMonth.DaysInMonth(CurrMonth.Year, CurrMonth.Month)))
                        For Each sDr As DataRow In sDt.Rows
                            Dim TotVeryGoodP As Double = 0
                            Dim TotGoodP As Double = 0
                            Dim TotAdjustP As Double = 0
                            Dim TotTotalP As Double = 0
                            If TotTotal(i) <> 0 Then
                                TotVeryGoodP = (TotVeryGood(i) * 100) / TotTotal(i)
                                TotGoodP = (TotGood(i) * 100) / TotTotal(i)
                                TotAdjustP = (TotAdjust(i) * 100) / TotTotal(i)
                                TotTotalP = (((TotVeryGood(i) + (TotGood(i) / 2)) * 100) / TotTotal(i))
                            End If

                            tmpDataRow.Append("       <td align='center' width='30px'>" & TotVeryGood(i) & "</td>")
                            tmpDataRow.Append("       <td align='center' width='30px'>" & Math.Round(TotVeryGoodP, MidpointRounding.AwayFromZero) & "%</td>")
                            tmpDataRow.Append("       <td align='center' width='30px'>" & TotGood(i) & "</td>")
                            tmpDataRow.Append("       <td align='center' width='30px'>" & Math.Round(TotGoodP, MidpointRounding.AwayFromZero) & "%</td>")
                            tmpDataRow.Append("       <td align='center' width='50px'>" & TotAdjust(i) & "</td>")
                            tmpDataRow.Append("       <td align='center' width='80px'>" & Math.Round(TotAdjustP, MidpointRounding.AwayFromZero) & "%</td>")
                            tmpDataRow.Append("       <td align='center' width='120px'>" & Math.Ceiling(TotTotalP) & "%</td>")
                            i += 1
                        Next
                        CurrMonth = DateAdd(DateInterval.Month, 1, CurrMonth)
                    Loop While CurrMonth.ToString("yyyyMM") <= DateTo.ToString("yyyyMM")

                    '### ตั้มเพิ่ม นำค่า Toal ที่เก็ยไว้มาแสดง ######
                    'Overall
                    Dim TotVeryGoodP_Overall As Double = 0
                    Dim TotGoodP_Overall As Double = 0
                    Dim TotAdjustP_Overall As Double = 0
                    Dim TotTotalP_Overall As Double = 0
                    If TotTotal_Overall <> 0 Then
                        TotVeryGoodP_Overall = (TotVeryGood_Overall * 100) / TotTotal_Overall
                        TotGoodP_Overall = (TotGood_Overall * 100) / TotTotal_Overall
                        TotAdjustP_Overall = (TotAdjust_Overall * 100) / TotTotal_Overall
                        TotTotalP_Overall = (((TotVeryGood_Overall + (TotGood_Overall / 2)) * 100) / TotTotal_Overall)
                    End If
                    tmpDataRow.Append("       <td align='center' width='30px'>" & TotVeryGood_Overall & "</td>")
                    tmpDataRow.Append("       <td align='center' width='30px'>" & Math.Round(TotVeryGoodP_Overall, MidpointRounding.AwayFromZero) & "%</td>")
                    tmpDataRow.Append("       <td align='center' width='30px'>" & TotGood_Overall & "</td>")
                    tmpDataRow.Append("       <td align='center' width='30px'>" & Math.Round(TotGoodP_Overall, MidpointRounding.AwayFromZero) & "%</td>")
                    tmpDataRow.Append("       <td align='center' width='50px'>" & TotAdjust_Overall & "</td>")
                    tmpDataRow.Append("       <td align='center' width='80px'>" & Math.Round(TotAdjustP_Overall, MidpointRounding.AwayFromZero) & "%</td>")
                    tmpDataRow.Append("       <td align='center' width='120px'>" & Math.Ceiling(TotTotalP_Overall) & "%</td>")
                    'Customer Service
                    Dim TotVeryGoodP_Customer_Service As Double = 0
                    Dim TotGoodP_Customer_Service As Double = 0
                    Dim TotAdjustP_Customer_Service As Double = 0
                    Dim TotTotalP_Customer_Service As Double = 0
                    If TotTotal_Customer_Service <> 0 Then
                        TotVeryGoodP_Customer_Service = (TotVeryGood_Customer_Service * 100) / TotTotal_Customer_Service
                        TotGoodP_Customer_Service = (TotGood_Customer_Service * 100) / TotTotal_Customer_Service
                        TotAdjustP_Customer_Service = (TotAdjust_Customer_Service * 100) / TotTotal_Customer_Service
                        TotTotalP_Customer_Service = (((TotVeryGood_Customer_Service + (TotGood_Customer_Service / 2)) * 100) / TotTotal_Customer_Service)
                    End If
                    tmpDataRow.Append("       <td align='center' width='30px'>" & TotVeryGood_Customer_Service & "</td>")
                    tmpDataRow.Append("       <td align='center' width='30px'>" & Math.Round(TotVeryGoodP_Customer_Service, MidpointRounding.AwayFromZero) & "%</td>")
                    tmpDataRow.Append("       <td align='center' width='30px'>" & TotGood_Customer_Service & "</td>")
                    tmpDataRow.Append("       <td align='center' width='30px'>" & Math.Round(TotGoodP_Customer_Service, MidpointRounding.AwayFromZero) & "%</td>")
                    tmpDataRow.Append("       <td align='center' width='50px'>" & TotAdjust_Customer_Service & "</td>")
                    tmpDataRow.Append("       <td align='center' width='80px'>" & Math.Round(TotAdjustP_Customer_Service, MidpointRounding.AwayFromZero) & "%</td>")
                    tmpDataRow.Append("       <td align='center' width='120px'>" & Math.Ceiling(TotTotalP_Customer_Service) & "%</td>")

                    '############################


                    tmpDataRow.Append("</tr>")
                Next


                '#### Grand Total
                tmpDataRow.Append("<tr style='background: Orange repeat-x top;font-weight: bold;'>")
                tmpDataRow.Append("       <td colspan='3' align='Center' >Grand Total</td>")
                CurrMonth = DateFrom
                Dim m As Integer = 0
                Do
                    Dim StartDate As Date = IIf(CurrMonth = DateFrom, DateFrom, New Date(CurrMonth.Year, CurrMonth.Month, 1))
                    Dim EndDate As Date = IIf(CurrMonth.ToString("MMyyyy") = DateTo.ToString("MMyyyy"), DateTo, New Date(CurrMonth.Year, CurrMonth.Month, CurrMonth.DaysInMonth(CurrMonth.Year, CurrMonth.Month)))
                    For Each sDr As DataRow In sDt.Rows
                        Dim GTotVeryGoodP As Double = 0
                        Dim GTotGoodP As Double = 0
                        Dim GTotAdjustP As Double = 0
                        Dim GTotTotalP As Double = 0
                        If GTotTotal(m) <> 0 Then
                            GTotVeryGoodP = (GTotVeryGood(m) * 100) / GTotTotal(m)
                            GTotGoodP = (GTotGood(m) * 100) / GTotTotal(m)
                            GTotAdjustP = (GTotAdjust(m) * 100) / GTotTotal(m)
                            GTotTotalP = (((GTotVeryGood(m) + (GTotGood(m) / 2)) * 100) / GTotTotal(m))
                        End If

                        tmpDataRow.Append("       <td align='center' >" & GTotVeryGood(m) & "</td>")
                        tmpDataRow.Append("       <td align='center' >" & Math.Round(GTotVeryGoodP, MidpointRounding.AwayFromZero) & "%</td>")
                        tmpDataRow.Append("       <td align='center' >" & GTotGood(m) & "</td>")
                        tmpDataRow.Append("       <td align='center' >" & Math.Round(GTotGoodP, MidpointRounding.AwayFromZero) & "%</td>")
                        tmpDataRow.Append("       <td align='center' >" & GTotAdjust(m) & "</td>")
                        tmpDataRow.Append("       <td align='center' >" & Math.Round(GTotAdjustP, MidpointRounding.AwayFromZero) & "%</td>")
                        tmpDataRow.Append("       <td align='center' >" & Math.Ceiling(GTotTotalP) & "%</td>")
                        m += 1
                    Next
                    CurrMonth = DateAdd(DateInterval.Month, 1, CurrMonth)
                Loop While CurrMonth.ToString("yyyyMM") <= DateTo.ToString("yyyyMM")

                '### ตั้มเพิ่ม นำค่า GrandToal ที่เก็ยไว้มาแสดง ######
                'Overall
                Dim GTotVeryGoodP_Overall As Double = 0
                Dim GTotGoodP_Overall As Double = 0
                Dim GTotAdjustP_Overall As Double = 0
                Dim GTotTotalP_Overall As Double = 0
                If GTotTotal_Overall <> 0 Then
                    GTotVeryGoodP_Overall = (GTotVeryGood_Overall * 100) / GTotTotal_Overall
                    GTotGoodP_Overall = (GTotGood_Overall * 100) / GTotTotal_Overall
                    GTotAdjustP_Overall = (GTotAdjust_Overall * 100) / GTotTotal_Overall
                    GTotTotalP_Overall = (((GTotVeryGood_Overall + (GTotGood_Overall / 2)) * 100) / GTotTotal_Overall)
                End If
                tmpDataRow.Append("       <td align='center' >" & GTotVeryGood_Overall & "</td>")
                tmpDataRow.Append("       <td align='center' >" & Math.Round(GTotVeryGoodP_Overall, MidpointRounding.AwayFromZero) & "%</td>")
                tmpDataRow.Append("       <td align='center' >" & GTotGood_Overall & "</td>")
                tmpDataRow.Append("       <td align='center' >" & Math.Round(GTotGoodP_Overall, MidpointRounding.AwayFromZero) & "%</td>")
                tmpDataRow.Append("       <td align='center' >" & GTotAdjust_Overall & "</td>")
                tmpDataRow.Append("       <td align='center' >" & Math.Round(GTotAdjustP_Overall, MidpointRounding.AwayFromZero) & "%</td>")
                tmpDataRow.Append("       <td align='center' >" & Math.Ceiling(GTotTotalP_Overall) & "%</td>")
                'Customer Service
                Dim GTotVeryGoodP_Customer_Service As Double = 0
                Dim GTotGoodP_Customer_Service As Double = 0
                Dim GTotAdjustP_Customer_Service As Double = 0
                Dim GTotTotalP_Customer_Service As Double = 0
                If GTotTotal_Customer_Service <> 0 Then
                    GTotVeryGoodP_Customer_Service = (GTotVeryGood_Customer_Service * 100) / GTotTotal_Customer_Service
                    GTotGoodP_Customer_Service = (GTotGood_Customer_Service * 100) / GTotTotal_Customer_Service
                    GTotAdjustP_Customer_Service = (GTotAdjust_Customer_Service * 100) / GTotTotal_Customer_Service
                    GTotTotalP_Customer_Service = (((GTotVeryGood_Customer_Service + (GTotGood_Customer_Service / 2)) * 100) / GTotTotal_Customer_Service)
                End If
                tmpDataRow.Append("       <td align='center' >" & GTotVeryGood_Customer_Service & "</td>")
                tmpDataRow.Append("       <td align='center' >" & Math.Round(GTotVeryGoodP_Customer_Service, MidpointRounding.AwayFromZero) & "%</td>")
                tmpDataRow.Append("       <td align='center' >" & GTotGood_Customer_Service & "</td>")
                tmpDataRow.Append("       <td align='center' >" & Math.Round(GTotGoodP_Customer_Service, MidpointRounding.AwayFromZero) & "%</td>")
                tmpDataRow.Append("       <td align='center' >" & GTotAdjust_Customer_Service & "</td>")
                tmpDataRow.Append("       <td align='center' >" & Math.Round(GTotAdjustP_Customer_Service, MidpointRounding.AwayFromZero) & "%</td>")
                tmpDataRow.Append("       <td align='center' >" & Math.Ceiling(GTotTotalP_Customer_Service) & "%</td>")
                '######################################

                tmpDataRow.Append("</tr>")
            End If


            ret.Append("    <tr >" & tmpHRow & "</tr>")
            ret.Append("    <tr style='background: yellowgreen repeat-x top;font-weight: bold;'>" & tmpSRow & "</tr>")
            ret.Append("    <tr style='background: yellowgreen repeat-x top;font-weight: bold;'>" & tmpReRow & "</tr>")
            ret.Append(tmpDataRow)
            ret.Append("</table>")
            lblReportDesc.Text = ret.ToString

            ret = Nothing
            sDt = Nothing
        End If

        If lblReportDesc.Text <> "" Then
            lblerror.Visible = False
            'lblRowCount.Text = "ค้นพบ " & dt.Rows.Count & " รายการ"
        End If
    End Sub

    Private Sub SearchNPSSCOREData()
        Dim sEng As New Engine.Configuration.MasterENG
        Dim sDt As New DataTable
        Dim sWh As String = " 1 = 1 "
        If Request("ServiceID") IsNot Nothing Then
            sWh += " and id= '" & Request("ServiceID") & "'"
        End If

        sDt = sEng.GetServiceActiveList(sWh)
        Dim shWh As String = " 1=1 "
        If Request("ShopID") IsNot Nothing Then
            shWh += " and sh.id = '" & Request("ShopID") & "'"
        End If
        Dim shDt As New DataTable
        Dim shEng As New Engine.Configuration.MasterENG
        shDt = shEng.GetShopList(shWh)

        If sDt.Rows.Count > 0 Then
            Dim eng As New Engine.CSI.CSIReportsENG
            Dim dt As New DataTable
            dt = eng.GetNPSSCOREDataList(GetWhText)
            If dt.Rows.Count > 0 Then
                Dim ret As New StringBuilder

                ret.Append("<table border='1' cellspacing='0' cellpadding='0' width='100%' class='mGrid' >")
                ret.Append("    <tr style='background: yellow repeat-x top;font-weight: bold;'>")
                ret.Append("        <td align='center'  rowspan='2' style='color: #000000;' >Location</td>")
                ret.Append("        <td align='center'  rowspan='2' style='color: #000000;' >AIS Shop</td>")
                ret.Append("        <td align='center' colspan='22'  style='color: #000000;' >NPS Score</td>")
                ret.Append("    </tr>")
                ret.Append("    <tr style='background: yellow repeat-x top;font-weight: bold;'>")
                ret.Append("        <td align='center' width='50px' style='color: #000000;' >&nbsp;0</td>")
                ret.Append("        <td align='center' width='50px' style='color: #000000;' >&nbsp;1</td>")
                ret.Append("        <td align='center' width='50px' style='color: #000000;' >&nbsp;2</td>")
                ret.Append("        <td align='center' width='50px' style='color: #000000;' >&nbsp;3</td>")
                ret.Append("        <td align='center' width='50px' style='color: #000000;' >&nbsp;4</td>")
                ret.Append("        <td align='center' width='50px' style='color: #000000;' >&nbsp;5</td>")
                ret.Append("        <td align='center' width='50px' style='color: #000000;' >&nbsp;6</td>")
                ret.Append("        <td align='center' width='50px' style='color: #000000;' >&nbsp;0-6</td>")
                ret.Append("        <td align='center' width='50px' style='color: #000000;' >&nbsp;%</td>")
                ret.Append("        <td align='center' width='50px' style='color: #000000;' >&nbsp;%0-6</td>")
                ret.Append("        <td align='center' width='50px' style='color: #000000;' >&nbsp;7</td>")
                ret.Append("        <td align='center' width='50px' style='color: #000000;' >&nbsp;8</td>")
                ret.Append("        <td align='center' width='50px' style='color: #000000;' >&nbsp;7-8</td>")
                ret.Append("        <td align='center' width='50px' style='color: #000000;' >&nbsp;%</td>")
                ret.Append("        <td align='center' width='50px' style='color: #000000;' >&nbsp;%7-8</td>")
                ret.Append("        <td align='center' width='50px' style='color: #000000;' >&nbsp;9</td>")
                ret.Append("        <td align='center' width='50px' style='color: #000000;' >&nbsp;10</td>")
                ret.Append("        <td align='center' width='50px' style='color: #000000;' >&nbsp;9-10</td>")
                ret.Append("        <td align='center' width='50px' style='color: #000000;' >&nbsp;%</td>")
                ret.Append("        <td align='center' width='50px' style='color: #000000;' >&nbsp;%9-10</td>")
                ret.Append("        <td align='center' width='50px' style='color: #000000;' >Grand To</td>")
                ret.Append("        <td align='center' width='50px' style='color: #000000;' >NPS</td>")
                ret.Append("    </tr>")

                Dim _all_sum0 As Integer = 0
                Dim _all_sum1 As Integer = 0
                Dim _all_sum2 As Integer = 0
                Dim _all_sum3 As Integer = 0
                Dim _all_sum4 As Integer = 0
                Dim _all_sum5 As Integer = 0
                Dim _all_sum6 As Integer = 0
                Dim _all_sum7 As Integer = 0
                Dim _all_sum8 As Integer = 0
                Dim _all_sum9 As Integer = 0
                Dim _all_sum10 As Integer = 0

                Dim rDt As New DataTable
                rDt = dt.DefaultView.ToTable(True, "region_id", "region_code", "region_name_en").Copy
                If rDt.Rows.Count > 0 Then
                    For Each rDr As DataRow In rDt.Rows
                        If rDr("region_id") Is DBNull.Value Then
                            Continue For
                        End If
                        dt.DefaultView.RowFilter = "region_id='" & rDr("region_id") & "'"

                        Dim _sum0 As Integer = 0
                        Dim _sum1 As Integer = 0
                        Dim _sum2 As Integer = 0
                        Dim _sum3 As Integer = 0
                        Dim _sum4 As Integer = 0
                        Dim _sum5 As Integer = 0
                        Dim _sum6 As Integer = 0
                        Dim _sum7 As Integer = 0
                        Dim _sum8 As Integer = 0
                        Dim _sum9 As Integer = 0
                        Dim _sum10 As Integer = 0
                        If dt.DefaultView.Count > 0 Then

                            For Each dr As DataRowView In dt.DefaultView
                                Dim grandTo As Integer = CInt(dr("GrandTo"))
                                Dim sum0_6 As Integer = CInt(dr("score_0")) + CInt(dr("score_1")) + _
                                CInt(dr("score_2")) + CInt(dr("score_3")) + CInt(dr("score_4")) + _
                                CInt(dr("score_5")) + CInt(dr("score_6"))
                                Dim percent0_6 As Double = Math.Round((sum0_6 / grandTo) * 100, 2)
                                Dim round0_6 As Integer = Math.Round(percent0_6)

                                Dim sum7_8 As Integer = CInt(dr("score_7")) + CInt(dr("score_8"))
                                Dim percent7_8 As Double = Math.Round((sum7_8 / grandTo) * 100, 2)
                                Dim round7_8 As Integer = Math.Round(percent7_8)

                                Dim sum9_10 As Integer = CInt(dr("score_9")) + CInt(dr("score_10"))
                                Dim percent9_10 As Double = Math.Round((sum9_10 / grandTo) * 100, 2)
                                Dim round9_10 As Integer = Math.Round(percent9_10)
                                Dim NPS As Integer = round9_10 - round0_6

                                _sum0 += CInt(dr("score_0"))
                                _sum1 += CInt(dr("score_1"))
                                _sum2 += CInt(dr("score_2"))
                                _sum3 += CInt(dr("score_3"))
                                _sum4 += CInt(dr("score_4"))
                                _sum5 += CInt(dr("score_5"))
                                _sum6 += CInt(dr("score_6"))
                                _sum7 += CInt(dr("score_7"))
                                _sum8 += CInt(dr("score_8"))
                                _sum9 += CInt(dr("score_9"))
                                _sum10 += CInt(dr("score_10"))

                                ret.Append("    <tr>")
                                ret.Append("        <td align='center' width='150px' style='color: #000000;' >" & dr("shop_code").ToString & "</td>")
                                ret.Append("        <td align='left' width='250px' style='color: #000000;' >" & dr("shop_name_en").ToString & "</td>")
                                ret.Append("        <td align='right' width='50px' style='color: #000000;' >" & dr("score_0").ToString & "</td>")
                                ret.Append("        <td align='right' width='50px' style='color: #000000;' >" & dr("score_1").ToString & "</td>")
                                ret.Append("        <td align='right' width='50px' style='color: #000000;' >" & dr("score_2").ToString & "</td>")
                                ret.Append("        <td align='right' width='50px' style='color: #000000;' >" & dr("score_3").ToString & "</td>")
                                ret.Append("        <td align='right' width='50px' style='color: #000000;' >" & dr("score_4").ToString & "</td>")
                                ret.Append("        <td align='right' width='50px' style='color: #000000;' >" & dr("score_5").ToString & "</td>")
                                ret.Append("        <td align='right' width='50px' style='color: #000000;' >" & dr("score_6").ToString & "</td>")
                                ret.Append("        <td align='right' width='50px' style='color: #000000;' >" & sum0_6 & "</td>")
                                ret.Append("        <td align='right' width='50px' style='color: #000000;' >" & percent0_6.ToString("0.00") & "%</td>")
                                ret.Append("        <td align='right' width='50px' style='color: #000000;' >" & round0_6 & "%</td>")
                                ret.Append("        <td align='right' width='50px' style='color: #000000;' >" & dr("score_7").ToString & "</td>")
                                ret.Append("        <td align='right' width='50px' style='color: #000000;' >" & dr("score_8").ToString & "</td>")
                                ret.Append("        <td align='right' width='50px' style='color: #000000;' >" & sum7_8 & "</td>")
                                ret.Append("        <td align='right' width='50px' style='color: #000000;' >" & percent7_8.ToString("0.00") & "%</td>")
                                ret.Append("        <td align='right' width='50px' style='color: #000000;' >" & round7_8 & "%</td>")
                                ret.Append("        <td align='right' width='50px' style='color: #000000;' >" & dr("score_9").ToString & "</td>")
                                ret.Append("        <td align='right' width='50px' style='color: #000000;' >" & dr("score_10").ToString & "</td>")
                                ret.Append("        <td align='right' width='50px' style='color: #000000;' >" & sum9_10 & "</td>")
                                ret.Append("        <td align='right' width='50px' style='color: #000000;' >" & percent9_10.ToString("0.00") & "%</td>")
                                ret.Append("        <td align='right' width='50px' style='color: #000000;' >" & round9_10 & "%</td>")
                                ret.Append("        <td align='right' width='50px' style='color: #000000;' >" & grandTo & "</td>")
                                ret.Append("        <td align='right' width='50px' style='color: #000000;' >" & NPS & "%</td>")
                                ret.Append("    </tr>")
                            Next
                        End If
                        dt.DefaultView.RowFilter = ""


                        Dim _grandTo As Integer = _sum0 + _sum1 + _sum2 + _sum3 + _sum4 + _sum5 + _sum6 + _sum7 + _sum8 + _sum9 + _sum10
                        Dim _sum0_6 As Integer = _sum0 + _sum1 + _sum2 + _sum3 + _sum4 + _sum5 + _sum6
                        Dim _sum7_8 As Integer = _sum7 + _sum8
                        Dim _sum9_10 As Integer = _sum9 + _sum10
                        Dim _percent0_6 As Double = Math.Round((_sum0_6 / _grandTo) * 100, 2)
                        Dim _percent7_8 As Double = Math.Round((_sum7_8 / _grandTo) * 100, 2)
                        Dim _percent9_10 As Double = Math.Round((_sum9_10 / _grandTo) * 100, 2)
                        Dim _round0_6 As Integer = Math.Round(_percent0_6)
                        Dim _round7_8 As Integer = Math.Round(_percent7_8)
                        Dim _round9_10 As Integer = Math.Round(_percent9_10)
                        Dim _nps As Integer = _round9_10 - _round0_6

                        _all_sum0 += _sum0
                        _all_sum1 += _sum1
                        _all_sum2 += _sum2
                        _all_sum3 += _sum3
                        _all_sum4 += _sum4
                        _all_sum5 += _sum5
                        _all_sum6 += _sum6
                        _all_sum7 += _sum7
                        _all_sum8 += _sum8
                        _all_sum9 += _sum9
                        _all_sum10 += _sum10

                        ret.Append("    <tr style='background: yellowgreen repeat-x top;font-weight: bold;'>")
                        'Summary by Region
                        ret.Append("        <td align='center' colspan='2' style='color: #000000;' >" & rDr("region_code") & "</td>")
                        'ret.Append("        <td align='center'  style='color: #000000;' ></td>")
                        ret.Append("        <td align='right'  style='color: #000000;' >" & _sum0 & "</td>")
                        ret.Append("        <td align='right'  style='color: #000000;' >" & _sum1 & "</td>")
                        ret.Append("        <td align='right'  style='color: #000000;' >" & _sum2 & "</td>")
                        ret.Append("        <td align='right'  style='color: #000000;' >" & _sum3 & "</td>")
                        ret.Append("        <td align='right'  style='color: #000000;' >" & _sum4 & "</td>")
                        ret.Append("        <td align='right'  style='color: #000000;' >" & _sum5 & "</td>")
                        ret.Append("        <td align='right'  style='color: #000000;' >" & _sum6 & "</td>")
                        ret.Append("        <td align='right'  style='color: #000000;' >" & _sum0_6 & "</td>")
                        ret.Append("        <td align='right'  style='color: #000000;' >" & _percent0_6.ToString("0.00") & "%</td>")
                        ret.Append("        <td align='right'  style='color: #000000;' >" & _round0_6 & "%</td>")
                        ret.Append("        <td align='right'  style='color: #000000;' >" & _sum7 & "</td>")
                        ret.Append("        <td align='right'  style='color: #000000;' >" & _sum8 & "</td>")
                        ret.Append("        <td align='right'  style='color: #000000;' >" & _sum7_8 & "</td>")
                        ret.Append("        <td align='right'  style='color: #000000;' >" & _percent7_8.ToString("0.00") & "%</td>")
                        ret.Append("        <td align='right'  style='color: #000000;' >" & _round7_8 & "%</td>")
                        ret.Append("        <td align='right'  style='color: #000000;' >" & _sum9 & "</td>")
                        ret.Append("        <td align='right'  style='color: #000000;' >" & _sum10 & "</td>")
                        ret.Append("        <td align='right'  style='color: #000000;' >" & _sum9_10 & "</td>")
                        ret.Append("        <td align='right'  style='color: #000000;' >" & _percent9_10.ToString("0.00") & "%</td>")
                        ret.Append("        <td align='right'  style='color: #000000;' >" & _round9_10 & "%</td>")
                        ret.Append("        <td align='right'  style='color: #000000;' >" & _grandTo & "</td>")
                        ret.Append("        <td align='right'  style='color: #000000;' >" & _nps & "%</td>")
                        ret.Append("    </tr>")
                    Next
                End If


                Dim _all_grandTo As Integer = _all_sum0 + _all_sum1 + _all_sum2 + _all_sum3 + _all_sum4 + _
                _all_sum5 + _all_sum6 + _all_sum7 + _all_sum8 + _all_sum9 + _all_sum10
                Dim _all_sum0_6 As Integer = _all_sum0 + _all_sum1 + _all_sum2 + _all_sum3 + _all_sum4 + _all_sum5 + _all_sum6
                Dim _all_sum7_8 As Integer = _all_sum7 + _all_sum8
                Dim _all_sum9_10 As Integer = _all_sum9 + _all_sum10
                Dim _all_percent0_6 As Double = Math.Round((_all_sum0_6 / _all_grandTo) * 100, 2)
                Dim _all_percent7_8 As Double = Math.Round((_all_sum7_8 / _all_grandTo) * 100, 2)
                Dim _all_percent9_10 As Double = Math.Round((_all_sum9_10 / _all_grandTo) * 100, 2)
                Dim _all_round0_6 As Integer = Math.Round(_all_percent0_6)
                Dim _all_round7_8 As Integer = Math.Round(_all_percent7_8)
                Dim _all_round9_10 As Integer = Math.Round(_all_percent9_10)
                Dim _all_nps As Integer = _all_round9_10 - _all_round0_6

                ret.Append("    <tr style='background: #2E9AFE repeat-x top;font-weight: bold;'>")
                'Summary all
                ret.Append("        <td align='center' colspan='2' style='color: #000000;' >Overall Retail Shop</td>")
                ' ret.Append("        <td align='center'  style='color: #000000;' ></td>")
                ret.Append("        <td align='right'  style='color: #000000;' >" & _all_sum0 & "</td>")
                ret.Append("        <td align='right'  style='color: #000000;' >" & _all_sum1 & "</td>")
                ret.Append("        <td align='right'  style='color: #000000;' >" & _all_sum2 & "</td>")
                ret.Append("        <td align='right'  style='color: #000000;' >" & _all_sum3 & "</td>")
                ret.Append("        <td align='right'  style='color: #000000;' >" & _all_sum4 & "</td>")
                ret.Append("        <td align='right'  style='color: #000000;' >" & _all_sum5 & "</td>")
                ret.Append("        <td align='right'  style='color: #000000;' >" & _all_sum6 & "</td>")
                ret.Append("        <td align='right'  style='color: #000000;' >" & _all_sum0_6 & "</td>")
                ret.Append("        <td align='right'  style='color: #000000;' >" & _all_percent0_6.ToString("0.00") & "%</td>")
                ret.Append("        <td align='right'  style='color: #000000;' >" & _all_round0_6 & "%</td>")
                ret.Append("        <td align='right'  style='color: #000000;' >" & _all_sum7 & "</td>")
                ret.Append("        <td align='right'  style='color: #000000;' >" & _all_sum8 & "</td>")
                ret.Append("        <td align='right'  style='color: #000000;' >" & _all_sum7_8 & "</td>")
                ret.Append("        <td align='right'  style='color: #000000;' >" & _all_percent7_8.ToString("0.00") & "%</td>")
                ret.Append("        <td align='right'  style='color: #000000;' >" & _all_round7_8 & "%</td>")
                ret.Append("        <td align='right'  style='color: #000000;' >" & _all_sum9 & "</td>")
                ret.Append("        <td align='right'  style='color: #000000;' >" & _all_sum10 & "</td>")
                ret.Append("        <td align='right'  style='color: #000000;' >" & _all_sum9_10 & "</td>")
                ret.Append("        <td align='right'  style='color: #000000;' >" & _all_percent9_10.ToString("0.00") & "%</td>")
                ret.Append("        <td align='right'  style='color: #000000;' >" & _all_round9_10 & "%</td>")
                ret.Append("        <td align='right'  style='color: #000000;' >" & _all_grandTo & "</td>")
                ret.Append("        <td align='right'  style='color: #000000;' >" & _all_nps & "%</td>")
                ret.Append("    </tr>")


                rDt.Dispose()

                ret.Append("</table>")
                lblRowCount.Text = "ค้นพบ " & dt.Rows.Count & " รายการ"

                lblReportDesc.Text = ret.ToString
                ret = Nothing
                dt = Nothing
                lblerror.Visible = False
            Else
                lblReportDesc.Text = ""
            End If
        End If

        If lblReportDesc.Text <> "" Then
            lblerror.Visible = False
            'lblRowCount.Text = "ค้นพบ " & dt.Rows.Count & " รายการ"
        End If
    End Sub

    Private Sub SearchNPSSCOREByAgentData()
        Dim sEng As New Engine.Configuration.MasterENG
        Dim sDt As New DataTable
        Dim sWh As String = " 1 = 1 "
        If Request("ServiceID") IsNot Nothing Then
            sWh += " and id= '" & Request("ServiceID") & "'"
        End If

        sDt = sEng.GetServiceActiveList(sWh)
        Dim shWh As String = " 1=1 "
        If Request("ShopID") IsNot Nothing Then
            shWh += " and sh.id = '" & Request("ShopID") & "'"
        End If
        Dim shDt As New DataTable
        Dim shEng As New Engine.Configuration.MasterENG
        shDt = shEng.GetShopList(shWh)

        If sDt.Rows.Count > 0 Then
            Dim eng As New Engine.CSI.CSIReportsENG
            Dim dt As New DataTable
            dt = eng.GetNPSSCOREByAgentDataList(GetWhText)
            If dt.Rows.Count > 0 Then
                Dim ret As New StringBuilder

                ret.Append("<table border='1' cellspacing='0' cellpadding='0' width='100%' class='mGrid' >")
                ret.Append("    <tr style='background: yellow repeat-x top;font-weight: bold;'>")
                ret.Append("        <td align='center'  rowspan='2' style='color: #000000;' >Location</td>")
                ret.Append("        <td align='center'  rowspan='2' style='color: #000000;' >AIS Shop</td>")
                ret.Append("        <td align='center'  rowspan='2' style='color: #000000;' >Agent</td>")
                ret.Append("        <td align='center' colspan='22'  style='color: #000000;' >NPS Score</td>")
                ret.Append("    </tr>")
                ret.Append("    <tr style='background: yellow repeat-x top;font-weight: bold;'>")
                ret.Append("        <td align='center' width='50px' style='color: #000000;' >&nbsp;0</td>")
                ret.Append("        <td align='center' width='50px' style='color: #000000;' >&nbsp;1</td>")
                ret.Append("        <td align='center' width='50px' style='color: #000000;' >&nbsp;2</td>")
                ret.Append("        <td align='center' width='50px' style='color: #000000;' >&nbsp;3</td>")
                ret.Append("        <td align='center' width='50px' style='color: #000000;' >&nbsp;4</td>")
                ret.Append("        <td align='center' width='50px' style='color: #000000;' >&nbsp;5</td>")
                ret.Append("        <td align='center' width='50px' style='color: #000000;' >&nbsp;6</td>")
                ret.Append("        <td align='center' width='50px' style='color: #000000;' >&nbsp;0-6</td>")
                ret.Append("        <td align='center' width='50px' style='color: #000000;' >&nbsp;%</td>")
                ret.Append("        <td align='center' width='50px' style='color: #000000;' >&nbsp;%0-6</td>")
                ret.Append("        <td align='center' width='50px' style='color: #000000;' >&nbsp;7</td>")
                ret.Append("        <td align='center' width='50px' style='color: #000000;' >&nbsp;8</td>")
                ret.Append("        <td align='center' width='50px' style='color: #000000;' >&nbsp;7-8</td>")
                ret.Append("        <td align='center' width='50px' style='color: #000000;' >&nbsp;%</td>")
                ret.Append("        <td align='center' width='50px' style='color: #000000;' >&nbsp;%7-8</td>")
                ret.Append("        <td align='center' width='50px' style='color: #000000;' >&nbsp;9</td>")
                ret.Append("        <td align='center' width='50px' style='color: #000000;' >&nbsp;10</td>")
                ret.Append("        <td align='center' width='50px' style='color: #000000;' >&nbsp;9-10</td>")
                ret.Append("        <td align='center' width='50px' style='color: #000000;' >&nbsp;%</td>")
                ret.Append("        <td align='center' width='50px' style='color: #000000;' >&nbsp;%9-10</td>")
                ret.Append("        <td align='center' width='50px' style='color: #000000;' >Grand To</td>")
                ret.Append("        <td align='center' width='50px' style='color: #000000;' >NPS</td>")
                ret.Append("    </tr>")

                Dim _all_sum0 As Integer = 0
                Dim _all_sum1 As Integer = 0
                Dim _all_sum2 As Integer = 0
                Dim _all_sum3 As Integer = 0
                Dim _all_sum4 As Integer = 0
                Dim _all_sum5 As Integer = 0
                Dim _all_sum6 As Integer = 0
                Dim _all_sum7 As Integer = 0
                Dim _all_sum8 As Integer = 0
                Dim _all_sum9 As Integer = 0
                Dim _all_sum10 As Integer = 0

                Dim rDt As New DataTable
                rDt = dt.DefaultView.ToTable(True, "region_id", "region_code", "region_name_en").Copy
                If rDt.Rows.Count > 0 Then
                    For Each rDr As DataRow In rDt.Rows
                        If rDr("region_id") Is DBNull.Value Then
                            Continue For
                        End If
                        dt.DefaultView.RowFilter = "region_id='" & rDr("region_id") & "'"

                        Dim _sum0 As Integer = 0
                        Dim _sum1 As Integer = 0
                        Dim _sum2 As Integer = 0
                        Dim _sum3 As Integer = 0
                        Dim _sum4 As Integer = 0
                        Dim _sum5 As Integer = 0
                        Dim _sum6 As Integer = 0
                        Dim _sum7 As Integer = 0
                        Dim _sum8 As Integer = 0
                        Dim _sum9 As Integer = 0
                        Dim _sum10 As Integer = 0
                        If dt.DefaultView.Count > 0 Then

                            For Each dr As DataRowView In dt.DefaultView
                                Dim grandTo As Integer = CInt(dr("GrandTo"))
                                Dim sum0_6 As Integer = CInt(dr("score_0")) + CInt(dr("score_1")) + _
                                CInt(dr("score_2")) + CInt(dr("score_3")) + CInt(dr("score_4")) + _
                                CInt(dr("score_5")) + CInt(dr("score_6"))
                                Dim percent0_6 As Double = Math.Round((sum0_6 / grandTo) * 100, 2)
                                Dim round0_6 As Integer = Math.Round(percent0_6)

                                Dim sum7_8 As Integer = CInt(dr("score_7")) + CInt(dr("score_8"))
                                Dim percent7_8 As Double = Math.Round((sum7_8 / grandTo) * 100, 2)
                                Dim round7_8 As Integer = Math.Round(percent7_8)

                                Dim sum9_10 As Integer = CInt(dr("score_9")) + CInt(dr("score_10"))
                                Dim percent9_10 As Double = Math.Round((sum9_10 / grandTo) * 100, 2)
                                Dim round9_10 As Integer = Math.Round(percent9_10)
                                Dim NPS As Integer = round9_10 - round0_6

                                _sum0 += CInt(dr("score_0"))
                                _sum1 += CInt(dr("score_1"))
                                _sum2 += CInt(dr("score_2"))
                                _sum3 += CInt(dr("score_3"))
                                _sum4 += CInt(dr("score_4"))
                                _sum5 += CInt(dr("score_5"))
                                _sum6 += CInt(dr("score_6"))
                                _sum7 += CInt(dr("score_7"))
                                _sum8 += CInt(dr("score_8"))
                                _sum9 += CInt(dr("score_9"))
                                _sum10 += CInt(dr("score_10"))

                                ret.Append("    <tr>")
                                ret.Append("        <td align='center' width='150px' style='color: #000000;' >" & dr("shop_code").ToString & "</td>")
                                ret.Append("        <td align='left' width='250px' style='color: #000000;' >" & dr("shop_name_en").ToString & "</td>")
                                ret.Append("        <td align='left' width='250px' style='color: #000000;' >" & dr("username").ToString & "</td>")
                                ret.Append("        <td align='right' width='50px' style='color: #000000;' >" & dr("score_0").ToString & "</td>")
                                ret.Append("        <td align='right' width='50px' style='color: #000000;' >" & dr("score_1").ToString & "</td>")
                                ret.Append("        <td align='right' width='50px' style='color: #000000;' >" & dr("score_2").ToString & "</td>")
                                ret.Append("        <td align='right' width='50px' style='color: #000000;' >" & dr("score_3").ToString & "</td>")
                                ret.Append("        <td align='right' width='50px' style='color: #000000;' >" & dr("score_4").ToString & "</td>")
                                ret.Append("        <td align='right' width='50px' style='color: #000000;' >" & dr("score_5").ToString & "</td>")
                                ret.Append("        <td align='right' width='50px' style='color: #000000;' >" & dr("score_6").ToString & "</td>")
                                ret.Append("        <td align='right' width='50px' style='color: #000000;' >" & sum0_6 & "</td>")
                                ret.Append("        <td align='right' width='50px' style='color: #000000;' >" & percent0_6.ToString("0.00") & "%</td>")
                                ret.Append("        <td align='right' width='50px' style='color: #000000;' >" & round0_6 & "%</td>")
                                ret.Append("        <td align='right' width='50px' style='color: #000000;' >" & dr("score_7").ToString & "</td>")
                                ret.Append("        <td align='right' width='50px' style='color: #000000;' >" & dr("score_8").ToString & "</td>")
                                ret.Append("        <td align='right' width='50px' style='color: #000000;' >" & sum7_8 & "</td>")
                                ret.Append("        <td align='right' width='50px' style='color: #000000;' >" & percent7_8.ToString("0.00") & "%</td>")
                                ret.Append("        <td align='right' width='50px' style='color: #000000;' >" & round7_8 & "%</td>")
                                ret.Append("        <td align='right' width='50px' style='color: #000000;' >" & dr("score_9").ToString & "</td>")
                                ret.Append("        <td align='right' width='50px' style='color: #000000;' >" & dr("score_10").ToString & "</td>")
                                ret.Append("        <td align='right' width='50px' style='color: #000000;' >" & sum9_10 & "</td>")
                                ret.Append("        <td align='right' width='50px' style='color: #000000;' >" & percent9_10.ToString("0.00") & "%</td>")
                                ret.Append("        <td align='right' width='50px' style='color: #000000;' >" & round9_10 & "%</td>")
                                ret.Append("        <td align='right' width='50px' style='color: #000000;' >" & grandTo & "</td>")
                                ret.Append("        <td align='right' width='50px' style='color: #000000;' >" & NPS & "%</td>")
                                ret.Append("    </tr>")
                            Next
                        End If
                        dt.DefaultView.RowFilter = ""


                        Dim _grandTo As Integer = _sum0 + _sum1 + _sum2 + _sum3 + _sum4 + _sum5 + _sum6 + _sum7 + _sum8 + _sum9 + _sum10
                        Dim _sum0_6 As Integer = _sum0 + _sum1 + _sum2 + _sum3 + _sum4 + _sum5 + _sum6
                        Dim _sum7_8 As Integer = _sum7 + _sum8
                        Dim _sum9_10 As Integer = _sum9 + _sum10
                        Dim _percent0_6 As Double = Math.Round((_sum0_6 / _grandTo) * 100, 2)
                        Dim _percent7_8 As Double = Math.Round((_sum7_8 / _grandTo) * 100, 2)
                        Dim _percent9_10 As Double = Math.Round((_sum9_10 / _grandTo) * 100, 2)
                        Dim _round0_6 As Integer = Math.Round(_percent0_6)
                        Dim _round7_8 As Integer = Math.Round(_percent7_8)
                        Dim _round9_10 As Integer = Math.Round(_percent9_10)
                        Dim _nps As Integer = _round9_10 - _round0_6

                        _all_sum0 += _sum0
                        _all_sum1 += _sum1
                        _all_sum2 += _sum2
                        _all_sum3 += _sum3
                        _all_sum4 += _sum4
                        _all_sum5 += _sum5
                        _all_sum6 += _sum6
                        _all_sum7 += _sum7
                        _all_sum8 += _sum8
                        _all_sum9 += _sum9
                        _all_sum10 += _sum10

                        ret.Append("    <tr style='background: yellowgreen repeat-x top;font-weight: bold;'>")
                        'Summary by Region
                        ret.Append("        <td align='center' colspan='3' style='color: #000000;' >" & rDr("region_code") & "</td>")
                        'ret.Append("        <td align='center'  style='color: #000000;' ></td>")
                        ret.Append("        <td align='right'  style='color: #000000;' >" & _sum0 & "</td>")
                        ret.Append("        <td align='right'  style='color: #000000;' >" & _sum1 & "</td>")
                        ret.Append("        <td align='right'  style='color: #000000;' >" & _sum2 & "</td>")
                        ret.Append("        <td align='right'  style='color: #000000;' >" & _sum3 & "</td>")
                        ret.Append("        <td align='right'  style='color: #000000;' >" & _sum4 & "</td>")
                        ret.Append("        <td align='right'  style='color: #000000;' >" & _sum5 & "</td>")
                        ret.Append("        <td align='right'  style='color: #000000;' >" & _sum6 & "</td>")
                        ret.Append("        <td align='right'  style='color: #000000;' >" & _sum0_6 & "</td>")
                        ret.Append("        <td align='right'  style='color: #000000;' >" & _percent0_6.ToString("0.00") & "%</td>")
                        ret.Append("        <td align='right'  style='color: #000000;' >" & _round0_6 & "%</td>")
                        ret.Append("        <td align='right'  style='color: #000000;' >" & _sum7 & "</td>")
                        ret.Append("        <td align='right'  style='color: #000000;' >" & _sum8 & "</td>")
                        ret.Append("        <td align='right'  style='color: #000000;' >" & _sum7_8 & "</td>")
                        ret.Append("        <td align='right'  style='color: #000000;' >" & _percent7_8.ToString("0.00") & "%</td>")
                        ret.Append("        <td align='right'  style='color: #000000;' >" & _round7_8 & "%</td>")
                        ret.Append("        <td align='right'  style='color: #000000;' >" & _sum9 & "</td>")
                        ret.Append("        <td align='right'  style='color: #000000;' >" & _sum10 & "</td>")
                        ret.Append("        <td align='right'  style='color: #000000;' >" & _sum9_10 & "</td>")
                        ret.Append("        <td align='right'  style='color: #000000;' >" & _percent9_10.ToString("0.00") & "%</td>")
                        ret.Append("        <td align='right'  style='color: #000000;' >" & _round9_10 & "%</td>")
                        ret.Append("        <td align='right'  style='color: #000000;' >" & _grandTo & "</td>")
                        ret.Append("        <td align='right'  style='color: #000000;' >" & _nps & "%</td>")
                        ret.Append("    </tr>")
                    Next
                End If


                Dim _all_grandTo As Integer = _all_sum0 + _all_sum1 + _all_sum2 + _all_sum3 + _all_sum4 + _
                _all_sum5 + _all_sum6 + _all_sum7 + _all_sum8 + _all_sum9 + _all_sum10
                Dim _all_sum0_6 As Integer = _all_sum0 + _all_sum1 + _all_sum2 + _all_sum3 + _all_sum4 + _all_sum5 + _all_sum6
                Dim _all_sum7_8 As Integer = _all_sum7 + _all_sum8
                Dim _all_sum9_10 As Integer = _all_sum9 + _all_sum10
                Dim _all_percent0_6 As Double = Math.Round((_all_sum0_6 / _all_grandTo) * 100, 2)
                Dim _all_percent7_8 As Double = Math.Round((_all_sum7_8 / _all_grandTo) * 100, 2)
                Dim _all_percent9_10 As Double = Math.Round((_all_sum9_10 / _all_grandTo) * 100, 2)
                Dim _all_round0_6 As Integer = Math.Round(_all_percent0_6)
                Dim _all_round7_8 As Integer = Math.Round(_all_percent7_8)
                Dim _all_round9_10 As Integer = Math.Round(_all_percent9_10)
                Dim _all_nps As Integer = _all_round9_10 - _all_round0_6

                ret.Append("    <tr style='background: #2E9AFE repeat-x top;font-weight: bold;'>")
                'Summary all
                ret.Append("        <td align='center' colspan='3' style='color: #000000;' >Overall Retail Shop</td>")
                ' ret.Append("        <td align='center'  style='color: #000000;' ></td>")
                ret.Append("        <td align='right'  style='color: #000000;' >" & _all_sum0 & "</td>")
                ret.Append("        <td align='right'  style='color: #000000;' >" & _all_sum1 & "</td>")
                ret.Append("        <td align='right'  style='color: #000000;' >" & _all_sum2 & "</td>")
                ret.Append("        <td align='right'  style='color: #000000;' >" & _all_sum3 & "</td>")
                ret.Append("        <td align='right'  style='color: #000000;' >" & _all_sum4 & "</td>")
                ret.Append("        <td align='right'  style='color: #000000;' >" & _all_sum5 & "</td>")
                ret.Append("        <td align='right'  style='color: #000000;' >" & _all_sum6 & "</td>")
                ret.Append("        <td align='right'  style='color: #000000;' >" & _all_sum0_6 & "</td>")
                ret.Append("        <td align='right'  style='color: #000000;' >" & _all_percent0_6.ToString("0.00") & "%</td>")
                ret.Append("        <td align='right'  style='color: #000000;' >" & _all_round0_6 & "%</td>")
                ret.Append("        <td align='right'  style='color: #000000;' >" & _all_sum7 & "</td>")
                ret.Append("        <td align='right'  style='color: #000000;' >" & _all_sum8 & "</td>")
                ret.Append("        <td align='right'  style='color: #000000;' >" & _all_sum7_8 & "</td>")
                ret.Append("        <td align='right'  style='color: #000000;' >" & _all_percent7_8.ToString("0.00") & "%</td>")
                ret.Append("        <td align='right'  style='color: #000000;' >" & _all_round7_8 & "%</td>")
                ret.Append("        <td align='right'  style='color: #000000;' >" & _all_sum9 & "</td>")
                ret.Append("        <td align='right'  style='color: #000000;' >" & _all_sum10 & "</td>")
                ret.Append("        <td align='right'  style='color: #000000;' >" & _all_sum9_10 & "</td>")
                ret.Append("        <td align='right'  style='color: #000000;' >" & _all_percent9_10.ToString("0.00") & "%</td>")
                ret.Append("        <td align='right'  style='color: #000000;' >" & _all_round9_10 & "%</td>")
                ret.Append("        <td align='right'  style='color: #000000;' >" & _all_grandTo & "</td>")
                ret.Append("        <td align='right'  style='color: #000000;' >" & _all_nps & "%</td>")
                ret.Append("    </tr>")


                rDt.Dispose()

                ret.Append("</table>")
                lblRowCount.Text = "ค้นพบ " & dt.Rows.Count & " รายการ"

                lblReportDesc.Text = ret.ToString
                ret = Nothing
                dt = Nothing
                lblerror.Visible = False
            Else
                lblReportDesc.Text = ""
            End If
        End If

        If lblReportDesc.Text <> "" Then
            lblerror.Visible = False
            'lblRowCount.Text = "ค้นพบ " & dt.Rows.Count & " รายการ"
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            If Request("ReportName") = "Detail" Then
                lblReportName.Text = "Detail Report"
                SearchDetailData()
            ElseIf Request("ReportName") = "CSI" Then
                lblReportName.Text = "CSI Report"
                SearchCSIData()
            ElseIf Request("ReportName") = "NPSSCORE" Then
                lblReportName.Text = "NPS SCORE Report"
                SearchNPSSCOREData()
            ElseIf Request("ReportName") = "CSI_BY_AGENT" Then
                lblReportName.Text = "CSI By Agent Report"
                SearchCSIByAgentData()
            ElseIf Request("ReportName") = "NPSSCORE_BY_AGENT" Then
                lblReportName.Text = "NPS SCORE By Agent Report"
                SearchNPSSCOREByAgentData()
            End If

        End If
    End Sub

    Protected Sub likExport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles likExport.Click
        Dim filename As String = Now.ToString("ddMMyyyyHHmmssfff")
        ExportData("application/vnd.xls", filename & ".xls")
    End Sub

    Private Sub ExportData(ByVal _contentType As String, ByVal fileName As String)
        Response.ClearContent()
        Response.Charset = "utf-8"
        Response.AddHeader("content-disposition", "attachment;filename=" + fileName)
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.ContentType = _contentType
        Dim sw As New StringWriter()
        Dim htw As New HtmlTextWriter(sw)
        Dim frm As New HtmlForm()
        frm.Attributes("runat") = "server"
        frm.Controls.Add(lblReportDesc)
        lblReportDesc.RenderControl(htw)

        Response.Write(sw.ToString())
        Response.[End]()
    End Sub

    Protected Sub imgExport_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgExport.Click
        Dim filename As String = Now.ToString("ddMMyyyyHHmmssfff")
        ExportData("application/vnd.xls", filename & ".xls")
    End Sub
End Class
