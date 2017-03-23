using System;
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
    class DVDs
    {
        private int dvdId;
        private string title;
        private string ageRating;
        private string genre;
        private string priceCatagory;
        private string status;
        private int ageRatingId;
        private int genreId;
        private int priceCatagoryId;

        public DVDs()
        {

        }

        public static DataSet getDVDs()
        {
            OracleConnection conn = new OracleConnection(DBConnect.oradb);
            //connect to the database
            conn.Open();

            //define sql query
            string strSql = "SELECT D.DVDID ,D.TITLE ,A.AGERATING ,G.GENRE ,R.Description AS " + "Price_Catagory" + " ,D.STATUS FROM DVDs D, AgeRating A,Genre G, Rate R WHERE Status != 'R' AND A.AgeRatingId = D.AgeRatingId AND D.GenreId = G.GenreId AND D.RateId = R.RateId ";

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

        public static DataSet getDVDs(string title)
        {
            OracleConnection conn = new OracleConnection(DBConnect.oradb);
            //connect to the database
            conn.Open();

            //define sql query
            string strSql = "SELECT D.DVDID ,D.TITLE ,A.AGERATING ,G.GENRE ,R.Description AS " + "PriceCatagory" + " ,D.STATUS FROM DVDs D, AgeRating A,Genre G, Rate R  WHERE D.Title like '%" + title + "%' AND Status != 'R' AND A.AgeRatingId = D.AgeRatingId AND D.GenreId = G.GenreId AND D.RateId = R.RateId ";
            
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

        public static DataSet getDVD(int DVDId)
        {
            OracleConnection conn = new OracleConnection(DBConnect.oradb);
            //connect to the database
            conn.Open();

            //define sql query
            string strSql = "SELECT * FROM DVDs WHERE Status != 'R' AND Status != 'U' AND DVDId = " + DVDId ;

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

        public static DataSet getDVDs(string orderBy, string filterBy)
        {
            OracleConnection conn = new OracleConnection(DBConnect.oradb);
            //connect to the database
            conn.Open();

            //define sql query
            string strSql = "SELECT D.DVDID ,D.TITLE ,A.AGERATING ,G.GENRE ,R.Description AS " + "Price_Catagory" + " ,D.STATUS FROM DVDs D, AgeRating A,Genre G, Rate R  WHERE D.Status like '%" + filterBy + "%' AND A.AgeRatingId = D.AgeRatingId AND D.GenreId = G.GenreId AND D.RateId = R.RateId " + orderBy + "";

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

        public static int nextDVDNo()
        {
            //Variable to hold value to be returned
            int intNextStockNo;

            //Connect to the DB
            OracleConnection myConn = new OracleConnection(DBConnect.oradb);
            myConn.Open();

            //Define SQL query to get MAX stock_no used
            string strSQL = "SELECT MAX(DVDId) FROM DVDs";

            OracleCommand cmd = new OracleCommand(strSQL, myConn);

            //execute the sql query
            OracleDataReader dr = cmd.ExecuteReader();

            //Read the first (only) value returned by query
            //If first stockNo, assign value 1, otherwise add 1 to MAX value
            dr.Read();

            if (dr.IsDBNull(0))
            {
                intNextStockNo = 1;
            }
            else
                intNextStockNo = Convert.ToInt16(dr.GetValue(0)) + 1;

            //Close the Db connection
            myConn.Close();

            //Return next StockNo
            return intNextStockNo;
        }

        public void regDVD()
        {
            //Connect to db
            OracleConnection myConn = new OracleConnection(DBConnect.oradb);
            myConn.Open();

            //Define SQL Query to INSERT stock record
            string strSQL = "INSERT INTO DVDs VALUES(" + getDvdId() + ",'" + getTitle().ToUpper() + "','" + getAgeRatingId() + "','" + 
                getGenreId() + "','" + getPriceCatagoryId() + "','" + getStatus() + "')";

            //Execute the Command
            OracleCommand cmd = new OracleCommand(strSQL, myConn);
          
            cmd.ExecuteNonQuery();

            //Close Connection
            myConn.Close();
			//https://www.codeproject.com/tips/483763/equivalent-function-of-mysql-real-escape-string-in
        }

        public void updateDVD(int DVDId)
        {
            //Connect to db
            OracleConnection myConn = new OracleConnection(DBConnect.oradb);
            myConn.Open();

            //Define SQL Query to update DVD record
            string strSQL = "UPDATE DVDs SET Title = '" + getTitle().ToUpper() + "', AgeRatingID = '" + getAgeRatingId() + "', GenreID = '" + getGenreId() + "', RateID = '" + getPriceCatagoryId() + "' WHERE DVDId = " + DVDId + "";

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

        public void removeDVD(int DVDId)
        {
            //Connect to db
            OracleConnection myConn = new OracleConnection(DBConnect.oradb);
            myConn.Open();

            //Define SQL Query to update DVD record
            string strSQL = "UPDATE DVDs SET Status = 'R' WHERE DVDId = " + DVDId + "";

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

        public static DataSet getGenreList()
        {

            OracleConnection conn = new OracleConnection(DBConnect.oradb);
            //connect to the database
            conn.Open();

            //define sql query
            string strSql = "SELECT * FROM Genre";

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

        public static DataSet getAgeRatingList()
        {
            
            OracleConnection conn = new OracleConnection(DBConnect.oradb);
            //connect to the database
            conn.Open();

            //define sql query
            string strSql = "SELECT * FROM AgeRating";

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

        public static DataSet getPriceCatagorys()
        {

            OracleConnection conn = new OracleConnection(DBConnect.oradb);
            //connect to the database
            conn.Open();

            //define sql query
            string strSql = "SELECT * FROM Rate";

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

        public int getDvdId()
        {
            return dvdId;
        }

        public void setDvdId(int dvdId)
        {
            this.dvdId = dvdId;
        }

        public string getTitle()
        {
            return title;
        }

        public void setTitle(string title)
        {
            this.title = title;
        }

        public string getAgeRating()
        {
            return ageRating;
        }

        public void setAgeRating(string ageRating)
        {
            this.ageRating = ageRating;
        }

        public int getAgeRatingId()
        {
            return ageRatingId;
        }

        public void setAgeRatingId(int ageRatingId)
        {
            this.ageRatingId = ageRatingId;
        }

        public string getGenre()
        {
            return genre;
        }

        public void setGenre(String genre)
        {
            this.genre = genre;
        }

        public int getGenreId()
        {
            return genreId;
        }

        public void setGenreId(int genreId)
        {
            this.genreId = genreId;
        }

        public string getPriceCatagory()
        {
            return priceCatagory;
        }

        public void setPriceCatagory(string priceCatagory)
        {
            this.priceCatagory = priceCatagory;
        }

        public int getPriceCatagoryId()
        {
            return priceCatagoryId;
        }

        public void setPriceCatagoryId(int priceCatagoryId)
        {
            this.priceCatagoryId = priceCatagoryId;
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
