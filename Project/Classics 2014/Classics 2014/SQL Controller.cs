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
            //StartDatabase();
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

        #endregion
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
        #endregion
    }
}
