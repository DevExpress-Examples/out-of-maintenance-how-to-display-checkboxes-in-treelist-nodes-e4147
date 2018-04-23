Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.ComponentModel

Namespace TreeListCheckBoxes
    Public Class Person
        Public Property IsChecked() As Boolean
        Public Property FirstName() As String
        Public Property LastName() As String
        Public Property Children() As List(Of Person)
        Public Sub New()
            Children = New List(Of Person)()
        End Sub
    End Class
End Namespace
