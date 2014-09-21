using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using MySql.Data.MySqlClient;
using System.ComponentModel;
using System.Windows.Forms;

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

        public SQL_Controller(string Server, string Database, string User, string Password)
        {
            this.server = Server;
            this.database = Database;
            this.user = User;
            SetupConnection(Password);
            StartDatabase();
        }

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

        public bool SetupConnection(string Password)
        {
            string connectionString;
            connectionString = "SERVER=" + server + ";DATABASE=" + database + ";UID=" + user +";PASSWORD=" + Password + ";";

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

        public bool CreateCompetitor(Competitor Competitor)
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

        public bool SaveTeams(int EventID, List<Team> Teams)
        {
            bool completed = false;
            string query;
            if (this.OpenConnection() == true)
            {
                for (int Ti = 0; Ti < Teams.Count; Ti++)
                {
                    for (int Ci = 0; Ci < Teams[Ti].Competitors.Count; Ci++)
                    {
                        query = "INSERT INTO `event teams` (EventID, UID, Team) VALUES ('" + EventID + "', '" + Teams[Ti].Competitors[Ci].ID + "', '" + Teams[Ti].Name + "');";
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

        #region StagedAccuracyLandingProcess

        //Stage 1
        public int CreateAccuracyLanding(int EventID, int Score)
        {
            int LandingID = -1;

            string query = "INSERT INTO `accuracy landings` (Score) VALUES ('" + Score + "');";

            ExecuteNonQuery(query);
            LandingID = GetLastInsertKey();

            query = "INSERT INTO `event " + EventID + "` (LandingID) VALUES ('" + LandingID + "');";
            ExecuteNonQuery(query);

            return LandingID;
        }

        //Stage 2
        public bool AssignCompetitorToLanding(int CompetitorID, int RoundNum, int LandingID, int EventID)
        {
            string query = "UPDATE `event " + EventID + "` SET `Round`='" + RoundNum + "', `UID`='" + CompetitorID + "'  WHERE `LandingID`='" + LandingID + "';";
            return ExecuteNonQuery(query);
        }

        //Stage 3
        public bool AssignWindDataToAccuracyLanding(byte[] LandingData, bool isRejumpable, int LandingID)
        {
            string hexLanding = ByteArrayToHex(LandingData);
            string query = "UPDATE `accuracy landings` SET `WindData`='" + hexLanding + "', `IsRejumpable`='" + isRejumpable + "' WHERE `LandingID`='" + LandingID + "';";
            return ExecuteNonQuery(query);
        }


        #endregion
        #endregion
        #region Remove

        public bool RemoveEvent(int EventID)
        {
            string query = "DROP TABLE `event " + EventID + "`;";
            if (ExecuteNonQuery(query))
            {
                string query2 = "DELETE FROM `events` WHERE `EventID`='" + EventID + "';";
                if (ExecuteNonQuery(query2))
                {
                    string query3 = "DELETE FROM `event teams` WHERE `EventID`='" + EventID + "';";
                    return ExecuteNonQuery(query3);
                }
            }
            return false;

        }

        public bool RemoveAccuracyLanding(int LandingID, int EventID)
        {
            string query = "DELETE FROM `accuracy landings` WHERE `LandingID`='" + LandingID + "';";
            if (ExecuteNonQuery(query))
            {
                string query2 = "DELETE FROM `event " + EventID + "` WHERE `LandingID`='" + LandingID + "';";
                return ExecuteNonQuery(query2);
            }
            return false;
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

        public bool ModifyLanding(int LandingID, int Score)
        {
            string query = "UPDATE `accuracy landings` SET `Score`='" + Score + "', `Modified`='1' WHERE `LandingID`='" + LandingID + "';";
            return ExecuteNonQuery(query);
        }

        public bool ModifyAccuracyRules(byte[] Rules, int EventID)
        {
            string hexRules = ByteArrayToHex(Rules);
            string query = "UPDATE `events` SET `Options`='" + hexRules + "' WHERE `EventID`='" + EventID + "';";
            return ExecuteNonQuery(query);
        }

        public bool ModifyCompetitorName(int UID, string NewName)
        {
            string query = "UPDATE `competitors` SET `Name`='" + NewName + "' WHERE `UID`='" + UID + "';";
            return ExecuteNonQuery(query);
        }

        #endregion
        #region Get

        public List<Competitor> GetCompetitorsByTeam(string Team, List<Competitor> CurrentCompetitors, List<Competitor> Ignorelist)
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

        public bool DoesCompetitorExist(Competitor Competitor)
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

        public List<Accuracy.MySqlReturnLanding> GetLandingsForAccuracyEvent(int EventID, Accuracy.Accuracy_Event Connected_Event)
        {
            List<Accuracy.MySqlReturnLanding> Landings = new List<Accuracy.MySqlReturnLanding>();

            string query = "SELECT * FROM `event " + EventID + "`";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                #region Query1
                try
                {
                    MySqlDataReader DataReader = cmd.ExecuteReader();
                    while (DataReader.Read())
                    {
                        Accuracy.MySqlReturnLanding CurrentLanding = new Accuracy.MySqlReturnLanding();

                        for (int i = 0; i < DataReader.FieldCount; i++)
                        {
                            switch (i)
                            {
                                case 0: CurrentLanding.ID = DataReader.GetInt16(i); break;
                                case 1: CurrentLanding.Round = DataReader.GetInt16(i); break;
                                case 2: CurrentLanding.UID = DataReader.GetInt16(i); break;
                            }
                            if (i == 2)
                            {
                                Landings.Add(CurrentLanding);
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
                #region Query2
                for (int i = 0; i < Landings.Count; i++)
                {
                    string query2 = "SELECT * FROM `accuracy landings` WHERE `LandingID`='" + Landings[i].ID + "'";
                    cmd = new MySqlCommand(query2, connection);
                    try
                    {
                        MySqlDataReader DataReader = cmd.ExecuteReader();
                        while (DataReader.Read())
                        {
                            string HexedWindData = "";
                            int CurrentScore = 100;
                            bool CurrentIsModified = false;
                            bool CurrentisRejumpable = false;

                            for (int i2 = 0; i2 < DataReader.FieldCount; i2++)
                            {
                                switch (i2)
                                {
                                    case 1: CurrentScore = DataReader.GetInt16(i2); break;
                                    case 2: HexedWindData = DataReader.GetString(i2); break;
                                    case 3: CurrentIsModified = DataReader.GetBoolean(i2); break;
                                    case 4: CurrentisRejumpable = DataReader.GetBoolean(i2); break;
                                }
                                if (i2 == 4)
                                {
                                    Accuracy.MySqlReturnLanding CurrentLanding = new Accuracy.MySqlReturnLanding();

                                    if (HexedWindData.Length > 2)
                                    {
                                        Byte[] WindData = StringToByteArray(HexedWindData);
                                        int Round = Landings[i].Round;
                                        int UID = Landings[i].UID;
                                        CurrentLanding = GlobalFunctions.CastAccLandingToMySqlReturnLanding(Connected_Event.ConvertByteArrayToLanding(WindData));
                                        CurrentLanding.UID = UID;
                                        CurrentLanding.Round = Round;
                                    }
                                    else
                                    {
                                        CurrentLanding.ID = Landings[i].ID;
                                        CurrentLanding.UID = Landings[i].UID;
                                        CurrentLanding.Round = Landings[i].Round;
                                    }
                                    
                                    CurrentLanding.score = CurrentScore;
                                    CurrentLanding.Modified = CurrentIsModified;
                                    Landings[i] = CurrentLanding;
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
                #endregion
                this.CloseConnection();
            }
            return Landings;
        }

        public int GetNoOfEventsByTypeOnDay(DateTime Date, EventType EventType)
        {
            string query = "SELECT EventID FROM `events` WHERE `Date`='" + Date.ToShortDateString() + "' AND `Type`='" + EventType.ToString() + "'";
            int Number = 0;

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
                            if (i == 0) { Number++; }
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
            return Number;
        }

        public List<TMySQLEventReturn> GetEvents()
        {
            List<TMySQLEventReturn> Events = new List<TMySQLEventReturn>();

            string query = "SELECT * FROM `events`";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                try
                {
                    MySqlDataReader DataReader = cmd.ExecuteReader();
                    while (DataReader.Read())
                    {
                        TMySQLEventReturn CurrentEvent;
                        CurrentEvent.ID = -1;
                        CurrentEvent.Date = DateTime.Now;
                        CurrentEvent.Name = "";
                        CurrentEvent.Options = new Byte[1];
                        CurrentEvent.Type = EventType.Accuracy;
                        string CurrentOptions = "";

                        for (int i = 0; i < DataReader.FieldCount; i++)
                        {
                            switch (i)
                            {
                                case 0: CurrentEvent.ID = DataReader.GetInt16(i); break;
                                case 1: CurrentEvent.Date = Convert.ToDateTime(DataReader.GetString(i)); break;
                                case 2: CurrentEvent.Name = DataReader.GetString(i); break;
                                case 3: CurrentEvent.Type = (EventType)Enum.Parse(typeof(EventType), DataReader.GetString(i)); break;
                                case 4: CurrentOptions = DataReader.GetString(i); break;
                            }
                            if (i == 4)
                            {
                                CurrentEvent.Options = StringToByteArray(CurrentOptions);
                                Events.Add(CurrentEvent);
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
            }
            return Events;
        }

        public List<Competitor> GetCompetitorsForEvent(int EventID)
        {
            List<Competitor> Competitors = new List<Competitor>();
            List<int> CompetitorIDs = new List<int>();
            string query = "SELECT UID FROM `event teams` WHERE `EventID`='" + EventID + "';";

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
                            CompetitorIDs.Add(DataReader.GetInt16(i));
                        }
                    }
                    DataReader.Close();
                }
                catch (MySqlException ex)
                {
                    error = ex.Message;
                }

                for (int i = 0; i < CompetitorIDs.Count; i++)
                {
                    string query2 = "SELECT * FROM `competitors` WHERE `UID`='" + CompetitorIDs[i] + "';";
                    MySqlCommand cmd2 = new MySqlCommand(query2, connection);
                    try
                    {
                        MySqlDataReader DataReader = cmd2.ExecuteReader();
                        while (DataReader.Read())
                        {
                            Competitor CurrentCompetitor = new Competitor();
                            CurrentCompetitor.ID = CompetitorIDs[i];
                            for (int i2 = 0; i2 < DataReader.FieldCount; i2++)
                            {
                                switch (i2)
                                {
                                    case 1: CurrentCompetitor.name = (DataReader.GetString(i2)); break;
                                    case 2: CurrentCompetitor.team = (DataReader.GetString(i2)); break;
                                    case 3: CurrentCompetitor.nationality = (DataReader.GetString(i2)); break;
                                }
                                if (i2 == 3) { Competitors.Add(CurrentCompetitor); }
                            }
                        }
                        DataReader.Close();
                    }
                    catch (MySqlException ex)
                    {
                        error = ex.Message;
                    }
                }
                this.CloseConnection();
            }
            return Competitors;
        }

        public List<Team> GetTeamsForEvent(int EventID)
        {
            List<MySqlCompetitorTeamReturn> Competitors = new List<MySqlCompetitorTeamReturn>();
            List<Team> Teams = new List<Team>();
            string query = "SELECT * FROM `event teams` WHERE `EventID`='" + EventID + "';";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                try
                {
                    MySqlDataReader DataReader = cmd.ExecuteReader();
                    while (DataReader.Read())
                    {
                        MySqlCompetitorTeamReturn CurrentCompetitor = new MySqlCompetitorTeamReturn();
                        CurrentCompetitor.Team = "";
                        CurrentCompetitor.UID = -1;

                        for (int i = 0; i < DataReader.FieldCount; i++)
                        {
                            switch (i)
                            {
                                case 1: CurrentCompetitor.UID = DataReader.GetInt16(i); break;
                                case 2: CurrentCompetitor.Team = DataReader.GetString(i); break;
                            }
                            if (i == 2) { Competitors.Add(CurrentCompetitor); }
                        }
                    }
                    DataReader.Close();
                }
                catch (MySqlException ex)
                {
                    error = ex.Message;
                }

                for (int Ci = 0; Ci < Competitors.Count; Ci++) // For each competitor
                {
                    string CurrentTeam = Competitors[Ci].Team;
                    bool IsUnique = true;
                    int TeamIndex = 0;

                    for (int Ti = 0; Ti < Teams.Count; Ti++) // Check if the team is unique
                    {
                        if (CurrentTeam == Teams[Ti].Name) { IsUnique = false; TeamIndex = Ti; }
                    }

                    if (IsUnique == true) // If it is, add the team, and create the list.
                    #region IsUnique
                    {
                        Team newTeam = new Team();
                        newTeam.Name = CurrentTeam;
                        Teams.Add(newTeam);

                        query = "SELECT * FROM `competitors` WHERE `UID`='" + Competitors[Ci].UID + "';";

                        cmd = new MySqlCommand(query, connection);
                        try
                        {
                            MySqlDataReader DataReader = cmd.ExecuteReader();
                            while (DataReader.Read())
                            {
                                EventCompetitor CurrentCompetitor = new EventCompetitor();
                                CurrentCompetitor.ID = -1;
                                CurrentCompetitor.name = "";
                                CurrentCompetitor.nationality = "";
                                CurrentCompetitor.team = "";

                                for (int i2 = 0; i2 < DataReader.FieldCount; i2++)
                                {
                                    switch (i2)
                                    {
                                        case 0: CurrentCompetitor.ID = DataReader.GetInt16(i2); break;
                                        case 1: CurrentCompetitor.name = DataReader.GetString(i2); break;
                                        case 2: CurrentCompetitor.team = DataReader.GetString(i2); break;
                                        case 3: CurrentCompetitor.nationality = DataReader.GetString(i2); break;
                                    }
                                    if (i2 == 3) { Teams[Teams.Count - 1].Competitors.Add(CurrentCompetitor); }
                                }
                            }
                            DataReader.Close();
                        }
                        catch (MySqlException ex)
                        {
                            error = ex.Message;
                        }
                    }
                    #endregion
                    else
                    #region NotUnique
                    {
                        query = "SELECT * FROM `competitors` WHERE `UID`='" + Competitors[Ci].UID + "';";

                        cmd = new MySqlCommand(query, connection);
                        try
                        {
                            MySqlDataReader DataReader = cmd.ExecuteReader();
                            while (DataReader.Read())
                            {
                                EventCompetitor CurrentCompetitor = new EventCompetitor();
                                CurrentCompetitor.ID = -1;
                                CurrentCompetitor.name = "";
                                CurrentCompetitor.nationality = "";
                                CurrentCompetitor.team = "";

                                for (int i2 = 0; i2 < DataReader.FieldCount; i2++)
                                {
                                    switch (i2)
                                    {
                                        case 0: CurrentCompetitor.ID = DataReader.GetInt16(i2); break;
                                        case 1: CurrentCompetitor.name = DataReader.GetString(i2); break;
                                        case 2: CurrentCompetitor.team = DataReader.GetString(i2); break;
                                        case 3: CurrentCompetitor.nationality = DataReader.GetString(i2); break;
                                    }
                                    if (i2 == 3) { Teams[TeamIndex].Competitors.Add(CurrentCompetitor); }
                                }
                            }
                            DataReader.Close();
                        }
                        catch (MySqlException ex)
                        {
                            error = ex.Message;
                        }
                    }
                    #endregion
                }
            }
            this.CloseConnection();
            return Teams;
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
