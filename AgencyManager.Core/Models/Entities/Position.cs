namespace AgencyManager.Core.Models.Entities
{
    public class Position : Entity
    {        
        public Position(string description, string responsabilities, decimal salary, Guid agencyId)
        {
            Description = description;
            Responsabilities = responsabilities;
            Salary = salary;  
            AgencyId = agencyId;
        }

        public string Description { get; private set; }
        public string Responsabilities { get; private set; }
        public decimal Salary { get; private set; }
        public Guid AgencyId { get; private set; }
    }
}