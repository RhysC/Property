using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Property.Web.Models.Landlord
{
    /// <summary>
    /// see http://schema.org/PostalAddress for definition of widely used postal address
    /// </summary>
    [ComplexType]
    public class Address
    {
        /// <summary>
        /// Unit number (if available). Could be 'A','1', 'Basement' etc
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// Building name (if available)
        /// </summary>
        public string BuildingName { get; set; }
        /// <summary>
        /// the number of the building, ie street number
        /// </summary>
        public string BuildingNumber { get; set; }
        /// <summary>
        /// Name and type of street
        /// </summary>
        public string Street { get; set; }
        /// <summary>
        /// Suburb
        /// </summary>
        public string Locality { get; set; }
        /// <summary>
        /// Region, county or state
        /// </summary>
        public string Region { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }

        public string StreetAddress
        {
            get
            {
                var contents = new[] { Unit, BuildingName, BuildingNumber, Street }.Where(c => !string.IsNullOrWhiteSpace(c));
                return string.Join(" ", contents);
            }
        }
    }
}