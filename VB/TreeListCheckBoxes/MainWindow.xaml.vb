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
            Persons = New List(Of Person) From { _
                New Person With { _
                    .IsChecked = True, .FirstName = "Billy", .LastName = "Kelm", .Children = New List(Of Person) From { _
                        New Person With { _
                            .IsChecked = True, .FirstName = "Daniel", .LastName = "Earwood", .Children = New List(Of Person) From { _
                                New Person With {.IsChecked = True, .FirstName = "Anne", .LastName = "Peacock"}, _
                                New Person With {.IsChecked = True, .FirstName = "Steven", .LastName = "Fuller"} _
                            } _
                        } _
                    } _
                }, _
                New Person With { _
                    .IsChecked = False, .FirstName = "Edwin", .LastName = "Thone", .Children = New List(Of Person) From { _
                        New Person With {.IsChecked = False, .FirstName = "Steven", .LastName = "King"} _
                    } _
                } _
            }
        End Sub
    End Class
End Namespace
