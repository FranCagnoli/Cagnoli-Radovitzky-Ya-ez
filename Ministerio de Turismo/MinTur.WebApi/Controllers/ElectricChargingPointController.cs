using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinTur.BusinessLogicInterface.ResourceManagers;
using MinTur.Domain.BusinessEntities;
using MinTur.Models.In;
using MinTur.Models.Out;
using System.Collections.Generic;
using System.Linq;
using MinTur.WebApi.Filters;

namespace MinTur.WebApi.Controllers
{
    [EnableCors("AllowEverything")]
    [Route("api/electricChargingPoints")]
    [ApiController]
    public class ElectricChargingPointController : Controller
    {

        private readonly IElectricChargingPointManager _ElectricChargingPointManager;

        public ElectricChargingPointController(IElectricChargingPointManager ElectricChargingPointManager)
        {
            _ElectricChargingPointManager = ElectricChargingPointManager;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<ElectricChargingPoint> retrievedElectricChargingPoints = _ElectricChargingPointManager.GetAllElectricChargingPoints();
            List<ElectricChargingPointBasicInfoModel> ElectricChargingPointBasicInfoModels = retrievedElectricChargingPoints.Select(ElectricChargingPoint => new ElectricChargingPointBasicInfoModel(ElectricChargingPoint)).ToList();
            return Ok(ElectricChargingPointBasicInfoModels);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetSpecificElectricChargingPoint(int id)
        {
            ElectricChargingPoint retrievedElectricChargingPoint = _ElectricChargingPointManager.GetElectricChargingPointById(id);
            ElectricChargingPointBasicInfoModel ElectricChargingPointBasicInfoModel = new ElectricChargingPointBasicInfoModel(retrievedElectricChargingPoint);
            return Ok(ElectricChargingPointBasicInfoModel);
        }

        [HttpPost]
        [ServiceFilter(typeof(AdministratorAuthorizationFilter))]
        public IActionResult CreateElectricChargingPoint([FromBody] ElectricChargingPointIntentModel ElectricChargingPointIntentModel)
        {
            ElectricChargingPoint createdElectricChargingPoint = _ElectricChargingPointManager.RegisterElectricChargingPoint(ElectricChargingPointIntentModel.ToEntity());
            ElectricChargingPointBasicInfoModel confirmation = new ElectricChargingPointBasicInfoModel(createdElectricChargingPoint);
            return Created("api/electricChargingPoints/" + createdElectricChargingPoint.Id, confirmation);
        }

    }
}
