using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartCA.Model.Employees
{
    public class Employee : Person
    {
        private string jobTitle;

        public Employee(object key)
            : this(key, string.Empty, string.Empty)
        { }

        public Employee(object key, string firstName, string lastName)
        {
            this.jobTitle = string.Empty;
        }

        public string JobTitle
        {
            get { return this.jobTitle; }
            set { this.jobTitle = value; }
        }
    }
}
