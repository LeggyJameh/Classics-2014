using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using MySql.Data.MySqlClient;
using System.ComponentModel;

namespace Classics_2014
{
    class SQL_Controller
    {
        private string server;
        private string database;
        private string user;
        private MySqlConnection connection;
        private string error;
        private Process localDatabaseMain = new Process();
        private string CurrentDirectory = Directory.GetCurrentDirectory();

        #region MainControls

        public SQL_Controller(string Server, string Database, string User)
        {
            this.server = Server;
            this.database = Database;
            this.user = User;
            SetupConnection();
            StartDatabase();
        }

        public bool StartDatabase()
        {
            try
            {
                localDatabaseMain.StartInfo.FileName = CurrentDirectory + "\\Database\\bin\\mysqld.exe";
                localDatabaseMain.StartInfo.CreateNoWindow = true;
                localDatabaseMain.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                localDatabaseMain.Start();
                return true;
            }
            catch (Win32Exception e)
            {
                error = e.NativeErrorCode.ToString();
            }
            return false;
        }

        public bool StopDatabase()
        {
            try
            {
                localDatabaseMain.StartInfo.FileName = CurrentDirectory + "\\Database\\bin\\mysqladmin.exe";
                localDatabaseMain.StartInfo.CreateNoWindow = true;
                localDatabaseMain.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                localDatabaseMain.StartInfo.Arguments = "-u root shutdown";
                localDatabaseMain.Start();
                return true;
            }
            catch (Win32Exception e)
            {
                error = e.NativeErrorCode.ToString();
            }
            return false;
        }

        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        error = "Failed to connect to the Database.";
                        break;

                    case 1045:
                        error = "Invalid username/password, please try again";
                        break;

                    case 1042:
                        error = "Unable to create the socket on port 3306. Please check your network configuration";
                        break;

                    default:
                        error = ("Error " + ex.Number + " has occurred. Please report this issue.");
                        break;
                }
                return false;
            }
        }

        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                error = (ex.Message);
            }
            return false;
        }

        public bool SetupConnection()
        {
            string connectionString;
            connectionString = "SERVER=" + server + ";DATABASE=" + database + ";UID=" + user;

            try
            {
                connection = new MySqlConnection(connectionString);
                return true;
            }
            catch
            {
                error = "Could not connect to the database";
            }
            return false;
        }

        #endregion

        #region Queries
        #region Create

        public bool CreateCompetitor(TCompetitor Competitor)
        {
            string query = "INSERT INTO competitors (Name, Team, Nationality) VALUES ('" + Competitor.name + "', '" + Competitor.team + "', '" + Competitor.nationality + "');";
            return ExecuteNonQuery(query);
        }

        public bool CreateEvent(string Name, EventType EventType, byte[] Options, DateTime Date)
        {
            string Query1;
            string Query2;
            int EventID;
            //Robs Code to convert Byte array to Hexadecimal
            string hexRuleset = ByteArrayToHex(Options);
            //Code ends here

            switch (EventType)
            {
                case EventType.Accuracy:
                    Query1 = "INSERT INTO events (Date, Name, Type, Options) VALUES ('" + Date.ToShortDateString() + "', '" + Name + "', '" + EventType + "', '" + hexRuleset + "');";
                    if (ExecuteNonQuery(Query1))
                    {
                        EventID = GetLastInsertKey();
                        Query2 = "CREATE TABLE `event " + EventID + "` (`LandingID` INT(11) NOT NULL DEFAULT '-1',`Round` INT(11) NOT NULL DEFAULT '1',`UID` INT(11) NOT NULL DEFAULT '-1')";
                        if (ExecuteNonQuery(Query2))
                        {
                            return true;
                        }
                    }
                break;
               //this line is no longer needed, we know what will be passed in case default: return false; break;
            }
            return false;
        }

        public bool SaveTeams(int EventID, List<List<TCompetitor>> Teams, List<string> TeamNames)
        {
            bool completed = false;
            string query;
            if (this.OpenConnection() == true)
            {
                for (int i = 0; i < Teams.Count; i++)
                {
                    for (int i2 = 0; i2 < Teams[i].Count; i2++)
                    {
                        query = "INSERT INTO `event teams` (EventID, UID, Team) VALUES ('" + EventID + "', '" + Teams[i][i2].ID + "', '" + TeamNames[i] + "');";
                        MySqlCommand cmd = new MySqlCommand(query, connection);
                        try
                        {       
                            cmd.ExecuteNonQuery();
                            completed = true;
                        }
                        catch (MySqlException ex)
                        {
                            error = ex.Message;
                            completed = false;
                        }
                    }
                }
                this.CloseConnection();
            }
            return completed;
        }

        public int CreateAccuracyLanding(int EventID, int Score, byte[] LandingData)
        {
            int LandingID = -1;
            string hexLanding = ByteArrayToHex(LandingData);

            string query = "INSERT INTO `accuracy landings` (Score, WindData) VALUES ('" + Score + "', '" + hexLanding + "');";

            ExecuteNonQuery(query);
            LandingID = GetLastInsertKey();

            query = "INSERT INTO `event " + EventID + "` (LandingID) VALUES ('" + LandingID + "');";
            ExecuteNonQuery(query);

            return LandingID;
        }

        #endregion
        #region Remove

        public bool RemoveEvent(int EventID)
        {
            string query = "DROP TABLE `event " + EventID + "`;";
            return ExecuteNonQuery(query);
        }

        public bool RemoveCompetitor(int UID)
        {
            string query = "UPDATE competitors SET `Team`='' WHERE `UID`='" + UID + "';";
            return ExecuteNonQuery(query);
        }

        public bool RemoveTeam(string Team)
        {
            string query = "UPDATE competitors SET `Team`='NO TEAM' WHERE `Team`='" + Team + "';";
            return ExecuteNonQuery(query);
        }

        #endregion
        #region Modify

        public bool AssignCompetitorToLanding(int CompetitorID, int RoundNum, int LandingID, int EventID)
        {
            string query = "UPDATE `event " + EventID + "` SET `Round`='" + RoundNum + "', `UID`='" + CompetitorID + "'  WHERE `LandingID`='" + LandingID + "';";
            return ExecuteNonQuery(query);
        }

        public bool ModifyLanding(int LandingID, int Score)
        {
            string query = "UPDATE `accuracy landings` SET `Score`='" + Score + "', `Modified`='1' WHERE `LandingID`='" + LandingID + "';";
            return ExecuteNonQuery(query);
        }

        #endregion
        #region Get

        public List<TCompetitor> GetCompetitorsByTeam(string Team, List<TCompetitor> CurrentCompetitors, List<TCompetitor> Ignorelist)
        {
            string query = "SELECT * FROM competitors WHERE Team='" + Team + "'";
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                try
                {
                    MySqlDataReader DataReader = cmd.ExecuteReader();
                    while (DataReader.Read())
                    {
                        TCompetitor CurrentCompetitor = new TCompetitor();
                        bool CanAdd = true;
                        for (int i = 0; i < DataReader.FieldCount; i++)
                        {
                            switch (i)
                            {
                                case 0: CurrentCompetitor.ID = DataReader.GetInt16(i); break;
                                case 1: CurrentCompetitor.name = DataReader.GetString(i); break;
                                case 2: CurrentCompetitor.team = DataReader.GetString(i); break;
                                case 3: CurrentCompetitor.nationality = DataReader.GetString(i); break;
                            }
                            for (int i2 = 0; i2 < Ignorelist.Count; i2++)
                            {
                                if (CurrentCompetitor.ID == Ignorelist[i2].ID) { CanAdd = false; }
                            }
                            if (i == 3 && CanAdd == true) { CurrentCompetitors.Add(CurrentCompetitor); }
                        }
                    }
                    DataReader.Close();
                }
                catch (MySqlException ex)
                {
                    error = ex.Message;
                }
                this.CloseConnection();
            }
            return CurrentCompetitors;
        }

        public List<string> GetTeams()
        {
            string query = "SELECT Team FROM competitors";
            List<string> Teams = new List<string>();
            Teams.Add("NO TEAM");

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                try
                {
                    MySqlDataReader DataReader = cmd.ExecuteReader();
                    while (DataReader.Read())
                    {
                        for (int i = 0; i < DataReader.FieldCount; i++)
                        {
                            bool TeamIsUnique = true;
                            string CurrentTeam = DataReader.GetString(i);
                            for (int i2 = 0; i2 < Teams.Count; i2++)
                            {
                                if (Teams[i2] == CurrentTeam || CurrentTeam == "")
                                {
                                    TeamIsUnique = false;
                                }
                            }
                            if (TeamIsUnique == true)
                            { Teams.Add(CurrentTeam); }
                        }
                    }
                    DataReader.Close();
                }
                catch (MySqlException ex)
                {
                    error = ex.Message;
                }
                this.CloseConnection();
            }

            return Teams;
        }

        public int GetLastInsertKey()
        {
            string query = "SELECT last_insert_id()";
            int ID = 0;

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                try
                {
                    MySqlDataReader DataReader = cmd.ExecuteReader();
                    while (DataReader.Read())
                    {
                        for (int i = 0; i < DataReader.FieldCount; i++)
                        {
                            ID = DataReader.GetInt16(i);
                        }
                    }
                    DataReader.Close();
                }
                catch (MySqlException ex)
                {
                    error = ex.Message;
                }
                this.CloseConnection();
            }
            return ID;
        }

        public bool DoesCompetitorExist(TCompetitor Competitor)
        {
            string query = "SELECT UID FROM competitors WHERE NAME='" + Competitor.name + "' AND Team='" + Competitor.team + "' AND Nationality ='" + Competitor.nationality + "'";
            int ID = -2;

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                try
                {
                    MySqlDataReader DataReader = cmd.ExecuteReader();
                    while (DataReader.Read())
                    {
                        for (int i = 0; i < DataReader.FieldCount; i++)
                        {
                            ID = DataReader.GetInt16(i);
                        }
                    }
                    DataReader.Close();
                }
                catch (MySqlException ex)
                {
                    error = ex.Message;
                }
                this.CloseConnection();
            }
            if (ID == -2) { return false; }
            else { return true; }
        }

        public TMySQLEventReturn GetEvent(int EventID)
        {
            string query = "SELECT * FROM `events` WHERE ID='" + EventID + "'";
            TMySQLEventReturn CurrentEvent = new TMySQLEventReturn();
            CurrentEvent.ID = -1;
            CurrentEvent.Name = "";
            CurrentEvent.Options = new byte[5];
            CurrentEvent.Type = EventType.Accuracy;
            CurrentEvent.Date = DateTime.Now;
            string CurrentOptions = "";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                try
                {
                    MySqlDataReader DataReader = cmd.ExecuteReader();
                    while (DataReader.Read())
                    {
                        for (int i = 0; i < DataReader.FieldCount; i++)
                        {
                            switch (i)
                            {
                                case 0: CurrentEvent.ID = DataReader.GetInt16(i); break;
                                case 1: CurrentEvent.Date = DataReader.GetDateTime(i); break;
                                case 2: CurrentEvent.Name = DataReader.GetString(i); break;
                                case 3: CurrentEvent.Type = (EventType)Enum.Parse(typeof(EventType), DataReader.GetString(i)); break;
                                case 4: CurrentOptions = DataReader.GetString(i); break;
                            }
                        }
                    }
                    DataReader.Close();
                }
                catch (MySqlException ex)
                {
                    error = ex.Message;
                }
                this.CloseConnection();

                CurrentEvent.Options = StringToByteArray(CurrentOptions);
            }
            return CurrentEvent;
        }

        #endregion
        #region Other
        private bool ExecuteNonQuery(string query)
        {
            bool completed = false;

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                try
                {
                    cmd.ExecuteNonQuery();
                    completed = true;
                }
                catch (MySqlException ex)
                {
                    error = ex.Message;
                    completed = false;
                }
                this.CloseConnection();
            }
            return completed;
        }

        private static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        private static string ByteArrayToHex(byte[] Input)
        {
            StringBuilder hex = new StringBuilder(Input.Length * 2);
            foreach (byte b in Input)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        #endregion
        #endregion
    }
}
