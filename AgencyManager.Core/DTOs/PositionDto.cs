namespace AgencyManager.Core.DTOs
{
    public class PositionDto
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Responsabilities { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public int AgencyId { get; set; }

        public override string ToString()
        {
            return Description;
        }
    }
}