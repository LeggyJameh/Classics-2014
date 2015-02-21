using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using MySql.Data.MySqlClient;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections.ObjectModel;

namespace CMS.MySQL
{
    partial class SQL_Controller 
    {
        private string server;
        private string database;
        private string user;
        private string password;
        private MySqlConnection connection;
        private string error;
        private Process localDatabaseMain;
        private string CurrentDirectory;
        private bool local;

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
            this.password = Password;
            if (Server == "127.0.0.1" || Server == "localhost")
            {
                local = true;
                CurrentDirectory = Directory.GetCurrentDirectory();
                StartDatabase();
                SetupConnection();
            }
            else
            {
                local = false;
                SetupConnection();
            }
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
            this.password = "";
            if (Server == "127.0.0.1" || Server == "localhost")
            {
                local = true;
                CurrentDirectory = Directory.GetCurrentDirectory();
                StartDatabase();
                SetupConnection();
            }
            else
            {
                local = false;
                SetupConnection();
            }
        }

        /// <summary>
        /// Starts the background process for the database
        /// </summary>
        /// <returns></returns>
        public bool StartDatabase()
        {
            localDatabaseMain = new Process();
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
            if (local == true)
            {
                try
                {
                    CloseConnection();
                    localDatabaseMain.StartInfo.FileName = CurrentDirectory + "\\Database\\bin\\mysqladmin.exe";
                    localDatabaseMain.StartInfo.CreateNoWindow = true;
                    localDatabaseMain.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    if (password != "")
                    {
                        localDatabaseMain.StartInfo.Arguments = "-s -u " + user + " -p " + password + " shutdown";
                    }
                    else
                    {
                        localDatabaseMain.StartInfo.Arguments = "-s -u " + user + " shutdown";
                    }
                    localDatabaseMain.Start();
                    return true;
                }
                catch (Win32Exception e)
                {
                    error = e.NativeErrorCode.ToString();
                }
                return false;
            }
            else
            {
                return true;
            }
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
            return true;
        }

        /// <summary>
        /// Sets up the connection to be opened between the database and client.
        /// </summary>
        /// <returns></returns>
        public bool SetupConnection()
        {
            string connectionString = "";
            if (password != "")
            {
                connectionString = "SERVER=" + server + ";DATABASE=" + database + ";UID=" + user;
            }
            else
            {
                connectionString = "SERVER=" + server + ";DATABASE=" + database + ";UID=" + user + ";PASSWORD=" + password + ";";
            }

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
        /// <param name="competitor">The competitor to be created</param>
        /// <returns>Query success</returns>
        public int CreateCompetitor(Competitor competitor)
        {
            string query = "INSERT INTO `competitors` (`Name`, `Group`, `Nationality`) VALUES ('" + competitor.name + "', '" + competitor.group + "', '" + competitor.nationality + "');";
            if (ExecuteNonQuery(query))
            {
                return GetLastInsertKey();
            }
            return 0;
        }

        /// <summary>
        /// Creates the event, returns the eventID.
        /// </summary>
        public int CreateEvent(Event Event)
        {
            MySqlEvent CurrentEvent = SerialiseEvent(Event);
            string query = "INSERT INTO `events` (`Name`, `Date`, `Type`, `Data`) VALUES ('" + CurrentEvent.Name + "', '" + CurrentEvent.Date.ToShortDateString() + "', '" + CurrentEvent.Type.ToString() + "', '" + ByteArrayToHex(CurrentEvent.Data) + "');";
            if (ExecuteNonQuery(query))
            {
                return GetLastInsertKey();
            }
            return 0;
        }

        /// <summary>
        /// Adds the team to the database, and returns it with ID.
        /// </summary>
        public Team CreateTeam(int eventID, string teamName)
        {
            string query = "INSERT INTO `event teams` (`EventID`, `Name`, `Image`, `Data`) VALUES ('" + eventID + "', '" + teamName + "', '" + ByteArrayToHex(new byte[1]) + "', '" + ByteArrayToHex(new byte[1]) + "');";
            if (ExecuteNonQuery(query))
            {
                Team team = new Team();
                team.Competitors = new ObservableCollection<EventCompetitor>();
                team.EventID = eventID;
                team.ID = GetLastInsertKey();
                team.Name = teamName;
                team.TeamImage = null;

                return team;
            }
            return null;
        }

        /// <summary>
        /// Adds the landing to the database, and returns the ID.
        /// </summary>
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
        public bool RemoveEvent(int eventID)
        {
            string query;
            query = "DELETE FROM `events` WHERE `ID` = '" + eventID + "';";
            if (ExecuteNonQuery(query))
            {
                query = "DELETE FROM `event teams` WHERE `EventID` = '" + eventID + "';";
                return ExecuteNonQuery(query);
            }
            else
            {
                return false;
            }
        }

        public bool RemoveLanding(int landingID)
        {
            string query = "DELETE FROM `landings` WHERE `ID` = '" + landingID + "';";
            return ExecuteNonQuery(query);
        }

        public bool RemoveCompetitor(int UID)
        {
            string query = "UPDATE `competitors` SET `Group` = '' WHERE `UID` = '" + UID + "';";
            return ExecuteNonQuery(query);
        }

        public bool RemoveTeam(Team team)
        {
            string query = "DELETE FROM `event teams` WHERE `ID` = '" + team.ID + "';";
            return ExecuteNonQuery(query);
        }

        public bool RemoveTeam(int teamID)
        {
            string query = "DELETE FROM `event teams` WHERE `ID` = '" + teamID + "';";
            return ExecuteNonQuery(query);
        }

        public bool RemoveAllTeamsForEvent(int eventID)
        {
            string query = "DELETE FROM `event teams` WHERE `EventID` = '" + eventID + "';";
            return ExecuteNonQuery(query);
        }

        /// <summary>
        /// Remove a competitor group.
        /// </summary>
        /// <param name="Team"></param>
        /// <returns></returns>
        public bool RemoveGroup(string group)
        {
            string query = "UPDATE `competitors` SET `Group` = 'NO GROUP' WHERE `Group` = '" + group + "';";
            return ExecuteNonQuery(query);
        }
        #endregion

        #region Update
        public bool ModifyLanding(Landing landing)
        {
            MySqlLanding NewLanding = SerialiseLanding(landing);
            string query = "UPDATE `landings` SET `Data` = '" + ByteArrayToHex(NewLanding.Data) + "' WHERE `ID` = '" + NewLanding.ID + "';";
            return ExecuteNonQuery(query);
        }

        public bool ModifyEvent(Event Event)
        {
            MySqlEvent NewEvent = SerialiseEvent(Event);
            string query = "UPDATE `events` SET `Name` = '" + NewEvent.Name + "', `Date` = '" + NewEvent.Date.ToShortDateString() + "', `Data` = '" + ByteArrayToHex(NewEvent.Data) + "' WHERE `ID` = '" + NewEvent.ID + "';";
            return ExecuteNonQuery(query);
        }

        public bool ModifyCompetitor(int UID, string newName, string newGroup, string newNationality)
        {
            string query = "UPDATE `competitors` SET `Name` = '" + newName + "', `Group` = '" + newGroup + "', `Nationality` = '" + newNationality + "' WHERE `UID` = '" + UID + "';";
            return ExecuteNonQuery(query);
        }

        public bool ModifyTeam(Team team)
        {
            MySqlTeam newTeam = SerialiseTeam(team);
            string query = "UPDATE `event teams` SET `EventID` = '" + newTeam.EventID + "', `Name` = '" + newTeam.Name + "', `Image` = '" + ByteArrayToHex(newTeam.Image) + "', `Data` = '" + ByteArrayToHex(newTeam.Data) + "' WHERE `ID`='" + newTeam.ID + "';";
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
                        MySqlCommand cmd = new MySqlCommand("INSERT INTO `competitors` (`UID`, `Name`, `Group`, `Nationality`) VALUES ('" + competitors[i].ID + "', '" + competitors[i].name + "', '" + competitors[i].group + "', '" + competitors[i].nationality + "');", connection);
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
                            MySqlCommand cmd = new MySqlCommand("INSERT INTO `competitors` (`ID`, `Name`, `Group`, `Nationality`) VALUES ('" + competitors[i].ID + "', '" + competitors[i].name + "', '" + competitors[i].group + "', '" + competitors[i].nationality + "');", connection);
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
        public List<Competitor> GetCompetitorsByIDList(List<int> IDs)
        {
            List<Competitor> competitors = new List<Competitor>();
            string query;
            MySqlCommand cmd;
            MySqlDataReader DataReader;

            foreach (int id in IDs)
            {
                query = "SELECT * FROM `competitors` WHERE `UID`='" + id + "'";

                if (connection.State == System.Data.ConnectionState.Open)
                {
                    cmd = new MySqlCommand(query, connection);
                    try
                    {
                        DataReader = cmd.ExecuteReader();
                        while (DataReader.Read())
                        {
                            Competitor currentCompetitor = new Competitor();
                            for (int i = 0; i < DataReader.FieldCount; i++)
                            {
                                switch (i)
                                {
                                    case 0: currentCompetitor.ID = DataReader.GetInt16(i); break;
                                    case 1: currentCompetitor.name = DataReader.GetString(i); break;
                                    case 2: currentCompetitor.group = DataReader.GetString(i); break;
                                    case 3: currentCompetitor.nationality = DataReader.GetString(i); break;
                                }
                                if (i == 3) { competitors.Add(currentCompetitor); }
                            }
                        }
                        DataReader.Close();
                    }
                    catch (MySqlException ex)
                    {
                        error = ex.Message;
                    }
                }
            }
            return competitors;
        }

        public List<Competitor> GetCompetitorsByGroup(string group)
        {
            List<Competitor> Competitors = new List<Competitor>();
            string query = "SELECT * FROM `competitors` WHERE `Group` = '" + group + "'";

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
                                case 2: CurrentCompetitor.group = DataReader.GetString(i); break;
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

        public List<Competitor> GetCompetitorsByGroup(string group, List<Competitor> ignoreList)
        {
            List<Competitor> Competitors = new List<Competitor>();
            string query = "SELECT * FROM `competitors` WHERE `Group` = '" + group + "'";

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
                                case 2: CurrentCompetitor.group = DataReader.GetString(i); break;
                                case 3: CurrentCompetitor.nationality = DataReader.GetString(i); break;
                            }

                            for (int i2 = 0; i2 < ignoreList.Count; i2++)
                            {
                                if (CurrentCompetitor.ID == ignoreList[i2].ID) { CanAdd = false; }
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

        public List<string> GetGroups(bool includeEmpty)
        {
            string query = "SELECT `Group` FROM `competitors`";
            List<string> Groups = new List<string>();
            Groups.Add("NO GROUP");

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
                            bool GroupUnique = true;
                            string CurrentGroup = DataReader.GetString(i);
                            if (CurrentGroup == "" && includeEmpty == true || CurrentGroup != "")
                            {
                                for (int i2 = 0; i2 < Groups.Count; i2++)
                                {
                                    if (Groups[i2] == CurrentGroup || CurrentGroup == "")
                                    {
                                        GroupUnique = false;
                                    }
                                }
                                if (GroupUnique == true)
                                { Groups.Add(CurrentGroup); }
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
            return Groups;
        }

        public bool DoesCompetitorExist(Competitor competitor)
        {
            string query = "SELECT UID FROM `competitors` WHERE `Name` = '" + competitor.name + "' AND `Group` = '" + competitor.group + "' AND `Nationality` = '" + competitor.nationality + "'";
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

        public bool DoesGroupExist(string group)
        {
            string query = "SELECT UID FROM `competitors` WHERE `Group` = '" + group + "'";
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

        public Event GetEvent(int eventID)
        {
            string query = "SELECT * FROM `events` WHERE `ID` = '" + eventID + "'";
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

        public dynamic GetLandingsForEvent(int eventID, EventType type)
        {
            string query = "SELECT * FROM `landings` WHERE `EventID` = '" + eventID + "'";
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
                        CurrentLanding.eventID = eventID;
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
                switch (type)
                {
                    case (EventType.INTL_ACCURACY):
                        List<Accuracy.AccuracyLanding> LandingsToReturn = new List<Accuracy.AccuracyLanding>();
                        for (int i = 0; i < Landings.Count; i++)
                        {
                            Accuracy.AccuracyLanding currentLanding = DeserialiseLanding(Landings[i], type);
                            currentLanding.ID = Landings[i].ID;
                            currentLanding.UID = Landings[i].UID;
                            currentLanding.eventID = Landings[i].eventID;
                            LandingsToReturn.Add(currentLanding);
                        }
                        return LandingsToReturn;
                    break;
                }

                return null;
        }

        public int GetNoOfEventsByTypeOnDay(DateTime date, EventType eventType)
        {
            string query = "SELECT * FROM `events` WHERE `Date` = '" + date.ToShortDateString() + "' AND `Type` = '" + eventType.ToString() + "'";
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
                                case 2: CurrentEvent.Date = Convert.ToDateTime(DataReader.GetString(i)); break;
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

        public List<Competitor> GetCompetitorsForEvent(int eventID)
        {
            List<Team> Teams = GetTeamsForEvent(eventID);
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

        public List<Team> GetTeamsForEvent(int eventID)
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
                query = "SELECT * FROM `event teams` WHERE `EventID` = '" + eventID + "'";
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
                                case 2: CurrentCompetitor.group = DataReader.GetString(i); break;
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
                #endregion

                #region Part C
                // Using the team information from the previous query, get the actual competitor data from the competitor table.
                for (int Ti = 0; Ti < Teams.Count; Ti++)
                {
                    Teams[Ti].EventID = eventID;
                    for (int Ci = 0; Ci < Teams[Ti].Competitors.Count; Ci++)
                    {
                        for (int i = 0; i < Competitors.Count; i++)
                        {
                            if (Teams[Ti].Competitors[Ci].ID == Competitors[i].ID)
                            {
                                Teams[Ti].Competitors[Ci].name = Competitors[i].name;
                                Teams[Ti].Competitors[Ci].nationality = Competitors[i].nationality;
                                Teams[Ti].Competitors[Ci].group = Competitors[i].group;  
                            }
                        }
                    }
                }
                #endregion
            }
            return Teams;
        }

        public bool GetDoesEventExist(int eventID)
        {
            string query = "SELECT * FROM `events` WHERE `ID`='" + eventID + "'";
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
            List<Competitor> competitors = new List<Competitor>();
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
                            case 2: CurrentCompetitor.group = DataReader.GetString(i); break;
                            case 3:
                                CurrentCompetitor.nationality = DataReader.GetString(i);
                                competitors.Add(CurrentCompetitor);
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
            return competitors;
        }

        public List<string> GetAllGroups()
        {
            string query = "SELECT `Group` FROM `competitors`";
            List<string> groupsToReturn = new List<string>();

            if (connection.State == System.Data.ConnectionState.Open)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                try
                {
                    MySqlDataReader DataReader = cmd.ExecuteReader();
                    while (DataReader.Read())
                    {
                        string currentGroup = DataReader.GetString(0);
                        if (currentGroup != "")
                        {
                            groupsToReturn.Add(currentGroup);
                        }
                    }
                    DataReader.Close();
                }
                catch (MySqlException ex)
                {
                    error = ex.Message;
                }
            }

            for (int i = 0; i < groupsToReturn.Count; i++)
            {
                for (int i2 = i + 1; i2 < groupsToReturn.Count; i2++)
                {
                    if (groupsToReturn[i] == groupsToReturn[i2])
                    {
                        groupsToReturn.RemoveAt(i2);
                        i2--;
                    }
                }
            }

            return groupsToReturn;
        }

        public int GetNumberCompetitorsInGroup(string groupName)
        {
            string query = "SELECT COUNT(1) FROM `competitors` WHERE `Group`='" + groupName + "'";
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
