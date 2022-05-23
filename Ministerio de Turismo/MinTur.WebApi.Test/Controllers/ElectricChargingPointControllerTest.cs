using System.Collections.Generic;
using MinTur.BusinessLogicInterface.ResourceManagers;
using MinTur.Domain.BusinessEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinTur.Models.In;
using MinTur.Models.Out;
using Moq;
using MinTur.WebApi.Controllers;

namespace MinTur.WebApi.Test.Controllers
{
    [TestClass]
    public class ElectricChargingPointControllerTest
    {
        private List<ElectricChargingPoint> _ElectricChargingPoints;
        private List<ElectricChargingPointBasicInfoModel> _ElectricChargingPointBasicInfoModels;
        private Mock<IElectricChargingPointManager> _ElectricChargingPointManagerMock;

        #region SetUp
        [TestInitialize]
        public void SetUp()
        {
            _ElectricChargingPoints = new List<ElectricChargingPoint>();
            _ElectricChargingPointBasicInfoModels = new List<ElectricChargingPointBasicInfoModel>();
            _ElectricChargingPointManagerMock = new Mock<IElectricChargingPointManager>(MockBehavior.Strict);

            LoadElectricChargingPoints();
            LoadElectricChargingPointBasicInfoModels();
        }

        private void LoadElectricChargingPoints()
        {
            ElectricChargingPoint ElectricChargingPoint1 = new ElectricChargingPoint()
            {
                Id = 1,
                Name = "Puerto1",
                RegionId = 2,
                Region = new Region()
                {
                    Id = 2,
                    Name = "Region"
                },
                Description = "Desc",
                Address = "Direcc"
            };

            ElectricChargingPoint ElectricChargingPoint2 = new ElectricChargingPoint()
            {
                Id = 2,
                Name = "Puerto2",
                RegionId = 2,
                Region = new Region()
                {
                    Id = 2,
                    Name = "Region"
                },
                Description = "Desc",
                Address = "Direcc"
            };
            _ElectricChargingPoints.Add(ElectricChargingPoint1);
            _ElectricChargingPoints.Add(ElectricChargingPoint2);
        }


        private void LoadElectricChargingPointBasicInfoModels()
        {
            foreach (ElectricChargingPoint ElectricChargingPoint in _ElectricChargingPoints)
            {
                _ElectricChargingPointBasicInfoModels.Add(new ElectricChargingPointBasicInfoModel(ElectricChargingPoint));
            }
        }

        #endregion

        [TestMethod]
        public void GetAllElectricChargingPointsOkTest()
        {
            _ElectricChargingPointManagerMock.Setup(c => c.GetAllElectricChargingPoints()).Returns(_ElectricChargingPoints);
            ElectricChargingPointController ElectricChargingPointController = new ElectricChargingPointController(_ElectricChargingPointManagerMock.Object);

            IActionResult result = ElectricChargingPointController.GetAll();
            OkObjectResult okResult = result as OkObjectResult;
            List<ElectricChargingPointBasicInfoModel> responseModel = okResult.Value as List<ElectricChargingPointBasicInfoModel>;

            _ElectricChargingPointManagerMock.VerifyAll();
            CollectionAssert.AreEquivalent(responseModel, _ElectricChargingPointBasicInfoModels);
        }

        [TestMethod]
        public void CreateElectricChargingPointCreatedTest()
        {
            ElectricChargingPointIntentModel ElectricChargingPointIntentModel = CreateElectricChargingPointIntentModel();
            ElectricChargingPoint createdElectricChargingPoint = CreateElectricChargingPoint();

            _ElectricChargingPointManagerMock.Setup(a => a.RegisterElectricChargingPoint(It.IsAny<ElectricChargingPoint>())).Returns(createdElectricChargingPoint);
            ElectricChargingPointController ElectricChargingPointController = new ElectricChargingPointController(_ElectricChargingPointManagerMock.Object);

            IActionResult result = ElectricChargingPointController.CreateElectricChargingPoint(ElectricChargingPointIntentModel);
            CreatedResult createdResult = result as CreatedResult;

            _ElectricChargingPointManagerMock.VerifyAll();
            Assert.IsTrue(createdResult.Value.Equals(new ElectricChargingPointBasicInfoModel(createdElectricChargingPoint)));
        }

        [TestMethod]
        public void GetElectricChargingPointByIdOkTest()
        {
            int ElectricChargingPointId = 4;
            ElectricChargingPoint expectedElectricChargingPoint = CreateElectricChargingPointWithSpecificId(ElectricChargingPointId);

            _ElectricChargingPointManagerMock.Setup(a => a.GetElectricChargingPointById(ElectricChargingPointId)).Returns(expectedElectricChargingPoint);
            ElectricChargingPointController ElectricChargingPointController = new ElectricChargingPointController(_ElectricChargingPointManagerMock.Object);

            IActionResult result = ElectricChargingPointController.GetSpecificElectricChargingPoint(ElectricChargingPointId);
            OkObjectResult okResult = result as OkObjectResult;

            _ElectricChargingPointManagerMock.VerifyAll();
            Assert.AreEqual(new ElectricChargingPointBasicInfoModel(expectedElectricChargingPoint), okResult.Value);
        }

        [TestMethod]
        public void DeleteElectricChargingPointTest()
        {
            ElectricChargingPoint ElectricChargingPointToDelete = CreateElectricChargingPoint();
            int ElectricChargingPointIdToDelete = ElectricChargingPointToDelete.Id;
            string succesfulDeletitionMessage = new { ResultMessage = $"Electric Charging Point {ElectricChargingPointIdToDelete} succesfully deleted" }.ToString();

            _ElectricChargingPointManagerMock.Setup(r => r.DeleteElectricChargingPointById(ElectricChargingPointIdToDelete));
            ElectricChargingPointController ElectricChargingPointController = new ElectricChargingPointController(_ElectricChargingPointManagerMock.Object);

            IActionResult result = ElectricChargingPointController.DeleteElectricChargingPoint(ElectricChargingPointIdToDelete);
            OkObjectResult okResult = result as OkObjectResult;
            string retrievedResultMessage = okResult.Value.ToString();

            _ElectricChargingPointManagerMock.VerifyAll();
            Assert.AreEqual(succesfulDeletitionMessage, retrievedResultMessage);
        }

        #region Helpers
        public ElectricChargingPointIntentModel CreateElectricChargingPointIntentModel()
        {
            return new ElectricChargingPointIntentModel()
            {
                Name = "Puerto de carga 1",
                Address = "Una direccion",
                RegionId = 1,
                Description = "Una Descripcion",
            };
        }

        public ElectricChargingPoint CreateElectricChargingPoint()
        {
            return new ElectricChargingPoint()
            {
                Id = 1,
                Name = "Puerto1",
                RegionId = 2,
                Region = new Region()
                {
                    Id = 2,
                    Name = "Region"
                },
                Description = "Desc",
                Address = "Direcc"
            };

        }
        public ElectricChargingPoint CreateElectricChargingPointWithSpecificId(int ElectricChargingPointId)
        {
            return new ElectricChargingPoint()
            {
                Id = ElectricChargingPointId,
                Name = "Puerto1",
                RegionId = 2,
                Region = new Region()
                {
                    Id = 2,
                    Name = "Region"
                },
                Description = "Desc",
                Address = "Direcc"
            };

        }
        #endregion
    }
}