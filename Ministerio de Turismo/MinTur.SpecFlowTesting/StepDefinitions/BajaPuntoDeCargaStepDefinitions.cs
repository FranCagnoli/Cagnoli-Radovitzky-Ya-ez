using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinTur.BusinessLogic.ResourceManagers;
using MinTur.DataAccess.Contexts;
using MinTur.DataAccess.Facades;
using MinTur.Domain.BusinessEntities;
using MinTur.Models.In;
using MinTur.WebApi.Controllers;
using Newtonsoft.Json;
using SpecFlow.Internal.Json;
using TechTalk.SpecFlow;

namespace MinTur.SpecFlowTesting.StepDefinitions
{
    [Binding]
    public class BajaPuntoDeCargaStepDefinitions
    {

        private readonly ScenarioContext context;
        private int ecpID;
        private ElectricChargingPointManager ecpManager;
        private RepositoryFacade repository;
        private DbContext dbContext;

        public BajaPuntoDeCargaStepDefinitions(ScenarioContext context)
        {
            this.context = context;
        }

        [BeforeScenario()]
        public void Setup()
        {
            this.dbContext = ContextFactory.GetNewContext(ContextType.Memory);
            this.dbContext.Database.EnsureDeleted();
            this.repository = new RepositoryFacade(this.dbContext);
            this.ecpManager = new ElectricChargingPointManager(this.repository);
        }


        [Given(@"un id (.*) de un punto de carga existente")]
        public void GivenUnIdDeUnPuntoDeCargaExistente(int id)
        {
            this.ecpID = id;
            this.dbContext.Add(new ElectricChargingPoint()
            {
                Id = id,
                Name = "Puerto de carga 1",
                Address = "Una direccion",
                Region = new Region()
                {
                    Id = 1,
                    Name = "Region"
                },
                Description = "Una Descripcion"

            }
            );
            this.dbContext.SaveChanges();

        }

        [When(@"se elimina el punto de carga")]
        public void WhenSeEliminaElPuntoDeCarga()
        {
            try
            {
                ElectricChargingPointController controller = new ElectricChargingPointController(this.ecpManager);
                IActionResult responseResult = controller.DeleteElectricChargingPoint(this.ecpID);
                OkObjectResult response = (OkObjectResult)responseResult;
                context.Set(response.StatusCode, "ResponseCode");
                context.Set(response.Value.ToString(), "ResponseValue");
            }
            catch (Exception ex)
            {
                context.Set(ex.Message, "Exception");
            }
        }

        [Then(@"responde con un mensaje de exito: ""([^""]*)""")]
        public void ThenRespondeConUnMensajeDeExito(string message)
        {
            var responseJson = context.Get<string>("ResponseValue");
            Assert.AreEqual($"{{ ResultMessage = {message} }}", responseJson);
        }

        [Given(@"un id (.*) de un punto de carga inexistente")]
        public void GivenUnIdDeUnPuntoDeCargaInexistente(int id)
        {
            this.ecpID = id;
        }
    }
}
