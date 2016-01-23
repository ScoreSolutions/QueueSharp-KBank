Imports System.IO
Imports Engine.Common
Namespace CSI


    Public Class CSIMasterENG
        Dim _err As String = ""
        Public ReadOnly Property ErrorMessage() As String
            Get
                Return _err
            End Get
        End Property

        Public Function SaveTWLocation(ByVal LoginName As String, ByVal para As CenParaDB.TABLE.TwLocationCenParaDB, ByVal trans As CenLinqDB.Common.Utilities.TransactionDB) As Boolean
            Dim lnq As New CenLinqDB.TABLE.TwLocationCenLinqDB
            If para.ID <> 0 Then
                lnq.GetDataByPK(para.ID, trans.Trans)
            End If
            lnq.LOCATION_CODE = para.LOCATION_CODE
            lnq.LOCATION_NAME_TH = para.LOCATION_NAME_TH
            lnq.LOCATION_SEGMENT = para.LOCATION_SEGMENT
            lnq.PROVINCE_CODE = para.PROVINCE_CODE
            lnq.REGION_CODE = para.REGION_CODE
            lnq.LOCATION_TYPE = para.LOCATION_TYPE

            Dim ret As Boolean
            If lnq.ID <> 0 Then
                ret = lnq.UpdateByPK(LoginName, trans.Trans)
            Else
                ret = lnq.InsertData(LoginName, trans.Trans)
            End If
            If ret = False Then
                _err = lnq.ErrorMessage
            End If
            Return ret
        End Function

        Public Function CheckDuplicateLocation(ByVal LocationCode As String, ByVal LocationID As Long) As Boolean
            Dim ret As Boolean = False
            Dim trans As New CenLinqDB.Common.Utilities.TransactionDB
            If trans.Trans IsNot Nothing Then
                Dim lnq As New CenLinqDB.TABLE.TwLocationCenLinqDB
                ret = lnq.ChkDuplicateByLOCATION_CODE(LocationCode, LocationID, trans.Trans)
                trans.CommitTransaction()
            End If
            Return ret
        End Function

        Public Function GetTWLocationPara(ByVal vID As Long, ByVal trans As CenLinqDB.Common.Utilities.TransactionDB) As CenParaDB.TABLE.TwLocationCenParaDB
            Dim para As New CenParaDB.TABLE.TwLocationCenParaDB
            Dim lnq As New CenLinqDB.TABLE.TwLocationCenLinqDB
            para = lnq.GetParameter(vID, trans.Trans)

            Return para
        End Function

        Public Function GetTWLocationByCode(ByVal LocationCode As String, ByVal trans As CenLinqDB.Common.Utilities.TransactionDB) As CenLinqDB.TABLE.TwLocationCenLinqDB
            'Dim para As New CenParaDB.TABLE.TwLocationCenParaDB
            Dim lnq As New CenLinqDB.TABLE.TwLocationCenLinqDB
            lnq.ChkDataByLOCATION_CODE(LocationCode, trans.Trans)

            Return lnq
        End Function

        Public Function GetTWLocationList(ByVal WhText As String) As DataTable
            Dim sql As String = ""
            sql += " select location_code,location_name_th,location_segment,province_code,region_code,location_type,id from TW_LOCATION"
            sql += " where active = 'Y' and " & WhText
            sql += " order by location_code "

            Dim dt As New DataTable
            Dim trans As New CenLinqDB.Common.Utilities.TransactionDB
            If trans.Trans IsNot Nothing Then
                Dim lnq As New CenLinqDB.TABLE.TwLocationCenLinqDB
                dt = lnq.GetListBySql(sql, trans.Trans)
                trans.CommitTransaction()
            End If

            Return dt
        End Function

        Public Function DeleteTWLocation(ByVal ID As Long) As Boolean
            Dim ret As Boolean = False
            Dim trans As New CenLinqDB.Common.Utilities.TransactionDB
            If trans.Trans IsNot Nothing Then
                Dim lnq As New CenLinqDB.TABLE.TwLocationCenLinqDB
                ret = lnq.DeleteByPK(ID, trans.Trans)
                If ret = True Then
                    trans.CommitTransaction()
                Else
                    trans.RollbackTransaction()
                End If
            End If

            Return ret
        End Function

        
    End Class
End Namespace