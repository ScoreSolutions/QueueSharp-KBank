Imports System.Data
Imports CenLinqDB.TABLE
Imports System.Windows.Forms

Public Class UpdateShopAppointServiceENG
    Public Sub UpdateShopAppointmentService(ByVal lblTime As Label)
        Try
            Dim sDt As DataTable = Engine.Common.FunctionEng.GetActiveShop()
            If sDt.Rows.Count > 0 Then
                Dim MaxAppointmentDay As String = Engine.Common.FunctionEng.GetQisDBConfig("MaxAppointmentDay")
                If MaxAppointmentDay.Trim = "" Then
                    MaxAppointmentDay = "7"
                End If
                Dim vDateFrom As String = DateTime.Now.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US"))
                Dim vDateTo As String = DateAdd(DateInterval.Day, Convert.ToInt16(MaxAppointmentDay), DateTime.Now).ToString("yyyyMMdd", New Globalization.CultureInfo("en-US"))
                Dim dDateFrom As New Date(Today.Year, Today.Month, Today.Day)

                For Each sDr As DataRow In sDt.Rows
                    Dim trans As New CenLinqDB.Common.Utilities.TransactionDB
                    Dim dSql As String = "delete from tb_shop_service_appointment  "
                    dSql += " where shop_id='" & sDr("id") & "'"
                    dSql += " and convert(varchar(8),app_date,112) between '" & vDateFrom & "' and '" & vDateTo & "'"
                    CenLinqDB.Common.Utilities.SqlDB.ExecuteNonQuery(dSql, trans.Trans)
                    trans.CommitTransaction()

                    Dim shTran As ShLinqDB.Common.Utilities.TransactionDB = Engine.Common.FunctionEng.GetShTransction(sDr("id"), "Engine.UpdateShopAppointServiceENG_UpdateShopAppointmentService")
                    If shTran.Trans IsNot Nothing Then
                        Dim sql As String = "select distinct i.master_itemid,CONVERT(varchar(8),sc.app_date,112) app_date " & vbNewLine
                        sql += " from TB_APPOINTMENT_SCHEDULE sc " & vbNewLine
                        sql += " inner join TB_APPOINTMENT_ITEM ai on CONVERT(varchar(8),ai.app_date,112)=CONVERT(varchar(8),sc.app_date,112) " & vbNewLine
                        sql += " inner join TB_ITEM i on i.id=ai.item_id " & vbNewLine
                        sql += " where CONVERT(varchar(8),sc.app_date,112) between '" & vDateFrom & "' and '" & vDateTo & "'"

                        Dim slDt As DataTable = ShLinqDB.Common.Utilities.SqlDB.ExecuteTable(sql, shTran.Trans)
                        shTran.CommitTransaction()
                        If slDt.Rows.Count > 0 Then
                            Dim CurrDate As Date = dDateFrom
                            Do
                                slDt.DefaultView.RowFilter = "app_date='" & CurrDate.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US")) & "'"
                                For Each slDr As DataRowView In slDt.DefaultView
                                    trans = New CenLinqDB.Common.Utilities.TransactionDB
                                    If trans.Trans IsNot Nothing Then
                                        Dim lnq As New TbShopServiceAppointmentCenLinqDB
                                        lnq.ChkDataByAPP_DATE_MASTER_ITEMID_SHOP_ID(CurrDate, slDr("master_itemid").ToString, sDr("id"), trans.Trans)
                                        lnq.SHOP_ID = sDr("id")
                                        If Convert.IsDBNull(slDr("master_itemid")) = False Then lnq.MASTER_ITEMID = slDr("master_itemid")
                                        lnq.APP_DATE = CurrDate

                                        Dim ret As Boolean = False
                                        If lnq.ID > 0 Then
                                            ret = lnq.UpdateByPK("UpdateShopAppointmentService", trans.Trans)
                                        Else
                                            ret = lnq.InsertData("UpdateShopAppointmentService", trans.Trans)
                                        End If

                                        If ret = True Then
                                            trans.CommitTransaction()
                                        Else
                                            trans.RollbackTransaction()
                                        End If
                                        lblTime.Text = DateTime.Now.ToString("HH:mm:ss")
                                        Application.DoEvents()
                                    End If
                                Next
                                slDt.DefaultView.RowFilter = ""
                                CurrDate = DateAdd(DateInterval.Day, 1, CurrDate)
                            Loop While CurrDate <= DateAdd(DateInterval.Day, Convert.ToInt16(MaxAppointmentDay), DateTime.Now).Date
                        End If
                        slDt.Dispose()
                    End If
                Next
            End If
            sDt.Dispose()
        Catch ex As Exception

        End Try

    End Sub
End Class
