Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.ComponentModel

Namespace TreeListCheckBoxes
	Public Class Person
		Implements INotifyPropertyChanged
		Private isChecked_Renamed As Boolean
		Private firstName_Renamed, lastName_Renamed As String

		Public Property IsChecked() As Boolean
			Get
				Return isChecked_Renamed
			End Get
			Set(ByVal value As Boolean)
				If IsChecked = value Then
					Return
				End If
				isChecked_Renamed = value
				OnPropertyChanged("IsChecked")
			End Set
		End Property

		Public Property FirstName() As String
			Get
				Return firstName_Renamed
			End Get
			Set(ByVal value As String)
				If FirstName = value Then
					Return
				End If
				firstName_Renamed = value
				OnPropertyChanged("FirstName")
			End Set
		End Property

		Public Property LastName() As String
			Get
				Return lastName_Renamed
			End Get
			Set(ByVal value As String)
				If LastName = value Then
					Return
				End If
				lastName_Renamed = value
				OnPropertyChanged("LastName")
			End Set
		End Property

		Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

		Protected Sub OnPropertyChanged(ByVal propertyName As String)
			RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
		End Sub
	End Class
End Namespace
