
Imports System.Data.Linq 
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports System.Linq.Expressions 

Namespace TABLE
    'Represents a transaction for TB_LOGFILE_HISTORY table Parameter.
    '[Create by  on March, 26 2012]

    <Table(Name:="TB_LOGFILE_HISTORY")>  _
    Public Class TbLogfileHistoryShParaDB

        'Generate Field List
        Dim _ID As Long = 0
        Dim _CREATE_BY As  String  = ""
        Dim _CREATE_DATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _UPDATE_BY As  String  = ""
        Dim _UPDATE_DATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _CQ_ID As  System.Nullable(Of Long)  = 0
        Dim _LOG_DATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _QUEUE_NO As  String  = ""
        Dim _CUSTOMER_ID As  String  = ""
        Dim _USER_ID As  System.Nullable(Of Long)  = 0
        Dim _ITEM_ID As  System.Nullable(Of Long)  = 0
        Dim _COUNTER_ID As  System.Nullable(Of Long)  = 0
        Dim _FLAG As  String  = ""
        Dim _STATUS As  System.Nullable(Of Long)  = 0
        Dim _TB_LOG_FILE_ID As Long = 0

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
        <Column(Storage:="_CREATE_BY", DbType:="VarChar(50)")>  _
        Public Property CREATE_BY() As  String 
            Get
                Return _CREATE_BY
            End Get
            Set(ByVal value As  String )
               _CREATE_BY = value
            End Set
        End Property 
        <Column(Storage:="_CREATE_DATE", DbType:="DateTime")>  _
        Public Property CREATE_DATE() As  System.Nullable(Of DateTime) 
            Get
                Return _CREATE_DATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
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
        <Column(Storage:="_CQ_ID", DbType:="Int")>  _
        Public Property CQ_ID() As  System.Nullable(Of Long) 
            Get
                Return _CQ_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _CQ_ID = value
            End Set
        End Property 
        <Column(Storage:="_LOG_DATE", DbType:="DateTime")>  _
        Public Property LOG_DATE() As  System.Nullable(Of DateTime) 
            Get
                Return _LOG_DATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _LOG_DATE = value
            End Set
        End Property 
        <Column(Storage:="_QUEUE_NO", DbType:="VarChar(20)")>  _
        Public Property QUEUE_NO() As  String 
            Get
                Return _QUEUE_NO
            End Get
            Set(ByVal value As  String )
               _QUEUE_NO = value
            End Set
        End Property 
        <Column(Storage:="_CUSTOMER_ID", DbType:="VarChar(20)")>  _
        Public Property CUSTOMER_ID() As  String 
            Get
                Return _CUSTOMER_ID
            End Get
            Set(ByVal value As  String )
               _CUSTOMER_ID = value
            End Set
        End Property 
        <Column(Storage:="_USER_ID", DbType:="Int")>  _
        Public Property USER_ID() As  System.Nullable(Of Long) 
            Get
                Return _USER_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _USER_ID = value
            End Set
        End Property 
        <Column(Storage:="_ITEM_ID", DbType:="Int")>  _
        Public Property ITEM_ID() As  System.Nullable(Of Long) 
            Get
                Return _ITEM_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _ITEM_ID = value
            End Set
        End Property 
        <Column(Storage:="_COUNTER_ID", DbType:="Int")>  _
        Public Property COUNTER_ID() As  System.Nullable(Of Long) 
            Get
                Return _COUNTER_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _COUNTER_ID = value
            End Set
        End Property 
        <Column(Storage:="_FLAG", DbType:="VarChar(500)")>  _
        Public Property FLAG() As  String 
            Get
                Return _FLAG
            End Get
            Set(ByVal value As  String )
               _FLAG = value
            End Set
        End Property 
        <Column(Storage:="_STATUS", DbType:="SmallInt")>  _
        Public Property STATUS() As  System.Nullable(Of Long) 
            Get
                Return _STATUS
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _STATUS = value
            End Set
        End Property 
        <Column(Storage:="_TB_LOG_FILE_ID", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property TB_LOG_FILE_ID() As Long
            Get
                Return _TB_LOG_FILE_ID
            End Get
            Set(ByVal value As Long)
               _TB_LOG_FILE_ID = value
            End Set
        End Property 


    End Class
End Namespace
