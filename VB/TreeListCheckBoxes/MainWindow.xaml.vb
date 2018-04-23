Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Windows
Imports DevExpress.Xpf.Grid
Imports DevExpress.Xpf.Editors

Namespace TreeListCheckBoxes
	Partial Public Class MainWindow
		Inherits Window
		Public Shared ReadOnly ApplyCheckedOnChildrenProperty As DependencyProperty = DependencyProperty.RegisterAttached("ApplyCheckedOnChildren", GetType(Boolean), GetType(MainWindow), New PropertyMetadata(False))

		Public Shared Sub SetApplyCheckedOnChildren(ByVal element As UIElement, ByVal value As Boolean)
			element.SetValue(ApplyCheckedOnChildrenProperty, value)
		End Sub

		Public Shared Function GetApplyCheckedOnChildren(ByVal element As UIElement) As Boolean
			Return CBool(element.GetValue(ApplyCheckedOnChildrenProperty))
		End Function

		Public Shared ReadOnly ApplyCheckedOnAncestorsProperty As DependencyProperty = DependencyProperty.RegisterAttached("ApplyCheckedOnAncestors", GetType(Boolean), GetType(MainWindow), New PropertyMetadata(False))

		Public Shared Sub SetApplyCheckedOnAncestors(ByVal element As UIElement, ByVal value As Boolean)
			element.SetValue(ApplyCheckedOnAncestorsProperty, value)
		End Sub

		Public Shared Function GetApplyCheckedOnAncestors(ByVal element As UIElement) As Boolean
			Return CBool(element.GetValue(ApplyCheckedOnAncestorsProperty))
		End Function

		Public Sub New()
			InitializeComponent()
			InitTreeList()
		End Sub

		Private Sub InitTreeList()
			treeListView1.Nodes.Add(New TreeListNode(New Person With {.IsChecked = True, .FirstName = "Billy", .LastName = "Kelm"}))
			treeListView1.Nodes.Add(New TreeListNode(New Person With {.IsChecked = False, .FirstName = "Edwin", .LastName = "Thone"}))
			treeListView1.Nodes(0).Nodes.Add(New TreeListNode(New Person With {.IsChecked = False, .FirstName = "Daniel", .LastName = "Earwood"}))
			treeListView1.Nodes(0).Nodes(0).Nodes.Add(New TreeListNode(New Person With {.IsChecked = False, .FirstName = "Anne", .LastName = "Peacock"}))
			treeListView1.Nodes(0).Nodes(0).Nodes.Add(New TreeListNode(New Person With {.IsChecked = False, .FirstName = "Steven", .LastName = "Fuller"}))
			treeListView1.Nodes(1).Nodes.Add(New TreeListNode(New Person With {.IsChecked = False, .FirstName = "Steven", .LastName = "King"}))
		End Sub

		Private Shared Sub SetForChildren(ByVal node As TreeListNode, ByVal value As Boolean)
			For Each childNode As TreeListNode In node.Nodes
				CType(childNode.Content, Person).IsChecked = value
				SetForChildren(childNode, value)
			Next childNode
		End Sub

		Private Shared Sub SetForAncestors(ByVal node As TreeListNode, ByVal value As Boolean)
			Dim parentNode As TreeListNode = node.ParentNode
			Do While parentNode IsNot Nothing
				CType(parentNode.Content, Person).IsChecked = value
				parentNode = parentNode.ParentNode
			Loop
		End Sub

		Private Sub CheckEdit_PreviewMouseDown(ByVal sender As Object, ByVal e As System.Windows.Input.MouseButtonEventArgs)
			Dim editor As CheckEdit = TryCast(sender, CheckEdit)
			Dim cellData As EditGridCellData = TryCast(editor.DataContext, EditGridCellData)
			Dim view As TreeListView = TryCast(cellData.View, TreeListView)
			Dim node As TreeListNode = view.GetNodeByRowHandle(cellData.RowData.RowHandle.Value)
			If node Is Nothing Then
				Return
			End If
			Dim applyOnAncestors As Boolean = Object.Equals(view.GetValue(MainWindow.ApplyCheckedOnAncestorsProperty), True)
			Dim applyOnChildren As Boolean = Object.Equals(view.GetValue(MainWindow.ApplyCheckedOnChildrenProperty), True)
			If applyOnAncestors Then
				SetForAncestors(node, (Not CBool(editor.EditValue)))
			End If
			If applyOnChildren Then
				SetForChildren(node, (Not CBool(editor.EditValue)))
			End If
		End Sub
	End Class
End Namespace
