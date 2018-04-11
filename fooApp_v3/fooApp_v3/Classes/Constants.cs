using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fooApp_v3.Classes
{
    /*
     *  Created by Alex Watts
     */

    /// <summary>
    /// A Tier 1 Master Class for providing access to all application resources & backbone data
    /// </summary>
    public static class Constants
    {
        /*
         * Instantiate Tier 2 Master Classes
         */

        /// <summary>
        /// Contains all references to all data sources & related behaviors for the application
        /// </summary>
        public static ApplicationDataSources AppDataSources = new ApplicationDataSources();

        /// <summary>
        /// Contains all definitions & behaviors for illegal characters in the application
        /// </summary>
        public static IllegalStringCharacters IllegalCharacters = new IllegalStringCharacters();

        /// <summary>
        /// Contains all definitions & behaviors for standardized error messages in the application
        /// </summary>
        public static ApplicationErrorMessages AppErrorMessages = new ApplicationErrorMessages();

        /// <summary>
        /// Contains all definitions & behaviors for the application's startup
        /// </summary>
        public static StartupRoutines StartupRoutine = new StartupRoutines();

        /// <summary>
        /// Defines the User Roles described in the database, but this makes it more internally accessible to the application
        /// </summary>
        public enum UserRolePermissions
        {
            Admin = 1,
            User = 2,
            Other = 3,
            Team = 4
        };

        /// <summary>
        /// Defines the Contestant Statuses described in the database, but this makes it more internally accessible to the application
        /// </summary>
        public enum ContestantStatuses
        {
            Active = 1,
            Inactive = 2,
            Retired = 3
        };

        /// <summary>
        /// Defines the Contestant Types described in the database, but this makes it more internally accessible to the application
        /// </summary>
        public enum ContestantTypes
        {
            Player = 1,
            Team = 2
        };
    }

    /*
     *  Tier 2 Classes
     */
    #region Tier 2 Classes

    /// <summary>
    /// Tier 2 Master Class used for housing all database & file resources for the application
    /// </summary>
    public class ApplicationDataSources
    {
        // Instantiate Tier 3 Master Classes that belong under ApplicationDataSources
        public readonly DatabaseResources DatabaseResources = new DatabaseResources();
        public readonly FileResources FileResources = new FileResources();
    }

    /// <summary>
    /// Tier 2 Master Class used for defining all illegal string characters for the application
    /// </summary>
    public class IllegalStringCharacters
    {
        // Returns a List of all illegal string characters
        public List<string> GetListOf_IllegalStringCharacters()
        {
            return new List<string>
            {
                "{",
                "}"
            };

        }

        // Turns the returned List object of illegal characters into a formatted output for display purposes
        public string Get_FormattedStringBuilderOf_IllegalStringCharacters()
        {
            // Create StringBuilder object set to the size of the Illegal Character list to format the output with
            StringBuilder formattedOutput = new StringBuilder(GetListOf_IllegalStringCharacters().Count());

            // Write out each illegal character from the list
            foreach (string character in GetListOf_IllegalStringCharacters())
            {
                formattedOutput.Append(character + "    ");
            }

            return formattedOutput.ToString();
        }
    }

    /// <summary>
    /// Tier 2 Master Class used for housing all error messages used throughout the application
    /// </summary>
    public class ApplicationErrorMessages
    {
        // Default/Generic error messages
        public readonly ErrorMessage Generic_ErrorMessage = new ErrorMessage();

        // Database error messages
        public readonly ErrorMessage DB_Query_ErrorMessage = new ErrorMessage("While attempting to query the database, the application has encountered the following error:   ", "A SQLITE Error Has Occurred");

        // Permissions error messages
        public readonly ErrorMessage Permissions_UserIsNotAdmin_ErrorMessage = new ErrorMessage("You do not have sufficient priviledges to access this feature . . . NERD!", "Permission Error");

        // Login/Registration error messages
        public readonly ErrorMessage Login_UserNotFound_ErrorMessage = new ErrorMessage("The Foos-ID you have entered does not match our records.\nPlease try again.", "Login Error");
        public readonly ErrorMessage Login_IncorrectPassword_ErrorMessage = new ErrorMessage("The password you have entered is incorrect.\nPlease try again.", "Login Error");
        public readonly ErrorMessage Registration_EmployeeNotFound_ErrorMessage = new ErrorMessage("The employee name you have entered does not match our records.\nPlease try again.", "Registration Error");
        public readonly ErrorMessage Registration_ExtensionNotFound_ErrorMessage = new ErrorMessage("The phone extension you have entered does not match our records.\nPlease try again.", "Registration Error");
        public readonly ErrorMessage Registration_ExtensionDoesNotMatch_ErrorMessage = new ErrorMessage("The phone extension you have entered does not belong to the employee you have entered.\nPlease try again.", "Registration Error");

        // Contestant error messages
        public readonly ErrorMessage Contestants_PlayerAlreadyExists_ErrorMessage = new ErrorMessage("The player you are trying to add already exists.", "Contestant Error");
        public readonly ErrorMessage Contestants_PlayersAlreadyOnSameTeam_ErrorMessage = new ErrorMessage("The two players you have selected are already on the same team.", "Contestant Error");
        public readonly ErrorMessage Contestants_TeamAlreadyExists_ErrorMessage = new ErrorMessage("The team you are trying to add already exists.", "Contestant Error");
        public readonly ErrorMessage Contestants_CannotPlaceContestantInTeam_ErrorMessage = new ErrorMessage("Either the team selected is not a valid team or the player selected is not a valid player. \nThe team cannot be created.", "Contestant Error");
    }

    /// <summary>
    /// Tier 2 Master Class used for housing all methods necessary for the application's startup process
    /// </summary>
    public class StartupRoutines
    {
        public void Do_All_StartupRoutines()
        {
            Validate_All_DatabaseTables();
        }

        private void Validate_All_DatabaseTables()
        {
            // Verify that the SQLite Database Inventory file exists & create it if it does not
            if (!File.Exists(Constants.AppDataSources.DatabaseResources.Database_FileLocation))
            {
                SQLiteConnection.CreateFile(Constants.AppDataSources.DatabaseResources.Database_FileLocation);
            }

            /*
            *  Validate & Create Database Tables
            */
            #region Validate & Create Database Tables

            // tbl_Contestants
            if (!Constants.AppDataSources.DatabaseResources.DatabaseTable_Contestants.ExecuteQuery_DoesTable_Exist())
            {
                // Table needs to be created
                Constants.AppDataSources.DatabaseResources.DatabaseTable_Contestants.ExecuteQuery_CREATE_Table();
            }

            // tbl_Contestant_Types
            if (!Constants.AppDataSources.DatabaseResources.DatabaseTable_Contestant_Types.ExecuteQuery_DoesTable_Exist())
            {
                // Table needs to be created
                Constants.AppDataSources.DatabaseResources.DatabaseTable_Contestant_Types.ExecuteQuery_CREATE_Table();
            }

            // tbl_Contestant_Statuses
            if (!Constants.AppDataSources.DatabaseResources.DatabaseTable_Contestant_Statuses.ExecuteQuery_DoesTable_Exist())
            {
                // Table needs to be created
                Constants.AppDataSources.DatabaseResources.DatabaseTable_Contestant_Statuses.ExecuteQuery_CREATE_Table();
            }

            // tbl_Teams
            if (!Constants.AppDataSources.DatabaseResources.DatabaseTable_Teams.ExecuteQuery_DoesTable_Exist())
            {
                // Table needs to be created
                Constants.AppDataSources.DatabaseResources.DatabaseTable_Teams.ExecuteQuery_CREATE_Table();
            }

            // tbl_Match_Contestants
            if (!Constants.AppDataSources.DatabaseResources.DatabaseTable_Match_Contestants.ExecuteQuery_DoesTable_Exist())
            {
                // Table needs to be created
                Constants.AppDataSources.DatabaseResources.DatabaseTable_Match_Contestants.ExecuteQuery_CREATE_Table();
            }

            // tbl_Matches
            if (!Constants.AppDataSources.DatabaseResources.DatabaseTable_Matches.ExecuteQuery_DoesTable_Exist())
            {
                // Table needs to be created
                Constants.AppDataSources.DatabaseResources.DatabaseTable_Matches.ExecuteQuery_CREATE_Table();
            }

            // tbl_Login_Credentials
            if (!Constants.AppDataSources.DatabaseResources.DatabaseTable_Login_Credentials.ExecuteQuery_DoesTable_Exist())
            {
                // Table needs to be created
                Constants.AppDataSources.DatabaseResources.DatabaseTable_Login_Credentials.ExecuteQuery_CREATE_Table();
            }

            // tbl_RSI_Employee_Roster
            if (!Constants.AppDataSources.DatabaseResources.DatabaseTable_RSI_Employee_Roster.ExecuteQuery_DoesTable_Exist())
            {
                // Table needs to be created
                Constants.AppDataSources.DatabaseResources.DatabaseTable_RSI_Employee_Roster.ExecuteQuery_CREATE_Table();
            }

            // tbl_User_Roles
            if (!Constants.AppDataSources.DatabaseResources.Databasetable_UserRoles.ExecuteQuery_DoesTable_Exist())
            {
                // Table needs to be created
                Constants.AppDataSources.DatabaseResources.Databasetable_UserRoles.ExecuteQuery_CREATE_Table();
            }

            #endregion Validate & Create Database Tables
        }
    }

    #endregion Tier 2 Classes

    /*
     *  Tier 3 Classes
     */
    #region Tier 3 Classes
    
    /// <summary>
    /// Tier 3 Master Class used for defining all database resources for the application
    /// </summary>
    public class DatabaseResources
    {
        // Folder path to the associated database files for the application
        private readonly string Database_FolderPath = @"Database Files\";

        // Name of the database file
        private readonly string Database_Name = @"FoosAppDatabase.sqlite";

        // Fully qualified database file location
        public readonly string Database_FileLocation;

        // Fully qualified database connection string
        public readonly string Database_ConnectionString;

        public DatabaseResources()
        {
            Database_FileLocation = Database_FolderPath + Database_Name;
            Database_ConnectionString = ("Data Source=" + Database_FileLocation + "; Version=3");
        }

        // Instantiate Tier 4 Master Classes that belong under DatabaseResources
        public readonly DatabaseTable_tbl_Contestants DatabaseTable_Contestants = new DatabaseTable_tbl_Contestants();
        public readonly DatabaseTable_tbl_Contestant_Types DatabaseTable_Contestant_Types = new DatabaseTable_tbl_Contestant_Types();
        public readonly DatabaseTable_tbl_Contestant_Statuses DatabaseTable_Contestant_Statuses = new DatabaseTable_tbl_Contestant_Statuses();
        public readonly DatabaseTable_tbl_Teams DatabaseTable_Teams = new DatabaseTable_tbl_Teams();
        public readonly DatabaseTable_tbl_Match_Contestants DatabaseTable_Match_Contestants = new DatabaseTable_tbl_Match_Contestants();
        public readonly DatabaseTable_tbl_Matches DatabaseTable_Matches = new DatabaseTable_tbl_Matches();
        public readonly DatabaseTable_tbl_Login_Credentials DatabaseTable_Login_Credentials = new DatabaseTable_tbl_Login_Credentials();
        public readonly DatabaseTable_tbl_RSI_Employee_Roster DatabaseTable_RSI_Employee_Roster = new DatabaseTable_tbl_RSI_Employee_Roster();
        public readonly DatabaseTable_tbl_User_Roles Databasetable_UserRoles = new DatabaseTable_tbl_User_Roles();
    }

    /// <summary>
    /// Tier 3 Master Class used for defining all file resources for the application
    /// </summary>
    public class FileResources
    {
        public FileResources()
        {
            // Application currently does not use any file resources
        }
    }

    /// <summary>
    /// Tier 3 Master Class used for defining an error message's details
    /// </summary>
    public class ErrorMessage
    {
        private const string default_ErrorMessageBody = "The application has encountered an error. \nIf any error information is available, it will be displayed here:\n\n";
        private const string default_ErrorMessageHeader = "An Error Has Occurred";

        private string errorMessageBody = string.Empty;
        private string errorMessageHeader = string.Empty;

        public ErrorMessage(string message = null, string header = null)
        {
            // If no custom message header & body are provided, use the default ones
            if (!(message == null))
            {
                errorMessageBody = message;
            }
            else
            {
                errorMessageBody = default_ErrorMessageBody;
            }

            if (!(header == null))
            {
                errorMessageHeader = header;
            }
            else
            {
                errorMessageHeader = default_ErrorMessageHeader;
            }
        }        

        // Displays a formatted or default error message based on input
        public void Display_ErrorMessage(Exception ex = null)
        {
            if (ex == null)
            {
                MessageBox.Show(errorMessageBody, errorMessageHeader);
            }
            else
            {
                MessageBox.Show(errorMessageBody + "\n\n" + ex.ToString(), errorMessageHeader);
            }
        }
    }

    #endregion Tier 3 Classes

    /*
     *  Tier 4 Classes
     */
    #region Tier 4 Classes

    /// <summary>
    /// Tier 4 Master Class used to define the schema for & handle interactions with tbl_Contestants
    /// </summary>
    public class DatabaseTable_tbl_Contestants
    {
        // Name of the table
        public readonly string TableName = @"tbl_Contestants";

        // Query to create the table
        public readonly string Query_CreateTable;

        // Objects of sub classes for table definitions
        public readonly TableColumns_Names Column_Names;
        public readonly TableColumns_DataTypes Column_DataTypes;

        public DatabaseTable_tbl_Contestants()
        {
            // Instantiate Tier 4 Sub Classes
            Column_Names = new TableColumns_Names();
            Column_DataTypes = new TableColumns_DataTypes();

            #region Stupid Hack to Expose Foreign Key Columns

            var tempContestantTypes = new DatabaseTable_tbl_Contestant_Types();
            var tempContestantStatuses = new DatabaseTable_tbl_Contestant_Statuses();
            var tempLoginCredentials = new DatabaseTable_tbl_Login_Credentials();

            #endregion Stupid Hack to Expose Foreign Key Columns

            Query_CreateTable = string.Format(@"CREATE TABLE {0} ("
                                                + this.Column_Names.ID          + " " + this.Column_DataTypes.ID            + " PRIMARY KEY NOT NULL, "
                                                + this.Column_Names.Name        + " " + this.Column_DataTypes.Name          + " NOT NULL, "
                                                + this.Column_Names.Type_ID     + " " + this.Column_DataTypes.Type_ID       + " NOT NULL, "                                                
                                                + this.Column_Names.Status_ID   + " " + this.Column_DataTypes.Status_ID     + " NOT NULL, "
                                                + this.Column_Names.Login_ID    + " " + this.Column_DataTypes.Login_ID      + " NOT NULL, "
                                                + this.Column_Names.Wins        + " " + this.Column_DataTypes.Wins          + " NOT NULL, "
                                                + this.Column_Names.Losses      + " " + this.Column_DataTypes.Losses        + " NOT NULL, "
                                                + this.Column_Names.Self_Goals  + " " + this.Column_DataTypes.Self_Goals    + " NOT NULL, "
                                                + "FOREIGN KEY (" + this.Column_Names.Type_ID   + ") REFERENCES " + tempContestantTypes.TableName       + "(" + tempContestantTypes.Column_Names.ID     + "), "
                                                + "FOREIGN KEY (" + this.Column_Names.Status_ID + ") REFERENCES " + tempContestantStatuses.TableName    + "(" + tempContestantStatuses.Column_Names.ID  + "), "
                                                + "FOREIGN KEY (" + this.Column_Names.Login_ID  + ") REFERENCES " + tempLoginCredentials.TableName      + "(" + tempLoginCredentials.Column_Names.ID    + ")"
                                                + ");", this.TableName);
        }

        #region Sub Classes

        /// <summary>
        /// Tier 4 Sub Class that defines the names of each column in the table
        /// </summary>
        public class TableColumns_Names
        {
            public readonly string ID = "ID";
            public readonly string Name = "Name";
            public readonly string Type_ID = "Type_ID";            
            public readonly string Status_ID = "Status_ID";
            public readonly string Login_ID = "Login_ID";
            public readonly string Wins = "Wins";
            public readonly string Losses = "Losses";
            public readonly string Self_Goals = "Self_Goals";
        }

        /// <summary>
        /// Tier 4 Sub Class that defines the datatypes of each column in the table
        /// </summary>
        public class TableColumns_DataTypes
        {
            public readonly string ID = "INTEGER";
            public readonly string Name = "TEXT";
            public readonly string Type_ID = "INTEGER";            
            public readonly string Status_ID = "INTEGER";
            public readonly string Login_ID = "INTEGER";
            public readonly string Wins = "INTEGER";
            public readonly string Losses = "INTEGER";
            public readonly string Self_Goals = "INTEGER";
        }

        #endregion Sub Classes

        #region Database Queries

        /// <summary>
        /// Creates a SQLite Database table for this class
        /// </summary>
        public void ExecuteQuery_CREATE_Table()
        {
            using (SQLiteConnection db_Connection = new SQLiteConnection(Constants.AppDataSources.DatabaseResources.Database_ConnectionString))
            {
                try
                {
                    // Open the database connection
                    db_Connection.Open();

                    // Create a COMMAND object to execute queries on the database
                    SQLiteCommand command_Object = db_Connection.CreateCommand();

                    // Set the query text to the local Query_CreateTable variable
                    command_Object.CommandText = this.Query_CreateTable;

                    // Execute the query in the Command object
                    command_Object.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Display the exception that has occurred
                    Constants.AppErrorMessages.DB_Query_ErrorMessage.Display_ErrorMessage(ex);
                }
            }
        }

        /// <summary>
        /// Queries the database to check if the table for this class exists
        /// </summary>
        /// <returns></returns>
        public bool ExecuteQuery_DoesTable_Exist()
        {
            using (SQLiteConnection db_Connection = new SQLiteConnection(Constants.AppDataSources.DatabaseResources.Database_ConnectionString))
            {
                try
                {
                    // Open the database connection
                    db_Connection.Open();

                    // Create a COMMAND object to execute queries on the database
                    SQLiteCommand command_Object = db_Connection.CreateCommand();

                    // Clear any previous Parameters from the Command object
                    command_Object.Parameters.Clear();

                    // Create a query to return the number of tables with the given name
                    string sql = string.Format(@"SELECT COUNT(*) FROM sqlite_master WHERE type = 'table' AND name = ?");

                    // Create a Parameter object to pass data into the Command object for query execution
                    DbParameter param = command_Object.CreateParameter();
                    param.ParameterName = "@TableName";     // Name of the parameter to pass
                    param.DbType = DbType.String;           // Datatype of the parameter to pass
                    param.Value = this.TableName;           // Value of the parameter to pass

                    // Add the new Parameter object to the Command object
                    command_Object.Parameters.Add(param);

                    // Set the query text in the command object
                    command_Object.CommandText = sql;

                    // Execute the query in the Command object to return the first column of the first row of the result set
                    long? result = (long?)command_Object.ExecuteScalar();

                    // Check if anything was returned
                    if (result.HasValue)
                    {
                        // Check if actual results were returned
                        return result.Value > 0;
                    }
                    else
                    {
                        // Dataset was returned with no results
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    // Display the exception that has occurred
                    Constants.AppErrorMessages.DB_Query_ErrorMessage.Display_ErrorMessage(ex);

                    // Returning true if an error occurs to prevent any attempts at re-creating the table & losing data
                    return true;
                }
            }
        }

        /// <summary>
        /// Queries the database to insert a new Contestant to the table
        /// </summary>
        public void ExecuteQuery_INSERT_NewContestant(Contestant newContestant)
        {
            /*
             *  Note: In order for a new Contestant to be entered successfully,
             *  they must have a matching record for Login_ID from tbl_Login_Credentials
             */ 
            using (SQLiteConnection db_Connection = new SQLiteConnection(Constants.AppDataSources.DatabaseResources.Database_ConnectionString))
            {
                try
                {
                    // Open the database connection
                    db_Connection.Open();

                    // Create a COMMAND object to execute queries on the database
                    SQLiteCommand command_Object = db_Connection.CreateCommand();

                    // Create a query that will insert the new Contestant
                    string sql = string.Format(@"INSERT INTO {0} ("
                                                + this.Column_Names.Name + ", " + this.Column_Names.Type_ID + ", " + this.Column_Names.Status_ID    + ", " + this.Column_Names.Login_ID + ", " 
                                                + this.Column_Names.Wins + ", " + this.Column_Names.Losses  + ", " + this.Column_Names.Self_Goals   + ") "
                                                + "VALUES ("
                                                + "\"" + newContestant.Name + "\"" + ", " + newContestant.Type_ID + ", " + newContestant.Status_ID  + ", " + newContestant.Login_ID + ", " 
                                                +        newContestant.Wins        + ", " + newContestant.Losses  + ", " + newContestant.Self_Goals + ");"
                                                , this.TableName);

                    // Set the query text to the local Query_CreateTable variable
                    command_Object.CommandText = sql;

                    // Execute the query in the Command object
                    command_Object.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Display the exception that has occurred
                    Constants.AppErrorMessages.DB_Query_ErrorMessage.Display_ErrorMessage(ex);
                }
            }
        }

        /// <summary>
        /// Queries the database to update an existing Contestant
        /// </summary>
        public void ExecuteQuery_UPDATE_ExistingContestant(Contestant updateContestant)
        {
            /*
             *  Note: A contestant may not have their Type_ID or Login_ID changed
             */
            if (ExecuteQuery_SELECT_DoesContestantExist(updateContestant))
            {
                using (SQLiteConnection db_Connection = new SQLiteConnection(Constants.AppDataSources.DatabaseResources.Database_ConnectionString))
                {
                    try
                    {
                        // Open the database connection
                        db_Connection.Open();

                        // Create a COMMAND object to execute queries on the database
                        SQLiteCommand command_Object = db_Connection.CreateCommand();

                        // Create a query that will update the Contestant
                        string sql = string.Format(@"UPDATE {0} SET "
                                                    + this.Column_Names.Name            + " = \""   + updateContestant.Name         + "\", "
                                                    + this.Column_Names.Status_ID       + " = "     + updateContestant.Status_ID    + ", "
                                                    + this.Column_Names.Wins            + " = "     + updateContestant.Wins         + ", "
                                                    + this.Column_Names.Losses          + " = "     + updateContestant.Losses       + ", "
                                                    + this.Column_Names.Self_Goals      + " = "     + updateContestant.Self_Goals   + " "
                                                    + "WHERE (" + this.Column_Names.ID  + " = "     + updateContestant.ID           + ");"
                                                    , this.TableName);

                        // Set the query text to the local Query_CreateTable variable
                        command_Object.CommandText = sql;

                        // Execute the query in the Command object
                        command_Object.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        // Display the exception that has occurred
                        Constants.AppErrorMessages.DB_Query_ErrorMessage.Display_ErrorMessage(ex);
                    }
                }
            }
            else
            {

            }
        }

        /// <summary>
        /// Queries the database to check if a Contestant already exists
        /// </summary>
        /// <returns></returns>
        public bool ExecuteQuery_SELECT_DoesContestantExist(Contestant mysteriousContestant)
        {
            using (SQLiteConnection db_Connection = new SQLiteConnection(Constants.AppDataSources.DatabaseResources.Database_ConnectionString))
            {
                try
                {
                    // Open the database connection
                    db_Connection.Open();

                    // Create a COMMAND object to execute queries on the database
                    SQLiteCommand command_Object = db_Connection.CreateCommand();

                    // Create a query that will check to see if the Contestant already exists
                    string sql = string.Format(@"SELECT COUNT(*) FROM {0} "
                                                + "WHERE (" + this.Column_Names.ID + " = " + mysteriousContestant.ID + ");"
                                                , this.TableName);

                    // Set the query text in the command object
                    command_Object.CommandText = sql;

                    // Execute the query in the Command object to return the first column of the first row of the result set
                    long? result = (long?)command_Object.ExecuteScalar();

                    // Check if anything was returned
                    if (result.HasValue)
                    {
                        // Check if actual results were returned
                        return result.Value > 0;
                    }
                    else
                    {
                        // Dataset was returned with no results
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    // Display the exception that has occurred
                    Constants.AppErrorMessages.DB_Query_ErrorMessage.Display_ErrorMessage(ex);
                }
            }

            return false;
        }

        #endregion Database Queries
    }

    /// <summary>
    /// Tier 4 Master Class used to define the schema for & handle interactions with tbl_Contestant_Types
    /// </summary>
    public class DatabaseTable_tbl_Contestant_Types
    {
        // Name of the table
        public readonly string TableName = @"tbl_Contestant_Types";

        // Query to create the table
        public readonly string Query_CreateTable;

        // Objects of sub classes for table definitions
        public readonly TableColumns_Names Column_Names;
        public readonly TableColumns_DataTypes Column_DataTypes;

        public DatabaseTable_tbl_Contestant_Types()
        {
            // Instantiate Tier 4 Sub Classes
            Column_Names = new TableColumns_Names();
            Column_DataTypes = new TableColumns_DataTypes();            

            Query_CreateTable = string.Format(@"CREATE TABLE {0} ("
                                                + this.Column_Names.ID      + " " + this.Column_DataTypes.ID    + " PRIMARY KEY NOT NULL, "
                                                + this.Column_Names.Type    + " " + this.Column_DataTypes.Type  + " NOT NULL"
                                                + ");", this.TableName);
        }

        #region Sub Classes

        /// <summary>
        /// Tier 4 Sub Class that defines the names of each column in the table
        /// </summary>
        public class TableColumns_Names
        {
            public readonly string ID = "ID";
            public readonly string Type = "Type";
        }

        /// <summary>
        /// Tier 4 Sub Class that defines the datatypes of each column in the table
        /// </summary>
        public class TableColumns_DataTypes
        {
            public readonly string ID = "INTEGER";
            public readonly string Type = "TEXT";
        }

        #endregion Sub Classes

        #region Database Queries

        /// <summary>
        /// Creates a SQLite Database table for this class
        /// </summary>
        public void ExecuteQuery_CREATE_Table()
        {
            using (SQLiteConnection db_Connection = new SQLiteConnection(Constants.AppDataSources.DatabaseResources.Database_ConnectionString))
            {
                try
                {
                    // Open the database connection
                    db_Connection.Open();

                    // Create a COMMAND object to execute queries on the database
                    SQLiteCommand command_Object = db_Connection.CreateCommand();

                    // Set the query text to the local Query_CreateTable variable
                    command_Object.CommandText = this.Query_CreateTable;

                    // Execute the query in the Command object
                    command_Object.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Display the exception that has occurred
                    Constants.AppErrorMessages.DB_Query_ErrorMessage.Display_ErrorMessage(ex);
                }
            }
        }

        /// <summary>
        /// Queries the database to check if the table for this class exists
        /// </summary>
        /// <returns></returns>
        public bool ExecuteQuery_DoesTable_Exist()
        {
            using (SQLiteConnection db_Connection = new SQLiteConnection(Constants.AppDataSources.DatabaseResources.Database_ConnectionString))
            {
                try
                {
                    // Open the database connection
                    db_Connection.Open();

                    // Create a COMMAND object to execute queries on the database
                    SQLiteCommand command_Object = db_Connection.CreateCommand();

                    // Clear any previous Parameters from the Command object
                    command_Object.Parameters.Clear();

                    // Create a query to return the number of tables with the given name
                    string sql = string.Format(@"SELECT COUNT(*) FROM sqlite_master WHERE type = 'table' AND name = ?");

                    // Create a Parameter object to pass data into the Command object for query execution
                    DbParameter param = command_Object.CreateParameter();
                    param.ParameterName = "@TableName";     // Name of the parameter to pass
                    param.DbType = DbType.String;           // Datatype of the parameter to pass
                    param.Value = this.TableName;           // Value of the parameter to pass

                    // Add the new Parameter object to the Command object
                    command_Object.Parameters.Add(param);

                    // Set the query text in the command object
                    command_Object.CommandText = sql;

                    // Execute the query in the Command object to return the first column of the first row of the result set
                    long? result = (long?)command_Object.ExecuteScalar();

                    // Check if anything was returned
                    if (result.HasValue)
                    {
                        // Check if actual results were returned
                        return result.Value > 0;
                    }
                    else
                    {
                        // Dataset was returned with no results
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    // Display the exception that has occurred
                    Constants.AppErrorMessages.DB_Query_ErrorMessage.Display_ErrorMessage(ex);

                    // Returning true if an error occurs to prevent any attempts at re-creating the table & losing data
                    return true;
                }
            }
        }

        #endregion Database Queries
    }

    /// <summary>
    /// Tier 4 Master Class used to define the schema for & handle interactions with tbl_Statuses
    /// </summary>
    public class DatabaseTable_tbl_Contestant_Statuses
    {
        // Name of the table
        public readonly string TableName = @"tbl_Contestant_Statuses";

        // Query to create the table
        public readonly string Query_CreateTable;

        // Objects of sub classes for table definitions
        public readonly TableColumns_Names Column_Names;
        public readonly TableColumns_DataTypes Column_DataTypes;

        public DatabaseTable_tbl_Contestant_Statuses()
        {
            // Instantiate Tier 4 Sub Classes
            Column_Names = new TableColumns_Names();
            Column_DataTypes = new TableColumns_DataTypes();

            Query_CreateTable = string.Format(@"CREATE TABLE {0} ("
                                                + this.Column_Names.ID     + " " + this.Column_DataTypes.ID     + " PRIMARY KEY NOT NULL, "
                                                + this.Column_Names.Status + " " + this.Column_DataTypes.Status + " NOT NULL"
                                                + ");", this.TableName);
        }

        #region Sub Classes

        /// <summary>
        /// Tier 4 Sub Class that defines the names of each column in the table
        /// </summary>
        public class TableColumns_Names
        {
            public readonly string ID = "ID";
            public readonly string Status = "Status";
        }

        /// <summary>
        /// Tier 4 Sub Class that defines the datatypes of each column in the table
        /// </summary>
        public class TableColumns_DataTypes
        {
            public readonly string ID = "INTEGER";
            public readonly string Status = "TEXT";
        }

        #endregion Sub Classes

        #region Database Queries

        /// <summary>
        /// Creates a SQLite Database table for this class
        /// </summary>
        public void ExecuteQuery_CREATE_Table()
        {
            using (SQLiteConnection db_Connection = new SQLiteConnection(Constants.AppDataSources.DatabaseResources.Database_ConnectionString))
            {
                try
                {
                    // Open the database connection
                    db_Connection.Open();

                    // Create a COMMAND object to execute queries on the database
                    SQLiteCommand command_Object = db_Connection.CreateCommand();

                    // Set the query text to the local Query_CreateTable variable
                    command_Object.CommandText = this.Query_CreateTable;

                    // Execute the query in the Command object
                    command_Object.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Display the exception that has occurred
                    Constants.AppErrorMessages.DB_Query_ErrorMessage.Display_ErrorMessage(ex);
                }
            }
        }

        /// <summary>
        /// Queries the database to check if the table for this class exists
        /// </summary>
        /// <returns></returns>
        public bool ExecuteQuery_DoesTable_Exist()
        {
            using (SQLiteConnection db_Connection = new SQLiteConnection(Constants.AppDataSources.DatabaseResources.Database_ConnectionString))
            {
                try
                {
                    // Open the database connection
                    db_Connection.Open();

                    // Create a COMMAND object to execute queries on the database
                    SQLiteCommand command_Object = db_Connection.CreateCommand();

                    // Clear any previous Parameters from the Command object
                    command_Object.Parameters.Clear();

                    // Create a query to return the number of tables with the given name
                    string sql = string.Format(@"SELECT COUNT(*) FROM sqlite_master WHERE type = 'table' AND name = ?");

                    // Create a Parameter object to pass data into the Command object for query execution
                    DbParameter param = command_Object.CreateParameter();
                    param.ParameterName = "@TableName";     // Name of the parameter to pass
                    param.DbType = DbType.String;           // Datatype of the parameter to pass
                    param.Value = this.TableName;           // Value of the parameter to pass

                    // Add the new Parameter object to the Command object
                    command_Object.Parameters.Add(param);

                    // Set the query text in the command object
                    command_Object.CommandText = sql;

                    // Execute the query in the Command object to return the first column of the first row of the result set
                    long? result = (long?)command_Object.ExecuteScalar();

                    // Check if anything was returned
                    if (result.HasValue)
                    {
                        // Check if actual results were returned
                        return result.Value > 0;
                    }
                    else
                    {
                        // Dataset was returned with no results
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    // Display the exception that has occurred
                    Constants.AppErrorMessages.DB_Query_ErrorMessage.Display_ErrorMessage(ex);

                    // Returning true if an error occurs to prevent any attempts at re-creating the table & losing data
                    return true;
                }
            }
        }

        #endregion Database Queries
    }

    /// <summary>
    /// Tier 4 Master Class used to define the schema for & handle interactions with tbl_Teams
    /// </summary>
    public class DatabaseTable_tbl_Teams
    {
        // Name of the table
        public readonly string TableName = @"tbl_Teams";

        // Query to create the table
        public readonly string Query_CreateTable;

        // Objects of sub classes for table definitions
        public readonly TableColumns_Names Column_Names;
        public readonly TableColumns_DataTypes Column_DataTypes;

        public DatabaseTable_tbl_Teams()
        {
            // Instantiate Tier 4 Sub Classes
            Column_Names = new TableColumns_Names();
            Column_DataTypes = new TableColumns_DataTypes();

            #region Stupid Hack to Expose Foreign Key Columns

            var tempContestants = new DatabaseTable_tbl_Contestants();            

            #endregion Stupid Hack to Expose Foreign Key Columns

            Query_CreateTable = string.Format(@"CREATE TABLE {0} ("
                                                + this.Column_Names.ID          + " " + this.Column_DataTypes.ID        + " PRIMARY KEY NOT NULL, "
                                                + this.Column_Names.Team_ID     + " " + this.Column_DataTypes.Team_ID   + " NOT NULL, "
                                                + this.Column_Names.Player_ID   + " " + this.Column_DataTypes.Player_ID + " NOT NULL, "
                                                + "FOREIGN KEY (" + this.Column_Names.Team_ID   + ") REFERENCES " + tempContestants.TableName + "(" + tempContestants.Column_Names.ID + "), "
                                                + "FOREIGN KEY (" + this.Column_Names.Player_ID + ") REFERENCES " + tempContestants.TableName + "(" + tempContestants.Column_Names.ID + ")"
                                                + "); "
                                                + "CREATE INDEX TeamCannotDupePlayer ON {0} (" + this.Column_Names.Team_ID + " ASC, " + this.Column_Names.Player_ID + " ASC);"
                                                , this.TableName);
        }

        #region Sub Classes

        /// <summary>
        /// Tier 4 Sub Class that defines the names of each column in the table
        /// </summary>
        public class TableColumns_Names
        {
            public readonly string ID = "ID";
            public readonly string Team_ID = "Team_ID";
            public readonly string Player_ID = "Player_ID";
        }

        /// <summary>
        /// Tier 4 Sub Class that defines the datatypes of each column in the table
        /// </summary>
        public class TableColumns_DataTypes
        {
            public readonly string ID = "INTEGER";
            public readonly string Team_ID = "INTEGER";
            public readonly string Player_ID = "INTEGER";
        }

        #endregion Sub Classes

        #region Database Queries

        /// <summary>
        /// Creates a SQLite Database table for this class
        /// </summary>
        public void ExecuteQuery_CREATE_Table()
        {
            using (SQLiteConnection db_Connection = new SQLiteConnection(Constants.AppDataSources.DatabaseResources.Database_ConnectionString))
            {
                try
                {
                    // Open the database connection
                    db_Connection.Open();

                    // Create a COMMAND object to execute queries on the database
                    SQLiteCommand command_Object = db_Connection.CreateCommand();

                    // Set the query text to the local Query_CreateTable variable
                    command_Object.CommandText = this.Query_CreateTable;

                    // Execute the query in the Command object
                    command_Object.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Display the exception that has occurred
                    Constants.AppErrorMessages.DB_Query_ErrorMessage.Display_ErrorMessage(ex);
                }
            }
        }

        /// <summary>
        /// Queries the database to check if the table for this class exists
        /// </summary>
        /// <returns></returns>
        public bool ExecuteQuery_DoesTable_Exist()
        {
            using (SQLiteConnection db_Connection = new SQLiteConnection(Constants.AppDataSources.DatabaseResources.Database_ConnectionString))
            {
                try
                {
                    // Open the database connection
                    db_Connection.Open();

                    // Create a COMMAND object to execute queries on the database
                    SQLiteCommand command_Object = db_Connection.CreateCommand();

                    // Clear any previous Parameters from the Command object
                    command_Object.Parameters.Clear();

                    // Create a query to return the number of tables with the given name
                    string sql = string.Format(@"SELECT COUNT(*) FROM sqlite_master WHERE type = 'table' AND name = ?");

                    // Create a Parameter object to pass data into the Command object for query execution
                    DbParameter param = command_Object.CreateParameter();
                    param.ParameterName = "@TableName";     // Name of the parameter to pass
                    param.DbType = DbType.String;           // Datatype of the parameter to pass
                    param.Value = this.TableName;           // Value of the parameter to pass

                    // Add the new Parameter object to the Command object
                    command_Object.Parameters.Add(param);

                    // Set the query text in the command object
                    command_Object.CommandText = sql;

                    // Execute the query in the Command object to return the first column of the first row of the result set
                    long? result = (long?)command_Object.ExecuteScalar();

                    // Check if anything was returned
                    if (result.HasValue)
                    {
                        // Check if actual results were returned
                        return result.Value > 0;
                    }
                    else
                    {
                        // Dataset was returned with no results
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    // Display the exception that has occurred
                    Constants.AppErrorMessages.DB_Query_ErrorMessage.Display_ErrorMessage(ex);

                    // Returning true if an error occurs to prevent any attempts at re-creating the table & losing data
                    return true;
                }
            }
        }

        // TODO : add to documentation & verify routine
        public void ExecuteQuery_INSERT_NewTeamMember(Contestant joinTeam, Contestant newMember)
        {
            // Verify that we are being passed a valid Team & Player, and not two of either type
            if ((joinTeam.Type_ID == (int)Constants.ContestantTypes.Team) && (newMember.Type_ID == (int)Constants.ContestantTypes.Player))
            {
                using (SQLiteConnection db_Connection = new SQLiteConnection(Constants.AppDataSources.DatabaseResources.Database_ConnectionString))
                {
                    try
                    {
                        // Open the database connection
                        db_Connection.Open();

                        // Create a COMMAND object to execute queries on the database
                        SQLiteCommand command_Object = db_Connection.CreateCommand();

                        // Create a query to assign a Contestant to a Team
                        string sql = string.Format(@"INSERT INTO {0} ("
                                                    + this.Column_Names.Team_ID + ", " + this.Column_Names.Player_ID + ") "
                                                    + "VALUES ("
                                                    + joinTeam.ID + ", " + newMember.ID + ");"
                                                    , this.TableName);

                        // Set the query text to the local Query_CreateTable variable
                        command_Object.CommandText = sql;

                        // Execute the query in the Command object
                        command_Object.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        // Display the exception that has occurred
                        Constants.AppErrorMessages.DB_Query_ErrorMessage.Display_ErrorMessage(ex);
                    }
                }
            }
            else
            {
                // Display an error that the Contestant must be of type Player to be added to a Team
                Constants.AppErrorMessages.Contestants_CannotPlaceContestantInTeam_ErrorMessage.Display_ErrorMessage();
            }
        }

        #endregion Database Queries
    }

    /// <summary>
    /// Tier 4 Master Class used to define the schema for & handle interactions with tbl_Match_Contestants
    /// </summary>
    public class DatabaseTable_tbl_Match_Contestants
    {
        // Name of the table
        public readonly string TableName = @"tbl_Match_Contestants";

        // Query to create the table
        public readonly string Query_CreateTable;

        // Objects of sub classes for table definitions
        public readonly TableColumns_Names Column_Names;
        public readonly TableColumns_DataTypes Column_DataTypes;

        public DatabaseTable_tbl_Match_Contestants()
        {
            // Instantiate Tier 4 Sub Classes
            Column_Names = new TableColumns_Names();
            Column_DataTypes = new TableColumns_DataTypes();

            #region Stupid Hack to Expose Foreign Key Columns

            var tempContestants = new DatabaseTable_tbl_Contestants();
            var tempMatches = new DatabaseTable_tbl_Matches();

            #endregion Stupid Hack to Expose Foreign Key Columns

            Query_CreateTable = string.Format(@"CREATE TABLE {0} ("
                                                + this.Column_Names.ID              + " " + this.Column_DataTypes.ID            + " PRIMARY KEY NOT NULL, "
                                                + this.Column_Names.Match_ID        + " " + this.Column_DataTypes.Match_ID      + " NOT NULL, "
                                                + this.Column_Names.Contestant_ID   + " " + this.Column_DataTypes.Contestant_ID + " NOT NULL, "
                                                + this.Column_Names.Score           + " " + this.Column_DataTypes.Score         + " NOT NULL, "
                                                + "FOREIGN KEY (" + this.Column_Names.Match_ID      + ") REFERENCES " + tempMatches.TableName       + "(" + tempMatches.Column_Names.ID     + "), "
                                                + "FOREIGN KEY (" + this.Column_Names.Contestant_ID + ") REFERENCES " + tempContestants.TableName   + "(" + tempContestants.Column_Names.ID + ")"
                                                + ");", this.TableName);
        }

        #region Sub Classes

        /// <summary>
        /// Tier 4 Sub Class that defines the names of each column in the table
        /// </summary>
        public class TableColumns_Names
        {
            public readonly string ID = "ID";
            public readonly string Match_ID = "Match_ID";
            public readonly string Contestant_ID = "Contestant_ID";
            public readonly string Score = "Score";
        }

        /// <summary>
        /// Tier 4 Sub Class that defines the datatypes of each column in the table
        /// </summary>
        public class TableColumns_DataTypes
        {
            public readonly string ID = "INTEGER";
            public readonly string Match_ID = "INTEGER";
            public readonly string Contestant_ID = "INTEGER";
            public readonly string Score = "INTEGER";
        }

        #endregion Sub Classes

        #region Database Queries

        /// <summary>
        /// Creates a SQLite Database table for this class
        /// </summary>
        public void ExecuteQuery_CREATE_Table()
        {
            using (SQLiteConnection db_Connection = new SQLiteConnection(Constants.AppDataSources.DatabaseResources.Database_ConnectionString))
            {
                try
                {
                    // Open the database connection
                    db_Connection.Open();

                    // Create a COMMAND object to execute queries on the database
                    SQLiteCommand command_Object = db_Connection.CreateCommand();

                    // Set the query text to the local Query_CreateTable variable
                    command_Object.CommandText = this.Query_CreateTable;

                    // Execute the query in the Command object
                    command_Object.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Display the exception that has occurred
                    Constants.AppErrorMessages.DB_Query_ErrorMessage.Display_ErrorMessage(ex);
                }
            }
        }       

        /// <summary>
        /// Queries the database to check if the table for this class exists
        /// </summary>
        /// <returns></returns>
        public bool ExecuteQuery_DoesTable_Exist()
        {
            using (SQLiteConnection db_Connection = new SQLiteConnection(Constants.AppDataSources.DatabaseResources.Database_ConnectionString))
            {
                try
                {
                    // Open the database connection
                    db_Connection.Open();

                    // Create a COMMAND object to execute queries on the database
                    SQLiteCommand command_Object = db_Connection.CreateCommand();

                    // Clear any previous Parameters from the Command object
                    command_Object.Parameters.Clear();

                    // Create a query to return the number of tables with the given name
                    string sql = string.Format(@"SELECT COUNT(*) FROM sqlite_master WHERE type = 'table' AND name = ?");

                    // Create a Parameter object to pass data into the Command object for query execution
                    DbParameter param = command_Object.CreateParameter();
                    param.ParameterName = "@TableName";     // Name of the parameter to pass
                    param.DbType = DbType.String;           // Datatype of the parameter to pass
                    param.Value = this.TableName;           // Value of the parameter to pass
                    
                    // Add the new Parameter object to the Command object
                    command_Object.Parameters.Add(param);

                    // Set the query text in the command object
                    command_Object.CommandText = sql;

                    // Execute the query in the Command object to return the first column of the first row of the result set
                    long? result = (long?)command_Object.ExecuteScalar();

                    // Check if anything was returned
                    if (result.HasValue)
                    {
                        // Check if actual results were returned
                        return result.Value > 0;
                    }
                    else
                    {
                        // Dataset was returned with no results
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    // Display the exception that has occurred
                    Constants.AppErrorMessages.DB_Query_ErrorMessage.Display_ErrorMessage(ex);

                    // Returning true if an error occurs to prevent any attempts at re-creating the table & losing data
                    return true;
                }
            }
        }

        // TODO : Figure out how we will take in this information via params
        public void ExecuteQuery_INSERT_RecordNewMatch(Contestant matchContestant, int score)
        {
            using (SQLiteConnection db_Connection = new SQLiteConnection(Constants.AppDataSources.DatabaseResources.Database_ConnectionString))
            {
                try
                {
                    // Open the database connection
                    db_Connection.Open();

                    // Create a COMMAND object to execute queries on the database
                    SQLiteCommand command_Object = db_Connection.CreateCommand();

                    // Create a query to record the results of the Match against the Contestants who played
                    string sql = string.Format(@"INSERT INTO {0} ("
                                                + this.Column_Names.Match_ID + ", " + this.Column_Names.Contestant_ID + ", " + this.Column_Names.Score + ") "
                                                + "VALUES ("
                                                + "("
                                                    + "SELECT MAX(" + Constants.AppDataSources.DatabaseResources.DatabaseTable_Matches.Column_Names.ID + ")"
                                                + ") AS Match_ID, "
                                                + matchContestant.ID + ", " + score + ");"
                                                , this.TableName);

                    // Set the query text to the local Query_CreateTable variable
                    command_Object.CommandText = this.Query_CreateTable;

                    // Execute the query in the Command object
                    command_Object.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Display the exception that has occurred
                    Constants.AppErrorMessages.DB_Query_ErrorMessage.Display_ErrorMessage(ex);
                }
            }
        }

        #endregion Database Queries
    }

    /// <summary>
    /// Tier 4 Master Class used to define the schema for & handle interactions with tbl_Matches
    /// </summary>
    public class DatabaseTable_tbl_Matches
    {
        // Name of the table
        public readonly string TableName = @"tbl_Matches";

        // Query to create the table
        public readonly string Query_CreateTable;

        // Objects of sub classes for table definitions
        public readonly TableColumns_Names Column_Names;
        public readonly TableColumns_DataTypes Column_DataTypes;

        public DatabaseTable_tbl_Matches()
        {
            // Instantiate Tier 4 Sub Classes
            Column_Names = new TableColumns_Names();
            Column_DataTypes = new TableColumns_DataTypes();

            Query_CreateTable = string.Format(@"CREATE TABLE {0} ("
                                                + this.Column_Names.ID                  + " " + this.Column_DataTypes.ID                    + " PRIMARY KEY NOT NULL, "
                                                + this.Column_Names.Date_Played         + " " + this.Column_DataTypes.Date_Played           + " NOT NULL, "
                                                + this.Column_Names.Duration_In_Seconds + " " + this.Column_DataTypes.Duration_In_Seconds   + " NOT NULL"
                                                + ");", this.TableName);
        }

        #region Sub Classes

        /// <summary>
        /// Tier 4 Sub Class that defines the names of each column in the table
        /// </summary>
        public class TableColumns_Names
        {
            public readonly string ID = "ID";
            public readonly string Date_Played = "Date_Played";
            public readonly string Duration_In_Seconds = "Duration_In_Seconds";
        }

        /// <summary>
        /// Tier 4 Sub Class that defines the datatypes of each column in the table
        /// </summary>
        public class TableColumns_DataTypes
        {
            public readonly string ID = "INTEGER";
            public readonly string Date_Played = "INTEGER";
            public readonly string Duration_In_Seconds = "INTEGER";
        }

        #endregion Sub Classes

        #region Database Queries

        /// <summary>
        /// Creates a SQLite Database table for this class
        /// </summary>
        public void ExecuteQuery_CREATE_Table()
        {
            using (SQLiteConnection db_Connection = new SQLiteConnection(Constants.AppDataSources.DatabaseResources.Database_ConnectionString))
            {
                try
                {
                    // Open the database connection
                    db_Connection.Open();

                    // Create a COMMAND object to execute queries on the database
                    SQLiteCommand command_Object = db_Connection.CreateCommand();

                    // Set the query text to the local Query_CreateTable variable
                    command_Object.CommandText = this.Query_CreateTable;

                    // Execute the query in the Command object
                    command_Object.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Display the exception that has occurred
                    Constants.AppErrorMessages.DB_Query_ErrorMessage.Display_ErrorMessage(ex);
                }
            }
        }

        /// <summary>
        /// Queries the database to check if the table for this class exists
        /// </summary>
        /// <returns></returns>
        public bool ExecuteQuery_DoesTable_Exist()
        {
            using (SQLiteConnection db_Connection = new SQLiteConnection(Constants.AppDataSources.DatabaseResources.Database_ConnectionString))
            {
                try
                {
                    // Open the database connection
                    db_Connection.Open();

                    // Create a COMMAND object to execute queries on the database
                    SQLiteCommand command_Object = db_Connection.CreateCommand();

                    // Clear any previous Parameters from the Command object
                    command_Object.Parameters.Clear();

                    // Create a query to return the number of tables with the given name
                    string sql = string.Format(@"SELECT COUNT(*) FROM sqlite_master WHERE type = 'table' AND name = ?");

                    // Create a Parameter object to pass data into the Command object for query execution
                    DbParameter param = command_Object.CreateParameter();
                    param.ParameterName = "@TableName";     // Name of the parameter to pass
                    param.DbType = DbType.String;           // Datatype of the parameter to pass
                    param.Value = this.TableName;           // Value of the parameter to pass

                    // Add the new Parameter object to the Command object
                    command_Object.Parameters.Add(param);

                    // Set the query text in the command object
                    command_Object.CommandText = sql;

                    // Execute the query in the Command object to return the first column of the first row of the result set
                    long? result = (long?)command_Object.ExecuteScalar();

                    // Check if anything was returned
                    if (result.HasValue)
                    {
                        // Check if actual results were returned
                        return result.Value > 0;
                    }
                    else
                    {
                        // Dataset was returned with no results
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    // Display the exception that has occurred
                    Constants.AppErrorMessages.DB_Query_ErrorMessage.Display_ErrorMessage(ex);

                    // Returning true if an error occurs to prevent any attempts at re-creating the table & losing data
                    return true;
                }
            }
        }

        /// <summary>
        /// Queries the database to insert the time data for a Match
        /// </summary>
        /// <param name="matchLengthInSeconds"></param>
        public void ExecuteQuery_INSERT_RecordNewMatch(int matchLengthInSeconds)
        {
            using (SQLiteConnection db_Connection = new SQLiteConnection(Constants.AppDataSources.DatabaseResources.Database_ConnectionString))
            {
                try
                {
                    // Convert the current Date to a Unix-based integer for storing in the database
                    int unixTimeStamp = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

                    // Open the database connection
                    db_Connection.Open();

                    // Create a COMMAND object to execute queries on the database
                    SQLiteCommand command_Object = db_Connection.CreateCommand();

                    // Create a query to record the date & elapsed time of the Match
                    string sql = string.Format(@"INSERT INTO {0} ("
                                                + this.Column_Names.Date_Played + ", " + this.Column_Names.Duration_In_Seconds + ") "
                                                + "VALUES ("
                                                + unixTimeStamp + ", " + matchLengthInSeconds + ");"
                                                , this.TableName);
                    
                    // Set the query text to the local Query_CreateTable variable
                    command_Object.CommandText = sql;

                    // Execute the query in the Command object
                    command_Object.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Display the exception that has occurred
                    Constants.AppErrorMessages.DB_Query_ErrorMessage.Display_ErrorMessage(ex);
                }
            }
        }

        #endregion Database Queries
    }

    /// <summary>
    /// Tier 4 Master Class used to define the schema for & handle interactions with tbl_Login_Credentials
    /// </summary>
    public class DatabaseTable_tbl_Login_Credentials
    {
        // Name of the table
        public readonly string TableName = @"tbl_Login_Credentials";

        // Query to create the table
        public readonly string Query_CreateTable;

        // Objects of sub classes for table definitions
        public readonly TableColumns_Names Column_Names;
        public readonly TableColumns_DataTypes Column_DataTypes;

        public DatabaseTable_tbl_Login_Credentials()
        {
            // Instantiate Tier 4 Sub Classes
            Column_Names = new TableColumns_Names();
            Column_DataTypes = new TableColumns_DataTypes();

            #region Stupid Hack to Expose Foreign Key Columns

            var tempEmployeeRoster = new DatabaseTable_tbl_RSI_Employee_Roster();
            var tempUserRoles = new DatabaseTable_tbl_User_Roles();

            #endregion Stupid Hack to Expose Foreign Key Columns

            Query_CreateTable = string.Format(@"CREATE TABLE {0} ("
                                                + this.Column_Names.ID                  + " " + this.Column_DataTypes.ID                + " PRIMARY KEY NOT NULL, "
                                                + this.Column_Names.UserName            + " " + this.Column_DataTypes.UserName          + " NOT NULL, "
                                                + this.Column_Names.Password            + " " + this.Column_DataTypes.Password          + " NOT NULL, "
                                                + this.Column_Names.EmployeeRoster_ID   + " " + this.Column_DataTypes.EmployeeRoster_ID + " NOT NULL, "
                                                + this.Column_Names.UserRole_ID         + " " + this.Column_DataTypes.UserRole_ID       + " NOT NULL, "
                                                + "FOREIGN KEY (" + this.Column_Names.EmployeeRoster_ID + ") REFERENCES " + tempEmployeeRoster.TableName + " (" + tempEmployeeRoster.Column_Names.ID + "), "
                                                + "FOREIGN KEY (" + this.Column_Names.UserRole_ID + ") REFERENCES " + tempUserRoles.TableName + " (" + tempUserRoles.Column_Names.ID + ")"
                                                + ");", this.TableName);
        }

        #region Sub Classes

        /// <summary>
        /// Tier 4 Sub Class that defines the names of each column in the table
        /// </summary>
        public class TableColumns_Names
        {
            public readonly string ID = "ID";
            public readonly string UserName = "UserName";
            public readonly string Password = "Password";
            public readonly string EmployeeRoster_ID = "EmployeeRoster_ID";
            public readonly string UserRole_ID = "UserRole_ID";
        }

        /// <summary>
        /// Tier 4 Sub Class that defines the datatypes of each column in the table
        /// </summary>
        public class TableColumns_DataTypes
        {
            public readonly string ID = "INTEGER";
            public readonly string UserName = "TEXT";
            public readonly string Password = "TEXT";
            public readonly string EmployeeRoster_ID = "INTEGER";
            public readonly string UserRole_ID = "INTEGER";
        }

        #endregion Sub Classes

        #region Database Queries

        /// <summary>
        /// Creates a SQLite Database table for this class
        /// </summary>
        public void ExecuteQuery_CREATE_Table()
        {
            using (SQLiteConnection db_Connection = new SQLiteConnection(Constants.AppDataSources.DatabaseResources.Database_ConnectionString))
            {
                try
                {
                    // Open the database connection
                    db_Connection.Open();

                    // Create a COMMAND object to execute queries on the database
                    SQLiteCommand command_Object = db_Connection.CreateCommand();

                    // Set the query text to the local Query_CreateTable variable
                    command_Object.CommandText = this.Query_CreateTable;

                    // Execute the query in the Command object
                    command_Object.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Display the exception that has occurred
                    Constants.AppErrorMessages.DB_Query_ErrorMessage.Display_ErrorMessage(ex);
                }
            }
        }

        /// <summary>
        /// Queries the database to check if the table for this class exists
        /// </summary>
        /// <returns></returns>
        public bool ExecuteQuery_DoesTable_Exist()
        {
            using (SQLiteConnection db_Connection = new SQLiteConnection(Constants.AppDataSources.DatabaseResources.Database_ConnectionString))
            {
                try
                {
                    // Open the database connection
                    db_Connection.Open();

                    // Create a COMMAND object to execute queries on the database
                    SQLiteCommand command_Object = db_Connection.CreateCommand();

                    // Clear any previous Parameters from the Command object
                    command_Object.Parameters.Clear();

                    // Create a query to return the number of tables with the given name
                    string sql = string.Format(@"SELECT COUNT(*) FROM sqlite_master WHERE type = 'table' AND name = ?");

                    // Create a Parameter object to pass data into the Command object for query execution
                    DbParameter param = command_Object.CreateParameter();
                    param.ParameterName = "@TableName";     // Name of the parameter to pass
                    param.DbType = DbType.String;           // Datatype of the parameter to pass
                    param.Value = this.TableName;           // Value of the parameter to pass

                    // Add the new Parameter object to the Command object
                    command_Object.Parameters.Add(param);

                    // Set the query text in the command object
                    command_Object.CommandText = sql;

                    // Execute the query in the Command object to return the first column of the first row of the result set
                    long? result = (long?)command_Object.ExecuteScalar();

                    // Check if anything was returned
                    if (result.HasValue)
                    {
                        // Check if actual results were returned
                        return result.Value > 0;
                    }
                    else
                    {
                        // Dataset was returned with no results
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    // Display the exception that has occurred
                    Constants.AppErrorMessages.DB_Query_ErrorMessage.Display_ErrorMessage(ex);

                    // Returning true if an error occurs to prevent any attempts at re-creating the table & losing data
                    return true;
                }
            }
        }

        /// <summary>
        /// Queries the database to insert the new User's Login into tbl_Login_Credentials
        /// </summary>
        /// <param name="newUser"></param>
        public void ExecuteQuery_INSERT_NewUserLogin(UserLogin newUser)
        {
            using (SQLiteConnection db_Connection = new SQLiteConnection(Constants.AppDataSources.DatabaseResources.Database_ConnectionString))
            {
                try
                {
                    // Open the database connection
                    db_Connection.Open();

                    // Create a COMMAND object to execute queries on the database
                    SQLiteCommand command_Object = db_Connection.CreateCommand();

                    // Create a query that will add the User to the tbl_Login_Credentials table
                    string sql = string.Format(@"INSERT INTO {0} ("
                                                + this.Column_Names.UserName + ", " + this.Column_Names.Password + ", " + this.Column_Names.EmployeeRoster_ID + ", " + this.Column_Names.UserRole_ID + ") "
                                                + "VALUES ("
                                                + "\"" + newUser.UserName + "\"" + ", " + "\"" + Encrypt_UserPassword(newUser.Password).ToString() + "\"" + ", "
                                                + "("
                                                    + "SELECT EmployeeRoster_ID." + Constants.AppDataSources.DatabaseResources.DatabaseTable_RSI_Employee_Roster.Column_Names.ID        + " FROM {1} "
                                                    + "WHERE (EmployeeRoster_ID." + Constants.AppDataSources.DatabaseResources.DatabaseTable_RSI_Employee_Roster.Column_Names.Extension + " = " + newUser.Extension + ")"
                                                + ") AS EmployeeRoster_ID, "
                                                + "("
                                                    + "SELECT UserRole_ID." + Constants.AppDataSources.DatabaseResources.Databasetable_UserRoles.Column_Names.ID + " FROM {2} "
                                                    + "WHERE (UserRole_ID." + Constants.AppDataSources.DatabaseResources.Databasetable_UserRoles.Column_Names.ID + " = " + newUser.UserRole_ID + ")"
                                                + ") AS UserRole_ID"
                                                + ");"
                                                , this.TableName
                                                , Constants.AppDataSources.DatabaseResources.DatabaseTable_RSI_Employee_Roster.TableName
                                                , Constants.AppDataSources.DatabaseResources.Databasetable_UserRoles.TableName);

                    // Set the query text in the command object
                    command_Object.CommandText = sql;

                    // Execute the query in the Command object
                    command_Object.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Display the exception that has occurred
                    Constants.AppErrorMessages.DB_Query_ErrorMessage.Display_ErrorMessage(ex);
                }
            }
        }

        // TODO : add to documentation & verify routine
        public void ExecuteQuery_UPDATE_UserLogin(UserLogin updateUser)
        {
            using (SQLiteConnection db_Connection = new SQLiteConnection(Constants.AppDataSources.DatabaseResources.Database_ConnectionString))
            {
                try
                {
                    // Open the database connection
                    db_Connection.Open();

                    // Create a COMMAND object to execute queries on the database
                    SQLiteCommand command_Object = db_Connection.CreateCommand();

                    // Create a query to update the existing User's login
                    string sql = string.Format(@"UPDATE {0} SET "
                                                + this.Column_Names.UserName        + " = \""   + updateUser.UserName                                   + "\", "
                                                + this.Column_Names.Password        + " = \""   + Encrypt_UserPassword(updateUser.Password).ToString()  + "\", "
                                                + this.Column_Names.UserRole_ID     + " = "     + updateUser.UserRole_ID                                + " "
                                                + "WHERE (" + this.Column_Names.ID  + " = "     + updateUser.ID                                         + ");"
                                                , this.TableName);

                    // Set the query text to the local Query_CreateTable variable
                    command_Object.CommandText = sql;

                    // Execute the query in the Command object
                    command_Object.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Display the exception that has occurred
                    Constants.AppErrorMessages.DB_Query_ErrorMessage.Display_ErrorMessage(ex);
                }
            }
        }

        // TODO : add to documentation & verify routine
        public bool ExecuteQuery_SELECT_DoesPasswordMatch(UserLogin validateUser)
        {
            using (SQLiteConnection db_Connection = new SQLiteConnection(Constants.AppDataSources.DatabaseResources.Database_ConnectionString))
            {
                try
                {
                    // Open the database connection
                    db_Connection.Open();

                    // Create a COMMAND object to execute queries on the database
                    SQLiteCommand command_Object = db_Connection.CreateCommand();

                    // Create a query to retrieve the user's password for verification
                    string sql = string.Format(@"SELECT "
                                                + this.Column_Names.Password
                                                + "FROM {0} "
                                                + "WHERE (" + this.Column_Names.UserName + " = \"" + validateUser.UserName + ");"
                                                , this.TableName);

                    // Set the query text to the local Query_CreateTable variable
                    command_Object.CommandText = sql;

                    // Execute the query in the Command object and store the result
                    string result = command_Object.ExecuteScalar().ToString();

                    // Check if a result was returned
                    if (result != null && result != string.Empty && result.ToUpperInvariant() != "NULL")
                    {
                        // Evaluate if the password entered by the user matches the password stored in the database
                        return (Encrypt_UserPassword(validateUser.Password).ToString() == result);
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    // Display the exception that has occurred
                    Constants.AppErrorMessages.DB_Query_ErrorMessage.Display_ErrorMessage(ex);

                    return false;
                }
            }
        }

        #endregion Database Queries

        /// <summary>
        /// Encrypts the passed-in string and returns a hashed byte array
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        private byte[] Encrypt_UserPassword(string password)
        {
            // Create encryption object
            SHA1 shaEncryptor = new SHA1CryptoServiceProvider();

            // Store the user's password as a Byte Array
            byte[] passwordByteArray = Convert.FromBase64String(password);

            // Encrypt the password
            return shaEncryptor.ComputeHash(passwordByteArray);
        }
    }

    /// <summary>
    /// Tier 4 Master Class used to define the schema for & handle interactions with tbl_RSI_Employee_Roster
    /// </summary>
    public class DatabaseTable_tbl_RSI_Employee_Roster
    {
        // Name of the table
        public readonly string TableName = @"tbl_RSI_Employee_Roster";

        // Query to create the table
        public readonly string Query_CreateTable;

        // Objects of sub classes for table definitions
        public readonly TableColumns_Names Column_Names;
        public readonly TableColumns_DataTypes Column_DataTypes;

        // Default fields for the reserved 'Team' record that must exist in tbl_RSI_Employee_Roster
        public readonly string Default_TeamFirstName = "FirstName";
        public readonly string Default_TeamLastName = "LastName";
        public readonly int Default_TeamExtension = 9000;

        public DatabaseTable_tbl_RSI_Employee_Roster()
        {
            // Instantiate Tier 4 Sub Classes
            Column_Names = new TableColumns_Names();
            Column_DataTypes = new TableColumns_DataTypes();

            Query_CreateTable = string.Format(@"CREATE TABLE {0} ("
                                                + this.Column_Names.ID          + " " + this.Column_DataTypes.ID        + " PRIMARY KEY NOT NULL, "
                                                + this.Column_Names.FirstName   + " " + this.Column_DataTypes.FirstName + ", "
                                                + this.Column_Names.LastName    + " " + this.Column_DataTypes.LastName  + ", "
                                                + this.Column_Names.Extension   + " " + this.Column_DataTypes.Extension
                                                + ");", this.TableName);
        }

        #region Sub Classes

        /// <summary>
        /// Tier 4 Sub Class that defines the names of each column in the table
        /// </summary>
        public class TableColumns_Names
        {
            public readonly string ID = "ID";
            public readonly string FirstName = "FirstName";
            public readonly string LastName = "LastName";
            public readonly string Extension = "Extension";
        }

        /// <summary>
        /// Tier 4 Sub Class that defines the datatypes of each column in the table
        /// </summary>
        public class TableColumns_DataTypes
        {
            public readonly string ID = "INTEGER";
            public readonly string FirstName = "TEXT";
            public readonly string LastName = "TEXT";
            public readonly string Extension = "INTEGER";
        }

        #endregion Sub Classes

        #region Database Queries

        /// <summary>
        /// Creates a SQLite Database table for this class
        /// </summary>
        public void ExecuteQuery_CREATE_Table()
        {
            using (SQLiteConnection db_Connection = new SQLiteConnection(Constants.AppDataSources.DatabaseResources.Database_ConnectionString))
            {
                try
                {
                    // Open the database connection
                    db_Connection.Open();

                    // Create a COMMAND object to execute queries on the database
                    SQLiteCommand command_Object = db_Connection.CreateCommand();

                    // Set the query text to the local Query_CreateTable variable
                    command_Object.CommandText = this.Query_CreateTable;

                    // Execute the query in the Command object
                    command_Object.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Display the exception that has occurred
                    Constants.AppErrorMessages.DB_Query_ErrorMessage.Display_ErrorMessage(ex);
                }
            }
        }

        /// <summary>
        /// Queries the database to check if the table for this class exists
        /// </summary>
        /// <returns></returns>
        public bool ExecuteQuery_DoesTable_Exist()
        {
            using (SQLiteConnection db_Connection = new SQLiteConnection(Constants.AppDataSources.DatabaseResources.Database_ConnectionString))
            {
                try
                {
                    // Open the database connection
                    db_Connection.Open();

                    // Create a COMMAND object to execute queries on the database
                    SQLiteCommand command_Object = db_Connection.CreateCommand();

                    // Clear any previous Parameters from the Command object
                    command_Object.Parameters.Clear();

                    // Create a query to return the number of tables with the given name
                    string sql = string.Format(@"SELECT COUNT(*) FROM sqlite_master WHERE type = 'table' AND name = ?");

                    // Create a Parameter object to pass data into the Command object for query execution
                    DbParameter param = command_Object.CreateParameter();
                    param.ParameterName = "@TableName";     // Name of the parameter to pass
                    param.DbType = DbType.String;           // Datatype of the parameter to pass
                    param.Value = this.TableName;           // Value of the parameter to pass

                    // Add the new Parameter object to the Command object
                    command_Object.Parameters.Add(param);

                    // Set the query text in the command object
                    command_Object.CommandText = sql;

                    // Execute the query in the Command object to return the first column of the first row of the result set
                    long? result = (long?)command_Object.ExecuteScalar();

                    // Check if anything was returned
                    if (result.HasValue)
                    {
                        // Check if actual results were returned
                        return result.Value > 0;
                    }
                    else
                    {
                        // Dataset was returned with no results
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    // Display the exception that has occurred
                    Constants.AppErrorMessages.DB_Query_ErrorMessage.Display_ErrorMessage(ex);

                    // Returning true if an error occurs to prevent any attempts at re-creating the table & losing data
                    return true;
                }
            }
        }

        // TODO : add to documentation & verify routine
        public void ExecuteQuery_INSERT_NewEmployee(RSIEmployeeRoster newEmployee)
        {
            using (SQLiteConnection db_Connection = new SQLiteConnection(Constants.AppDataSources.DatabaseResources.Database_ConnectionString))
            {
                try
                {
                    // Open the database connection
                    db_Connection.Open();

                    // Create a COMMAND object to execute queries on the database
                    SQLiteCommand command_Object = db_Connection.CreateCommand();

                    // Create a query to insert the new Employee
                    string sql = string.Format(@"INSERT INTO {0} ("
                                                + this.Column_Names.FirstName   + ", " + this.Column_Names.LastName + ", " + this.Column_Names.Extension    + ") "
                                                + "VALUES ("
                                                + newEmployee.FirstName         + ", " + newEmployee.LastName       + ", " + newEmployee.Extension          + ");"
                                                , this.TableName);

                    // Set the query text to the local Query_CreateTable variable
                    command_Object.CommandText = this.Query_CreateTable;

                    // Execute the query in the Command object
                    command_Object.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Display the exception that has occurred
                    Constants.AppErrorMessages.DB_Query_ErrorMessage.Display_ErrorMessage(ex);
                }
            }
        }

        // TODO : add to documentation & verify routine
        public void ExecuteQuery_UPDATE_ExistingEmployee(RSIEmployeeRoster updateEmployee)
        {
            using (SQLiteConnection db_Connection = new SQLiteConnection(Constants.AppDataSources.DatabaseResources.Database_ConnectionString))
            {
                try
                {
                    // Open the database connection
                    db_Connection.Open();

                    // Create a COMMAND object to execute queries on the database
                    SQLiteCommand command_Object = db_Connection.CreateCommand();

                    // Create a query to insert the new Employee
                    string sql = string.Format(@"UPDATE {0} SET"
                                                + this.Column_Names.FirstName       + " = \""   + updateEmployee.FirstName    + "\", "
                                                + this.Column_Names.LastName        + " = \""   + updateEmployee.LastName     + "\", "
                                                + this.Column_Names.Extension       + " = "     + updateEmployee.LastName     + " "
                                                + "WHERE (" + this.Column_Names.ID  + " = "     + updateEmployee.ID           + ");"
                                                , this.TableName);

                    // Set the query text to the local Query_CreateTable variable
                    command_Object.CommandText = this.Query_CreateTable;

                    // Execute the query in the Command object
                    command_Object.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Display the exception that has occurred
                    Constants.AppErrorMessages.DB_Query_ErrorMessage.Display_ErrorMessage(ex);
                }
            }
        }

        #endregion Database Queries
    }

    /// <summary>
    /// Tier 4 Master Class used to define the schema for & handle interactions with tbl_User_Roles
    /// </summary>
    public class DatabaseTable_tbl_User_Roles
    {
        // Name of the table
        public readonly string TableName = @"tbl_tbl_User_Roles";

        // Query to create the table
        public readonly string Query_CreateTable;

        // Objects of sub classes for table definitions
        public readonly TableColumns_Names Column_Names;
        public readonly TableColumns_DataTypes Column_DataTypes;

        public DatabaseTable_tbl_User_Roles()
        {
            // Instantiate Tier 4 Sub Classes
            Column_Names = new TableColumns_Names();
            Column_DataTypes = new TableColumns_DataTypes();

            Query_CreateTable = string.Format(@"CREATE TABLE {0} ("
                                                + this.Column_Names.ID + " " + this.Column_DataTypes.ID + " PRIMARY KEY NOT NULL, "
                                                + this.Column_Names.UserRole + " " + this.Column_DataTypes.UserRole + " NOT NULL"
                                                + ");", this.TableName);
        }

        #region Sub Classes

        /// <summary>
        /// Tier 4 Sub Class that defines the names of each column in the table
        /// </summary>
        public class TableColumns_Names
        {
            public readonly string ID = "ID";
            public readonly string UserRole = "Role";
        }

        /// <summary>
        /// Tier 4 Sub Class that defines the datatypes of each column in the table
        /// </summary>
        public class TableColumns_DataTypes
        {
            public readonly string ID = "INTEGER";
            public readonly string UserRole = "TEXT";
        }

        #endregion Sub Classes

        #region Database Queries

        /// <summary>
        /// Creates a SQLite Database table for this class
        /// </summary>
        public void ExecuteQuery_CREATE_Table()
        {
            using (SQLiteConnection db_Connection = new SQLiteConnection(Constants.AppDataSources.DatabaseResources.Database_ConnectionString))
            {
                try
                {
                    // Open the database connection
                    db_Connection.Open();

                    // Create a COMMAND object to execute queries on the database
                    SQLiteCommand command_Object = db_Connection.CreateCommand();

                    // Set the query text to the local Query_CreateTable variable
                    command_Object.CommandText = this.Query_CreateTable;

                    // Execute the query in the Command object
                    command_Object.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Display the exception that has occurred
                    Constants.AppErrorMessages.DB_Query_ErrorMessage.Display_ErrorMessage(ex);
                }
            }
        }

        /// <summary>
        /// Queries the database to check if the table for this class exists
        /// </summary>
        /// <returns></returns>
        public bool ExecuteQuery_DoesTable_Exist()
        {
            using (SQLiteConnection db_Connection = new SQLiteConnection(Constants.AppDataSources.DatabaseResources.Database_ConnectionString))
            {
                try
                {
                    // Open the database connection
                    db_Connection.Open();

                    // Create a COMMAND object to execute queries on the database
                    SQLiteCommand command_Object = db_Connection.CreateCommand();

                    // Clear any previous Parameters from the Command object
                    command_Object.Parameters.Clear();

                    // Create a query to return the number of tables with the given name
                    string sql = string.Format(@"SELECT COUNT(*) FROM sqlite_master WHERE type = 'table' AND name = ?");

                    // Create a Parameter object to pass data into the Command object for query execution
                    DbParameter param = command_Object.CreateParameter();
                    param.ParameterName = "@TableName";     // Name of the parameter to pass
                    param.DbType = DbType.String;           // Datatype of the parameter to pass
                    param.Value = this.TableName;           // Value of the parameter to pass

                    // Add the new Parameter object to the Command object
                    command_Object.Parameters.Add(param);

                    // Set the query text in the command object
                    command_Object.CommandText = sql;

                    // Execute the query in the Command object to return the first column of the first row of the result set
                    long? result = (long?)command_Object.ExecuteScalar();

                    // Check if anything was returned
                    if (result.HasValue)
                    {
                        // Check if actual results were returned
                        return result.Value > 0;
                    }
                    else
                    {
                        // Dataset was returned with no results
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    // Display the exception that has occurred
                    Constants.AppErrorMessages.DB_Query_ErrorMessage.Display_ErrorMessage(ex);

                    // Returning true if an error occurs to prevent any attempts at re-creating the table & losing data
                    return true;
                }
            }
        }

        #endregion Database Queries
    }

    #endregion Tier 4 Classes
}
