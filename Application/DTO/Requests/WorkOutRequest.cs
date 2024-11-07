using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Requests
{
    public class WorkOutRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int TypeId { get; set; }
        public int CategoryId { get; set; }
        public string TrainingDuration { get; set; }
        public Price Price { get; set; } 
    }
}
