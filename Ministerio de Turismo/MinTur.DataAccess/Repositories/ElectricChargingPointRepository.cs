using Microsoft.EntityFrameworkCore;
using MinTur.DataAccessInterface.Repositories;
using MinTur.Domain.BusinessEntities;
using System.Collections.Generic;
using System.Linq;
using MinTur.Exceptions;
using System;

namespace MinTur.DataAccess.Repositories
{
    public class ElectricChargingPointRepository : IElectricChargingPointRepository
    {
        protected DbContext Context { get; set; }

        public ElectricChargingPointRepository(DbContext dbContext)
        {
            Context = dbContext;
        }

        public List<ElectricChargingPoint> GetAllElectricChargingPoints()
        {
            return Context.Set<ElectricChargingPoint>().ToList();
        }

        public ElectricChargingPoint GetElectricChargingPointById(int id)
        {
            ElectricChargingPoint retrievedElectricChargingPoint = Context.Set<ElectricChargingPoint>().
                Where(ecp => ecp.Id == id).Include(ecp => ecp.Region).FirstOrDefault();

            if (retrievedElectricChargingPoint == null)
                throw new ResourceNotFoundException("Could not find specified Electric Charging Point");

            return retrievedElectricChargingPoint;
        }

        public int StoreElectricChargingPoint(ElectricChargingPoint newElectricChargingPoint)
        {
            if (!RegionExists(newElectricChargingPoint.Region))
                throw new ResourceNotFoundException("Could not find specified region");

            newElectricChargingPoint.Region = Context.Set<Region>().Where(r => r.Id == newElectricChargingPoint.Region.Id).FirstOrDefault();
            StoreInDb(newElectricChargingPoint);

            return newElectricChargingPoint.Id;
        }

        private bool RegionExists(Region region)
        {
            return Context.Set<Region>().Any(r => r.Id == region.Id);
        }

        private void StoreInDb(ElectricChargingPoint newElectricChargingPoint)
        {
            Context.Set<ElectricChargingPoint>().Add(newElectricChargingPoint);
            Context.SaveChanges();
        }
    }
}