using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL.Dapper
{
    public class Person
    {

        private string _firstname;

        public string Firstname
        {
            get { return _firstname; }
            set { _firstname = value; }
        }

        private string _lastname;

        public string Lastname
        {
            get { return _lastname; }
            set { _lastname = value; }
        }

        public string FullName
        {
            get
            {
                return $"{Firstname} {Lastname}";
            }
        }
    }
}
