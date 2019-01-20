using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQL.Dapper
{
    public partial class Form1 : Form
    {
        List<Person> people = new List<Person>();

        public Form1()
        {
            InitializeComponent();

            DisplayPeopleFromDB();
        }

        private void DisplayPeopleFromDB()
        {
            DataAccess db = new DataAccess();
            List<Person> allPeopleInDB = db.GetAllPeople();

            peopleFoundListBox.DataSource = allPeopleInDB;
            peopleFoundListBox.DisplayMember = "FullName";
        }

        private void UpdateBinding()
        {
            peopleFoundListBox.DataSource = people;
            peopleFoundListBox.DisplayMember = "FullName";
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataAccess db = new DataAccess();

            people = db.GetPeople(txtLastname.Text);

            // Dapper maps the property of person with the
            // data from the database.
            // MAKE SURE THAT THE PROPERTY NAMES INSIDE THE
            // PERSON CLASS EXCATLY MATCHES THE NAMES OF THE
            // COLUMNS OF YOUR DATABASE TABLE. ELSE IT WILL
            // NOT WORK CORRECTLY.

            UpdateBinding();

            txtLastname.Text = string.Empty;
        }

        private void btninsert_Click(object sender, EventArgs e)
        {
            Person addPerson = new Person { Firstname = txtFirstNameIns.Text, Lastname = txtLastNameIns.Text };

            DataAccess db = new DataAccess();
            db.InsertPersonRecord(addPerson);
            txtFirstNameIns.Text = string.Empty;
            txtLastNameIns.Text = string.Empty;

            DisplayPeopleFromDB();

        }
    }
}
