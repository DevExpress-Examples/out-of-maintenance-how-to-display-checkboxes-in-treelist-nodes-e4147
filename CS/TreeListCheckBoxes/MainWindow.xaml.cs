using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Editors;

namespace TreeListCheckBoxes
{
    public partial class MainWindow : Window
    {
        public static readonly DependencyProperty ApplyCheckedOnChildrenProperty =
            DependencyProperty.RegisterAttached("ApplyCheckedOnChildren", typeof(bool), typeof(MainWindow), new PropertyMetadata(false));

        public static void SetApplyCheckedOnChildren(UIElement element, Boolean value)
        {
            element.SetValue(ApplyCheckedOnChildrenProperty, value);
        }

        public static bool GetApplyCheckedOnChildren(UIElement element)
        {
            return (bool)element.GetValue(ApplyCheckedOnChildrenProperty);
        }

        public static readonly DependencyProperty ApplyCheckedOnAncestorsProperty =
            DependencyProperty.RegisterAttached("ApplyCheckedOnAncestors", typeof(bool), typeof(MainWindow), new PropertyMetadata(false));

        public static void SetApplyCheckedOnAncestors(UIElement element, Boolean value)
        {
            element.SetValue(ApplyCheckedOnAncestorsProperty, value);
        }

        public static bool GetApplyCheckedOnAncestors(UIElement element)
        {
            return (bool)element.GetValue(ApplyCheckedOnAncestorsProperty);
        }

        public MainWindow()
        {
            InitializeComponent();
            InitTreeList();
        }

        void InitTreeList()
        {
            treeListView1.Nodes.Add(new TreeListNode(new Person { IsChecked = true, FirstName = "Billy", LastName = "Kelm" }));
            treeListView1.Nodes.Add(new TreeListNode(new Person { IsChecked = false, FirstName = "Edwin", LastName = "Thone" }));
            treeListView1.Nodes[0].Nodes.Add(new TreeListNode(new Person { IsChecked = false, FirstName = "Daniel", LastName = "Earwood" }));
            treeListView1.Nodes[0].Nodes[0].Nodes.Add(new TreeListNode(new Person { IsChecked = false, FirstName = "Anne", LastName = "Peacock" }));
            treeListView1.Nodes[0].Nodes[0].Nodes.Add(new TreeListNode(new Person { IsChecked = false, FirstName = "Steven", LastName = "Fuller" }));
            treeListView1.Nodes[1].Nodes.Add(new TreeListNode(new Person { IsChecked = false, FirstName = "Steven", LastName = "King" }));
        }

        private static void SetForChildren(TreeListNode node, bool value)
        {
            foreach (TreeListNode childNode in node.Nodes)
            {
                ((Person)childNode.Content).IsChecked = value;
                SetForChildren(childNode, value);
            }
        }

        private static void SetForAncestors(TreeListNode node, bool value)
        {
            TreeListNode parentNode = node.ParentNode;
            while (parentNode != null)
            {
                ((Person)parentNode.Content).IsChecked = value;
                parentNode = parentNode.ParentNode;
            }
        }

        private void CheckEdit_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            CheckEdit editor = sender as CheckEdit;
            EditGridCellData cellData = editor.DataContext as EditGridCellData;
            TreeListView view = cellData.View as TreeListView;
            TreeListNode node = view.GetNodeByRowHandle(cellData.RowData.RowHandle.Value);
            if (node == null)
                return;
            bool applyOnAncestors = Object.Equals(view.GetValue(MainWindow.ApplyCheckedOnAncestorsProperty), true);
            bool applyOnChildren = Object.Equals(view.GetValue(MainWindow.ApplyCheckedOnChildrenProperty), true);
            if (applyOnAncestors)
                SetForAncestors(node, !(bool)editor.EditValue);
            if (applyOnChildren)
                SetForChildren(node, !(bool)editor.EditValue);
        }
    }
}
