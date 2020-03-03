using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace RackSpaceWPF.Classes
{
    public class Database
    {
        //Aaron's Home FilePath
        //private const string RackUrl = ("C:/Users/Aaron DeSanctis/Desktop/RackSpaceWPF/RackSpaceWPF/bin/Debug/RackDatabase.xml");
        //private const string ItemUrl = ("C:/Users/Aaron DeSanctis/Desktop/RackSpaceWPF/RackSpaceWPF/bin/Debug/ItemDatabase.xml");
        //private const string UnitUrl = ("C:/Users/Aaron DeSanctis/Desktop/RackSpaceWPF/RackSpaceWPF/bin/Debug/UnitDatabase.xml");

        // Alto-Shaam FilePath
        private const string RackUrl = ("I:/R&D/Test_Lab/InventoryAppFiles/RackSpaceWPF/RackSpaceWPF/bin/Debug/RackDatabase.xml");
        private const string ItemUrl = ("I:/R&D/Test_Lab/InventoryAppFiles/RackSpaceWPF/RackSpaceWPF/bin/Debug/ItemDatabase.xml");
        private const string UnitUrl = ("I:/R&D/Test_Lab/InventoryAppFiles/RackSpaceWPF/RackSpaceWPF/bin/Debug/UnitDatabase.xml");


        public bool Update(List<Rack> rackList)
        {
            if (rackList != null)
            {
                return (UpdateDatabase(RackUrl, rackList));
            }
            else
            {
                return false;
            }
        }
        public List<Item> GetItems()
        {
               return(ReadItemDatabase(ItemUrl));
        }
        public List<Rack> GetRacks()
        {
               return (ReadRackDatabase(RackUrl));
        }
        //public List<Unit> GetUnits()
        //{
        //    return (ReadItemDatabase(ItemUrl));
        //}
        public bool Create(Item item)
        {
            try
            {
                Globals.AllItems.Add(item);
                return Update(Globals.AllItems);
            }
            catch
            {
                return false;
            }
        }
        public bool Create(Rack rack)
        {
            try
            {
                Globals.AllRacks.Add(rack);
                return Update(Globals.AllRacks);
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(Rack rack)
        {
            try
            {
                Globals.AllRacks.Remove(rack);
                return Update(Globals.AllRacks);
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(Item item)
        {
            try
            {
                if (item.GetImageUrl() != "" && item.GetImageUrl() != null && item.GetImageUrl() != Globals.DefaultImage)
                {
                    Globals.DeleteFileFromFolder(item.GetImageUrl());
                }
                Globals.AllItems.Remove(item);
                Globals.AllItems = Globals.AllItems;
                return Update(Globals.AllItems);
            }
            catch
            {
                return false;
            }
        }
        public bool Update(List<Item> itemList)
        {
            return (UpdateDatabase(ItemUrl, itemList));
        }
        private bool UpdateDatabase(string path, List<Item> itemList)
        {
            try
            {
                XmlSerializer serializerObj = new XmlSerializer(typeof(List<Item>));
                TextWriter writeFileStream = new StreamWriter(path);
                serializerObj.Serialize(writeFileStream, itemList);
                writeFileStream.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        private bool UpdateDatabase(string path, List<Rack> rackList)
        {
            try
            {
                XmlSerializer serializerObj = new XmlSerializer(typeof(List<Rack>));
                TextWriter writeFileStream = new StreamWriter(path);
                serializerObj.Serialize(writeFileStream, rackList);
                writeFileStream.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        private List<Item> ReadItemDatabase(string path)
        {
            XmlSerializer serializerObj = new XmlSerializer(typeof(List<Item>));
            if (File.Exists(path) == true)
            {
                FileStream readFileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                try
                {
                    List<Item> itemList = (List<Item>)serializerObj.Deserialize(readFileStream);
                    readFileStream.Close();
                    return itemList;
                }
                catch
                {
                    readFileStream.Close();
                    return new List<Item>();
                }
            }
            else
            {
                CreateNewXMLFile("ItemDatabase.xml");
                return new List<Item>();

            }
        }
        private List<Unit> ReadUnitDatabase(string path)
        {
            XmlSerializer serializerObj = new XmlSerializer(typeof(List<Unit>));
            if (File.Exists(path) == true)
            {
                FileStream readFileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                try
                {
                    List<Unit> unitList = (List<Unit>)serializerObj.Deserialize(readFileStream);
                    readFileStream.Close();
                    return unitList;
                }
                catch
                {
                    readFileStream.Close();
                    return new List<Unit>();
                }
            }
            else
            {
                CreateNewXMLFile("UnitDatabase.xml");
                return new List<Unit>();

            }
        }
        private List<Rack> ReadRackDatabase(string path)
        {
            XmlSerializer serializerObj = new XmlSerializer(typeof(List<Rack>));
            
            if (File.Exists(path) == true)
            {
                FileStream readFileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                try
                {
                    List<Rack> rackList = (List<Rack>)serializerObj.Deserialize(readFileStream);
                    //if(GetRackList(rackList) != null)
                    //{
                    //    rackList = GetRackList(rackList);
                    //}
                    readFileStream.Close();
                    return rackList;
                }
                catch
                {
                    readFileStream.Close();
                    return new List<Rack>();
                }
            }
            else
            {
                CreateNewXMLFile("RackDatabase.xml");
                return new List<Rack>();
            }
        }
        //Editing function and need to call when reading from database -AD 8/13/2019
        //public List<Rack> GetRackList(List<Rack> rackList)
        //{
        //    Rack unRacked = new Rack();
        //    unRacked.ChooseGuid();
        //    unRacked.Id = "Un-Racked";
        //    unRacked.IsVacant = false;
        //    Rack groundRack = new Rack();
        //    groundRack.ChooseGuid();
        //    groundRack.Id = "Ground or Cul de Sac";
        //    groundRack.IsVacant = true;

        //    int unrackedCounter = 0;
        //    int groundRackCounter = 0;
        //    List<Rack> TempRacklist = new List<Rack>(); 

        //    foreach (Rack rack in rackList)
        //    {
        //        if(rack.Id == unRacked.Id)
        //        {
        //            unrackedCounter += 1;
        //            if (unrackedCounter > 1)
        //            {
        //                rackList.Remove(rack);
        //            }
        //        }
        //        if (rack.Id == groundRack.Id)
        //        {
        //            groundRackCounter += 1;
        //            if (groundRackCounter > 1)
        //            {
        //                rackList.Remove(rack);
        //            }
        //        }

        //    }
        //    if(unrackedCounter == 0)
        //    {
        //        TempRacklist.Add(unRacked);
        //    }
        //    if (groundRackCounter == 0)
        //    {
        //        TempRacklist.Add(groundRack);
        //    }
        //    foreach(Rack rack in rackList)
        //    {
        //        TempRacklist.Add(rack);
        //    }
        //    return TempRacklist;
        //}
        private void CreateNewXMLFile(string FileName)
        {
            using (XmlWriter writer = XmlWriter.Create(FileName))
            {
            }
        }
    }
}
