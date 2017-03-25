using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace DVDRentalsSystem.Customer
{
    class Rentals
    {
        private int rentalsId;
        private int customerId;
        private decimal cost;
        private string dateFrom;
        private string dateDue;
        private string dateReturned;

        private ArrayList DVDList;

        private int DVDid;


        public Rentals()
        {

        }

        public static int nextRentalNo()
        {
            //Variable to hold value to be returned
            int intNextRentalNo;

            //Connect to the DB
            OracleConnection myConn = new OracleConnection(DBConnect.oradb);
            myConn.Open();

            //Define SQL query to get MAX stock_no used
            string strSQL = "SELECT MAX(RentalsId) FROM Rentals";

            OracleCommand cmd = new OracleCommand(strSQL, myConn);

            //execute the sql query
            OracleDataReader dr = cmd.ExecuteReader();

            //Read the first (only) value returned by query
            //If first RentalsId, assign value 1, otherwise add 1 to MAX value
            dr.Read();

            if (dr.IsDBNull(0))
            {
                intNextRentalNo = 1;
            }
            else
                intNextRentalNo = Convert.ToInt16(dr.GetValue(0)) + 1;

            //Close the Db connection
            myConn.Close();

            //Return next StockNo
            return intNextRentalNo;
        }

        public void regCustomer()
        {
            //Connect to db
            OracleConnection myConn = new OracleConnection(DBConnect.oradb);
            myConn.Open();

            //Define SQL Query to INSERT stock record
            string strSQL = "INSERT INTO Customer VALUES(" + getCustomerId() + ",'" +
                getTitleId() + "', '" + getForename() + "', '" + getSurname() + "', '" +
                getDob() + "', '" + getAddress1() + "', '" + getAddress2() + "', '" + getTown() + "', '" + getCountyId() + "', '" + getCountryId() + "', '" + getEmail() + "', '" + getPhoneNo() + "', '" + getStatus() + "')";

            //Execute the Command
            OracleCommand cmd = new OracleCommand(strSQL, myConn);

            cmd.ExecuteNonQuery();

            //Close Connection
            myConn.Close();
            //https://www.codeproject.com/tips/483763/equivalent-function-of-mysql-real-escape-string-in
        }

        public void rentDVD()
        {
            
        }

        public DataSet listDailyRentals(string date)
        {
            return new DataSet();
        }

        public void returnDVD()
        {
            
        }

        public int getRentalsId()
        {
            return rentalsId;
        }

        public void setRentalsId(int rentalsId)
        {
            this.rentalsId = rentalsId;
        }

        public int getCustomerId()
        {
            return customerId;
        }

        public void setCustomerId(int customerId)
        {
            this.customerId = customerId;
        }

        public decimal getCost()
        {
            return cost;
        }

        public void setCost(decimal cost)
        {
            this.cost = cost;
        }

        public string getDateFrom()
        {
            return dateFrom;
        }

        public void setDateFrom(string dateFrom)
        {
            this.dateFrom = dateFrom;
        }

        public string getDateDue()
        {
            return dateDue;
        }

        public void setDateDue(string dateDue)
        {
            this.dateDue = dateDue;
        }

        public string getDateReturned()
        {
            return dateReturned;
        }

        public void setDateReturned(string dateReturned)
        {
            this.dateReturned = dateReturned;
        }

        public int getDVDId()
        {
            return DVDid;
        }

        public void setDVDId(int DVDid)
        {
            this.DVDid = DVDid;
        }

        public ArrayList getDVDList()
        {
            return DVDList;
        }

        public void setDVDId(ArrayList DVDList)
        {
            this.DVDList = DVDList;
        }



    }
}
