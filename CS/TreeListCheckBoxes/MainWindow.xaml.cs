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
        public MainWindow()
        {
            InitializeComponent();
        }
    }

    public class ViewModel {
        public List<Person> Persons { get; set; }

        public ViewModel() {
            Persons = new List<Person> {
                new Person { IsChecked = true, FirstName = "Billy", LastName = "Kelm", Children = new List<Person> {
                    new Person { IsChecked = true, FirstName = "Daniel", LastName = "Earwood", Children = new List<Person> {
                        new Person { IsChecked = true, FirstName = "Anne", LastName = "Peacock" },
                        new Person { IsChecked = true, FirstName = "Steven", LastName = "Fuller" }
                    } }
                } },
                new Person { IsChecked = false, FirstName = "Edwin", LastName = "Thone", Children = new List<Person> {
                    new Person { IsChecked = false, FirstName = "Steven", LastName = "King" }
                } }
            };
        } 
    }
}
