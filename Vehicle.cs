using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TJS.VehicleTracker.PL;  

namespace TJS.VehicleTracker.BL
{
    public class Vehicle
    {
        public int Year { get; set; }
        public string VIN { get; set; }
        public Guid Id { get; set; }        
        public Guid ColorId { get; set; }
        public Guid MakeId { get; set; }
        public Guid ModelId { get; set; }

        public string ColorName { get; set; }

        public string MakeName { get; set; }

        public string ModelName { get; set; }

        public Vehicle(Guid id)
        {
            this.Id = id;
        }

        public Vehicle(Guid id, Guid colorId, Guid makeId, Guid modelId, string vin, int year)
        {
            this.Id = id;
            this.ColorId = colorId;
            this.MakeId = makeId;
            this.ModelId = modelId;
            this.VIN = vin;
            this.Year = year;
        }

        public Vehicle(Guid id, Guid colorId, Guid makeId, Guid modelId, string vin, int year,string colorname, string makename,string modelname)
        {
            this.Id = id;
            this.ColorId = colorId;
            this.MakeId = makeId;
            this.ModelId = modelId;
            this.VIN = vin;
            this.Year = year;
            this.ColorName = colorname;
            this.MakeName = makename;
            this.ModelName = modelname;
        }

        public void Insert()
        {
            try
            {
                using (VehicleEntities dc = new VehicleEntities())
                {
                    tblVehicle model = new tblVehicle();

                    model.Id = Guid.NewGuid();
                    model.MakeId = this.MakeId;
                    model.ColorId = this.ColorId;
                    model.ModelId = this.ModelId;
                    model.VIN = this.VIN;
                    model.Year = this.Year;

                    dc.tblVehicles.Add(model);
                    dc.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Vehicle()
        {

        }

        public void Update()
        {
            try
            {
                using (VehicleEntities dc = new VehicleEntities())
                {
                    tblVehicle model = dc.tblVehicles.FirstOrDefault(c => c.Id == this.Id);

                    model.ColorId = this.ColorId;
                    model.MakeId = this.MakeId;
                    model.ModelId = this.ModelId;
                    model.VIN = this.VIN;
                    model.Year = this.Year;
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
                    tblVehicle model = dc.tblVehicles.FirstOrDefault(c => c.Id == this.Id);
                    dc.tblVehicles.Remove(model);
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
                    tblVehicle model = dc.tblVehicles.FirstOrDefault(c => c.Id == this.Id);
                    if (model != null)
                    {
                        this.Id = model.Id;
                        this.ColorId = model.ColorId;
                        this.MakeId = model.MakeId;
                        this.ModelId = model.ModelId;
                        this.VIN = model.VIN;
                        this.Year = model.Year;

                        
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }

    public class VehicleList : List<Vehicle>
    {
        public void Load()
        {
            try
            {
                using (VehicleEntities dc = new VehicleEntities())
                {
                    var vehicles = from v in dc.tblVehicles
                                   join c in dc.tblColors on v.ColorId equals c.Id
                                   join mo in dc.tblModels on v.ModelId equals mo.Id
                                   join ma in dc.tblMakes on v.MakeId equals ma.Id
                                   select new
                                   {
                                       v.Id,
                                       v.MakeId,
                                       v.ModelId,
                                       v.VIN,
                                       v.Year,
                                       v.ColorId,
                                       ColorName = c.Description,
                                       MakeName = ma.Description,
                                       ModelName = mo.Description
                                   };

                    foreach (var m in vehicles)
                    {
                        Vehicle model = new Vehicle(m.Id, m.ColorId, m.MakeId, m.ModelId, m.VIN, m.Year, m.ModelName, m.MakeName, m.ColorName);
                        this.Add(model);
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
    