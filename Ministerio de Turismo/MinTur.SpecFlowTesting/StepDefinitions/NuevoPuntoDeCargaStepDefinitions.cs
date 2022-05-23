using System;
using System.Net;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinTur.BusinessLogic.ResourceManagers;
using MinTur.DataAccess.Contexts;
using MinTur.DataAccess.Facades;
using MinTur.Domain.BusinessEntities;
using MinTur.Models.In;
using MinTur.Models.Out;
using MinTur.WebApi.Controllers;
using Newtonsoft.Json;
using SpecFlow.Internal.Json;
using TechTalk.SpecFlow;

namespace MinTur.SpecFlowTesting.StepDefinitions
{
    [Binding]
    public class NuevoPuntoDeCargaStepDefinitions
    {

        private readonly ScenarioContext context;
        private ElectricChargingPointIntentModel ecp;
        private ElectricChargingPointManager ecpManager;
        private RepositoryFacade repository;
        private DbContext dbContext;

        public NuevoPuntoDeCargaStepDefinitions(ScenarioContext context)
        {
            this.context = context;
        }

        [BeforeScenario()]
        public void Setup()
        {
            this.dbContext = ContextFactory.GetNewContext(ContextType.Memory);
            this.dbContext.Database.EnsureDeleted();
            this.ecp = new ElectricChargingPointIntentModel();
            this.repository = new RepositoryFacade(this.dbContext);
            this.ecpManager = new ElectricChargingPointManager(this.repository);
        }


        [Given(@"un usuario loggeado como admin")]
        public void GivenUnUsuarioLoggeadoComoAdmin()
        {
            this.context.Set(new Administrator() { Email = "a@a.com", Password = "APassword" }, "User");
        }


        [Given(@"un nombre ""([^""]*)""")]
        public void GivenUnNombre(string name)
        {
            this.ecp.Name = name;
        }

        [Given(@"una direccion ""([^""]*)""")]
        public void GivenUnaDireccion(string address)
        {
            this.ecp.Address = address;
        }

        [Given(@"un ID de Region (.*) existente")]
        public void GivenUnIDDeRegionExistente(int regionId)
        {
            this.ecp.RegionId = regionId;
            this.dbContext.Add(new Region() { Name = "Name", Id = regionId });
            this.dbContext.SaveChanges();
            this.repository = new RepositoryFacade(this.dbContext);
            this.ecpManager = new ElectricChargingPointManager(this.repository);
        }

        [Given(@"un ID de Region (.*) inexistente")]
        public void GivenUnIDDeRegionInexistente(int regionId)
        {
            this.ecp.RegionId = regionId;
        }
        
        [Given(@"una descripcion ""([^""]*)""")]
        public void GivenUnaDescripcion(string description)
        {
            this.ecp.Description = description;
        }


        [When(@"creo un punto de carga con esos valores")]
        public void WhenCreoUnPuntoDeCargaConEsosValores()
        {
            try
            {
                ElectricChargingPointController controller = new ElectricChargingPointController(this.ecpManager);
                IActionResult responseResult = controller.CreateElectricChargingPoint(this.ecp);
                CreatedResult response = (CreatedResult)responseResult;
                context.Set(response.StatusCode, "ResponseCode");
                context.Set(response.Value, "ResponseValue");
            }
            catch (Exception ex)
            {
                context.Set(ex.Message, "Exception");
            }

        }

        [Then(@"responde con un codigo de exito (.*)")]
        public void ThenRespondeConUnCodigoDeExito(int code)
        {
            Assert.AreEqual(code, (int)context.Get<HttpStatusCode>("ResponseCode"));

        }

        [Then(@"responde con el punto de carga creado\.")]
        public void ThenRespondeConElPuntoDeCargaCreado_()
        {
            ElectricChargingPointBasicInfoModel response =
                context.Get<ElectricChargingPointBasicInfoModel>("ResponseValue");
            Assert.AreEqual(this.ecp.Name, response.Name);
            Assert.AreEqual(this.ecp.Address, response.Address);
            Assert.AreEqual(this.ecp.Description, response.Description);
        }

        [Then(@"arroja una excepcion indicando ""([^""]*)""")]
        public void ThenArrojaUnaExcepcionIndicando(string exception)
        {
            string exMessage = context.Get<string>("Exception");
            Assert.AreEqual(exception, exMessage);
        }


    }
}
