
Imports System.Data.Linq 
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports System.Linq.Expressions 

Namespace TABLE
    'Represents a transaction for TB_MESSAGE_COUNTER table Parameter.
    '[Create by  on March, 26 2012]

    <Table(Name:="TB_MESSAGE_COUNTER")>  _
    Public Class TbMessageCounterShParaDB

        'Generate Field List
        Dim _ID As Long = 0
        Dim _COUNTER_ID As  System.Nullable(Of Long)  = 0
        Dim _COUNTER_SEND As  System.Nullable(Of Long)  = 0
        Dim _MESSAGE As  String  = ""
        Dim _MESSAGE_STATUS As  System.Nullable(Of Long)  = 0
        Dim _CREATE_BY As  System.Nullable(Of Long)  = 0
        Dim _CREATE_DATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _UPDATE_BY As  System.Nullable(Of Long)  = 0
        Dim _UPDATE_DATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)

        'Generate Field Property 
        <Column(Storage:="_ID", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property ID() As Long
            Get
                Return _ID
            End Get
            Set(ByVal value As Long)
               _ID = value
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
        <Column(Storage:="_COUNTER_SEND", DbType:="Int")>  _
        Public Property COUNTER_SEND() As  System.Nullable(Of Long) 
            Get
                Return _COUNTER_SEND
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _COUNTER_SEND = value
            End Set
        End Property 
        <Column(Storage:="_MESSAGE", DbType:="VarChar(200)")>  _
        Public Property MESSAGE() As  String 
            Get
                Return _MESSAGE
            End Get
            Set(ByVal value As  String )
               _MESSAGE = value
            End Set
        End Property 
        <Column(Storage:="_MESSAGE_STATUS", DbType:="SmallInt")>  _
        Public Property MESSAGE_STATUS() As  System.Nullable(Of Long) 
            Get
                Return _MESSAGE_STATUS
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _MESSAGE_STATUS = value
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


    End Class
End Namespace