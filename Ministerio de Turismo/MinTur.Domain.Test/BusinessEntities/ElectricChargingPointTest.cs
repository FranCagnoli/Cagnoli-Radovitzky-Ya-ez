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
                Region = new Region()
                {
                    Name = "Region"
                },
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
                Region = new Region()
                {
                    Name = "Region"
                },
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
                Region = new Region()
                {
                    Name = "Region"
                },
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
                Region = new Region()
                {
                    Name = "Region"
                },
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
                Region = new Region()
                {
                    Name = "Region"
                },
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
                Region = new Region()
                {
                    Name = "Region"
                },
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
                Region = new Region()
                {
                    Name = "Region"
                },
                Description = "Una Descripcion",
            };
            ElectricChargingPoint.ValidOrFail();
        }

   

    }
}
