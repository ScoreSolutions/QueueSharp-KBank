
Imports System.Data.Linq 
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports System.Linq.Expressions 

Namespace TABLE
    'Represents a transaction for TB_ITEM_PRIORITY_HISTORY table Parameter.
    '[Create by  on March, 26 2012]

    <Table(Name:="TB_ITEM_PRIORITY_HISTORY")>  _
    Public Class TbItemPriorityHistoryShParaDB

        'Generate Field List
        Dim _ID As Long = 0
        Dim _ITEM_BEFORE As  System.Nullable(Of Long)  = 0
        Dim _ITEM_AFTER As  System.Nullable(Of Long)  = 0
        Dim _IMM As  System.Nullable(Of Long)  = 0
        Dim _ACTIVE_STATUS As  System.Nullable(Of Long)  = 0
        Dim _CREATE_BY As  System.Nullable(Of Long)  = 0
        Dim _CREATE_DATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _UPDATE_BY As  System.Nullable(Of Long)  = 0
        Dim _UPDATE_DATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _TB_ITEM_PRIORITY_ID As Long = 0

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
        <Column(Storage:="_ITEM_BEFORE", DbType:="Int")>  _
        Public Property ITEM_BEFORE() As  System.Nullable(Of Long) 
            Get
                Return _ITEM_BEFORE
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _ITEM_BEFORE = value
            End Set
        End Property 
        <Column(Storage:="_ITEM_AFTER", DbType:="Int")>  _
        Public Property ITEM_AFTER() As  System.Nullable(Of Long) 
            Get
                Return _ITEM_AFTER
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _ITEM_AFTER = value
            End Set
        End Property 
        <Column(Storage:="_IMM", DbType:="SmallInt")>  _
        Public Property IMM() As  System.Nullable(Of Long) 
            Get
                Return _IMM
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _IMM = value
            End Set
        End Property 
        <Column(Storage:="_ACTIVE_STATUS", DbType:="SmallInt")>  _
        Public Property ACTIVE_STATUS() As  System.Nullable(Of Long) 
            Get
                Return _ACTIVE_STATUS
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _ACTIVE_STATUS = value
            End Set
        End Property 
        <Column(Storage:="_CREATE_BY", DbType:="Int")>  _
        Public Property CREATE_BY() As  System.Nullable(Of Long) 
            Get
                Return _CREATE_BY
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
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
        <Column(Storage:="_UPDATE_BY", DbType:="Int")>  _
        Public Property UPDATE_BY() As  System.Nullable(Of Long) 
            Get
                Return _UPDATE_BY
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
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
        <Column(Storage:="_TB_ITEM_PRIORITY_ID", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property TB_ITEM_PRIORITY_ID() As Long
            Get
                Return _TB_ITEM_PRIORITY_ID
            End Get
            Set(ByVal value As Long)
               _TB_ITEM_PRIORITY_ID = value
            End Set
        End Property 


    End Class
End Namespace
