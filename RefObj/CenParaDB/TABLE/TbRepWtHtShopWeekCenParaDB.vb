
Imports System.Data.Linq 
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports System.Linq.Expressions 

Namespace TABLE
    'Represents a transaction for TB_REP_WT_HT_SHOP_WEEK table Parameter.
    '[Create by  on March, 14 2013]

    <Table(Name:="TB_REP_WT_HT_SHOP_WEEK")>  _
    Public Class TbRepWtHtShopWeekCenParaDB

        'Generate Field List
        Dim _ID As Long = 0
        Dim _CREATE_BY As String = ""
        Dim _CREATE_DATE As DateTime = New DateTime(1,1,1)
        Dim _UPDATE_BY As  String  = ""
        Dim _UPDATE_DATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _SHOP_ID As Long = 0
        Dim _SHOP_NAME_TH As String = ""
        Dim _SHOP_NAME_EN As String = ""
        Dim _SHOW_YEAR As Long = 0
        Dim _WEEK_OF_YEAR As Long = 0
        Dim _PERIOD_DATE As String = ""
        Dim _SERVICE_ID As Long = 0
        Dim _SERVICE_NAME_EN As String = ""
        Dim _SERVICE_NAME_TH As String = ""
        Dim _REGIS As Long = 0
        Dim _SERVE As Long = 0
        Dim _MISSED_CALL As Long = 0
        Dim _CANCLE As Long = 0
        Dim _INCOMPLETE As Long = 0
        Dim _AWT As Long = 0
        Dim _AHT As Long = 0
        Dim _ACT As Long = 0
        Dim _COUNT_WT As Long = 0
        Dim _SUM_WT As Long = 0
        Dim _COUNT_HT As Long = 0
        Dim _SUM_HT As Long = 0
        Dim _COUNT_CT As Long = 0
        Dim _SUM_CT As Long = 0

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
        <Column(Storage:="_SHOW_YEAR", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property SHOW_YEAR() As Long
            Get
                Return _SHOW_YEAR
            End Get
            Set(ByVal value As Long)
               _SHOW_YEAR = value
            End Set
        End Property 
        <Column(Storage:="_WEEK_OF_YEAR", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property WEEK_OF_YEAR() As Long
            Get
                Return _WEEK_OF_YEAR
            End Get
            Set(ByVal value As Long)
               _WEEK_OF_YEAR = value
            End Set
        End Property 
        <Column(Storage:="_PERIOD_DATE", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property PERIOD_DATE() As String
            Get
                Return _PERIOD_DATE
            End Get
            Set(ByVal value As String)
               _PERIOD_DATE = value
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
        <Column(Storage:="_SERVICE_NAME_EN", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property SERVICE_NAME_EN() As String
            Get
                Return _SERVICE_NAME_EN
            End Get
            Set(ByVal value As String)
               _SERVICE_NAME_EN = value
            End Set
        End Property 
        <Column(Storage:="_SERVICE_NAME_TH", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property SERVICE_NAME_TH() As String
            Get
                Return _SERVICE_NAME_TH
            End Get
            Set(ByVal value As String)
               _SERVICE_NAME_TH = value
            End Set
        End Property 
        <Column(Storage:="_REGIS", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property REGIS() As Long
            Get
                Return _REGIS
            End Get
            Set(ByVal value As Long)
               _REGIS = value
            End Set
        End Property 
        <Column(Storage:="_SERVE", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property SERVE() As Long
            Get
                Return _SERVE
            End Get
            Set(ByVal value As Long)
               _SERVE = value
            End Set
        End Property 
        <Column(Storage:="_MISSED_CALL", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property MISSED_CALL() As Long
            Get
                Return _MISSED_CALL
            End Get
            Set(ByVal value As Long)
               _MISSED_CALL = value
            End Set
        End Property 
        <Column(Storage:="_CANCLE", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property CANCLE() As Long
            Get
                Return _CANCLE
            End Get
            Set(ByVal value As Long)
               _CANCLE = value
            End Set
        End Property 
        <Column(Storage:="_INCOMPLETE", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property INCOMPLETE() As Long
            Get
                Return _INCOMPLETE
            End Get
            Set(ByVal value As Long)
               _INCOMPLETE = value
            End Set
        End Property 
        <Column(Storage:="_AWT", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property AWT() As Long
            Get
                Return _AWT
            End Get
            Set(ByVal value As Long)
               _AWT = value
            End Set
        End Property 
        <Column(Storage:="_AHT", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property AHT() As Long
            Get
                Return _AHT
            End Get
            Set(ByVal value As Long)
               _AHT = value
            End Set
        End Property 
        <Column(Storage:="_ACT", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property ACT() As Long
            Get
                Return _ACT
            End Get
            Set(ByVal value As Long)
               _ACT = value
            End Set
        End Property 
        <Column(Storage:="_COUNT_WT", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property COUNT_WT() As Long
            Get
                Return _COUNT_WT
            End Get
            Set(ByVal value As Long)
               _COUNT_WT = value
            End Set
        End Property 
        <Column(Storage:="_SUM_WT", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property SUM_WT() As Long
            Get
                Return _SUM_WT
            End Get
            Set(ByVal value As Long)
               _SUM_WT = value
            End Set
        End Property 
        <Column(Storage:="_COUNT_HT", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property COUNT_HT() As Long
            Get
                Return _COUNT_HT
            End Get
            Set(ByVal value As Long)
               _COUNT_HT = value
            End Set
        End Property 
        <Column(Storage:="_SUM_HT", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property SUM_HT() As Long
            Get
                Return _SUM_HT
            End Get
            Set(ByVal value As Long)
               _SUM_HT = value
            End Set
        End Property 
        <Column(Storage:="_COUNT_CT", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property COUNT_CT() As Long
            Get
                Return _COUNT_CT
            End Get
            Set(ByVal value As Long)
               _COUNT_CT = value
            End Set
        End Property 
        <Column(Storage:="_SUM_CT", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property SUM_CT() As Long
            Get
                Return _SUM_CT
            End Get
            Set(ByVal value As Long)
               _SUM_CT = value
            End Set
        End Property 


    End Class
End Namespace