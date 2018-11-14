﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TJS.VehicleTracker.PL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class VehicleEntities : DbContext
    {
        public VehicleEntities()
            : base("name=VehicleEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblColor> tblColors { get; set; }
        public virtual DbSet<tblModel> tblModels { get; set; }
        public virtual DbSet<tblVehicle> tblVehicles { get; set; }
        public virtual DbSet<tblMake> tblMakes { get; set; }
    
        public virtual ObjectResult<spGetVehicles_Result> spGetVehicles()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spGetVehicles_Result>("spGetVehicles");
        }
    
        public virtual ObjectResult<spGetVehiclesByColor_Result> spGetVehiclesByColor(string colorName)
        {
            var colorNameParameter = colorName != null ?
                new ObjectParameter("ColorName", colorName) :
                new ObjectParameter("ColorName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spGetVehiclesByColor_Result>("spGetVehiclesByColor", colorNameParameter);
        }
    }
}
