using System;
using System.Collections.Generic;
using System.Linq;
using MinTur.Domain.BusinessEntities;

namespace MinTur.Models.Out
{
    public class ElectricChargingPointBasicInfoModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }

        public RegionBasicInfoModel Region { get; set; }

        public ElectricChargingPointBasicInfoModel(ElectricChargingPoint ElectricChargingPoint)
        {
            Id = ElectricChargingPoint.Id;
            Name = ElectricChargingPoint.Name;
            Address= ElectricChargingPoint.Address;
            Description = ElectricChargingPoint.Description;
            Region = new RegionBasicInfoModel(ElectricChargingPoint.Region);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
                return false;

            var ElectricChargingPointModel = obj as ElectricChargingPointBasicInfoModel;
            return Id == ElectricChargingPointModel.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
