using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TJS.VehicleTracker.PL;

namespace TJS.VehicleTracker.BL
{
    public class Make
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public Make()
        {

        }

        public Make(Guid id, string desc)
        {
            this.Id = id;
            this.Description = desc;
        }

        public Make(string desc)
        {
            this.Description = desc;
        }

        public Make(Guid id)
        {
            this.Id = id;

        }


        public void Insert()
        {
            try
            {
                using (VehicleEntities dc = new VehicleEntities())
                {
                    tblMake make = new tblMake();

                    make.Id = Guid.NewGuid();
                    make.Description = this.Description;


                    dc.tblMakes.Add(make);
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
                    tblMake make = dc.tblMakes.FirstOrDefault(c => c.Id == this.Id);

                    make.Description = this.Description;
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
                    tblMake make = dc.tblMakes.FirstOrDefault(c => c.Id == this.Id);
                    if (make != null)
                    {
                        this.Id = make.Id;

                        this.Description = make.Description;
                    }
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
                    tblMake make = dc.tblMakes.FirstOrDefault(c => c.Id == this.Id);
                    dc.tblMakes.Remove(make);
                    dc.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }

    public class MakeList : List<Make>
    {
        public void Load()
        {
            try
            {
                using (VehicleEntities dc = new VehicleEntities())
                {
                    var makes = dc.tblMakes;

                    foreach (var c in makes)
                    {
                        Make make = new Make(c.Id, c.Description);
                        this.Add(make);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

