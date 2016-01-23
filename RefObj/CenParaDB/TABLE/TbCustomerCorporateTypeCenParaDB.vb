
Imports System.Data.Linq 
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports System.Linq.Expressions 

Namespace TABLE
    'Represents a transaction for TB_CUSTOMER_CORPORATE_TYPE table Parameter.
    '[Create by  on March, 26 2013]

    <Table(Name:="TB_CUSTOMER_CORPORATE_TYPE")>  _
    Public Class TbCustomerCorporateTypeCenParaDB

        'Generate Field List
        Dim _ID As Long = 0
        Dim _CREATE_BY As String = ""
        Dim _CREATE_DATE As DateTime = New DateTime(1,1,1)
        Dim _UPDATE_BY As  String  = ""
        Dim _UPDATE_DATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _CORPORATE_TYPE_CODE As String = ""
        Dim _CORPORATE_TYPE_NAME As String = ""
        Dim _PARENT_LIC As  String  = ""

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
        <Column(Storage:="_CORPORATE_TYPE_CODE", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property CORPORATE_TYPE_CODE() As String
            Get
                Return _CORPORATE_TYPE_CODE
            End Get
            Set(ByVal value As String)
               _CORPORATE_TYPE_CODE = value
            End Set
        End Property 
        <Column(Storage:="_CORPORATE_TYPE_NAME", DbType:="VarChar(200) NOT NULL ",CanBeNull:=false)>  _
        Public Property CORPORATE_TYPE_NAME() As String
            Get
                Return _CORPORATE_TYPE_NAME
            End Get
            Set(ByVal value As String)
               _CORPORATE_TYPE_NAME = value
            End Set
        End Property 
        <Column(Storage:="_PARENT_LIC", DbType:="VarChar(50)")>  _
        Public Property PARENT_LIC() As  String 
            Get
                Return _PARENT_LIC
            End Get
            Set(ByVal value As  String )
               _PARENT_LIC = value
            End Set
        End Property 


    End Class
End Namespace
