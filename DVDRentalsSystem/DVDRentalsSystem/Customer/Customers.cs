﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Collections;
using System.Windows.Forms;

namespace DVDRentalsSystem
{
    class Customers
    {
        //Class Attributes
        private int customerId;
        private string title;
        private string surname;
        private string forename;
        private string dob;
        private string address1;
        private string address2;
        private string town;
        private string county;
        private string country;
        private string email;
        private string phoneNo;
        private string status;
        private int countyId;
        private int countryId;
        private int titleId;


        //Empty Constructor
        public Customers()
        {
            
        }


        //Code brings back the max customerId and adding 1 to give the next customerId
        public static int nextCustNo()
        {
            //Variable to hold value to be returned
            int intNextCustNo;

            //Connect to the DB
            OracleConnection myConn = new OracleConnection(DBConnect.oradb);
            myConn.Open();

            //Define SQL query to get MAX customerId used
            string strSQL = "SELECT MAX(customerId) FROM Customer";

            OracleCommand cmd = new OracleCommand(strSQL, myConn);

            //execute the sql query
            OracleDataReader dr = cmd.ExecuteReader();

            //Read the first (only) value returned by query
            //If first customerId, assign value 1, otherwise add 1 to MAX value
            dr.Read();

            if (dr.IsDBNull(0))
            {
                intNextCustNo = 1;
            }
            else
                intNextCustNo = Convert.ToInt16(dr.GetValue(0)) + 1;

            //Close the Db connection
            myConn.Close();

            //Return next next customerId
            return intNextCustNo;
        }

        public void regCustomer()
        {
            //Connect to db
            OracleConnection myConn = new OracleConnection(DBConnect.oradb);
            myConn.Open();

            //Define SQL Query to INSERT stock record
            string strSQL = "INSERT INTO Customer VALUES(" + getCustomerId() + ",'" + 
                getTitleId() + "', '" +  getForename() + "', '" + getSurname() + "', '" + 
                getDob() + "', '" + getAddress1() + "', '" + getAddress2() + "', '" + getTown() + "', '" + getCountyId() + "', '" + getCountryId() + "', '" + getEmail() + "', '" + getPhoneNo() + "', '" + getStatus() + "')";

            //Execute the Command
            OracleCommand cmd = new OracleCommand(strSQL, myConn);

            cmd.ExecuteNonQuery();

            //Close Connection
            myConn.Close();
            //https://www.codeproject.com/tips/483763/equivalent-function-of-mysql-real-escape-string-in
        }


        //Code to update a specified customer in the database
        public void updateCustomer(int customerId)
        {
            //Connect to db
            OracleConnection myConn = new OracleConnection(DBConnect.oradb);
            myConn.Open();

            //Define SQL Query to update customer record

            string strSQL = "UPDATE Customer SET TitleId = " + getTitleId() + ",Forename = '" + getForename() + "', Surname = '" + getSurname() + "', DOB =  '" + getDob() + "', Address1 =  '" + getAddress1() + "', Address2 =  '" + getAddress2() + "', Town = '" + getTown() + "', CountyId = " + getCountyId() + ", CountryId =  " + getCountryId() + ", Email = '" + getEmail() + "', Phone = '" + getPhoneNo() + "' WHERE CustomerId = "+ customerId + "";

            //Execute the Command
            OracleCommand cmd = new OracleCommand(strSQL, myConn);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (OracleException e)
            {
                MessageBox.Show(e.StackTrace);
            }

            //Close Connection
            myConn.Close();
        }


        //Code to update specified customer status to 'R'
        public void removeCustomer(int customerId)
        {
            //Connect to db
            OracleConnection myConn = new OracleConnection(DBConnect.oradb);
            myConn.Open();

            //Define SQL Query to update customer status to 'R'

            string strSQL = "UPDATE Customer set Status = 'R' WHERE CustomerId = " + customerId + "";

            //Execute the Command
            OracleCommand cmd = new OracleCommand(strSQL, myConn);


            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (OracleException e)
            {
                MessageBox.Show(e.StackTrace);
            }
            //Close Connection
            myConn.Close();
        }


        //Code to bring back all customer details from the database
        public static DataSet getCustomers()
        {
            OracleConnection conn = new OracleConnection(DBConnect.oradb);
            //connect to the database
            conn.Open();

            //define sql query
            string strSql = "SELECT * FROM Customer";

            //execute the query
            OracleCommand cmd = new OracleCommand(strSql, conn);

            //get the data onto the form
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();

            //uses a data adapter to fill the dataset
            da.Fill(ds, "ss");

            //close the database
            conn.Close();

            return ds;
        }

        //code to bring back all the specified customers rentals
        public static DataSet getCustomerRentals(int CustomerId)
        {
            OracleConnection conn = new OracleConnection(DBConnect.oradb);
            //connect to the database
            conn.Open();

            //define sql query

            string strSql = "Select D.DVDID, D.Title,R.DateFrom,RI.DateReturned,SUM((RA.PRICE*TO_NUMBER(R.DATEDUE - R.DATEFROM)))AS Cost_Of_DVD_Rental, " +
                            "CASE WHEN (RI.DATERETURNED - R.DATEDUE) < 0 THEN 0 " +
                            "ELSE SUM((RA.PRICE * TO_NUMBER(RI.DATERETURNED - R.DATEDUE))) " +
                            "END AS Amount_Overdue " +
                            "FROM RENTALS R,DVDS D, RENTALSITEMS RI,RATE RA " +
                            "WHERE R.CUSTOMERID = " + CustomerId + " AND R.RENTALSID = RI.RENTALSID AND D.DVDID = RI.DVDID AND RA.RATEID = D.RATEID " +
                            "GROUP by D.Title, R.DateFrom, RI.DateReturned,R.DATEDUE,D.DVDID ";

            //execute the query
            OracleCommand cmd = new OracleCommand(strSql, conn);

            //get the data onto the form
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();

            //uses a data adapter to fill the dataset
            da.Fill(ds, "ss");

            //close the database
            conn.Close();

            return ds;
        }

        //code to brin back the customer details from customers with matching surnames
        public static DataSet getCustomers(string surname)
        {
            OracleConnection conn = new OracleConnection(DBConnect.oradb);
            //connect to the database
            conn.Open();

            //define sql query
            string strSql = "SELECT C.CustomerId, T.TITLE, C.FORENAME, C.SURNAME, C.DOB, C.EMAIL, C.PHONE, C.ADDRESS1, C.ADDRESS2, C.TOWN, CY.COUNTY, CRY.COUNTRY FROM CUSTOMER C, COUNTIES CY, COUNTRIES CRY, TITLE T WHERE T.TITLEID = C.TITLEID AND C.COUNTYID = CY.COUNTIESID AND C.COUNTRYID = CRY.COUNTRIESID AND C.SURNAME LIKE '%" + surname + "%' AND C.STATUS = 'A'";

            //execute the query
            OracleCommand cmd = new OracleCommand(strSql, conn);

            //get the data onto the form
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();

            //uses a data adapter to fill the dataset
            da.Fill(ds, "ss");

            //close the database
            conn.Close();

            return ds;
        }
        
        //code to bring back the list of counties from the database
        public static DataSet getCountyList()
        {

            OracleConnection conn = new OracleConnection(DBConnect.oradb);
            //connect to the database
            conn.Open();

            //define sql query
            string strSql = "SELECT * FROM Counties";

            //execute the query
            OracleCommand cmd = new OracleCommand(strSql, conn);

            //Read the return data from the query

            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();

            //uses a data adapter to fill the dataset
            da.Fill(ds, "ss");

            //close the database
            conn.Close();

            return ds;
        }

        //code to bring back the a list of titles from the database
        public static DataSet getTitlesList()
        {

            OracleConnection conn = new OracleConnection(DBConnect.oradb);
            //connect to the database
            conn.Open();

            //define sql query
            string strSql = "SELECT * FROM Title";

            //execute the query
            OracleCommand cmd = new OracleCommand(strSql, conn);

            //Read the return data from the query

            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();

            //uses a data adapter to fill the dataset
            da.Fill(ds, "ss");

            //close the database
            conn.Close();

            return ds;
        }

        //code to bring back the list of countries from the database
        public static DataSet getCountryList()
        {

            OracleConnection conn = new OracleConnection(DBConnect.oradb);
            //connect to the database
            conn.Open();

            //define sql query
            string strSql = "SELECT * FROM Countries";

            //execute the query
            OracleCommand cmd = new OracleCommand(strSql, conn);

            //Read the return data from the query

            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();

            //uses a data adapter to fill the dataset
            da.Fill(ds, "ss");

            //close the database
            conn.Close();

            return ds;
        }


        //general getters and setters
        public int getCustomerId()
        {
            return customerId;
        }

        public void setCustomerId(int customerId)
        {
            this.customerId = customerId;
        }

        public int getCountryId()
        {
            return countryId;
        }

        public void setCountryId(int countryId)
        {
            this.countryId = countryId;
        }

        public int getCountyId()
        {
            return countyId;
        }

        public void setCountyId(int countyId)
        {
            this.countyId = countyId;
        }

        public string getTitle()
        {
            return title;
        }

        public void setTitle(string title)
        {
            this.title = title;
        }

        public int getTitleId()
        {
            return titleId;
        }

        public void setTitleId(int titleId)
        {
            this.titleId = titleId;
        }

        public string getSurname()
        {
            return surname;
        }

        public void setSurname(string surname)
        {
            this.surname = surname;
        }

        public string getForename()
        {
            return forename;
        }

        public void setForename(string forename)
        {
            this.forename = forename;
        }

        public string getDob()
        {
            return dob;
        }

        public void setDob(string dob)
        {
            this.dob = dob;
        }

        public string getAddress1()
        {
            return address1;
        }

        public void setAddress1(string address1)
        {
            this.address1 = address1;
        }

        public string getAddress2()
        {
            return address2;
        }

        public void setAddress2(string address2)
        {
            this.address2 = address2;
        }

        public string getTown()
        {
            return town;
        }

        public void setTown(string town)
        {
            this.town = town;
        }

        public string getCounty()
        {
            return county;
        }

        public void setCounty(string county)
        {
            this.county = county;
        }

        public string getCountry()
        {
            return country;
        }

        public void setCountry(string country)
        {
            this.country = country;
        }

        public string getEmail()
        {
            return email;
        }

        public void setEmail(string email)
        {
            this.email = email;
        }

        public string getPhoneNo()
        {
            return phoneNo;
        }

        public void setPhoneNo(string phoneNo)
        {
            this.phoneNo = phoneNo;
        }

        public string getStatus()
        {
            return status;
        }

        public void setStatus(string status)
        {
            this.status = status;
        }

    }
}
