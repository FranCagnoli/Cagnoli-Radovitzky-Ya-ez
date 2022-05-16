using MinTur.Domain.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinTur.Models.In
{
    public class ElectricChargingPointIntentModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int RegionId { get; set; }
        public string Description { get; set; }


        public ElectricChargingPointIntentModel() { }

        public ElectricChargingPoint ToEntity()
        {
            ElectricChargingPoint ElectricChargingPoint = new ElectricChargingPoint()
            {
                Name = Name,
                Address = Address,
                RegionId = RegionId,
                Description = Description,
            };
            return ElectricChargingPoint;
        }

    }
}
