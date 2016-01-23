
Imports System.Data.Linq 
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports System.Linq.Expressions 

Namespace TABLE
    'Represents a transaction for TB_LOG_HOLD table Parameter.
    '[Create by  on March, 26 2012]

    <Table(Name:="TB_LOG_HOLD")>  _
    Public Class TbLogHoldShParaDB

        'Generate Field List
        Dim _ID As Long = 0
        Dim _CREATE_BY As  System.Nullable(Of Long)  = 0
        Dim _CREATE_DATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _UPDATE_BY As  System.Nullable(Of Long)  = 0
        Dim _UPDATE_DATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _SERVICE_DATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _USER_ID As  System.Nullable(Of Long)  = 0
        Dim _COUNTER_ID As  System.Nullable(Of Long)  = 0
        Dim _REASON_ID As  System.Nullable(Of Long)  = 0
        Dim _PRODUCTIVE As  System.Nullable(Of Long)  = 0
        Dim _ACTION As  System.Nullable(Of Long)  = 0

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
        <Column(Storage:="_SERVICE_DATE", DbType:="DateTime")>  _
        Public Property SERVICE_DATE() As  System.Nullable(Of DateTime) 
            Get
                Return _SERVICE_DATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _SERVICE_DATE = value
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
        <Column(Storage:="_COUNTER_ID", DbType:="Int")>  _
        Public Property COUNTER_ID() As  System.Nullable(Of Long) 
            Get
                Return _COUNTER_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _COUNTER_ID = value
            End Set
        End Property 
        <Column(Storage:="_REASON_ID", DbType:="Int")>  _
        Public Property REASON_ID() As  System.Nullable(Of Long) 
            Get
                Return _REASON_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _REASON_ID = value
            End Set
        End Property 
        <Column(Storage:="_PRODUCTIVE", DbType:="SmallInt")>  _
        Public Property PRODUCTIVE() As  System.Nullable(Of Long) 
            Get
                Return _PRODUCTIVE
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _PRODUCTIVE = value
            End Set
        End Property 
        <Column(Storage:="_ACTION", DbType:="SmallInt")>  _
        Public Property ACTION() As  System.Nullable(Of Long) 
            Get
                Return _ACTION
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _ACTION = value
            End Set
        End Property 


    End Class
End Namespace
