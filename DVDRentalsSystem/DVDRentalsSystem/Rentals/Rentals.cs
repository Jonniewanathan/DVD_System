using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace DVDRentalsSystem {

    class Rentals
    {
        private int rentalsId;
        private int customerId;
        private decimal cost;
        private string dateFrom;
        private string dateDue;
        private string dateReturned;

        private ArrayList DVDList = new ArrayList();
        private int DVDid;


        public Rentals()
        {
            DVDList.Cast<int>();
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


        public void rentDVD()
        {
            this.setRentalsId(nextRentalNo());
            addRental();
            for (int i = 0; i < DVDList.Count; i++)
            {
                addToRentalList(Convert.ToInt16(DVDList[i]));
                setDVDUnavailable(Convert.ToInt16(DVDList[i]));
            }
            
        }

        public void addRental()
        {
            //Connect to db
            OracleConnection myConn = new OracleConnection(DBConnect.oradb);
            myConn.Open();

            //Define SQL Query to INSERT stock record
            string strSQL = "INSERT INTO RENTALS VALUES(" + getRentalsId() + ", " + getCustomerId() + "," + getCost() + ", '" + getDateFrom() + "', '" + getDateDue() + "')";

            //Execute the Command
            OracleCommand cmd = new OracleCommand(strSQL, myConn);

            cmd.ExecuteNonQuery();

            //Close Connection
            myConn.Close();
        }

        public static decimal getPrice(int RateId)
        {
            //Variable to hold value to be returned
            decimal price;

            //Connect to the DB
            OracleConnection myConn = new OracleConnection(DBConnect.oradb);
            myConn.Open();

            //Define SQL query to get price of the DVD
            string strSQL = "SELECT R.Price FROM Rate R, DVDS D WHERE R.RateId = " + RateId + "";

            OracleCommand cmd = new OracleCommand(strSQL, myConn);

            //execute the sql query
            OracleDataReader dr = cmd.ExecuteReader();

            //Read the first (only) value returned by query
            dr.Read();

            price = Convert.ToDecimal(dr.GetValue(0));

            //Close the Db connection
            myConn.Close();

            //Return price
            return price;
        }

        public void addToRentalList(int DVDId)
        {
            OracleConnection myConn = new OracleConnection(DBConnect.oradb);
            myConn.Open();

            //Define SQL Query to INSERT stock record
            string strSQL = "INSERT INTO RENTALSITEMS VALUES(" + rentalsId + ", " + DVDId + ", NULL)";

            //Execute the Command
            OracleCommand cmd = new OracleCommand(strSQL, myConn);

            cmd.ExecuteNonQuery();

            //Close Connection
            myConn.Close();
        }

        public void setDVDUnavailable(int DVDId)
        {
            //Connect to db
            OracleConnection myConn = new OracleConnection(DBConnect.oradb);
            myConn.Open();

            //Define SQL Query to update DVD record
            string strSQL = "UPDATE DVDs SET Status = 'U' WHERE DVDId = " + DVDId + "";

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

        public void setDVDAvailable()
        {
            //Connect to db
            OracleConnection myConn = new OracleConnection(DBConnect.oradb);
            myConn.Open();

            //Define SQL Query to update DVD record
            string strSQL = "UPDATE DVDs SET Status = 'A' WHERE DVDId = " + DVDid + "";

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

        public void setReturnDate()
        {
            

            //Connect to db
            OracleConnection myConn = new OracleConnection(DBConnect.oradb);
            myConn.Open();

            //Define SQL Query to update DVD record
            string strSQL = "UPDATE RENTALSITEMS SET DATERETURNED = '" + dateReturned + "' WHERE DVDID = " + DVDid + " AND DATERETURNED IS NULL";

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
           
        public DataSet listDailyRentals(string date)
        {
            return new DataSet();
        }

        public void returnDVD()
        {
            setReturnDate();
            setDVDAvailable();
        }

        public static DataSet getDVD(int DVDId)
        {
            OracleConnection conn = new OracleConnection(DBConnect.oradb);
            //connect to the database
            conn.Open();

            //define sql query
            string strSql = "SELECT * FROM DVDs WHERE Status != 'A' AND Status != 'R' AND DVDId = " + DVDId;

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

        public DataSet getRentals()
        {
            OracleConnection conn = new OracleConnection(DBConnect.oradb);
            //connect to the database
            conn.Open();

            //define sql query
            string strSql = "SELECT R.RENTALSID,R.DATEDUE FROM RENTALSITEMS RI,RENTALS R WHERE RI.DVDID = " + DVDid + " AND R.RENTALSID = RI.RENTALSID AND RI.DATERETURNED IS NULL";

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

        public static DataSet getDailyRentalsList(string date)
        {
            OracleConnection conn = new OracleConnection(DBConnect.oradb);
            //connect to the database
            conn.Open();

            //define sql query
            string strSql = "Select D.Title,C.FORENAME,C.SURNAME,R.DateFrom,RI.DateReturned,SUM((RA.PRICE*TO_NUMBER(R.DATEDUE - R.DATEFROM)))AS Cost_Of_DVD_Rental, " +
                            "CASE WHEN (RI.DATERETURNED - R.DATEDUE) < 0 THEN 0 " +
                            "ELSE SUM((RA.PRICE * TO_NUMBER(RI.DATERETURNED - R.DATEDUE))) " +
                            "END AS Amount_Overdue " +
                            "FROM RENTALS R, DVDS D, RENTALSITEMS RI, RATE RA, CUSTOMER C " +
                            "WHERE R.RENTALSID = RI.RENTALSID AND D.DVDID = RI.DVDID AND RA.RATEID = D.RATEID AND C.CUSTOMERID = R.CUSTOMERID AND R.DATEFROM = '" + date + "' " +
                            "GROUP by D.Title, R.DateFrom, RI.DateReturned, R.DATEDUE, C.FORENAME, C.SURNAME ";

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

        public void setDVDList(ArrayList DVDList)
        {
            this.DVDList = DVDList;
        }
    }
}
