using System.Collections.Generic;
using MinTur.BusinessLogicInterface.ResourceManagers;
using MinTur.DataAccessInterface.Facades;
using MinTur.Domain.BusinessEntities;

namespace MinTur.BusinessLogic.ResourceManagers
{
    public class ElectricChargingPointManager : IElectricChargingPointManager
    {
        private readonly IRepositoryFacade _repositoryFacade;

        public ElectricChargingPointManager(IRepositoryFacade repositoryFacade)
        {
            _repositoryFacade = repositoryFacade;
        }

        public ElectricChargingPoint GetElectricChargingPointById(int ElectricChargingPointId)
        {
            return _repositoryFacade.GetElectricChargingPointById(ElectricChargingPointId);
        }

        public List<ElectricChargingPoint> GetAllElectricChargingPoints()
        {
            return _repositoryFacade.GetAllElectricChargingPoints();
        }

        public ElectricChargingPoint RegisterElectricChargingPoint(ElectricChargingPoint ElectricChargingPoint)
        {
            ElectricChargingPoint.ValidOrFail();
            int newElectricChargingPointId = _repositoryFacade.StoreElectricChargingPoint(ElectricChargingPoint);
            ElectricChargingPoint createdElectricChargingPoint = _repositoryFacade.GetElectricChargingPointById(newElectricChargingPointId);

            return createdElectricChargingPoint;
        }

    }
}