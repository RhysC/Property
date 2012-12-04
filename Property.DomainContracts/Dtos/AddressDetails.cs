using System;

namespace Property.DomainContracts.Dtos
{
    public class AddressDetails
    {
        public Address Address { get; set; }
        public TimeSpan CurrentAddress { get; set; }//perhaps a form and to date?
        public LivingArrangement LivingArrangementAtAddress { get; set; }
    }
}