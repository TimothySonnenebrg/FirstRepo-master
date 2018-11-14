using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TJS.VehicleTracker.PL;

namespace TJS.VehicleTracker.BL
{
    public class Model
    {
        public Guid Id { get; set; }
        public int ModelCode { get; set; }
        public string Description { get; set; }

        public Model()
        {

        }

        public Model(Guid id, string desc)
        {
            this.Id = id;
            this.Description = desc;
        }

        public Model(string desc)
        {
            this.Description = desc;
        }

        public Model(Guid id)
        {
            this.Id = id;

        }

        public void Insert()
        {
            try
            {
                using (VehicleEntities dc = new VehicleEntities())
                {
                    tblModel model = new tblModel();

                    model.Id = Guid.NewGuid();
                    model.Description = this.Description;


                    dc.tblModels.Add(model);
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
                    tblModel model = dc.tblModels.FirstOrDefault(c => c.Id == this.Id);

                    model.Description = this.Description;
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
                    tblModel model = dc.tblModels.FirstOrDefault(c => c.Id == this.Id);
                    dc.tblModels.Remove(model);
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
                    tblModel model = dc.tblModels.FirstOrDefault(c => c.Id == this.Id);
                    if (model != null)
                    {
                        this.Id = model.Id;

                        this.Description = model.Description;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }

    public class ModelList : List<Model>
    {
        public void Load()
        {
            try
            {
                using (VehicleEntities dc = new VehicleEntities())
                {
                    var models = dc.tblModels;

                    foreach (var m in models)
                    {
                        Model model = new Model(m.Id, m.Description);
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

