using MinTur.Domain.BusinessEntities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinTur.Models.In;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinTur.Models.Test.In
{
    [TestClass]
    public class ElectricChargingPointIntentModelTest
    {
        [TestMethod]
        public void ElectricChargingPointIntentModelCreatedAsExpected()
        {
            ElectricChargingPointIntentModel ElectricChargingPointIntentModel = new ElectricChargingPointIntentModel()
            {
                Name = "Puerto de carga 1",
                Address = "Una direccion",
                RegionId = 1,
                Description = "Una Descripcion",
            };

            ElectricChargingPoint ElectricChargingPoint = ElectricChargingPointIntentModel.ToEntity();

            Assert.IsTrue(ElectricChargingPoint.Name == ElectricChargingPointIntentModel.Name);
            Assert.IsTrue(ElectricChargingPoint.Address == ElectricChargingPointIntentModel.Address);
            Assert.IsTrue(ElectricChargingPoint.Description == ElectricChargingPointIntentModel.Description);
            Assert.IsTrue(ElectricChargingPoint.RegionId == ElectricChargingPointIntentModel.RegionId);
        }
    }
}
