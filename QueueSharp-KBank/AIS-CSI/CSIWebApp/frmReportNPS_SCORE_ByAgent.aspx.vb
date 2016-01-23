Imports System.Data
Imports System.Globalization
Imports System.IO
Partial Class CSIWebApp_frmReportNPS_SCORE_ByAgent
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            SetCombo()
        End If
    End Sub

    Private Sub SetCombo()
        cmbShopID.SetItemList(Engine.Common.FunctionEng.GetActiveShopDDL, "shop_name", "id")

        Dim sEng As New Engine.Configuration.MasterENG
        cmbServiceID.SetItemList(sEng.GetServiceActiveList("1=1"), "item_name", "id")
        sEng = Nothing

    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If txtDateFrom.DateValue.Year = "1" Then
            Config.SetAlert("กรุณาเลือก Date from !!!", Me, txtDateFrom.ClientID)
            Exit Sub
        End If
        If txtDateTo.DateValue.Year = "1" Then
            Config.SetAlert("กรุณาเลือก Date to !!!", Me, txtDateTo.ClientID)
            Exit Sub
        End If

        If txtDateFrom.DateValue > txtDateTo.DateValue Then
            Config.SetAlert("คุณเลือก Date From มากกว่า Date To !!!", Me)
            Exit Sub
        End If

        Dim para As String = ""
        para += "?ReportName=NPSSCORE_BY_AGENT"
        para += "&rnd=" & DateTime.Now.Millisecond

        If txtDateFrom.DateValue.Year <> 1 Then
            para += "&DateFrom=" & txtDateFrom.DateValue.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US"))
        End If
        If txtDateTo.DateValue.Year <> 1 Then
            para += "&DateTo=" & txtDateTo.DateValue.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US"))
        End If
        If cmbShopID.SelectedValue <> "0" Then
            para += "&ShopID=" & cmbShopID.SelectedValue
            If cmbShopUserID.SelectedValue <> "" Then
                para += "&ShopUserName=" & cmbShopUserID.SelectedValue
            End If
        End If
        If cmbServiceID.SelectedValue <> "0" Then
            para += "&ServiceID=" & cmbServiceID.SelectedValue
        End If

        Dim SelectTemplate As String = ctlSelectFilterTemplate1.GetSelectedFilterID
        If SelectTemplate <> "" Then
            para += "&TemplateID=" & SelectTemplate
        End If

        para += "&Status=2"


        Dim scr As String = "window.open('../CSIWebApp/frmReportPreview.aspx" & para & "', '_blank', 'height=650,left=600,location=no,menubar=no,toolbar=no,status=yes,resizable=yes,scrollbars=yes', true);"
        ScriptManager.RegisterStartupScript(Me, GetType(String), "ShowReport", scr, True)
    End Sub

    Protected Sub cmbShopID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbShopID.SelectedIndexChanged
        If cmbShopID.SelectedValue <> "0" Then
            Dim eng As New Engine.Configuration.ShopUserENG
            Dim dt As New DataTable
            dt = eng.GetShopUser2(cmbShopID.SelectedValue)
            cmbShopUserID.SetItemList(dt, "fullname", "username")
            dt.Dispose()
            eng = Nothing
        Else
            cmbShopUserID.ClearCombo()
            cmbShopUserID.SetItemList("เลือก", "")
        End If
    End Sub


    Protected Sub ctlSelectFilterTemplate1_Search(ByVal sender As Object, ByVal e As System.EventArgs) Handles ctlSelectFilterTemplate1.Search
        If txtDateFrom.DateValue.Year = "1" Then
            Config.SetAlert("กรุณาเลือก Date from !!!", Me, txtDateFrom.ClientID)
            Exit Sub
        End If
        If txtDateTo.DateValue.Year = "1" Then
            Config.SetAlert("กรุณาเลือก Date to !!!", Me, txtDateTo.ClientID)
            Exit Sub
        End If

        If txtDateFrom.DateValue > txtDateTo.DateValue Then
            Config.SetAlert("คุณเลือก Date From มากกว่า Date To !!!", Me)
            Exit Sub
        End If

        If txtDateFrom.DateValue.Year <> 1 Then
            ctlSelectFilterTemplate1.DateFrom = txtDateFrom.DateValue.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US"))
        End If
        If txtDateTo.DateValue.Year <> 1 Then
            ctlSelectFilterTemplate1.DateTo = txtDateTo.DateValue.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US"))
        End If
    End Sub
End Class
