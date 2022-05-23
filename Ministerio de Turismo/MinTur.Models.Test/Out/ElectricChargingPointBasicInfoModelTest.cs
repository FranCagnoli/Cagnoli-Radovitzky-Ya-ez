using MinTur.Domain.BusinessEntities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinTur.Models.Out;

namespace MinTur.Models.Test.Out
{
    [TestClass]
    public class ElectricChargingPointBasicInfoModelTest
    {
        [TestMethod]
        public void ElectricChargingPointIntentModelCreatedAsExpected()
        {
            ElectricChargingPoint ElectricChargingPoint = new ElectricChargingPoint()
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

            ElectricChargingPointBasicInfoModel electricChargingPointBasicInfoModel = new ElectricChargingPointBasicInfoModel(ElectricChargingPoint);

            Assert.IsTrue(ElectricChargingPoint.Name == electricChargingPointBasicInfoModel.Name);
            Assert.IsTrue(ElectricChargingPoint.Address == electricChargingPointBasicInfoModel.Address);
            Assert.IsTrue(ElectricChargingPoint.Description == electricChargingPointBasicInfoModel.Description);
        }
    }
}
