Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Windows
Imports DevExpress.Xpf.Grid
Imports DevExpress.Xpf.Editors

Namespace TreeListCheckBoxes
	Partial Public Class MainWindow
		Inherits Window

		Public Sub New()
			InitializeComponent()
		End Sub
	End Class

	Public Class ViewModel
		Public Property Persons() As List(Of Person)

		Public Sub New()
			Persons = New List(Of Person) _
				From {
					New Person With {.IsChecked = True, .FirstName = "Billy", .LastName = "Kelm", .Children = New List(Of Person) _
						From {
							New Person With {
								.IsChecked = True, .FirstName = "Daniel", .LastName = "Earwood", .Children = New List(Of Person) From {
									New Person With {
										.IsChecked = True,
										.FirstName = "Anne",
										.LastName = "Peacock"
									},
									New Person With {
										.IsChecked = True,
										.FirstName = "Steven",
										.LastName = "Fuller"
									}
								}
							}
						}
						},
					New Person With {
						.IsChecked = False,
						.FirstName = "Edwin",
						.LastName = "Thone",
						.Children = New List(Of Person) From {
							New Person With {
								.IsChecked = False,
								.FirstName = "Steven",
								.LastName = "King"
							}
						}
					}
				}
		End Sub
	End Class
End Namespace
