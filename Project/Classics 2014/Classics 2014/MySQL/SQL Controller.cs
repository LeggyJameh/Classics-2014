using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using MySql.Data.MySqlClient;
using System.ComponentModel;
using System.Windows.Forms;

namespace CMS.MySQL
{
    partial class SQL_Controller 
    {
        private string server;
        private string database;
        private string user;
        private MySqlConnection connection;
        private string error;
        private Process localDatabaseMain = new Process();
        private string CurrentDirectory = Directory.GetCurrentDirectory();

        #region MainControls
        /// <summary>
        /// Class through which all SQL functions are passed.
        /// </summary>
        /// <param name="Server">Server IP address</param>
        /// <param name="Database">Database on server to access</param>
        /// <param name="User">User</param>
        /// <param name="Password">Password</param>
        public SQL_Controller(string Server, string Database, string User, string Password)
        {
            this.server = Server;
            this.database = Database;
            this.user = User;
            SetupConnection(Password);
            StartDatabase();
        }

        /// <summary>
        /// Class through which all SQL functions are passed. Passwordless init.
        /// </summary>
        /// <param name="Server">Server IP address</param>
        /// <param name="Database">Database on server to access</param>
        /// <param name="User">User</param>
        public SQL_Controller(string Server, string Database, string User)
        {
            this.server = Server;
            this.database = Database;
            this.user = User;
            SetupConnection();
            StartDatabase();
        }

        /// <summary>
        /// Starts the background process for the database
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Ends the background process for the database
        /// </summary>
        /// <returns></returns>
        public bool StopDatabase()
        {
            try
            {
                CloseConnection();
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

        /// <summary>
        /// Opens the network connection between the database server and this client
        /// </summary>
        /// <returns></returns>
        public bool OpenConnection()
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

        /// <summary>
        /// Closes the network connection between the database server and this client
        /// </summary>
        /// <returns></returns>
        private bool CloseConnection()
        {
            do
            {
                try
                {
                    connection.Close();
                }
                catch (MySqlException ex)
                {
                    error = (ex.Message);
                }
            }
            while (connection.State != System.Data.ConnectionState.Closed);
          //  while (connection.State != System.Data.ConnectionState.Open || connection.State != System.Data.ConnectionState.Closed); Your original Code. if connection is not open or is not closed (Every scenario?) Loop.
            return true;
        }

        /// <summary>
        /// Sets up the connection to be opened between the database and client.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Sets up the connection between the database and the client w/ password
        /// </summary>
        /// <param name="Password"></param>
        /// <returns></returns>
        public bool SetupConnection(string Password)
        {
            string connectionString;
            connectionString = "SERVER=" + server + ";DATABASE=" + database + ";UID=" + user + ";PASSWORD=" + Password + ";";

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
        /// <summary>
        /// Creates a competitor in the `competitors` table
        /// </summary>
        /// <param name="Competitor">The competitor to be created</param>
        /// <returns>Query success</returns>
        public int CreateCompetitor(Competitor Competitor)
        {
            string query = "INSERT INTO `competitors` (`Name`, `Team Name`, `Nationality`) VALUES ('" + Competitor.name + "', '" + Competitor.team + "', '" + Competitor.nationality + "');";
            if (ExecuteNonQuery(query))
            {
                return GetLastInsertKey();
            }
            return 0;
        }

        public int CreateEvent(Event Event)
        {
            MySqlEvent CurrentEvent = SerialiseEvent(Event);
            string query = "INSERT INTO `events` (`Name`, `Date`, `Type`, `Stage`, Data`) VALUES ('" + CurrentEvent.Name + "', '" + CurrentEvent.Date.ToShortDateString() + "', '" + CurrentEvent.Type.ToString() + "', '0', '" + ByteArrayToHex(CurrentEvent.Data) + "');";
            if (ExecuteNonQuery(query))
            {
                return GetLastInsertKey();
            }
            return 0;
        }

        /// <summary>
        /// Save the 'Scoring' Teams.
        /// </summary>
        /// <param name="EventID"></param>
        /// <param name="Teams"></param>
        /// <returns></returns>
        public List<Team> CreateSTeams(int EventID, List<Team> Teams)
        {
            string query;
            for (int Ti = 0; Ti < Teams.Count; Ti++)
            {
                MySqlTeam CurrentTeam = SerialiseTeam(Teams[Ti]);
                query = "INSERT INTO `event teams` (`ID`, `EventID`, `Name`, `Image`, `Data`) VALUES ('" + CurrentTeam.ID + "', '" + CurrentTeam.EventID + "', '" + CurrentTeam.Name + "', '" + ByteArrayToHex(CurrentTeam.Image) + "', '" + ByteArrayToHex(CurrentTeam.Data) + "');";
                ExecuteNonQuery(query);
                Teams[Ti].ID = GetLastInsertKey();
            }
            return Teams;
        }

        public int CreateLanding(Landing Landing)
        {
            MySqlLanding CurrentLanding = SerialiseLanding(Landing);
            string query = "INSERT INTO `landings` (`EventID`, `UID`, `Data`) VALUES ('" + CurrentLanding.eventID + "', '" + CurrentLanding.UID + "', '" + ByteArrayToHex(CurrentLanding.Data) + "');";
            if (ExecuteNonQuery(query))
            {
                return GetLastInsertKey();
            }
            return 0;
        }

        #endregion

        #region Remove
        public bool RemoveEvent(int EventID)
        {
            string query;
            query = "DELETE FROM `events` WHERE `ID` = '" + EventID + "';";
            if (ExecuteNonQuery(query))
            {
                query = "DELETE FROM `event teams` WHERE `EventID` = '" + EventID + "';";
                return ExecuteNonQuery(query);
            }
            else
            {
                return false;
            }
        }

        public bool RemoveLanding(int LandingID)
        {
            string query = "DELETE FROM `landings` WHERE `ID` = '" + LandingID + "';";
            return ExecuteNonQuery(query);
        }

        public bool RemoveCompetitor(int UID)
        {
            string query = "UPDATE `competitors` SET `Team Name` = '' WHERE `UID` = '" + UID + "';";
            return ExecuteNonQuery(query);
        }

        /// <summary>
        /// Remove a 'competitor' Team.
        /// </summary>
        /// <param name="Team"></param>
        /// <returns></returns>
        public bool RemoveCTeam(string Team)
        {
            string query = "UPDATE `competitors` SET `Team Name` = 'NO TEAM' WHERE `Team Name` = '" + Team + "';";
            return ExecuteNonQuery(query);
        }
        #endregion

        #region Update
        public bool ModifyLanding(Landing Landing)
        {
            MySqlLanding NewLanding = SerialiseLanding(Landing);
            string query = "UPDATE `landings` SET `Data` = '" + ByteArrayToHex(NewLanding.Data) + "' WHERE `ID` = '" + NewLanding.ID + "';";
            return ExecuteNonQuery(query);
        }

        public bool ModifyEvent(Event Event)
        {
            MySqlEvent NewEvent = SerialiseEvent(Event);
            string query = "UPDATE `events` SET `Name` = '" + NewEvent.Name + "', `Date` = '" + NewEvent.Date.ToShortDateString() + "', `Data` = '" + ByteArrayToHex(NewEvent.Data) + "' WHERE `ID` = '" + NewEvent.ID + "';";
            return ExecuteNonQuery(query);
        }

        public bool ModifyCompetitor(int UID, string NewName, string NewTeam, string NewNationality)
        {
            string query = "UPDATE `competitors` SET `Name` = '" + NewName + "', `Team Name` = '" + NewTeam + "', `Nationality` = '" + NewNationality + "' WHERE `UID` = '" + UID + "';";
            return ExecuteNonQuery(query);
        }

        public bool ModifyTeam(Team Team)
        {
            MySqlTeam NewTeam = SerialiseTeam(Team);
            string query = "UPDATE `event teams` SET `EventID` = '" + NewTeam.EventID + "', `Name` = '" + NewTeam.Name + "', `Image` = '" + NewTeam.Image + "', `Data` = '" + NewTeam.Data + "';";
            return ExecuteNonQuery(query);
        }

        public bool SaveCompetitorsOverwriteAndRemoveExcess(List<Competitor> competitors)
        {
            string query;

            query = "DELETE FROM `competitors`";

            if (ExecuteNonQuery(query))
            {
                bool completed = true;

                if (connection.State == System.Data.ConnectionState.Open)
                {
                    for (int i = 0; i < competitors.Count; i++)
                    {
                        MySqlCommand cmd = new MySqlCommand("INSERT INTO `competitors` (`UID`, `Name`, `Team Name`, `Nationality`) VALUES ('" + competitors[i].ID + "', '" + competitors[i].name + "', '" + competitors[i].team + "', '" + competitors[i].nationality + "');", connection);
                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (MySqlException ex)
                        {
                            error = ex.Message;
                            completed = false;
                        }
                    }
                }
                else
                    if (this.OpenConnection() == true)
                    {
                        for (int i = 0; i < competitors.Count; i++)
                        {
                            MySqlCommand cmd = new MySqlCommand("INSERT INTO `competitors` (`ID`, `Name`, `Team Name`, `Nationality`) VALUES ('" + competitors[i].ID + "', '" + competitors[i].name + "', '" + competitors[i].team + "', '" + competitors[i].nationality + "');", connection);
                            try
                            {
                                cmd.ExecuteNonQuery();
                            }
                            catch (MySqlException ex)
                            {
                                error = ex.Message;
                                completed = false;
                            }
                        }
                    }
                    else
                    {
                        return false;
                    }
                return completed;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region Get
        public List<Competitor> GetCompetitorsByCTeam(string Team)
        {
            List<Competitor> Competitors = new List<Competitor>();
            string query = "SELECT * FROM `competitors` WHERE `Team Name` = '" + Team + "'";

            if (connection.State == System.Data.ConnectionState.Open)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                try
                {
                    MySqlDataReader DataReader = cmd.ExecuteReader();
                    while (DataReader.Read())
                    {
                        Competitor CurrentCompetitor = new Competitor();
                        for (int i = 0; i < DataReader.FieldCount; i++)
                        {
                            switch (i)
                            {
                                case 0: CurrentCompetitor.ID = DataReader.GetInt16(i); break;
                                case 1: CurrentCompetitor.name = DataReader.GetString(i); break;
                                case 2: CurrentCompetitor.team = DataReader.GetString(i); break;
                                case 3: CurrentCompetitor.nationality = DataReader.GetString(i); break;
                            }
                            if (i == 3) { Competitors.Add(CurrentCompetitor); }
                        }
                    }
                    DataReader.Close();
                }
                catch (MySqlException ex)
                {
                    error = ex.Message;
                }
            }
            return Competitors;
        }

        public List<Competitor> GetCompetitorsByCTeam(string Team, List<Competitor> IgnoreList)
        {
            List<Competitor> Competitors = new List<Competitor>();
            string query = "SELECT * FROM `competitors` WHERE `Team Name` = '" + Team + "'";

            if (connection.State == System.Data.ConnectionState.Open)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                try
                {
                    MySqlDataReader DataReader = cmd.ExecuteReader();
                    while (DataReader.Read())
                    {
                        Competitor CurrentCompetitor = new Competitor();
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

                            for (int i2 = 0; i2 < IgnoreList.Count; i2++)
                            {
                                if (CurrentCompetitor.ID == IgnoreList[i2].ID) { CanAdd = false; }
                            }

                            if (i == 3 && CanAdd == true) { Competitors.Add(CurrentCompetitor); }
                        }
                    }
                    DataReader.Close();
                }
                catch (MySqlException ex)
                {
                    error = ex.Message;
                }
            }
            return Competitors;
        }

        public int GetLastInsertKey()
        {
            string query = "SELECT last_insert_id()";
            int ID = 0;

            if (connection.State == System.Data.ConnectionState.Open)
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
            }
            return ID;
        }

        public List<string> GetCTeams(bool IncludeEmpty)
        {
            string query = "SELECT `Team Name` FROM `competitors`";
            List<string> Teams = new List<string>();
            Teams.Add("NO TEAM");

            if (connection.State == System.Data.ConnectionState.Open)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                try
                {
                    MySqlDataReader DataReader = cmd.ExecuteReader();
                    while (DataReader.Read())
                    {
                        for (int i = 0; i < DataReader.FieldCount; i++)
                        {
                            bool TeamUnique = true;
                            string CurrentTeam = DataReader.GetString(i);
                            if (CurrentTeam == "" && IncludeEmpty == true || CurrentTeam != "")
                            {
                                for (int i2 = 0; i2 < Teams.Count; i2++)
                                {
                                    if (Teams[i2] == CurrentTeam || CurrentTeam == "")
                                    {
                                        TeamUnique = false;
                                    }
                                }
                                if (TeamUnique == true)
                                { Teams.Add(CurrentTeam); }
                            }
                        }
                    }
                    DataReader.Close();
                }
                catch (MySqlException ex)
                {
                    error = ex.Message;
                }
            }
            return Teams;
        }

        public bool DoesCompetitorExist(Competitor Competitor)
        {
            string query = "SELECT UID FROM `competitors` WHERE `Name` = '" + Competitor.name + "' AND `Team Name` = '" + Competitor.team + "' AND `Nationality` = '" + Competitor.nationality + "'";
            int ID = 0;

            if (connection.State == System.Data.ConnectionState.Open)
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
            }

            if (ID == 0) { return false; }
            else { return true; }
        }

        public bool DoesCTeamExist(string team)
        {
            string query = "SELECT UID FROM `competitors` WHERE `Team` = '" + team + "'";
            int ID = 0;

            if (connection.State == System.Data.ConnectionState.Open)
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
            }

            if (ID == 0) { return false; }
            else { return true; }
        }

        public Event GetEvent(int EventID)
        {
            string query = "SELECT * FROM `events` WHERE `ID` = '" + EventID + "'";
            MySqlEvent Event = new MySqlEvent();

            if (connection.State == System.Data.ConnectionState.Open)
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
                                case 1: Event.Name = DataReader.GetString(i); break;
                                case 2: Event.Date = DataReader.GetDateTime(i); break;
                                case 3: Event.Type = (EventType)Enum.Parse(typeof(EventType), DataReader.GetString(i)); break;
                                case 4: Event.Data = StringToByteArray(DataReader.GetString(i)); break;
                            }
                        }
                    }
                    DataReader.Close();
                }
                catch (MySqlException ex)
                {
                    error = ex.Message;
                }
            }
            return DeserialiseEvent(Event);
        }

        public dynamic GetLandingsForEvent(int EventID, EventType Type)
        {
            string query = "SELECT * FROM `landings` WHERE `EventID` = '" + EventID + "'";
            List<MySqlLanding> Landings = new List<MySqlLanding>();

            if (connection.State == System.Data.ConnectionState.Open) // Get the landings from the DB
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                try
                {
                    MySqlDataReader DataReader = cmd.ExecuteReader();
                    while (DataReader.Read())
                    {
                        MySqlLanding CurrentLanding = new MySqlLanding();
                        CurrentLanding.eventID = EventID;
                        for (int i = 0; i < DataReader.FieldCount; i++)
                        {
                            switch (i)
                            {
                                case 0: CurrentLanding.ID = DataReader.GetInt16(i); break;
                                case 2: CurrentLanding.UID = DataReader.GetInt16(i); break;
                                case 3:
                                    CurrentLanding.Data = StringToByteArray(DataReader.GetString(i));
                                    Landings.Add(CurrentLanding);
                                    break;
                            }
                        }
                    }
                    DataReader.Close();
                }
                catch (MySqlException ex)
                {
                    error = ex.Message;
                }

            }

             // Deserialise the landings' data
                switch (Type)
                {
                    case (EventType.Accuracy):
                        List<Accuracy.AccuracyLanding> LandingsToReturn = new List<Accuracy.AccuracyLanding>();
                        for (int i = 0; i < Landings.Count; i++)
                        {
                            LandingsToReturn.Add(DeserialiseAccuracyLanding(Landings[i], Type));
                        }
                        return LandingsToReturn;
                    break;
                }

                return null;
        }

        public int GetNoOfEventsByTypeOnDay(DateTime Date, EventType EventType)
        {
            string query = "SELECT * FROM `events` WHERE `Date` = '" + Date.ToShortDateString() + "' AND `Type` = '" + EventType.ToString() + "'";
            int Quantity = 0;

            if (connection.State == System.Data.ConnectionState.Open)
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
                                case 4: Quantity++; break;
                            }
                        }
                    }
                    DataReader.Close();
                }
                catch (MySqlException ex)
                {
                    error = ex.Message;
                }
            }
            return Quantity;
        }

        public List<Event> GetEvents()
        {
            string query = "SELECT * FROM `events`";
            List<MySqlEvent> Events = new List<MySqlEvent>();
            List<Event> EventsToReturn = new List<Event>();

            if (connection.State == System.Data.ConnectionState.Open)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                try
                {
                    MySqlDataReader DataReader = cmd.ExecuteReader();
                    while (DataReader.Read())
                    {
                        MySqlEvent CurrentEvent = new MySqlEvent();
                        for (int i = 0; i < DataReader.FieldCount; i++)
                        {
                            switch (i)
                            {
                                case 0: CurrentEvent.ID = DataReader.GetInt16(i); break;
                                case 1: CurrentEvent.Name = DataReader.GetString(i); break;
                                case 2: CurrentEvent.Date = DataReader.GetDateTime(i); break;
                                case 3: CurrentEvent.Type = (EventType)Enum.Parse(typeof(EventType), DataReader.GetString(i)); break;
                                case 4:
                                    CurrentEvent.Data = StringToByteArray(DataReader.GetString(i));
                                    Events.Add(CurrentEvent);
                                    break;
                            }
                        }
                    }
                    DataReader.Close();
                }
                catch (MySqlException ex)
                {
                    error = ex.Message;
                }
            }

            for (int i = 0; i < Events.Count; i++)
            {
                EventsToReturn.Add(DeserialiseEvent(Events[i]));
            }

            return EventsToReturn;
        }

        public List<Competitor> GetCompetitorsForEvent(int EventID)
        {
            List<Team> Teams = GetSTeamsForEvent(EventID);
            List<Competitor> Competitors = new List<Competitor>();

            for (int Ti = 0; Ti < Teams.Count; Ti++)
            {
                for (int Ci = 0; Ci < Teams[Ti].Competitors.Count; Ci++)
                {
                    Competitors.Add(Teams[Ti].Competitors[Ci]);
                }
            }

            return Competitors;
        }

        public List<Team> GetSTeamsForEvent(int EventID)
        {
            string query;
            MySqlCommand cmd;
            MySqlDataReader DataReader;
            List<Team> Teams = new List<Team>();
            List<Competitor> Competitors = new List<Competitor>();

            if (connection.State == System.Data.ConnectionState.Open)
            {
                #region Part A
                // Getting the teams for the event.
                query = "SELECT * FROM `event teams` WHERE `EventID` = '" + EventID + "'";
                cmd = new MySqlCommand(query, connection);
                try
                {
                    DataReader = cmd.ExecuteReader();
                    while (DataReader.Read())
                    {
                        MySqlTeam CurrentTeam = new MySqlTeam();
                        for (int i = 0; i < DataReader.FieldCount; i++)
                        {
                            switch (i)
                            {
                                case 0: CurrentTeam.ID = DataReader.GetInt16(i); break;
                                case 2: CurrentTeam.Name = DataReader.GetString(i); break;
                                case 3: CurrentTeam.Image = StringToByteArray(DataReader.GetString(i)); break;
                                case 4:
                                    CurrentTeam.Data = StringToByteArray(DataReader.GetString(i));
                                    Teams.Add(DeserialiseTeam(CurrentTeam));
                                    break;
                            }
                        }
                    }
                    DataReader.Close();
                }
                catch (MySqlException ex)
                {
                    error = ex.Message;
                }
                #endregion

                #region Part B
                query = "SELECT * FROM `competitors`";
                cmd = new MySqlCommand(query, connection);

                try
                {
                    DataReader = cmd.ExecuteReader();
                    while (DataReader.Read())
                    {
                        Competitor CurrentCompetitor = new Competitor();
                        for (int i = 0; i < DataReader.FieldCount; i++)
			            {
			                switch(i)
                            {
                                case 0: CurrentCompetitor.ID = DataReader.GetInt16(i); break;
                                case 1: CurrentCompetitor.name = DataReader.GetString(i); break;
                                case 2: CurrentCompetitor.team = DataReader.GetString(i); break;
                                case 3:
                                    CurrentCompetitor.nationality = DataReader.GetString(i);
                                    Competitors.Add(CurrentCompetitor);
                                    break;
                            }
			            }
                    }
                }
                catch (MySqlException ex)
                {
                    error = ex.Message;
                }
                #endregion

                #region Part C
                // Using the team information from the previous query, get the actual competitor data from the competitor table.
                for (int Ti = 0; Ti < Teams.Count; Ti++)
                {
                    for (int Ci = 0; Ci < Teams[Ti].Competitors.Count; Ci++)
                    {
                        for (int i = 0; i < Competitors.Count; i++)
                        {
                           if (Teams[Ti].Competitors[Ci].ID == Competitors[i].ID);
                            {
                                Teams[Ti].Competitors[Ci].name = Competitors[i].name;
                                Teams[Ti].Competitors[Ci].nationality = Competitors[i].nationality;
                                Teams[Ti].Competitors[Ci].team = Competitors[i].team;  
                            }
                        }
                    }
                }
                #endregion
            }
            return Teams;
        }

        public bool GetDoesEventExist(int EventID)
        {
            string query = "SELECT * FROM `events` WHERE `ID`='" + EventID + "'";
            bool exists = false;

            if (connection.State == System.Data.ConnectionState.Open)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                try
                {
                    MySqlDataReader DataReader = cmd.ExecuteReader();
                    while (DataReader.Read())
                    {
                        if (DataReader.FieldCount > 0)
                        {
                            exists = true;
                        }
                    }
                    DataReader.Close();
                }
                catch (MySqlException ex)
                {
                    error = ex.Message;
                }
            }
            return exists;
        }

        public List<Competitor> GetCompetitors()
        {
            List<Competitor> Competitors = new List<Competitor>();
            string query = "SELECT * FROM `competitors`";
            MySqlCommand cmd = new MySqlCommand(query, connection);

            try
            {
                MySqlDataReader DataReader = cmd.ExecuteReader();
                while (DataReader.Read())
                {
                    Competitor CurrentCompetitor = new Competitor();
                    for (int i = 0; i < DataReader.FieldCount; i++)
                    {
                        switch (i)
                        {
                            case 0: CurrentCompetitor.ID = DataReader.GetInt16(i); break;
                            case 1: CurrentCompetitor.name = DataReader.GetString(i); break;
                            case 2: CurrentCompetitor.team = DataReader.GetString(i); break;
                            case 3:
                                CurrentCompetitor.nationality = DataReader.GetString(i);
                                Competitors.Add(CurrentCompetitor);
                                break;
                        }
                    }
                }
                DataReader.Close();
            }
            catch (MySqlException ex)
            {
                error = ex.Message;
            }
            return Competitors;
        }

        public List<string> GetAllTeams()
        {
            string query = "SELECT `Team Name` FROM `competitors`";
            List<string> teamsToReturn = new List<string>();

            if (connection.State == System.Data.ConnectionState.Open)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                try
                {
                    MySqlDataReader DataReader = cmd.ExecuteReader();
                    while (DataReader.Read())
                    {
                        string currentTeam = DataReader.GetString(0);
                        if (currentTeam != "")
                        {
                            teamsToReturn.Add(currentTeam);
                        }
                    }
                    DataReader.Close();
                }
                catch (MySqlException ex)
                {
                    error = ex.Message;
                }
            }

            for (int i = 0; i < teamsToReturn.Count; i++)
            {
                for (int i2 = i + 1; i2 < teamsToReturn.Count; i2++)
                {
                    if (teamsToReturn[i] == teamsToReturn[i2])
                    {
                        teamsToReturn.RemoveAt(i2);
                        i2--;
                    }
                }
            }

            return teamsToReturn;
        }

        public int GetNumberCompetitorsInTeam(string teamName)
        {
            string query = "SELECT COUNT(1) FROM `competitors` WHERE `Team Name`='" + teamName + "'";
            int number = 0;

            if (connection.State == System.Data.ConnectionState.Open)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                try
                {
                    MySqlDataReader DataReader = cmd.ExecuteReader();
                    while (DataReader.Read())
                    {
                        for (int i = 0; i < DataReader.FieldCount; i++)
                        {
                            number = DataReader.GetInt16(i);
                        }
                    }
                    DataReader.Close();
                }
                catch (MySqlException ex)
                {
                    error = ex.Message;
                }
            }
            return number;
        }

        #endregion
        #endregion

        #region Other
        /// <summary>
        /// Query used for all non-return type queries.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        private bool ExecuteNonQuery(string query)
        {
            bool completed = false;

            if (connection.State == System.Data.ConnectionState.Open)
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
            }
            else
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
                }
                else
                {
                    return false;
                }
            return completed;
        }

        /// <summary>
        /// Converts a hexadecimal string into a serialised byte array
        /// </summary>
        /// <param name="hex">Hex string to be converted</param>
        /// <returns></returns>
        private static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        /// <summary>
        /// Converts a serialised byte array into a hexadecimal string
        /// </summary>
        /// <param name="Input">Byte array to be converted</param>
        /// <returns></returns>
        private static string ByteArrayToHex(byte[] Input)
        {
            StringBuilder hex = new StringBuilder(Input.Length * 2);
            foreach (byte b in Input)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        #endregion
    }
}
