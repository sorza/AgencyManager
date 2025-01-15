using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgencyManager.Core.DTOs
{
    public class PositionDto
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Responsabilities { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public int AgencyId { get; set; }
    }
}
