﻿
Namespace GateWay
    Public Class LDAPResponsePara
        Dim _RESULT As Boolean = False
        Dim _RESPONSE_MSG As String = ""

        Public Property RESULT() As Boolean
            Get
                Return _RESULT
            End Get
            Set(ByVal value As Boolean)
                _RESULT = value
            End Set
        End Property
        Public Property RESPONSE_MSG() As String
            Get
                Return _RESPONSE_MSG
            End Get
            Set(ByVal value As String)
                _RESPONSE_MSG = value
            End Set
        End Property
    End Class
End Namespace

