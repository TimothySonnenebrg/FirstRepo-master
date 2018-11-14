using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TJS.Utilities.Reporting;
using TJS.VehicleTracker.PL;

namespace TJS.VehicleTracker.BL
{
    public class Color
    {
        public Guid Id { get; set; }
        public int ColorCode { get; set; }
        public string Description { get; set; }

        #region "Constructors"

        public Color()
        {

        }


        public Color(Guid id, int code, string desc)
        {
            this.Id = id;
            this.ColorCode = code;  //loading
            this.Description = desc;
        }

        public Color(int code, string desc)
        {
            
            this.ColorCode = code; //insert
            this.Description = desc;
        }

        public Color(Guid id)
        { //updating
            this.Id = id;
        }


#endregion

        public void Insert()
        {
            try
            {
                using(VehicleEntities dc = new VehicleEntities())
                {
                    tblColor color = new tblColor();
                    color.Id = Guid.NewGuid();
                    color.Description = this.Description;
                    color.ColorCode = this.ColorCode;
                    dc.tblColors.Add(color);

                    dc.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Update()
        {
            try
            {
                using (VehicleEntities dc = new VehicleEntities())
                {
                    tblColor color = dc.tblColors.FirstOrDefault(c => c.Id == this.Id);

                    color.ColorCode = this.ColorCode;
                    color.Description = this.Description;
                    dc.SaveChanges();

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public void Delete()
        {
            try
            {
                using (VehicleEntities dc = new VehicleEntities())
                {
                    tblColor color = dc.tblColors.FirstOrDefault(c => c.Id == this.Id);

                    dc.tblColors.Remove(color);
                    dc.SaveChanges();

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }



        public void LoadById(Guid id)
        {
            this.Id = id;
            LoadById();
        }


            public void LoadById()
        {
            try
            {
                using (VehicleEntities dc = new VehicleEntities())
                {
                    tblColor color = dc.tblColors.FirstOrDefault(c => c.Id == this.Id);
                    if (color != null)
                    {
                        this.Id = color.Id;
                        this.ColorCode = color.ColorCode;
                        this.Description = color.Description;
                    }

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }




    public class ColorList : List<Color>
    {
        public void Load()
        {
            try
            {
                using (VehicleEntities dc = new VehicleEntities())
                {
                    var colors = dc.tblColors;

                    foreach (var c in colors)
                    {
                        Color color = new Color(c.Id, c.ColorCode, c.Description);
                        this.Add(color);
                    }

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public void Export()
        {
            string[,] colors = new string[this.Count+1, 2];

            //Make column headers 
            colors[0, 0] = "Color Code";
            colors[0, 1] = "Description";

            for (int iCnt = 1; iCnt < this.Count + 1; iCnt++)
            {
                Color c = this[iCnt - 1];
                colors[iCnt, 0] = c.ColorCode.ToString();
                colors[iCnt, 1] = c.Description;
            }

            CExcel.Export("Colors.xlsx", colors);
        }


    }

}
