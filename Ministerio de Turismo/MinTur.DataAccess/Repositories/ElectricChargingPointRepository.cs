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
            return Context.Set<ElectricChargingPoint>().Include(ecp => ecp.Region).ToList();
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
            if (!RegionExists(newElectricChargingPoint.RegionId))
                throw new ResourceNotFoundException("Could not find specified region");

            newElectricChargingPoint.Region = Context.Set<Region>().Where(r => r.Id == newElectricChargingPoint.RegionId).FirstOrDefault();
            StoreInDb(newElectricChargingPoint);

            return newElectricChargingPoint.Id;
        }

        private bool RegionExists(int regionId)
        {
            return Context.Set<Region>().Any(r => r.Id == regionId);
        }

        private void StoreInDb(ElectricChargingPoint newElectricChargingPoint)
        {
            Context.Set<ElectricChargingPoint>().Add(newElectricChargingPoint);
            Context.SaveChanges();
        }

        public void DeleteElectricChargingPoint(ElectricChargingPoint electricChargingPoint)
        {
            if (!ElectricChargingPointExists(electricChargingPoint.Id))
                throw new ResourceNotFoundException("Could not find specified electric charging point");

            ElectricChargingPoint retrievedElectricChargingPoint = Context.Set<ElectricChargingPoint>().Where(a => a.Id == electricChargingPoint.Id).FirstOrDefault();
            DeleteElectricChargingPointFromDb(electricChargingPoint);
        }

        private bool ElectricChargingPointExists(int id)
        {
            ElectricChargingPoint retrievedElectricChargingPoint = Context.Set<ElectricChargingPoint>().AsNoTracking().Where(ecp => ecp.Id == id).FirstOrDefault();
            return retrievedElectricChargingPoint != null;
        }

        private void DeleteElectricChargingPointFromDb(ElectricChargingPoint electricChargingPoint)
        {
            Context.Set<ElectricChargingPoint>().Remove(electricChargingPoint);
            Context.SaveChanges();
        }
    }
}