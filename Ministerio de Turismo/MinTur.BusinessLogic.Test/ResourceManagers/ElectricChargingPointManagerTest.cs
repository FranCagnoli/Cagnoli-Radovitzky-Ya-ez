using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MinTur.BusinessLogic.ResourceManagers;
using MinTur.DataAccessInterface.Facades;
using MinTur.Domain.BusinessEntities;
using System.Collections.Generic;

namespace MinTur.BusinessLogic.Test.ResourceManagers
{
    [TestClass]
    public class ElectricChargingPointManagerTest
    {
        private List<ElectricChargingPoint> _ElectricChargingPoints;
        private Mock<IRepositoryFacade> _repositoryFacadeMock;
        private Mock<ElectricChargingPoint> _ElectricChargingPointMock;

        #region SetUp
        [TestInitialize]
        public void SetUp()
        {
            _ElectricChargingPoints = new List<ElectricChargingPoint>();
            _repositoryFacadeMock = new Mock<IRepositoryFacade>(MockBehavior.Strict);
            _ElectricChargingPointMock = new Mock<ElectricChargingPoint>(MockBehavior.Strict);

            LoadElectricChargingPoints();
        }

        private void LoadElectricChargingPoints()
        {
            ElectricChargingPoint electricChargingPoint1 = new ElectricChargingPoint()
            {
                Name = "Puerto de carga 1",
                Address = "Una direccion",
                Region = new Region()
                {
                    Name = "Region"
                },
                Description = "Una Descripcion",
            };
            ElectricChargingPoint electricChargingPoint2 = new ElectricChargingPoint()
            {
                Name = "Puerto de carga 2",
                Address = "Una direccion",
                Region = new Region()
                {
                    Name = "Region"
                },
                Description = "Una Descripcion",
            };
            _ElectricChargingPoints.Add(electricChargingPoint1);
            _ElectricChargingPoints.Add(electricChargingPoint2);
        }

        #endregion

        [TestMethod]
        public void GetAllElectricChargingPointsReturnsAsExpected()
        {
            _repositoryFacadeMock.Setup(r => r.GetAllElectricChargingPoints()).Returns(_ElectricChargingPoints);

            ElectricChargingPointManager ElectricChargingPointManager = new ElectricChargingPointManager(_repositoryFacadeMock.Object);
            List<ElectricChargingPoint> retrievedElectricChargingPoints = ElectricChargingPointManager.GetAllElectricChargingPoints();

            _repositoryFacadeMock.VerifyAll();
            CollectionAssert.AreEquivalent(retrievedElectricChargingPoints, _ElectricChargingPoints);
        }

        [TestMethod]
        public void RegisterElectricChargingPointReturnsAsExpected()
        {
            int ElectricChargingPointId = 6;
            ElectricChargingPoint createdElectricChargingPoint = CreateElectricChargingPointWithSpecificId(ElectricChargingPointId);

            Mock<ElectricChargingPoint> ElectricChargingPointMock = new Mock<ElectricChargingPoint>(MockBehavior.Strict);
            ElectricChargingPointMock.Setup(r => r.ValidOrFail());

            _repositoryFacadeMock.Setup(r => r.StoreElectricChargingPoint(ElectricChargingPointMock.Object)).Returns(ElectricChargingPointId);
            _repositoryFacadeMock.Setup(r => r.GetElectricChargingPointById(ElectricChargingPointId)).Returns(createdElectricChargingPoint);

            ElectricChargingPointManager ElectricChargingPointManager = new ElectricChargingPointManager(_repositoryFacadeMock.Object);
            ElectricChargingPoint retrievedElectricChargingPoint = ElectricChargingPointManager.RegisterElectricChargingPoint(ElectricChargingPointMock.Object);

            _repositoryFacadeMock.VerifyAll();
            ElectricChargingPointMock.VerifyAll();
            Assert.AreEqual(createdElectricChargingPoint, retrievedElectricChargingPoint);
        }

        [TestMethod]
        public void GetElectricChargingPointByIdReturnsAsExpected()
        {
            int ElectricChargingPointId = 6;
            ElectricChargingPoint expectedElectricChargingPoint = new ElectricChargingPoint()
            {
                Id = 6,
                Name = "Puerto de carga 1",
                Address = "Una direccion",
                Region = new Region()
                {
                    Id = 1,
                    Name = "Region"
                },
                Description = "Una Descripcion",
            };
            _repositoryFacadeMock.Setup(r => r.GetElectricChargingPointById(ElectricChargingPointId)).Returns(expectedElectricChargingPoint);

            ElectricChargingPointManager ElectricChargingPointManager = new ElectricChargingPointManager(_repositoryFacadeMock.Object);
            ElectricChargingPoint retrievedElectricChargingPoint = ElectricChargingPointManager.GetElectricChargingPointById(ElectricChargingPointId);

            _repositoryFacadeMock.VerifyAll();
            Assert.AreEqual(expectedElectricChargingPoint, retrievedElectricChargingPoint);
        }

        [TestMethod]
        public void DeleteElectricChargingPointReturnsAsExpected()
        {
            int ElectricChargingPointId = 6;
            ElectricChargingPoint ElectricChargingPointToBeDeleted = CreateElectricChargingPointWithSpecificId(ElectricChargingPointId);

            _repositoryFacadeMock.Setup(r => r.GetElectricChargingPointById(ElectricChargingPointId)).Returns(ElectricChargingPointToBeDeleted);
            _repositoryFacadeMock.Setup(r => r.DeleteElectricChargingPoint(ElectricChargingPointToBeDeleted));
            ElectricChargingPointManager ElectricChargingPointManager = new ElectricChargingPointManager(_repositoryFacadeMock.Object);

            ElectricChargingPointManager.DeleteElectricChargingPointById(ElectricChargingPointId);
            _repositoryFacadeMock.VerifyAll();
            Assert.IsTrue(ElectricChargingPointId.Equals(ElectricChargingPointToBeDeleted.Id));
        }

        #region Helpers

        public ElectricChargingPoint CreateElectricChargingPointWithSpecificId(int id)
        {
            return new ElectricChargingPoint()
            {
                Id = id,
                Name = "Puerto de carga 1",
                Address = "Una direccion",
                Region = new Region()
                {
                    Id = 1,
                    Name = "Region"
                },
                Description = "Una Descripcion",
            };
        }



        #endregion
    }
}