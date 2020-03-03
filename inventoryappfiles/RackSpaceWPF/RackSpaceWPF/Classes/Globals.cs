using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace RackSpaceWPF.Classes
{
    public static class Globals
    {
        private static List<Item> itemList;
        private static List<Rack> rackList;
        private static List<User> userList;
        public static Visibility BtnVis { get; set; }
        private static Visibility btnVis { get; set; }
        
        public static void SetVisibility()
        {
            if(CurrentUser.IsAuthenticated == true)
            {
                BtnVis = Visibility.Visible;
            }
            else
            {
                BtnVis = Visibility.Collapsed;
            }
        }
        public static Visibility GetVisibility()
        {
            return BtnVis;
        }
        public static string DefaultImage = "I:/R&D/Test_Lab/InventoryAppFiles/AltoShaamMid.jpg";
        public static User CurrentUser { get; set; }
        public static List<Rack> AllRacks
        {
            get
            {
                return rackList;
            }
            set
            {
                rackList = value;
            }
        }
        public static List<Item> AllItems
        {
            get
            {
                return itemList;
            }
            set
            {
                itemList = value;
            }
        }
        public static List<User> AllUsers
        {
            get
            {
                return userList;
            }
            set
            {
                userList = value;
            }
        }
        public static bool SaveRacksToDB()
        {
            //Need to Update Save function for SQL AD - 1/7/2020
            //Database db = new Database();
            //return db.Update(AllRacks);
            return false;
        }
        public static bool SaveItemsToDB()
        {
            //Need to Update Save function for SQL AD - 1/7/2020
            //Database db = new Database();
            //return db.Update(AllItems);
            return false;
        }
        public static bool SaveUsersToDB()
        {
            //Need to Update Save function for SQL AD - 1/7/2020
            //Database db = new Database();
            //return db.Update(AllUsers);
            return false;
        }
        public static void UpdateRacksFromDB()
        {
            AllRacks = SQLDatabase.GetRacks();
        }
       
        public static void UpdateItemsFromDB()
        {
            AllItems = SQLDatabase.GetItems();
        }
        public static void UpdateUsersFromDB()
        {
            AllUsers = SQLDatabase.GetUsers();
        }
        public static bool CreateNewItem(Item item)
        {            
            return SQLDatabase.CreateItem(item);
        }
        public static bool CreateNewUser(User user)
        {
            return SQLDatabase.CreateUser(user);
        }
        public static bool DeleteSelectedItem(Item item)
        {
            return SQLDatabase.DeleteItem(item);
        }
        public static bool DeleteSelectedRack(Rack rack)
        {
            return SQLDatabase.DeleteRack(rack);
        }
        public static bool DeleteSelectedUser(User user)
        {
            return SQLDatabase.DeleteUser(user);
        }

        public static bool SaveItem(Item item)
        {
            return SQLDatabase.UpdateItem(item);
        }
        public static bool SaveRack(Rack rack)
        {
            return SQLDatabase.UpdateRack(rack);
        }
        public static bool SaveUser(User user)
        {
            return SQLDatabase.UpdateUser(user);
        }

        public static void InitializeGlobals()
        {
            UpdateRacksFromDB();
            UpdateItemsFromDB();
            UpdateUsersFromDB();
        }
        public static void SaveGlobals()
        {
            SaveRacksToDB();
            SaveItemsToDB();
            SaveUsersToDB();
        }
        public static int BooltoBit(bool VarBool)
        {
            if(VarBool == true)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public static bool BitToBool(int VarBit)
        {
            if (VarBit == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static float DoubleToFloat(double value)
        {
            return (float)value;
        }
        public static double FloatToDouble(float value)
        {
            return double.Parse(value.ToString());
        }
        public static String GetDestinationPath(string filename, string foldername)
        {
            String appStartPath = System.AppDomain.CurrentDomain.BaseDirectory;
            string directory = Path.GetDirectoryName(appStartPath); //without file name
            string oneUp = Path.GetDirectoryName(directory);
            string twoUp = Path.GetDirectoryName(oneUp);// Temp folder
            appStartPath = String.Format(twoUp + "\\{0}\\" + filename, foldername);
            return appStartPath;
        }
        public static string CopyFileToFolder(string filepath)
        {
            string name = System.IO.Path.GetFileName(filepath);
            string destinationPath = GetDestinationPath(name, "UnitImages");
            if(File.Exists(destinationPath)){
                return destinationPath;
            }           
            File.Copy(filepath, destinationPath, true);
            return destinationPath;
        }
        public static void DeleteFileFromFolder(string file)
        {
            try
            {
                File.Delete(file);
            }
            catch
            {

            }
            
        }
        public static ImageBrush GetImageBrush(string ImageFilePath)
        {
            ImageBrush myBrush = new ImageBrush();
            Image image = new Image();
            image.Source = new System.Windows.Media.Imaging.BitmapImage(
                new Uri(
                   ImageFilePath));
            myBrush.ImageSource = image.Source;
            return myBrush;
        }
        public static string FormatListBoxItemString(Item item)
        {
            string isunitstring;
            if (item.IsUnit == true)
            {
                isunitstring = "Unit";
                return String.Format("|| Model: {1} || Type: {0} || Serial Number: {2} || Volts: {3} || Phase: {4} || Rack: {5} ||",
                isunitstring, item.Model, item.SerialNum, item.Volts, item.Phase, item.RackId);
            }
            else
            {
                isunitstring = "Non-unit";
                return String.Format("|| Name: {1} || Type: {0} || Rack: {2} ||",
                isunitstring, item.Name, item.RackId);
            }
        }


        internal static object FormatComboBoxRackString(Rack rack)
        {
            throw new NotImplementedException();
        }

        public static string FormatListBoxRackString(Rack rack)
        {
            string isGround;
            string vacant;
            if(rack.IsVacant == true)
            {
                vacant = "Vacant";
            }
            else
            {
                vacant = "Occupied";
            }
            if (rack.IsGroundOrCuldesac == true)
            {

                isGround = "Ground / Cul de sac";
            }
            else
            {
                isGround = "Rack";
            }
            return String.Format(" {0} / {2}",
                rack.Name, isGround, vacant);
        }
        internal static List<Item> GetSearchResultList(string searchText, int searchType)
        {

            return GetItemListBySearchType(searchText, searchType);
        }
        private static List<Item> GetItemListBySearchType(string searchText, int ItemVar)
        {
            List<Item>ReturnList = new List<Item>();
            switch (ItemVar)
            {
                case 1:
                    //Name
                    ReturnList = AllItems.Where(x => x.Name.Contains(searchText.ToUpper())).ToList();
                    break;
                case 2:
                    //Model
                    ReturnList = AllItems.Where(x => x.Model.Contains(searchText.ToUpper())).ToList();
                    break; 
                case 3:
                    //RackID
                    ReturnList = AllItems.Where(x => x.RackId.Contains(searchText.ToUpper())).ToList();
                    break;
                case 4:
                    //Volts
                    ReturnList = AllItems.Where(x => x.Volts.Contains(searchText.ToUpper())).ToList();
                    break;
                case 5:
                    //SerialNum
                    ReturnList = AllItems.Where(x => x.SerialNum.Contains(searchText.ToUpper())).ToList();
                    break;
            }
            return ReturnList;
        }
        public static IEnumerable<T> GetMatches<T>(List<T> list, string search)
        {

            if (search.ToUpper() == null)
                throw new ArgumentNullException("search");

            var ReturnList = list.Select(x => new
            {
                X = x,
                Props = x.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public),
                Fields = x.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public),
            })
            .Where(x => x.Props.Any(p =>
            {
                var val = p.GetValue(x.X, null);
                return val != null
                && val.GetType().GetMethod("ToString", Type.EmptyTypes).DeclaringType == val.GetType()
                && val.ToString().ToUpper().Contains(search.ToUpper());
            })
                        || x.Fields.Any(p =>
                        {
                            var val = p.GetValue(x.X);
                            return val != null
                            && val.GetType().GetMethod("ToString", Type.EmptyTypes).DeclaringType == val.GetType()
                            && val.ToString().ToUpper().Contains(search.ToUpper());
                        }))
            .Select(x => x.X);
            return ReturnList;
        }
        public static DataSet ToDataSet<T>(this IList<T> list)
        {
            Type elementType = typeof(T);
            DataSet ds = new DataSet();
            DataTable t = new DataTable();
            ds.Tables.Add(t);

            //add a column to table for each public property on T
            foreach (var propInfo in elementType.GetProperties())
            {
                Type ColType = Nullable.GetUnderlyingType(propInfo.PropertyType) ?? propInfo.PropertyType;

                t.Columns.Add(propInfo.Name, ColType);
            }

            //go through each property on T and add each value to the table
            foreach (T item in list)
            {
                DataRow row = t.NewRow();

                foreach (var propInfo in elementType.GetProperties())
                {
                    row[propInfo.Name] = propInfo.GetValue(item, null) ?? DBNull.Value;
                }

                t.Rows.Add(row);
            }

            return ds;
        }
        public static void ExportToExcel(DataTable dt, string Name)
        {
            Microsoft.Office.Interop.Excel.Application excel = null;
            Microsoft.Office.Interop.Excel.Workbook wb = null;

            object missing = Type.Missing;
            Microsoft.Office.Interop.Excel.Worksheet ws = null;
            Microsoft.Office.Interop.Excel.Range rng = null;

            try
            {
                excel = new Microsoft.Office.Interop.Excel.Application();
                wb = excel.Workbooks.Add();
                ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.ActiveSheet;
                ws.Name = Name;
                for (int Idx = 0; Idx < dt.Columns.Count; Idx++)
                {
                    ws.Range["A1"].Offset[0, Idx].Value = dt.Columns[Idx].ColumnName;
                }

                for (int Idx = 0; Idx < dt.Rows.Count; Idx++)
                {  // <small>hey! I did not invent this line of code, 
                   // I found it somewhere on CodeProject.</small> 
                   // <small>It works to add the whole row at once, pretty cool huh?</small>
                    ws.Range["A2"].Offset[Idx].Resize[1, dt.Columns.Count].Value =
                    dt.Rows[Idx].ItemArray;
                }

                excel.Visible = true;
                wb.Activate();
                
            }
            catch (COMException ex)
            {
                MessageBox.Show("Error accessing Excel: " + ex.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
        }
    }
}
