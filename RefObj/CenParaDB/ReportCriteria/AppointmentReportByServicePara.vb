﻿Namespace ReportCriteria
    Public Class AppointmentReportByServicePara
        Dim _SHOP_ID As String = ""   'ตัวอย่าง "1,2,3"
        Dim _DateFrom As String = ""
        Dim _DateTo As String = ""
        Dim _DayInWeek As String = ""   'ตัวอย่าง 1,2,3 (1=วันอาทิตย์  , 7=วันเสาร์)
        Dim _IntervalMinute As Integer = 0
        Dim _TimePeroidFrom As String = ""  'ตัวอย่าง 09:00
        Dim _TimePeroidTo As String = "" 'ตัวอย่าง 19:00
        Dim _WeekInYearFrom As Integer = 0
        Dim _WeekInYearTo As Integer = 0
        Dim _MonthFrom As Integer = 0
        Dim _MonthTo As Integer = 0
        Dim _YearFrom As Integer = 0
        Dim _YearTo As Integer = 0

        Public Property ShopID() As String
            Get
                Return _SHOP_ID
            End Get
            Set(ByVal value As String)
                _SHOP_ID = value
            End Set
        End Property
        Public Property TimeFrom() As String
            Get
                Return _TimePeroidFrom.Trim
            End Get
            Set(ByVal value As String)
                _TimePeroidFrom = False
            End Set
        End Property
        Public Property TimeTo() As String
            Get
                Return _TimePeroidTo.Trim
            End Get
            Set(ByVal value As String)
                _TimePeroidTo = value
            End Set
        End Property
        Public Property DateFrom() As String
            Get
                Return _DateFrom
            End Get
            Set(ByVal value As String)
                _DateFrom = value
            End Set
        End Property
        Public Property DateTo() As String
            Get
                Return _DateTo
            End Get
            Set(ByVal value As String)
                _DateTo = value
            End Set
        End Property
        Public Property DayInWeek() As String
            Get
                Return _DayInWeek
            End Get
            Set(ByVal value As String)
                _DayInWeek = value
            End Set
        End Property
        Public Property IntervalMinute() As Integer
            Get
                Return _IntervalMinute
            End Get
            Set(ByVal value As Integer)
                _IntervalMinute = value
            End Set
        End Property
        Public Property TimePeroidFrom() As String
            Get
                Return _TimePeroidFrom
            End Get
            Set(ByVal value As String)
                _TimePeroidFrom = value
            End Set
        End Property
        Public Property TimePeroidTo() As String
            Get
                Return _TimePeroidTo
            End Get
            Set(ByVal value As String)
                _TimePeroidTo = value
            End Set
        End Property
        Public Property WeekInYearFrom() As Integer
            Get
                Return _WeekInYearFrom
            End Get
            Set(ByVal value As Integer)
                _WeekInYearFrom = value
            End Set
        End Property
        Public Property WeekInYearTo() As Integer
            Get
                Return _WeekInYearTo
            End Get
            Set(ByVal value As Integer)
                _WeekInYearTo = value
            End Set
        End Property
        Public Property MonthFrom() As Integer
            Get
                Return _MonthFrom
            End Get
            Set(ByVal value As Integer)
                _MonthFrom = value
            End Set
        End Property
        Public Property MonthTo() As Integer
            Get
                Return _MonthTo
            End Get
            Set(ByVal value As Integer)
                _MonthTo = value
            End Set
        End Property
        Public Property YearFrom() As Integer
            Get
                Return _YearFrom
            End Get
            Set(ByVal value As Integer)
                _YearFrom = value
            End Set
        End Property
        Public Property YearTo() As Integer
            Get
                Return _YearTo
            End Get
            Set(ByVal value As Integer)
                _YearTo = value
            End Set
        End Property
    End Class
End Namespace

