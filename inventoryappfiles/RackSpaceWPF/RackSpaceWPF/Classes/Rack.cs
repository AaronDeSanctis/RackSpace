using RackSpaceWPF.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RackSpaceWPF
{
    public class Rack
    {
        public Rack()
        {
            if (Image == "" || Image == null)
            {
                SetDefaultImage();
            }           
        }
        public Guid guid{ get; set; }
        public string Name { get; set; }
        public bool IsVacant { get; set; }
        public bool IsGroundOrCuldesac { get; set; }
        public string Image { get; set; }
        public double ImageRotation { get; set; }
        public string Location { get; set; }
        public int ItemCount
        {
            get { return Globals.AllItems.Where(x => x.RackId == Name).Count(); }
        }
        public void PutItemOnRack(Item item)
        {
            if (IsVacant == true)
            {
                item.RackId = Name;
                IsVacant = false;
            }
            else
            {
                if(IsGroundOrCuldesac == false)
                {
                    TakeItemOffOfRack();
                }
                item.RackId = Name;
                IsVacant = false;
            }
        }

        public void TakeItemOffOfRack()
        {
            try
            {
                foreach (Item item in Globals.AllItems)
                {
                    if (item.RackId == Name)
                    {
                        item.RackId = "";
                    }
                }
                IsVacant = true;
            }
            catch
            {

            }
        }

        internal void ChooseGuid()
        {
            guid = Guid.NewGuid();
            if(Globals.AllRacks == null)
            {
                return;
            }
            else
            {
                foreach (Rack rack in Globals.AllRacks)
                {
                    if (rack.guid == guid)
                    {
                        ChooseGuid();
                        return;
                    }
                }
            }
            
        }
        public void SetDefaultImage()
        {
            Image = Globals.DefaultImage;
            ImageRotation = 0;
        }
        public string GetImageUrl()
        {
            return Image;
        }
        public void SetImageUrl(string value)
        {
            Image = value;
        }

    }
}
