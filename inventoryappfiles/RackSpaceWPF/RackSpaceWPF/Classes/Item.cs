using RackSpaceWPF.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RackSpaceWPF
{
    public class Item
    {
        public Item()
        {
            if (ImageUrl == "" || ImageUrl == null)
            {
                SetDefaultImage();
            }
        }
        public int Id { get; set; }
        public Guid guid { get; set; }
        public string Name { get; set; }
        public bool IsUnit { get; set; }
        public string RackId { get; set; }
        public Guid? RackGuid { get; set; }
        public virtual List<Note> Notes { get; set; }
        public string Model { get; set; }
        public string SerialNum { get; set; }
        public string Volts { get; set; }
        public string Phase { get; set; }
        public string ImageUrl { get; set; }
        public double ImageRotation { get; set; }
        //public bool IsOperational { get; set; }

        //public bool IsLabEquipment { get; set; }

        //public bool IsThermoCouple { get; set; }

        //public string TCId { get; set; }

        //public bool IsPart { get; set; }

        //public bool IsMisc { get; set; }

        //public Guid RackGuid { get; set; }
        public Guid GetGuid()
        {
            return guid;
        }
        public string GetImageUrl()
        {
            return ImageUrl;
        }
        public void SetImageUrl(string value)
        {
            ImageUrl = value;
        }
        public double GetImageRotation()
        {
            return ImageRotation;
        }
        public void SetImageRotation(double value)
        {
            ImageRotation = value;
        }
        public void ChooseGuid()
        {
            guid = Guid.NewGuid();
        }
        
        public void SetDefaultImage()
        {
            ImageUrl = Globals.DefaultImage;
            ImageRotation = 0;
        }
    }
}
