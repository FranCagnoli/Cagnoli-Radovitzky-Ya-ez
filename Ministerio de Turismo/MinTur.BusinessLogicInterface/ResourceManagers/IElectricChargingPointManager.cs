using System.Collections.Generic;
using MinTur.Domain.BusinessEntities;

namespace MinTur.BusinessLogicInterface.ResourceManagers
{
    public interface IElectricChargingPointManager
    {
        List<ElectricChargingPoint> GetAllElectricChargingPoints();
        ElectricChargingPoint RegisterElectricChargingPoint(ElectricChargingPoint newElectricChargingPoint);
        ElectricChargingPoint GetElectricChargingPointById(int electricChargingPointId);
        void DeleteElectricChargingPointById(int electricChargingPointId);
    }
}