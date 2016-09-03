using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace best_vethack3.Models.Domain
{
    public class Buddy
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int IsActive { get; set; }
        public string Branch { get; set; }
        public string Rank { get; set; }
        public int YearsServed { get; set; }
        public string Location { get; set; }
        public string CurrentOccupation { get; set; }
        public string TagLine { get; set; }
        public string Bio { get; set; }
    }
}