using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace TreeListCheckBoxes
{
    public class Person {
        public bool IsChecked { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Person> Children { get; set; }
        public Person() {
            Children = new List<Person>();
        }
    }
}
