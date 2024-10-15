using AgencyManager.Core.Models.Entities;

namespace AgencyManager.Core.Models
{
    public class Position
    {
        private const int MinDescriptionLenght = 2;
        private const int MaxDescriptionLenght = 100;
        private const int MinResposabilitiesLenght = 10;
        private const int MaxResponsabilitiesLenght = 500;
        private const int MinSalaryValue = 500;
        private const int MaxSalaryValue = 50000;
        
        public Position(string description, string responsabilities, decimal salary, Agency agency)
        {
            Description = description;
            Responsabilities = responsabilities;
            Salary = salary;            
            Agency = agency;
            AgencyId = agency.Id;
        }

        public int Id { get; set; }
        public string Description { get; private set; }
        public string Responsabilities { get; private set; }
        public decimal Salary { get; private set; }
        public int AgencyId { get; private set; }
        public virtual Agency Agency { get; set; }

        public bool Validate()
        {
            if(Description is not null && 
                Description.Length > MinDescriptionLenght && 
                Description.Length < MaxDescriptionLenght &&

                Responsabilities is not null && 
                Responsabilities.Length > MinResposabilitiesLenght && 
                Responsabilities.Length < MaxResponsabilitiesLenght &&
                Salary > MinSalaryValue && Salary < MaxSalaryValue &&

                Agency is not null && Agency.Id > 0) 
                return true;
            return false;
        }
    }
}