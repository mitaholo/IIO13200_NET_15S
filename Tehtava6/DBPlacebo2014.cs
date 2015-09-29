using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace JAMK.ICT.Data
{
    public static class DBPlacebo
    {
        public static DataTable GetTestCustomers()
	    {
            //create
            DataTable dt = new DataTable();
            //columns
            dt.Columns.Add("asioid",typeof(string));
            dt.Columns.Add("LastName",typeof(string));
            dt.Columns.Add("FirstName", typeof(string));
            //rows
            dt.Rows.Add("A3581", "Waltari","Mika");
	        dt.Rows.Add("B3553", "King", "Stephen");
	        dt.Rows.Add("C1238", "Neruda", "Pablo");
	        dt.Rows.Add("D9876", "Oksanen", "Sofi");
	        return dt;
	    }

        public static DataTable GetCustomersFromSQLServer(string search, out string message)
        {
            try
            {
                string connectionStr = JAMK.ICT.Properties.Settings.Default.Tietokanta;
                string table = JAMK.ICT.Properties.Settings.Default.Taulu;
                SqlConnection myConn = new SqlConnection(connectionStr);
                myConn.Open();
                SqlCommand cmd;
                if(search == "") cmd = new SqlCommand("SELECT * FROM " + table, myConn);
                else cmd = new SqlCommand("SELECT * FROM " + table + " WHERE City = '" + search + "'", myConn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, table);
                message = "Data successfully fetched from " + myConn.DataSource;
                return ds.Tables[table];
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                message = ex.Message;
                return null;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                throw;
            }
        }

        public static DataTable GetAllCustomersFromSQLServer(out string message)
        {
            return GetCustomersFromSQLServer("", out message);
        }

        public static ArrayList GetCities(out string message)
        {
           try
           {
                ArrayList cities = new ArrayList();
                string city = "";
                string connectionStr = JAMK.ICT.Properties.Settings.Default.Tietokanta;
                string table = JAMK.ICT.Properties.Settings.Default.Taulu;

                SqlConnection myConn = new SqlConnection(connectionStr);
                myConn.Open();
                SqlCommand cmd = new SqlCommand("SELECT City FROM " + table, myConn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (!reader.IsDBNull(0)) city = reader.GetString(0);
                    if (!cities.Contains(city)) cities.Add(city);
                }

                cities.Sort();
                message = "Ready";
                return cities;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                message = ex.Message;
                return null;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                throw;
            }
        }
    }
}
