Namespace CSI
    Public Class CSIReportsENG
        Public Function GetDetailDataList(ByVal whText As String) As DataTable
            Dim sql As String = ""
            sql += " select fd.tb_filter_id, f.filter_name, s.id shop_id,s.shop_code, s.shop_name_en, ti.id item_id, ti.item_name, "
            sql += " fd.end_time, fd.filter_time, fd.send_time, fd.atsr_call_time, fd.mobile_no, fd.result,  fd.customer_name, fd.username, fd.nps_score, fd.network_type"
            sql += " from  TB_FILTER_DATA fd"
            sql += " inner join TB_FILTER_SERVICE fs on fd.tb_filter_id= fs.tb_filter_id and fd.tb_item_id=fs.tb_item_id "
            sql += " inner join TB_FILTER f on f.id=fd.tb_filter_id"
            sql += " inner join TB_ITEM ti on ti.id=fs.tb_item_id"
            sql += " inner join TB_SHOP s on s.id=fd.shop_id "
            sql += " where " & whText
            sql += " order by s.shop_name_en, ti.item_name, fd.send_time"

            Dim lnq As New CenLinqDB.TABLE.TbFilterDataCenLinqDB
            Dim trans As New CenLinqDB.Common.Utilities.TransactionDB
            Dim dt As New DataTable
            dt = lnq.GetListBySql(sql, trans.Trans)
            trans.CommitTransaction()

            Return dt
        End Function

        Public Function GetCSIDataList(ByVal WhText As String) As DataTable
            Dim sql As String = ""
            sql += " select datename(MONTH, fd.send_time) + ' ' + LTRIM(RTRIM(str(year(fd.send_time)))) month_name," & vbNewLine
            sql += " s.shop_code, s.shop_name_en, ti.id item_id, ti.item_name," & vbNewLine
            sql += " sum(case fd.result when 'ดีมาก' then 1 else 0 end) result_very_good," & vbNewLine
            sql += " sum(case fd.result when 'ดี' then 1 else 0 end) result_good," & vbNewLine
            sql += " sum(case fd.result when 'ควรปรับปรุง' then 1 else 0 end) result_adjust" & vbNewLine
            sql += " from  TB_FILTER_DATA fd" & vbNewLine
            sql += " inner join TB_FILTER_SERVICE fs on fd.tb_filter_id= fs.tb_filter_id and fd.tb_item_id=fs.tb_item_id " & vbNewLine
            sql += " inner join TB_ITEM ti on ti.id=fs.tb_item_id" & vbNewLine
            sql += " inner join TB_SHOP s on s.id=fd.shop_id" & vbNewLine
            sql += " where " & WhText & vbNewLine
            sql += " group by s.shop_code, s.shop_name_en, ti.id, ti.item_name," & vbNewLine
            sql += " datename(MONTH, fd.send_time),year(fd.send_time)" & vbNewLine
            sql += " order by s.shop_name_en, ti.item_name" & vbNewLine

            Dim lnq As New CenLinqDB.TABLE.TbFilterDataCenLinqDB
            Dim trans As New CenLinqDB.Common.Utilities.TransactionDB
            Dim dt As New DataTable
            dt = lnq.GetListBySql(sql, trans.Trans)
            trans.CommitTransaction()

            Return dt
        End Function

        Public Function GetCSIByAgentDataList(ByVal WhText As String) As DataTable
            Dim sql As String = ""
            sql += " select datename(MONTH, fd.send_time) + ' ' + LTRIM(RTRIM(str(year(fd.send_time)))) month_name," & vbNewLine
            sql += " s.shop_code, s.shop_name_en, ti.id item_id, ti.item_name,username," & vbNewLine
            sql += " sum(case fd.result when 'ดีมาก' then 1 else 0 end) result_very_good," & vbNewLine
            sql += " sum(case fd.result when 'ดี' then 1 else 0 end) result_good," & vbNewLine
            sql += " sum(case fd.result when 'ควรปรับปรุง' then 1 else 0 end) result_adjust" & vbNewLine
            sql += " from  TB_FILTER_DATA fd" & vbNewLine
            sql += " inner join TB_FILTER_SERVICE fs on fd.tb_filter_id= fs.tb_filter_id and fd.tb_item_id=fs.tb_item_id " & vbNewLine
            sql += " inner join TB_ITEM ti on ti.id=fs.tb_item_id" & vbNewLine
            sql += " inner join TB_SHOP s on s.id=fd.shop_id" & vbNewLine
            'sql += " where fd.shop_id=1"
            sql += " where " & WhText & vbNewLine
            sql += " group by s.shop_code, s.shop_name_en, ti.id, ti.item_name,username," & vbNewLine
            sql += " datename(MONTH, fd.send_time),year(fd.send_time)" & vbNewLine
            sql += " order by s.shop_name_en, ti.item_name" & vbNewLine

            Dim lnq As New CenLinqDB.TABLE.TbFilterDataCenLinqDB
            Dim trans As New CenLinqDB.Common.Utilities.TransactionDB
            Dim dt As New DataTable
            dt = lnq.GetListBySql(sql, trans.Trans)
            trans.CommitTransaction()

            Return dt
        End Function

        Public Function GetNPSSCOREDataList(ByVal whText As String) As DataTable
            Dim sql As String = ""
            sql += "select count(fd.id) GrandTo,shop_id ,r.id as region_id," & _
             " s.shop_code,s.shop_name_en,  r.region_code,r.region_name_en ," & _
             " SUM(case fd.nps_score when 0 then 1 else 0 end) score_0," & _
             " SUM(case fd.nps_score when 1 then 1 else 0 end) score_1," & _
             " SUM(case fd.nps_score when 2 then 1 else 0 end) score_2," & _
             " SUM(case fd.nps_score when 3 then 1 else 0 end) score_3," & _
             " SUM(case fd.nps_score when 4 then 1 else 0 end) score_4," & _
             " SUM(case fd.nps_score when 5 then 1 else 0 end) score_5," & _
             " SUM(case fd.nps_score when 6 then 1 else 0 end) score_6," & _
             " SUM(case fd.nps_score when 7 then 1 else 0 end) score_7," & _
             " SUM(case fd.nps_score when 8 then 1 else 0 end) score_8," & _
             " SUM(case fd.nps_score when 9 then 1 else 0 end) score_9," & _
             " SUM(case fd.nps_score when 10 then 1 else 0 end) score_10" & _
             " from TB_FILTER_DATA fd  " & _
             " left join TB_SHOP S on fd.shop_id=S.id  " & _
             " left join TB_REGION R on s.region_id = r.id" & _
             " where result_status =2 and nps_score <> -1"
            sql += " and " & whText
            sql += " group by shop_id ,r.id, s.shop_code, s.shop_name_en, r.region_code, r.region_name_en "
            sql += " order by s.shop_code, s.shop_name_en "

            Dim lnq As New CenLinqDB.TABLE.TbFilterDataCenLinqDB
            Dim trans As New CenLinqDB.Common.Utilities.TransactionDB
            Dim dt As New DataTable
            dt = lnq.GetListBySql(sql, trans.Trans)
            trans.CommitTransaction()

            Return dt
        End Function

        Public Function GetNPSSCOREByAgentDataList(ByVal whText As String) As DataTable
            Dim sql As String = ""
            sql += "select count(fd.id) GrandTo,shop_id ,r.id as region_id," & _
             " s.shop_code,s.shop_name_en,  r.region_code,r.region_name_en ,fd.username," & _
             " SUM(case fd.nps_score when 0 then 1 else 0 end) score_0," & _
             " SUM(case fd.nps_score when 1 then 1 else 0 end) score_1," & _
             " SUM(case fd.nps_score when 2 then 1 else 0 end) score_2," & _
             " SUM(case fd.nps_score when 3 then 1 else 0 end) score_3," & _
             " SUM(case fd.nps_score when 4 then 1 else 0 end) score_4," & _
             " SUM(case fd.nps_score when 5 then 1 else 0 end) score_5," & _
             " SUM(case fd.nps_score when 6 then 1 else 0 end) score_6," & _
             " SUM(case fd.nps_score when 7 then 1 else 0 end) score_7," & _
             " SUM(case fd.nps_score when 8 then 1 else 0 end) score_8," & _
             " SUM(case fd.nps_score when 9 then 1 else 0 end) score_9," & _
             " SUM(case fd.nps_score when 10 then 1 else 0 end) score_10" & _
             " from TB_FILTER_DATA fd  " & _
             " left join TB_SHOP S on fd.shop_id=S.id  " & _
             " left join TB_REGION R on s.region_id = r.id" & _
             " where result_status =2 and nps_score <> -1"
            sql += " and " & whText
            sql += " group by shop_id ,r.id, s.shop_code, s.shop_name_en, r.region_code, r.region_name_en, fd.username "
            sql += " order by s.shop_code, s.shop_name_en "

            Dim lnq As New CenLinqDB.TABLE.TbFilterDataCenLinqDB
            Dim trans As New CenLinqDB.Common.Utilities.TransactionDB
            Dim dt As New DataTable
            dt = lnq.GetListBySql(sql, trans.Trans)
            trans.CommitTransaction()

            Return dt
        End Function

        Public Function GetTWDetailDataList(ByVal whText As String) As DataTable
            Dim sql As String = ""
            sql += " select fd.tw_filter_id,F.filter_name,Fd.tw_location_id,L.location_code,l.region_code,l.province_code,"
            sql += " L.location_name_th ,fd.order_type_name,fd.end_time,fd.filter_time,"
            sql += " fd.send_time, fd.atsr_call_time, fd.mobile_no, fd.result, fd.customer_name, fd.network_type,fd.nps_score"
            sql += " from  TW_FILTER_DATA fd"
            sql += " inner join TW_FILTER F on F.id=fd.tw_filter_id"
            sql += " inner join TW_LOCATION L on L.id=fd.tw_location_id"
            sql += " where " & whText
            sql += " order by l.region_code,l.province_code,L.location_name_th, fd.order_type_name, fd.send_time"

            Dim lnq As New CenLinqDB.TABLE.TwFilterDataCenLinqDB
            Dim trans As New CenLinqDB.Common.Utilities.TransactionDB
            Dim dt As New DataTable
            dt = lnq.GetListBySql(sql, trans.Trans)
            trans.CommitTransaction()

            Return dt
        End Function

        Public Function GetTWCSIDataList(ByVal WhText As String) As DataTable
            Dim sql As String = ""
            sql += " select L.location_code,L.location_name_th, L.province_code,L.region_code,L.location_segment," & vbNewLine
            sql += " sum(case fd.result when 'ดีมาก' then 1 else 0 end) result_very_good," & vbNewLine
            sql += " sum(case fd.result when 'ดี' then 1 else 0 end) result_good," & vbNewLine
            sql += " sum(case fd.result when 'ควรปรับปรุง' then 1 else 0 end) result_adjust" & vbNewLine
            sql += " from  TW_FILTER_DATA fd" & vbNewLine
            sql += " inner join TW_FILTER F on F.id=fd.tw_filter_id" & vbNewLine
            sql += " inner join TW_LOCATION L on L.id=fd.tw_location_id" & vbNewLine
            sql += " where  " & WhText & vbNewLine
            'sql += " and fd.result_status='2'"
            sql += " group by L.location_code, L.location_name_th, L.province_code,L.region_code,L.location_segment" & vbNewLine
            sql += " order by L.region_code,L.province_code, L.location_name_th"

            Dim lnq As New CenLinqDB.TABLE.TwFilterDataCenLinqDB
            Dim trans As New CenLinqDB.Common.Utilities.TransactionDB
            Dim dt As New DataTable
            dt = lnq.GetListBySql(sql, trans.Trans)
            trans.CommitTransaction()

            Return dt
        End Function

        Public Function GetTWNPSSCOREDataList(ByVal whText As String) As DataTable
            Dim sql As String = ""
            sql += " select count(fd.id) GrandTo,fd.tw_location_id shop_id ,"
            sql += " L.location_code shop_code,L.location_name_th shop_name_en, region_code ,"
            sql += " SUM(case fd.nps_score when 0 then 1 else 0 end) score_0,"
            sql += " SUM(case fd.nps_score when 1 then 1 else 0 end) score_1,"
            sql += " SUM(case fd.nps_score when 2 then 1 else 0 end) score_2,"
            sql += " SUM(case fd.nps_score when 3 then 1 else 0 end) score_3,"
            sql += " SUM(case fd.nps_score when 4 then 1 else 0 end) score_4,"
            sql += " SUM(case fd.nps_score when 5 then 1 else 0 end) score_5,"
            sql += " SUM(case fd.nps_score when 6 then 1 else 0 end) score_6,"
            sql += " SUM(case fd.nps_score when 7 then 1 else 0 end) score_7,"
            sql += " SUM(case fd.nps_score when 8 then 1 else 0 end) score_8,"
            sql += " SUM(case fd.nps_score when 9 then 1 else 0 end) score_9,"
            sql += " SUM(case fd.nps_score when 10 then 1 else 0 end) score_10"
            sql += " from TW_FILTER_DATA fd  "
            sql += " left join TW_LOCATION L on fd.tw_location_id=L.ID  "
            sql += " where result_status = 2 And nps_score <> -1 "
            sql += " and " & whText
            sql += " group by fd.tw_location_id ,L.location_code,L.location_name_th,region_code"
            sql += " order by L.location_code, L.location_name_th "

            Dim lnq As New CenLinqDB.TABLE.TbFilterDataCenLinqDB
            Dim trans As New CenLinqDB.Common.Utilities.TransactionDB
            Dim dt As New DataTable
            dt = lnq.GetListBySql(sql, trans.Trans)
            trans.CommitTransaction()

            Return dt
        End Function
    End Class
End Namespace

