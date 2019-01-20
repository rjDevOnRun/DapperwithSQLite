using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;

namespace SQL.Dapper
{
    public class DataAccess
    {
        /*
         * - Using Dapper package for database wiring
         * - Using SqLite.Core package as the Sqlite db
         */


        public List<Person> GetAllPeople()
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source=D:\\DEVELOPMENT\\SQLite\\Person.db;Version=3;");

            try
            {
                conn.Open();
                return conn.Query<Person>($"select * from PersonTable").ToList();
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message + ex.InnerException);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        public List<Person> GetPeople(string LastName)
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source=D:\\DEVELOPMENT\\SQLite\\Person.db;Version=3;");

            try
            {
                conn.Open();
                return conn.Query<Person>($"select * from PersonTable where Lastname like '{ LastName }'").ToList();
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message + ex.InnerException);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        public void InsertPersonRecord(Person peopleRecord)
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source=D:\\DEVELOPMENT\\SQLite\\Person.db;Version=3;");

            try
            {
                conn.Open();
                conn.Execute($"insert into PersonTable (Firstname, Lastname) " +
                             $"Values (@Firstname, @Lastname)", peopleRecord);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message + ex.InnerException);
            }
            finally
            {
                conn.Close();
            }
        }


    }
}
