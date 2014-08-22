using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;
using System.Windows.Forms;


namespace NetSpeedDataCollector
{
    class DatabaseHelper
    {
        private MySqlConnection connection;
        private static string server = "localhost";
        private static string database = "netdata";
        private static string uid = "root";
        private static string password = "falcon";
        public bool errorDisplayed = false;
       
    

        public DatabaseHelper()
        {


            Initialize();

            if (checkDatabaseStatus())
                CreateTables();

        }


        private void writeData(int speed, int average)
        {

            using (StreamWriter w = File.AppendText("config.cfg"))
            {
                w.WriteLine(server);
                w.WriteLine(database);
                w.WriteLine(uid);
                w.WriteLine(password);
            }
        }


        //Initialize values
        private void Initialize()
        {
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "Port = 3306;" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                if (errorDisplayed == false)
                {
                    switch (ex.Number)
                    {
                        case 0:
                            MessageBox.Show("Cannot connect to server.");
                            break;

                        case 259:
                            MessageBox.Show("Invalid username/password, please try again");
                            break;
                    }
                    errorDisplayed = true;
                    return false;

                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }




        public bool checkDatabaseStatus()
        {
            try
            {
                connection.Open();
                connection.Close();
                return true;
            }
            catch (MySqlException exp)
            {
                return false;
            }
        }


        //Insert statement
        public bool Insert(int speed, int average)
        {
            
            string time = DateTime.Now.ToString("d:h:mm ");        
            string query = "INSERT INTO `netdata`.`speed_data`" +
            "(`Date`," +  
            "`Average`," +
            "`Speed`)"
            +"VALUES" 
            +"("+"'"+time+"','"+average+"','"+speed+"');";



    
            Console.WriteLine(query);

            //open connection
            if (this.OpenConnection() == true)
            {
                try
                {
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    //Execute command
                    cmd.ExecuteNonQuery();

                    //close connection
                    this.CloseConnection();


                    return true;

                }
                catch (MySqlException exc)
                {
                    this.CloseConnection();

                    return false;
                }


            }
            else { return true; }


        }

        public void CreateTables()
        {

            string query = "CREATE TABLE IF NOT EXISTS `speed_data` (" +
                         " `Date` varchar(15) NOT NULL,   " +
                         " `Max Speed` varchar(15) NOT NULL,   " +
                         " `Average` varchar(15) NOT NULL   );";


            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();


            }


        }



    }

}


