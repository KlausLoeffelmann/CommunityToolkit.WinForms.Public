Option Strict On
Option Explicit On
Option Infer Off

Imports System

Namespace Fubar

    Public Class MyClass
        Private ReadOnly _startDate As DateTime

        Private Shared ReadOnly s_staticMessage As String = "Hello from static land!"

        Public Shared ReadOnly Property StaticValue As Integer

        Shared Sub New()
            StaticValue = 42
        End Sub

        Public Sub New(startDate As DateTime, endDate As DateTime)
            If endDate < startDate Then
                Throw New ArgumentException("End date must be after start date.")
            End If

            _startDate = startDate

            endDate = endDate
        End Sub

        Public ReadOnly Property EndDate As DateTime

        Public ReadOnly Property DaysInRange As Integer
            Get
                Return (EndDate - _startDate).Days + 1
            End Get
        End Property

        Default Public ReadOnly Property Item(index As Integer) As DateTime
            Get
                If index < 0 OrElse index >= DaysInRange Then
                    Throw New IndexOutOfRangeException()
                End If

                Return _startDate.AddDays(index)
            End Get
        End Property

        Public Event MyEvent As EventHandler

        Public Sub DoSomething()
            RaiseEvent MyEvent(Me, EventArgs.Empty)
        End Sub

        Public Shared Function GetStaticMessage() As String
            Return s_staticMessage
        End Function

        Public Class NestedClass
            Public Property Name As String
        End Class
    End Class
End Namespace
