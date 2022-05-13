using MinTur.Exceptions;
using System;
using System.ComponentModel.DataAnnotations;

namespace MinTur.Domain.BusinessEntities
{
    public class ElectricChargingPoint
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
        public Region Region { get; set; }
        public int RegionId { get; set; }
        public string Description { get; set; }

        public virtual void ValidOrFail()
        {
            ValidateName();
            ValidateAddress();
            ValidateRegion();
            ValidateDescription();
        }

        private void ValidateName()
        {
            if (String.IsNullOrEmpty(Name) || Name.Length > 20)
                throw new InvalidRequestDataException("Invalid or missing Name. Only up to 20 characters allowed");
        }

        private void ValidateAddress()
        {
            if (String.IsNullOrEmpty(Address) || Address.Length > 30)
                throw new InvalidRequestDataException("Invalid or missing Address. Only up to 30 characters allowed");
        }

        private void ValidateRegion()
        {
            if (RegionId <= 0)
                throw new InvalidRequestDataException("Invalid or missing Region");
        }

        private void ValidateDescription()
        {
            if (String.IsNullOrEmpty(Description) || Description.Length > 60)
                throw new InvalidRequestDataException("Invalid or missing Description. Only up to 60 characters allowed");
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
                return false;

            var electricChargingPoint = obj as ElectricChargingPoint;
            return Id == electricChargingPoint.Id;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

    }
}
