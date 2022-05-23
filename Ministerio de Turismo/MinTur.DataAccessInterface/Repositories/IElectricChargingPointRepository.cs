using System.Collections.Generic;
using MinTur.Domain.BusinessEntities;

namespace MinTur.DataAccessInterface.Repositories
{
    public interface IElectricChargingPointRepository
    {
        List<ElectricChargingPoint> GetAllElectricChargingPoints();
        ElectricChargingPoint GetElectricChargingPointById(int id);
        int StoreElectricChargingPoint(ElectricChargingPoint newElectricChargingPoint);
        void DeleteElectricChargingPoint(ElectricChargingPoint electricChargingPoint);
    }
}