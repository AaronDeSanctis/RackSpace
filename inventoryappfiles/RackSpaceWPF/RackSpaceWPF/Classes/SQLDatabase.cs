using RackSpaceWPF.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace RackSpaceWPF.Classes
{
    public static class SQLDatabase
    {
        private static string ItemsTableName = "ItemTable";
        private static string RacksTableName = "RackTable";
        private static string UsersTableName = "UserTable";
        private static string NotesTableName = "NoteTable";
        static List<Item> ItemList(IAsyncResult result)
        {
            if (result.IsCompleted == true)
            {
                return new List<Item>();
            }
            else
            {
                return new List<Item>();
            }
        }
        private static string ConnectionString = Properties.Settings.Default.Connection_String;
        
        //private async static void StartTest(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        if (ConnectionString == String.Empty)
        //        {
        //            var scsb = new SqlConnectionStringBuilder(Properties.Settings.Default.Connection_String);

        //            ConnectionString = scsb.ConnectionString;

        //            if (ConnectionString == String.Empty)
        //            {
        //                throw new Exception("Connection string error. String is empty.");
        //            }
        //        }

        //        if (ItemsTableName == String.Empty)
        //        {
        //            throw new Exception("Items table name error. String is empty.");
        //        }

        //        // Note: If the start test button was disabled, this would be unnecessary
        //        _cts.Cancel();

        //        // Re-initialize this. Otherwise, StartTest won't work.
        //        _cts = new CancellationTokenSource();

        //        DataItemsList.Clear();

        //        // Note the simulated delay, which will happen on the DB server. You can vary this to see its effect.
        //        // Try dragging the window around after hitting the start test button.
        //        const string query =
        //        @"WAITFOR DELAY '00:00:03'; SELECT * FROM [Production].[WorkOrder];";

        //        // Note that setting the WAITFOR delay to exceed this, eg. 00:02:01, will trigger an exception
        //        int queryTimeout = 120;

        //        RequestStatus = "started";

        //        await ProcessQueryCancelleable(_connectionString, query, queryTimeout, _cts.Token);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message + " (from StartTest)");

        //        Debug.WriteLine(ex.Message);
        //    }
        //}
        //public static DataTable ToDataTable<T>(this IList<T> data)
        //{
        //    PropertyDescriptorCollection props =
        //        TypeDescriptor.GetProperties(typeof(T));
        //    DataTable table = new DataTable();

        //    for (int i = 0; i < props.Count; i++)
        //    {
        //        PropertyDescriptor prop = props[i];
        //        table.Columns.Add(prop.Name, prop.PropertyType);
        //        //Item item = new Item();
        //        //if(data[0].GetType() == item.GetType())
        //        //{
        //        //    //if(prop.Name != item.guid.GetType().GetProperty(item.ToString()).ToString() && prop.Name != item.ImageUrl.GetType().GetProperty(item.ToString()).ToString() && prop.Name != item.ImageRotation.GetType().GetProperty(item.ToString()).ToString())
        //        //    //{
        //        //    //    table.Columns.Add(prop.Name, prop.PropertyType);
        //        //    //}
        //        //    //if(prop.PropertyType != item.guid.GetType() && prop.PropertyType != item.ImageUrl.GetType() && prop.PropertyType != item.ImageRotation.GetType())
        //        //    //{
        //        //    //    table.Columns.Add(prop.Name, prop.PropertyType);
        //        //    //}
        //        //}
        //        //else
        //        //{
        //        //    table.Columns.Add(prop.Name, prop.PropertyType);
        //        //}


        //    }
        //    object[] values = new object[props.Count];
        //    foreach (T item in data)
        //    {
        //        for (int i = 0; i < values.Length; i++)
        //        {
        //            Item varItem = new Item();
        //            //if(props[i].GetType() != varItem.guid.GetType() && props[i].GetType() != varItem.ImageUrl.GetType() && props[i].GetType() != varItem.ImageRotation.GetType())
        //            //{

        //            //}
        //            values[i] = props[i].GetValue(item);
        //        }
        //        table.Rows.Add(values);
        //    }
        //    return table;
        //}

        public static DataTable IenumerableToDataTable<T>(IEnumerable items)
        {

                var tb = new DataTable(typeof(T).Name);

                PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

                foreach (var prop in props)
                {
                    tb.Columns.Add(prop.Name, prop.PropertyType);
                }

                foreach (var item in items)
                {
                    var values = new object[props.Length];
                    for (var i = 0; i < props.Length; i++)
                    {
                        values[i] = props[i].GetValue(item, null);
                    }

                    tb.Rows.Add(values);
                }

                return tb;
        }
        public static List<Note> GetNotes()
        {
            return NoteTableToList(PullNoteData(NotesTableName));
            //return DataTable ToDataTable<T>(this ILis(PullItemData(ItemsTableName));
        }
        public static List<Item> GetItems()
        {
            return ItemTableToList(PullItemData(ItemsTableName));
            //return DataTable ToDataTable<T>(this ILis(PullItemData(ItemsTableName));
        }
        public static List<User> GetUsers()
        {
            return UserTableToList(PullUserData(UsersTableName));
        }
        public static List<Rack> GetRacks()
        {
            return RackTableToList(PullRackData(RacksTableName));
        }
        public static List<Item> ItemTableToList(DataTable table)
        {
            
            List<Item> items = new List<Item>();
            foreach (DataRow row in table.Rows)
            {
                Item item = new Item();
                item.guid = Guid.Parse(row["Guid"].ToString());
                item.Name = row["Name"].ToString();
                item.IsUnit = Globals.BitToBool(Convert.ToInt32(row["IsUnit"]));
                item.RackId = row["RackId"].ToString();
                if(Guid.TryParse(row["RackGuid"].ToString(), out Guid guid))
                    {
                    item.RackGuid = Guid.Parse(row["RackGuid"].ToString());
                }                              
                item.Model = row["Model"].ToString();
                item.SerialNum = row["SerialNum"].ToString();
                item.Volts = row["Volts"].ToString();
                item.Phase = row["Phase"].ToString();
                item.ImageUrl = row["ImageUrl"].ToString();
                item.ImageRotation = Globals.FloatToDouble(float.Parse(row["ImageRotation"].ToString()));
                items.Add(item);
            }
            return items;
        }
        public static List<Rack> RackTableToList(DataTable table)
        {
            List<Rack> racks = new List<Rack>();
            foreach (DataRow row in table.Rows)
            {
                Rack rack = new Rack();
                rack.guid = Guid.Parse(row["Guid"].ToString());
                rack.Name = row["Name"].ToString();
                rack.IsVacant = Globals.BitToBool(Convert.ToInt32(row["IsVacant"]));
                rack.IsGroundOrCuldesac = Globals.BitToBool(Convert.ToInt32(row["IsGroundOrCuldesac"]));
                rack.Image = row["Image"].ToString();
                rack.ImageRotation = Globals.FloatToDouble(float.Parse(row["ImageRotation"].ToString()));
                rack.Location = row["Location"].ToString();
                racks.Add(rack);
            }
            return racks;
        }
        public static List<User> UserTableToList(DataTable table)
        {
            List<User> users = new List<User>();
            foreach (DataRow row in table.Rows)
            {
                User user = new User();
                user.guid = Guid.Parse(row["Guid"].ToString());
                user.Username = row["Username"].ToString();
                user.Password = row["Password"].ToString();
                users.Add(user);         
            }
            return users;
        }
        public static List<Note> NoteTableToList(DataTable table)
        {

            List<Note> notes = new List<Note>();
            foreach (DataRow row in table.Rows)
            {
                Note note = new Note();
                note.guid = Guid.Parse(row["Guid"].ToString());
                note.Text = row["Text"].ToString();
                note.ItemType = row["ItemType"].ToString();
                note.ItemGuid = Guid.Parse(row["ItemGuid"].ToString());
                note.TimeStamp = DateTime.Parse(row["TimeStamp"].ToString());
                note.UserGuid = Guid.Parse(row["UserGuid"].ToString());
                note.IsSubNote = Globals.BitToBool(Convert.ToInt32(row["IsSubNote"]));
                if (Guid.TryParse(row["SubNoteTargetGuid"].ToString(), out Guid guid))
                {
                    note.SubNoteTargetGuid = Guid.Parse(row["SubNoteTargetGuid"].ToString());
                }
                notes.Add(note);
            }
            return notes;
        }
        public static DataTable CreateDB(string TableName)
        {
            return new DataTable();

            
        }
        public static DataTable PullItemData(string TableName)
        {
            String query = "SELECT [Guid], [Name], [IsUnit], [RackId], [RackGuid], [Model], [SerialNum], [Volts], [Phase], [ImageUrl], [ImageRotation] FROM ItemTable;";
            String connString = ConnectionString;
            SqlConnection sqlConn = new SqlConnection(connString);
            SqlCommand sqlCmd = new SqlCommand(query, sqlConn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCmd);
            DataTable itemTable = new DataTable(TableName);
            sqlDataAdapter.Fill(itemTable);
            return itemTable;
           
        }
        public static DataTable PullRackData(string TableName)
        {
            String query = "SELECT [Guid], [Name], [IsVacant], [IsGroundOrCuldesac], [Image], [ImageRotation], [Location] FROM RackTable;";
            String connString = ConnectionString;
            SqlConnection sqlConn = new SqlConnection(connString);
            SqlCommand sqlCmd = new SqlCommand(query, sqlConn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCmd);
            DataTable rackTable = new DataTable(TableName);
            sqlDataAdapter.Fill(rackTable);
            return rackTable;

        }
        public static DataTable PullUserData(string TableName)
        {
            String query = "SELECT [Guid], [Username], [Password] FROM UserTable;";
            String connString = ConnectionString;
            SqlConnection sqlConn = new SqlConnection(connString);
            SqlCommand sqlCmd = new SqlCommand(query, sqlConn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCmd);
            DataTable userTable = new DataTable(TableName);
            sqlDataAdapter.Fill(userTable);
            return userTable;

        }
        public static DataTable PullNoteData(string TableName)
        {
            String query = "SELECT [Guid], [Text], [ItemType], [ItemGuid], [TimeStamp], [UserGuid], [IsSubNote], [SubNoteTargetGuid]  FROM UserTable;";
            String connString = ConnectionString;
            SqlConnection sqlConn = new SqlConnection(connString);
            SqlCommand sqlCmd = new SqlCommand(query, sqlConn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCmd);
            DataTable noteTable = new DataTable(TableName);
            sqlDataAdapter.Fill(noteTable);
            return noteTable;

        }
        public static async Task<int> ExecuteAsync(SqlConnection conn, SqlCommand cmd)      {
            await conn.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
            return 1;
        }
        //public static Task<DataTable> PullUserDataAsync(string TableName)
        //{
        //    //DataTable UserTable = new DataTable();
        //    AsyncCallback itemList = new AsyncCallback(ItemList);
        //    String query = "SELECT [Guid], [Username], [Password] FROM UserTable;";
        //    using (SqlConnection conn = new SqlConnection(ConnectionString))
        //    {
                
        //        conn.OpenAsync().ContinueWith((task) => {
        //            SqlCommand command = new SqlCommand(query, conn);
        //            IAsyncResult ia = command.BeginExecuteReader(itemList, command);
        //            DataTable userTable = new DataTable(TableName);
                    
        //        }, TaskContinuationOptions.OnlyOnRanToCompletion);
        //    }
            
        //}
        //String query = "SELECT [Guid], [Username], [Password] FROM UserTable;";
        //String connString = ConnectionString;
        //SqlConnection sqlConn = new SqlConnection(connString);
        //SqlCommand sqlCmd = new SqlCommand(query, sqlConn);
        //SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCmd);
        //DataTable userTable = new DataTable(TableName);
        //sqlDataAdapter.Fill(userTable);
        //return userTable;
        //using (SqlConnection conn = new SqlConnection(ConnectionString))
        //{
        //    conn.OpenAsync().ContinueWith((task) => {
        //        SqlCommand command = new SqlCommand(query, conn);
        //        IAsyncResult ia = command.BeginExecuteReader(itemList, command);
        //    }, TaskContinuationOptions.OnlyOnRanToCompletion);
        //int result = ExecuteAsync(conn, command).Result;
        //SqlDataReader reader = command.ExecuteReader();
        //while (reader.Read())
        //    Console.WriteLine(reader[0]);
        //AsyncCallback itemList = new AsyncCallback(ItemList);
        //SqlConnection conn = new SqlConnection("Data Source=(local); Initial Catalog=NorthWind; Integrated Security=SSPI");
        //    conn.OpenAsync().ContinueWith((task) => {
        //        SqlCommand cmd = new SqlCommand("select top 2 * from orders", conn);
        //        IAsyncResult ia = cmd.BeginExecuteReader(productList, cmd);
        //    }, TaskContinuationOptions.OnlyOnRanToCompletion);
        //}

        #region
        public static SqlConnection Get_DB_Connection()

        {

            //--------< db_Get_Connection() >--------

            //< db oeffnen >

            string cn_String = Properties.Settings.Default.Connection_String;

            SqlConnection cn_connection = new SqlConnection(cn_String);

            if (cn_connection.State != ConnectionState.Open) cn_connection.Open();

            //</ db oeffnen >



            //< output >

            return cn_connection;

            //</ output >

            //--------</ db_Get_Connection() >--------

        }
        #endregion
        #region
        public static DataTable Get_DataTable(string SQL_Text)

        {

            //--------< db_Get_DataTable() >--------

            SqlConnection cn_connection = Get_DB_Connection();



            //< get Table >

            DataTable table = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter(SQL_Text, cn_connection);

            adapter.Fill(table);

            //</ get Table >



            //< output >

            return table;

            //</ output >

            //--------</ db_Get_DataTable() >--------

        }
        #endregion
        #region
        public static void Execute_SQL(string SQL_Text)

        {

            //--------< Execute_SQL() >--------

            SqlConnection cn_connection = Get_DB_Connection();



            //< get Table >

            SqlCommand cmd_Command = new SqlCommand(SQL_Text, cn_connection);

            cmd_Command.ExecuteNonQuery();

            //</ get Table >



            //--------</ Execute_SQL() >--------

        }
        #endregion
        #region
        public static void Close_DB_Connection()

        {

            //--------< Close_DB_Connection() >--------

            //< db oeffnen >

            string cn_String = Properties.Settings.Default.Connection_String;

            SqlConnection cn_connection = new SqlConnection(cn_String);

            if (cn_connection.State != ConnectionState.Closed) cn_connection.Close();

            //</ db oeffnen >



            //--------</ Close_DB_Connection() >--------

        }
        #endregion
        public static bool CreateItem(Item item)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RackSpaceWPF.Properties.Settings.Connection_String"].ConnectionString))
                {

                    string sql = "INSERT INTO ItemTable VALUES (@Guid,@Name,@RackId,@RackGuid,@Model,@ImageUrl,@IsUnit,@Phase,@Volts,@SerialNum,@ImageRotation)";

                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.Add("@Guid", SqlDbType.UniqueIdentifier).Value = item.guid;
                        cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = item.Name;
                        cmd.Parameters.Add("@RackId", SqlDbType.VarChar, 50).Value = (object)item.RackId ?? DBNull.Value;
                        cmd.Parameters.Add("@RackGuid", SqlDbType.UniqueIdentifier).Value = (object)item.RackGuid ?? DBNull.Value;
                        cmd.Parameters.Add("@Model", SqlDbType.VarChar, 50).Value = (object)item.Model ?? DBNull.Value;
                        cmd.Parameters.Add("@ImageUrl", SqlDbType.VarChar).Value = (object)item.ImageUrl ?? DBNull.Value;
                        cmd.Parameters.Add("@IsUnit", SqlDbType.Bit).Value = Globals.BooltoBit(item.IsUnit);
                        cmd.Parameters.Add("@Phase", SqlDbType.VarChar, 50).Value = (object)item.Phase ?? DBNull.Value;
                        cmd.Parameters.Add("@Volts", SqlDbType.VarChar, 50).Value = (object)item.Volts ?? DBNull.Value;
                        cmd.Parameters.Add("@SerialNum", SqlDbType.VarChar, 50).Value = (object)item.SerialNum ?? DBNull.Value;
                        cmd.Parameters.Add("@ImageRotation", SqlDbType.Float).Value = (object)Globals.DoubleToFloat(item.ImageRotation) ?? DBNull.Value;
                        cmd.CommandType = CommandType.Text;
                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                    Close_DB_Connection();
                }
                return true;
            }
            catch
            {
                return false;
            }         
        }
        public static bool CreateItemAsync(Item item)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RackSpaceWPF.Properties.Settings.Connection_String"].ConnectionString))
                {

                    string sql = "INSERT INTO ItemTable VALUES (@Guid,@Name,@RackId,@RackGuid,@Model,@ImageUrl,@IsUnit,@Phase,@Volts,@SerialNum,@ImageRotation)";

                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.Add("@Guid", SqlDbType.UniqueIdentifier).Value = item.guid;
                        cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = item.Name;
                        cmd.Parameters.Add("@RackId", SqlDbType.VarChar, 50).Value = (object)item.RackId ?? DBNull.Value;
                        cmd.Parameters.Add("@RackGuid", SqlDbType.UniqueIdentifier).Value = (object)item.RackGuid ?? DBNull.Value;
                        cmd.Parameters.Add("@Model", SqlDbType.VarChar, 50).Value = (object)item.Model ?? DBNull.Value;
                        cmd.Parameters.Add("@ImageUrl", SqlDbType.VarChar).Value = (object)item.ImageUrl ?? DBNull.Value;
                        cmd.Parameters.Add("@IsUnit", SqlDbType.Bit).Value = Globals.BooltoBit(item.IsUnit);
                        cmd.Parameters.Add("@Phase", SqlDbType.VarChar, 50).Value = (object)item.Phase ?? DBNull.Value;
                        cmd.Parameters.Add("@Volts", SqlDbType.VarChar, 50).Value = (object)item.Volts ?? DBNull.Value;
                        cmd.Parameters.Add("@SerialNum", SqlDbType.VarChar, 50).Value = (object)item.SerialNum ?? DBNull.Value;
                        cmd.Parameters.Add("@ImageRotation", SqlDbType.Float).Value = (object)Globals.DoubleToFloat(item.ImageRotation) ?? DBNull.Value;
                        cmd.CommandType = CommandType.Text;
                        connection.OpenAsync();
                        cmd.ExecuteNonQueryAsync();
                    }
                    Close_DB_Connection();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool CreateRack(Rack rack)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RackSpaceWPF.Properties.Settings.Connection_String"].ConnectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO " + RacksTableName + " (Guid, Name, IsVacant, IsGroundOrCuldesac, Image, ImageRotation, Location) VALUES(@Guid,@Name,@IsVacant,@IsGroundOrCuldesac,@Image,@ImageRotation,@Location)";
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.Add("@Guid", SqlDbType.UniqueIdentifier).Value = rack.guid;
                        cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = rack.Name;
                        cmd.Parameters.Add("@IsVacant", SqlDbType.Bit).Value = (object)Globals.BooltoBit(rack.IsVacant) ?? DBNull.Value;
                        cmd.Parameters.Add("@IsGroundOrCuldesac", SqlDbType.Bit).Value = (object)Globals.BooltoBit(rack.IsGroundOrCuldesac) ?? DBNull.Value;
                        cmd.Parameters.Add("@Image", SqlDbType.VarChar).Value = (object)rack.Image ?? DBNull.Value;
                        cmd.Parameters.Add("@ImageRotation", SqlDbType.Float).Value = (object)Globals.DoubleToFloat(rack.ImageRotation) ?? DBNull.Value;
                        cmd.Parameters.Add("@Location", SqlDbType.VarChar, 50).Value = (object)rack.Location ?? DBNull.Value;
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                    }
                    Close_DB_Connection();
                }
                return true;
            }
            catch
            {
                return false;
            }

        }
        public static bool CreateRackAsync(Rack rack)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RackSpaceWPF.Properties.Settings.Connection_String"].ConnectionString))
                {
                    connection.OpenAsync();
                    string sql = "INSERT INTO " + RacksTableName + " (Guid, Name, IsVacant, IsGroundOrCuldesac, Image, ImageRotation, Location) VALUES(@Guid,@Name,@IsVacant,@IsGroundOrCuldesac,@Image,@ImageRotation,@Location)";
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.Add("@Guid", SqlDbType.UniqueIdentifier).Value = rack.guid;
                        cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = rack.Name;
                        cmd.Parameters.Add("@IsVacant", SqlDbType.Bit).Value = (object)Globals.BooltoBit(rack.IsVacant) ?? DBNull.Value;
                        cmd.Parameters.Add("@IsGroundOrCuldesac", SqlDbType.Bit).Value = (object)Globals.BooltoBit(rack.IsGroundOrCuldesac) ?? DBNull.Value;
                        cmd.Parameters.Add("@Image", SqlDbType.VarChar).Value = (object)rack.Image ?? DBNull.Value;
                        cmd.Parameters.Add("@ImageRotation", SqlDbType.Float).Value = (object)Globals.DoubleToFloat(rack.ImageRotation) ?? DBNull.Value;
                        cmd.Parameters.Add("@Location", SqlDbType.VarChar, 50).Value = (object)rack.Location ?? DBNull.Value;
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQueryAsync();
                    }
                    Close_DB_Connection();
                }
                return true;
            }
            catch
            {
                return false;
            }

        }
        public static bool CreateUser(User user)
        {
            //try
            //{
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RackSpaceWPF.Properties.Settings.Connection_String"].ConnectionString))
                {

                    string sql = "INSERT INTO UserTable VALUES (@Guid,@Username,@Password)";

                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.Add("@Guid", SqlDbType.UniqueIdentifier).Value = user.guid;
                        cmd.Parameters.Add("@Username", SqlDbType.VarChar, 50).Value = user.Username;
                        cmd.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = user.Password;
                        cmd.CommandType = CommandType.Text;
                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                    Close_DB_Connection();
                }
                return true;
            //}
            //catch
            //{
            //    return false;
            //}
        }
        public static bool CreateUserAsync(User user)
        {
            //try
            //{
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RackSpaceWPF.Properties.Settings.Connection_String"].ConnectionString))
            {

                string sql = "INSERT INTO UserTable VALUES (@Guid,@Username,@Password)";

                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.Add("@Guid", SqlDbType.UniqueIdentifier).Value = user.guid;
                    cmd.Parameters.Add("@Username", SqlDbType.VarChar, 50).Value = user.Username;
                    cmd.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = user.Password;
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    cmd.ExecuteNonQueryAsync();
                }
                Close_DB_Connection();
            }
            return true;
            //}
            //catch
            //{
            //    return false;
            //}
        }
        //note.guid = Guid.Parse(row["Guid"].ToString());
        //note.Text = row["Text"].ToString();
        //note.ItemType = row["ItemType"].ToString();
        //note.ItemGuid = Guid.Parse(row["ItemGuid"].ToString());
        //note.TimeStamp = DateTime.Parse(row["TimeStamp"].ToString());
        //note.UserGuid = Guid.Parse(row["UserGuid"].ToString());
        //note.IsSubNote = Globals.BitToBool(Convert.ToInt32(row["IsSubNote"]));
        //note.SubNoteTargetGuid = Guid.Parse(row["SubNoteTargetGuid"].ToString());
        public static bool CreateNote(Note note)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RackSpaceWPF.Properties.Settings.Connection_String"].ConnectionString))
                {

                    string sql = "INSERT INTO NoteTable VALUES (@Guid,@Text,@ItemType,@ItemGuid,@TimeStamp,@UserGuid,@IsSubNote,@SubNoteTargetGuid)";

                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.Add("@Guid", SqlDbType.UniqueIdentifier).Value = note.guid;
                        cmd.Parameters.Add("@Text", SqlDbType.VarChar).Value = note.Text;
                        cmd.Parameters.Add("@ItemType", SqlDbType.VarChar, 50).Value = (object)note.ItemType ?? DBNull.Value;
                        cmd.Parameters.Add("@ItemGuid", SqlDbType.UniqueIdentifier).Value = (object)note.ItemGuid ?? DBNull.Value;
                        cmd.Parameters.Add("@TimeStamp", SqlDbType.DateTime, 50).Value = note.TimeStamp;
                        cmd.Parameters.Add("@UserGuid", SqlDbType.UniqueIdentifier).Value = (object)note.UserGuid ?? DBNull.Value;
                        cmd.Parameters.Add("@IsSubNote", SqlDbType.Bit).Value = (object)Globals.BooltoBit(note.IsSubNote) ?? DBNull.Value;
                        cmd.Parameters.Add("@SubNoteTargetGuid", SqlDbType.UniqueIdentifier, 50).Value = (object)note.SubNoteTargetGuid ?? DBNull.Value;
                        cmd.CommandType = CommandType.Text;
                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                    Close_DB_Connection();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool CreateNoteAsync(Note note)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RackSpaceWPF.Properties.Settings.Connection_String"].ConnectionString))
                {

                    string sql = "INSERT INTO NoteTable VALUES (@Guid,@Text,@ItemType,@ItemGuid,@TimeStamp,@UserGuid,@IsSubNote,@SubNoteTargetGuid)";

                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.Add("@Guid", SqlDbType.UniqueIdentifier).Value = note.guid;
                        cmd.Parameters.Add("@Text", SqlDbType.VarChar).Value = note.Text;
                        cmd.Parameters.Add("@ItemType", SqlDbType.VarChar, 50).Value = (object)note.ItemType ?? DBNull.Value;
                        cmd.Parameters.Add("@ItemGuid", SqlDbType.UniqueIdentifier).Value = (object)note.ItemGuid ?? DBNull.Value;
                        cmd.Parameters.Add("@TimeStamp", SqlDbType.DateTime, 50).Value = note.TimeStamp;
                        cmd.Parameters.Add("@UserGuid", SqlDbType.UniqueIdentifier).Value = (object)note.UserGuid ?? DBNull.Value;
                        cmd.Parameters.Add("@IsSubNote", SqlDbType.Bit).Value = (object)Globals.BooltoBit(note.IsSubNote) ?? DBNull.Value;
                        cmd.Parameters.Add("@SubNoteTargetGuid", SqlDbType.UniqueIdentifier, 50).Value = (object)note.SubNoteTargetGuid ?? DBNull.Value;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandType = CommandType.Text;
                        connection.OpenAsync();
                        cmd.ExecuteNonQueryAsync();
                    }
                    Close_DB_Connection();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool UpdateItem(Item item)
        {
            try
            {

                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RackSpaceWPF.Properties.Settings.Connection_String"].ConnectionString))
                {
                    //            command.CommandText = "UPDATE Student 
                    //SET Address = @add, City = @cit Where FirstName = @fn and LastName = @add";

                    string sql = "UPDATE ItemTable SET Guid = @Guid, Name = @Name, RackId = @RackId, Model = @Model, ImageUrl = @ImageUrl, IsUnit = @IsUnit, Phase = @Phase, Volts = @Volts, SerialNum = @SerialNum, ImageRotation = @ImageRotation WHERE Guid = @Guid";

                    //1/7/2020 temporarily testing new insert string
                    //string sql = "INSERT INTO " + ItemsTableName + " (Guid, Name, RackId, Model, ImageUrl, IsUnit, Phase, Volts, SerialNum, ImageRotation) VALUES(@Guid,@Name,@RackId,@Model,@ImageUrl,@IsUnit,@Phase,@Volts,@SerialNum,@ImageRotation)";

                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.Add("@Guid", SqlDbType.UniqueIdentifier).Value = item.guid;
                        cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = item.Name;
                        cmd.Parameters.Add("@RackId", SqlDbType.VarChar, 50).Value = (object)item.RackId ?? DBNull.Value;
                        cmd.Parameters.Add("@RackGuid", SqlDbType.UniqueIdentifier).Value = (object)item.RackGuid ?? DBNull.Value;
                        cmd.Parameters.Add("@Model", SqlDbType.VarChar, 50).Value = (object)item.Model ?? DBNull.Value;
                        cmd.Parameters.Add("@ImageUrl", SqlDbType.VarChar).Value = (object)item.ImageUrl ?? DBNull.Value;
                        cmd.Parameters.Add("@IsUnit", SqlDbType.Bit).Value = Globals.BooltoBit(item.IsUnit);
                        cmd.Parameters.Add("@Phase", SqlDbType.VarChar, 50).Value = (object)item.Phase ?? DBNull.Value;
                        cmd.Parameters.Add("@Volts", SqlDbType.VarChar, 50).Value = (object)item.Volts ?? DBNull.Value;
                        cmd.Parameters.Add("@SerialNum", SqlDbType.VarChar, 50).Value = (object)item.SerialNum ?? DBNull.Value;
                        cmd.Parameters.Add("@ImageRotation", SqlDbType.Float).Value = (object)Globals.DoubleToFloat(item.ImageRotation) ?? DBNull.Value;
                        cmd.CommandType = CommandType.Text;
                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                    Close_DB_Connection();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool UpdateItemAsync(Item item)
        {
            try
            {

                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RackSpaceWPF.Properties.Settings.Connection_String"].ConnectionString))
                {
                    //            command.CommandText = "UPDATE Student 
                    //SET Address = @add, City = @cit Where FirstName = @fn and LastName = @add";

                    string sql = "UPDATE ItemTable SET Guid = @Guid, Name = @Name, RackId = @RackId, Model = @Model, ImageUrl = @ImageUrl, IsUnit = @IsUnit, Phase = @Phase, Volts = @Volts, SerialNum = @SerialNum, ImageRotation = @ImageRotation WHERE Guid = @Guid";

                    //1/7/2020 temporarily testing new insert string
                    //string sql = "INSERT INTO " + ItemsTableName + " (Guid, Name, RackId, Model, ImageUrl, IsUnit, Phase, Volts, SerialNum, ImageRotation) VALUES(@Guid,@Name,@RackId,@Model,@ImageUrl,@IsUnit,@Phase,@Volts,@SerialNum,@ImageRotation)";

                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.Add("@Guid", SqlDbType.UniqueIdentifier).Value = item.guid;
                        cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = item.Name;
                        cmd.Parameters.Add("@RackId", SqlDbType.VarChar, 50).Value = (object)item.RackId ?? DBNull.Value;
                        cmd.Parameters.Add("@RackGuid", SqlDbType.UniqueIdentifier).Value = (object)item.RackGuid ?? DBNull.Value;
                        cmd.Parameters.Add("@Model", SqlDbType.VarChar, 50).Value = (object)item.Model ?? DBNull.Value;
                        cmd.Parameters.Add("@ImageUrl", SqlDbType.VarChar).Value = (object)item.ImageUrl ?? DBNull.Value;
                        cmd.Parameters.Add("@IsUnit", SqlDbType.Bit).Value = Globals.BooltoBit(item.IsUnit);
                        cmd.Parameters.Add("@Phase", SqlDbType.VarChar, 50).Value = (object)item.Phase ?? DBNull.Value;
                        cmd.Parameters.Add("@Volts", SqlDbType.VarChar, 50).Value = (object)item.Volts ?? DBNull.Value;
                        cmd.Parameters.Add("@SerialNum", SqlDbType.VarChar, 50).Value = (object)item.SerialNum ?? DBNull.Value;
                        cmd.Parameters.Add("@ImageRotation", SqlDbType.Float).Value = (object)Globals.DoubleToFloat(item.ImageRotation) ?? DBNull.Value;
                        cmd.CommandType = CommandType.Text;
                        connection.Open();
                        cmd.ExecuteNonQueryAsync();
                    }
                    Close_DB_Connection();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool UpdateUser(User user)
        {
            try
            {

                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RackSpaceWPF.Properties.Settings.Connection_String"].ConnectionString))
            {
                //            command.CommandText = "UPDATE Student 
                //SET Address = @add, City = @cit Where FirstName = @fn and LastName = @add";

                string sql = "UPDATE UserTable SET Guid = @Guid, Username = @Username, Password = @Password  WHERE Guid = @Guid";

                //1/7/2020 temporarily testing new insert string
                //string sql = "INSERT INTO " + ItemsTableName + " (Guid, Name, RackId, Model, ImageUrl, IsUnit, Phase, Volts, SerialNum, ImageRotation) VALUES(@Guid,@Name,@RackId,@Model,@ImageUrl,@IsUnit,@Phase,@Volts,@SerialNum,@ImageRotation)";

                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.Add("@Guid", SqlDbType.UniqueIdentifier).Value = user.guid;
                    cmd.Parameters.Add("@Username", SqlDbType.VarChar, 50).Value = user.Username;
                    cmd.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = user.Password;
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
                Close_DB_Connection();
            }
            return true;
            }
            catch
            {
                return false;
            }

        }
        public static bool UpdateUserAsync(User user)
        {
            try
            {

                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RackSpaceWPF.Properties.Settings.Connection_String"].ConnectionString))
                {
                    //            command.CommandText = "UPDATE Student 
                    //SET Address = @add, City = @cit Where FirstName = @fn and LastName = @add";

                    string sql = "UPDATE UserTable SET Guid = @Guid, Username = @Username, Password = @Password  WHERE Guid = @Guid";

                    //1/7/2020 temporarily testing new insert string
                    //string sql = "INSERT INTO " + ItemsTableName + " (Guid, Name, RackId, Model, ImageUrl, IsUnit, Phase, Volts, SerialNum, ImageRotation) VALUES(@Guid,@Name,@RackId,@Model,@ImageUrl,@IsUnit,@Phase,@Volts,@SerialNum,@ImageRotation)";

                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.Add("@Guid", SqlDbType.UniqueIdentifier).Value = user.guid;
                        cmd.Parameters.Add("@Username", SqlDbType.VarChar, 50).Value = user.Username;
                        cmd.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = user.Password;
                        cmd.CommandType = CommandType.Text;
                        connection.Open();
                        cmd.ExecuteNonQueryAsync();
                    }
                    Close_DB_Connection();
                }
                return true;
            }
            catch
            {
                return false;
            }

        }
        public static bool UpdateRack(Rack rack)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RackSpaceWPF.Properties.Settings.Connection_String"].ConnectionString))
                {
                connection.Open();
                string sql = "UPDATE RackTable SET Guid = @Guid, Name = @Name, IsVacant = @IsVacant, IsGroundOrCuldesac = @IsGroundOrCuldesac, Image = @Image, ImageRotation = @ImageRotation, Location = @Location WHERE Guid = @Guid";

                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.Add("@Guid", SqlDbType.UniqueIdentifier).Value = rack.guid;
                        cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = rack.Name;
                        cmd.Parameters.Add("@IsVacant", SqlDbType.Bit).Value = (object)Globals.BooltoBit(rack.IsVacant) ?? DBNull.Value;
                        cmd.Parameters.Add("@IsGroundOrCuldesac", SqlDbType.Bit).Value = (object)Globals.BooltoBit(rack.IsGroundOrCuldesac) ?? DBNull.Value;
                        cmd.Parameters.Add("@Image", SqlDbType.VarChar).Value = (object)rack.Image ?? DBNull.Value;
                        cmd.Parameters.Add("@ImageRotation", SqlDbType.Float).Value = (object)Globals.DoubleToFloat(rack.ImageRotation) ?? DBNull.Value;
                        cmd.Parameters.Add("@Location", SqlDbType.VarChar, 50).Value = (object)rack.Location ?? DBNull.Value;
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                    }
                    Close_DB_Connection();
                }
                return true;
            }
            catch
            {
                return false;
            }


        }
        public static bool UpdateRackAsync(Rack rack)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RackSpaceWPF.Properties.Settings.Connection_String"].ConnectionString))
                {
                    connection.Open();
                    string sql = "UPDATE RackTable SET Guid = @Guid, Name = @Name, IsVacant = @IsVacant, IsGroundOrCuldesac = @IsGroundOrCuldesac, Image = @Image, ImageRotation = @ImageRotation, Location = @Location WHERE Guid = @Guid";

                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.Add("@Guid", SqlDbType.UniqueIdentifier).Value = rack.guid;
                        cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = rack.Name;
                        cmd.Parameters.Add("@IsVacant", SqlDbType.Bit).Value = (object)Globals.BooltoBit(rack.IsVacant) ?? DBNull.Value;
                        cmd.Parameters.Add("@IsGroundOrCuldesac", SqlDbType.Bit).Value = (object)Globals.BooltoBit(rack.IsGroundOrCuldesac) ?? DBNull.Value;
                        cmd.Parameters.Add("@Image", SqlDbType.VarChar).Value = (object)rack.Image ?? DBNull.Value;
                        cmd.Parameters.Add("@ImageRotation", SqlDbType.Float).Value = (object)Globals.DoubleToFloat(rack.ImageRotation) ?? DBNull.Value;
                        cmd.Parameters.Add("@Location", SqlDbType.VarChar, 50).Value = (object)rack.Location ?? DBNull.Value;
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                    }
                    Close_DB_Connection();
                }
                return true;
            }
            catch
            {
                return false;
            }


        }
        //cmd.Parameters.Add("@Guid", SqlDbType.UniqueIdentifier).Value = note.guid;
        //cmd.Parameters.Add("@Text", SqlDbType.VarChar).Value = note.Text;
        //cmd.Parameters.Add("@ItemType", SqlDbType.VarChar, 50).Value = note.ItemType;
        //cmd.Parameters.Add("@ItemGuid", SqlDbType.UniqueIdentifier).Value = (object) note.ItemGuid ?? DBNull.Value;
        //cmd.Parameters.Add("@TimeStamp", SqlDbType.DateTime, 50).Value = note.TimeStamp;
        //cmd.Parameters.Add("@UserGuid", SqlDbType.UniqueIdentifier).Value = (object) note.UserGuid ?? DBNull.Value;
        //cmd.Parameters.Add("@IsSubNote", SqlDbType.Bit).Value = (object) Globals.BooltoBit(note.IsSubNote) ?? DBNull.Value;
        //cmd.Parameters.Add("@SubNoteTargetGuid", SqlDbType.UniqueIdentifier, 50).Value = (object) note.SubNoteTargetGuid ?? DBNull.Value;
        public static bool UpdateNote(Note note)
        {
            try
            {

                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RackSpaceWPF.Properties.Settings.Connection_String"].ConnectionString))
                {
                    //            command.CommandText = "UPDATE Student 
                    //SET Address = @add, City = @cit Where FirstName = @fn and LastName = @add";

                    string sql = "UPDATE NoteTable SET Guid = @Guid, Text = @Text, ItemType = @ItemType, ItemGuid = @ItemGuid, TimeStamp = @TimeStamp, UserGuid = @UserGuid, IsSubNote = @IsSubNote, SubNoteTargetGuid = @SubNoteTargetGuid WHERE Guid = @Guid";

                    //1/7/2020 temporarily testing new insert string
                    //string sql = "INSERT INTO " + ItemsTableName + " (Guid, Name, RackId, Model, ImageUrl, IsUnit, Phase, Volts, SerialNum, ImageRotation) VALUES(@Guid,@Name,@RackId,@Model,@ImageUrl,@IsUnit,@Phase,@Volts,@SerialNum,@ImageRotation)";

                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.Add("@Guid", SqlDbType.UniqueIdentifier).Value = note.guid;
                        cmd.Parameters.Add("@Text", SqlDbType.VarChar).Value = note.Text;
                        cmd.Parameters.Add("@ItemType", SqlDbType.VarChar, 50).Value = (object)note.ItemType ?? DBNull.Value;
                        cmd.Parameters.Add("@ItemGuid", SqlDbType.UniqueIdentifier).Value = (object)note.ItemGuid ?? DBNull.Value;
                        cmd.Parameters.Add("@TimeStamp", SqlDbType.DateTime, 50).Value = note.TimeStamp;
                        cmd.Parameters.Add("@UserGuid", SqlDbType.UniqueIdentifier).Value = (object)note.UserGuid ?? DBNull.Value;
                        cmd.Parameters.Add("@IsSubNote", SqlDbType.Bit).Value = (object)Globals.BooltoBit(note.IsSubNote) ?? DBNull.Value;
                        cmd.Parameters.Add("@SubNoteTargetGuid", SqlDbType.UniqueIdentifier, 50).Value = (object)note.SubNoteTargetGuid ?? DBNull.Value;
                        cmd.CommandType = CommandType.Text;
                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                    Close_DB_Connection();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool UpdateNoteAsync(Note note)
        {
            try
            {

                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RackSpaceWPF.Properties.Settings.Connection_String"].ConnectionString))
                {
                    //            command.CommandText = "UPDATE Student 
                    //SET Address = @add, City = @cit Where FirstName = @fn and LastName = @add";

                    string sql = "UPDATE NoteTable SET Guid = @Guid, Text = @Text, ItemType = @ItemType, ItemGuid = @ItemGuid, TimeStamp = @TimeStamp, UserGuid = @UserGuid, IsSubNote = @IsSubNote, SubNoteTargetGuid = @SubNoteTargetGuid WHERE Guid = @Guid";

                    //1/7/2020 temporarily testing new insert string
                    //string sql = "INSERT INTO " + ItemsTableName + " (Guid, Name, RackId, Model, ImageUrl, IsUnit, Phase, Volts, SerialNum, ImageRotation) VALUES(@Guid,@Name,@RackId,@Model,@ImageUrl,@IsUnit,@Phase,@Volts,@SerialNum,@ImageRotation)";

                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.Add("@Guid", SqlDbType.UniqueIdentifier).Value = note.guid;
                        cmd.Parameters.Add("@Text", SqlDbType.VarChar).Value = note.Text;
                        cmd.Parameters.Add("@ItemType", SqlDbType.VarChar, 50).Value = (object)note.ItemType ?? DBNull.Value;
                        cmd.Parameters.Add("@ItemGuid", SqlDbType.UniqueIdentifier).Value = (object)note.ItemGuid ?? DBNull.Value;
                        cmd.Parameters.Add("@TimeStamp", SqlDbType.DateTime, 50).Value = note.TimeStamp;
                        cmd.Parameters.Add("@UserGuid", SqlDbType.UniqueIdentifier).Value = (object)note.UserGuid ?? DBNull.Value;
                        cmd.Parameters.Add("@IsSubNote", SqlDbType.Bit).Value = (object)Globals.BooltoBit(note.IsSubNote) ?? DBNull.Value;
                        cmd.Parameters.Add("@SubNoteTargetGuid", SqlDbType.UniqueIdentifier, 50).Value = (object)note.SubNoteTargetGuid ?? DBNull.Value;
                        cmd.CommandType = CommandType.Text;
                        connection.Open();
                        cmd.ExecuteNonQueryAsync();
                    }
                    Close_DB_Connection();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool DeleteItem(Item item)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RackSpaceWPF.Properties.Settings.Connection_String"].ConnectionString))
                {
                    string sql = "DELETE FROM " + ItemsTableName + " WHERE " + "Guid" + " = " + "@Guid";
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.Add("@Guid", SqlDbType.UniqueIdentifier).Value = item.guid;
                        cmd.CommandType = CommandType.Text;
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        Close_DB_Connection();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool DeleteItemAsync(Item item)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RackSpaceWPF.Properties.Settings.Connection_String"].ConnectionString))
                {
                    string sql = "DELETE FROM " + ItemsTableName + " WHERE " + "Guid" + " = " + "@Guid";
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.Add("@Guid", SqlDbType.UniqueIdentifier).Value = item.guid;
                        cmd.CommandType = CommandType.Text;
                        connection.OpenAsync();
                        cmd.ExecuteNonQueryAsync();
                        Close_DB_Connection();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool DeleteUser(User user)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RackSpaceWPF.Properties.Settings.Connection_String"].ConnectionString))
                {
                    string sql = "DELETE FROM " + UsersTableName + " WHERE " + "Guid" + " = " + "@Guid";
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.Add("@Guid", SqlDbType.UniqueIdentifier).Value = user.guid;
                        cmd.CommandType = CommandType.Text;
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        Close_DB_Connection();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool DeleteUserAsync(User user)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RackSpaceWPF.Properties.Settings.Connection_String"].ConnectionString))
                {
                    string sql = "DELETE FROM " + UsersTableName + " WHERE " + "Guid" + " = " + "@Guid";
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.Add("@Guid", SqlDbType.UniqueIdentifier).Value = user.guid;
                        cmd.CommandType = CommandType.Text;
                        connection.OpenAsync();
                        cmd.ExecuteNonQueryAsync();
                        Close_DB_Connection();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool DeleteRack(Rack rack)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RackSpaceWPF.Properties.Settings.Connection_String"].ConnectionString))
                {
                    string sql = "DELETE FROM " + RacksTableName + " WHERE " + "Guid" + " = " + "@Guid";
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.Add("@Guid", SqlDbType.UniqueIdentifier).Value = rack.guid;
                        cmd.CommandType = CommandType.Text;
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        Close_DB_Connection();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool DeleteRackAsync(Rack rack)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RackSpaceWPF.Properties.Settings.Connection_String"].ConnectionString))
                {
                    string sql = "DELETE FROM " + RacksTableName + " WHERE " + "Guid" + " = " + "@Guid";
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.Add("@Guid", SqlDbType.UniqueIdentifier).Value = rack.guid;
                        cmd.CommandType = CommandType.Text;
                        connection.OpenAsync();
                        cmd.ExecuteNonQueryAsync();
                        Close_DB_Connection();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool DeleteNote(Note note)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RackSpaceWPF.Properties.Settings.Connection_String"].ConnectionString))
                {
                    string sql = "DELETE FROM " + NotesTableName + " WHERE " + "Guid" + " = " + "@Guid";
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.Add("@Guid", SqlDbType.UniqueIdentifier).Value = note.guid;
                        cmd.CommandType = CommandType.Text;
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        Close_DB_Connection();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool DeleteNoteAsync(Note note)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RackSpaceWPF.Properties.Settings.Connection_String"].ConnectionString))
                {
                    string sql = "DELETE FROM " + NotesTableName + " WHERE " + "Guid" + " = " + "@Guid";
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.Add("@Guid", SqlDbType.UniqueIdentifier).Value = note.guid;
                        cmd.CommandType = CommandType.Text;
                        connection.OpenAsync();
                        cmd.ExecuteNonQueryAsync();
                        Close_DB_Connection();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
