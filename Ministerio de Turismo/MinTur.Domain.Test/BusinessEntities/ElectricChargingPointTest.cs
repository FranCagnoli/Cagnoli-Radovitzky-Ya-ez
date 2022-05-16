using MinTur.Domain.BusinessEntities;
using MinTur.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MinTur.Domain.Test.BusinessEntities
{
    [TestClass]
    public class ElectricChargingPointTest
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidRequestDataException))]
        public void ElectricChargingPointWithNoNameValidation()
        {
            ElectricChargingPoint ElectricChargingPoint = new ElectricChargingPoint()
            {
                Address = "Una direccion",
                RegionId = 1,
                Description = "Una Descripcion",
            };
            ElectricChargingPoint.ValidOrFail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidRequestDataException))]
        public void ElectricChargingPointWithLongNameValidation()
        {
            ElectricChargingPoint ElectricChargingPoint = new ElectricChargingPoint()
            {
                Name = "Puerto de carga con nombre largo",
                Address = "Una direccion",
                RegionId = 1,
                Description = "Una Descripcion",
            };
            ElectricChargingPoint.ValidOrFail();
        }


        [TestMethod]
        [ExpectedException(typeof(InvalidRequestDataException))]
        public void ElectricChargingPointWithNoAddressFailsValidation()
        {
            ElectricChargingPoint ElectricChargingPoint = new ElectricChargingPoint()
            {
                Name = "Puerto de carga 1",
                RegionId = 1,
                Description = "Una Descripcion",
            };
            ElectricChargingPoint.ValidOrFail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidRequestDataException))]
        public void ElectricChargingPointWithLongAddressFailsValidation()
        {
            ElectricChargingPoint ElectricChargingPoint = new ElectricChargingPoint()
            {
                Name = "Puerto de carga 1",
                Address = "Una direccion muy larga para la validacion",
                RegionId = 1,
                Description = "Una Descripcion",
            };
            ElectricChargingPoint.ValidOrFail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidRequestDataException))]
        public void ElectricChargingPointWithNoRegionFailsValidation()
        {
            ElectricChargingPoint ElectricChargingPoint = new ElectricChargingPoint()
            {
                Name = "Puerto de carga 1",
                Address = "Una direccion",
                Description = "Una Descripcion",
                RegionId = -1,

            };
            ElectricChargingPoint.ValidOrFail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidRequestDataException))]
        public void ElectricChargingPointWithNoDescriptionFailsValidation()
        {
            ElectricChargingPoint ElectricChargingPoint = new ElectricChargingPoint()
            {
                Name = "Puerto de carga 1",
                Address = "Una direccion",
                RegionId = 1,
            };
            ElectricChargingPoint.ValidOrFail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidRequestDataException))]
        public void ElectricChargingPointWithLongDescriptionFailsValidation()
        {
            ElectricChargingPoint ElectricChargingPoint = new ElectricChargingPoint()
            {
                Name = "Puerto de carga 1",
                Address = "Una direccion",
                RegionId = 1,
                Description = "Una Descripcion muy larga para el campo, Una Descripcion muy larga para el campo.",

            };
            ElectricChargingPoint.ValidOrFail();
        }


        [TestMethod]
        public void ValidElectricChargingPointPassesValidation()
        {
            ElectricChargingPoint ElectricChargingPoint = new ElectricChargingPoint()
            {
                Name = "Puerto de carga 1",
                Address = "Una direccion",
                RegionId = 1,
                Description = "Una Descripcion",
            };
            ElectricChargingPoint.ValidOrFail();
        }

   

    }
}
