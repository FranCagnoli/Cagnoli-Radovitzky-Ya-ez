using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using MinTur.DataAccess.Contexts;
using MinTur.Domain.BusinessEntities;
using MinTur.DataAccess.Repositories;
using MinTur.Exceptions;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MinTur.DataAccess.Test.Repositories
{
    [TestClass]
    public class ElectricChargingPointRepositoryTest
    {
        private ElectricChargingPointRepository _repository;

        private NaturalUruguayContext _context;

        [TestInitialize]
        public void SetUp()
        {
            _context = ContextFactory.GetNewContext(ContextType.Memory);
            _repository = new ElectricChargingPointRepository(_context);
        }

        [TestCleanup]
        public void CleanUp()
        {
            _context.Database.EnsureDeleted();
        }

        [TestMethod]
        public void GetAllElectricChargingPointRepositoryOnEmptyRepository()
        {
            List<ElectricChargingPoint> expectedElectricChargingPoints = new List<ElectricChargingPoint>();
            List<ElectricChargingPoint> retrievedElectricChargingPoints = _repository.GetAllElectricChargingPoints();

            CollectionAssert.AreEquivalent(expectedElectricChargingPoints, retrievedElectricChargingPoints);
        }

        [TestMethod]
        public void GetAllElectricChargingPointsReturnsAsExpected()
        {
            List<ElectricChargingPoint> expectedElectricChargingPoints = new List<ElectricChargingPoint>();
            LoadElectricChargingPoints(expectedElectricChargingPoints);

            List<ElectricChargingPoint> retrievedElectricChargingPoints = _repository.GetAllElectricChargingPoints();
            CollectionAssert.AreEquivalent(expectedElectricChargingPoints, retrievedElectricChargingPoints);
        }

        [TestMethod]
        public void GetElectricChargingPointByIdReturnsAsExpected()
        {
            ElectricChargingPoint expectedElectricChargingPoint = new ElectricChargingPoint()
            {
                Id = 1,
                Name = "Puerto1",
                Region = new Region()
                {
                    Name = "Region"
                },
                Description = "Desc",
                Address = "Direcc"
            };
            _context.ElectricChargingPoints.Add(expectedElectricChargingPoint);
            _context.SaveChanges();

            ElectricChargingPoint retrievedElectricChargingPoint = _repository.GetElectricChargingPointById(expectedElectricChargingPoint.Id);
            Assert.IsTrue(expectedElectricChargingPoint.Equals(retrievedElectricChargingPoint));
        }

        [TestMethod]
        [ExpectedException(typeof(ResourceNotFoundException))]
        public void GetElectricChargingPointByIdWhichDoesntExistThrowsException()
        {
            _repository.GetElectricChargingPointById(-3);
        }

        #region Helpers
        private void LoadElectricChargingPoints(List<ElectricChargingPoint> ElectricChargingPoints)
        {
            ElectricChargingPoint ElectricChargingPoint1 = new ElectricChargingPoint()
            {
                Id = 1,
                Name = "Puerto1",
                Region = new Region()
                {
                    Name = "Region"
                },
                Description = "Desc",
                Address = "Direcc"
            };
            ElectricChargingPoint ElectricChargingPoint2 = new ElectricChargingPoint()
            {
                Id = 2,
                Name = "Puerto2",
                Region = new Region()
                {
                    Name = "Region"
                },
                Description = "Desc",
                Address = "Direcc"
            };

            ElectricChargingPoints.Add(ElectricChargingPoint1);
            ElectricChargingPoints.Add(ElectricChargingPoint2);

            _context.ElectricChargingPoints.Add(ElectricChargingPoint1);
            _context.ElectricChargingPoints.Add(ElectricChargingPoint2);
            _context.SaveChanges();
        }

        [TestMethod]
        public void StoreElectricChargingPointReturnsAsExpected()
        {
            Region region = new Region() { Id=1,Name = "Region" };
            _context.Regions.Add(region);
            _context.SaveChanges();
            _context.Entry(region).State = EntityState.Detached;


            ElectricChargingPoint electricChargingPoint = new ElectricChargingPoint()
            {
                Name = "Puerto2",
                RegionId = 1,
                Description = "Desc",
                Address = "Direcc"
            };
            int newElectricChargingPointId = _repository.StoreElectricChargingPoint(electricChargingPoint);

            Assert.AreEqual(electricChargingPoint.Id, newElectricChargingPointId);
            Assert.IsNotNull(_context.ElectricChargingPoints.Where(ecp => ecp.Id == newElectricChargingPointId).FirstOrDefault());
        }

        [TestMethod]
        [ExpectedException(typeof(ResourceNotFoundException))]
        public void StoreElectricChargingPointNonExistentRegion()
        {
            ElectricChargingPoint electricChargingPoint = new ElectricChargingPoint()
            {
                Name = "Puerto2",
                Region = new Region()
                {
                    Name = "Region"
                },
                Description = "Desc",
                Address = "Direcc"
            }; 
            electricChargingPoint.Region.Id = -4;

            _repository.StoreElectricChargingPoint(electricChargingPoint);
        }

        [TestMethod]
        public void DeleteElectricChargingPointReturnsAsExpected()
        {
            ElectricChargingPoint ElectricChargingPointToBeDeleted = new ElectricChargingPoint()
            {
                Name = "Puerto2",
                RegionId = 1,
                Description = "Desc",
                Address = "Direcc"
            };
            _context.Set<ElectricChargingPoint>().Add(ElectricChargingPointToBeDeleted);
            _context.SaveChanges();

            _repository.DeleteElectricChargingPoint(ElectricChargingPointToBeDeleted);
        }

        [TestMethod]
        [ExpectedException(typeof(ResourceNotFoundException))]
        public void DeleteElectricChargingPointDoesntExist()
        {
            _repository.DeleteElectricChargingPoint(new ElectricChargingPoint() {
                Id = -1,
                Name = "Puerto2",
                RegionId = 1,
                Description = "Desc",
                Address = "Direcc"
            });
        }


        #endregion
    }
}