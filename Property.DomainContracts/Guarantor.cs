namespace Property.DomainContracts
{
    public class Guarantor
    {
        public string Name { get; set; }
        public EmploymentDetails[] EmploymentDetails { get; set; }
        public ContactDetails ContactDetails { get; set; }
    }
}