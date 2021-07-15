using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class AppUser : IdentityUser
    {
        public string DisplayName {get; set;}
        public string Bio {get; set;}
        public string Role { get; set; }

        public List<Test> Tests { get; set; } = new List<Test>();
        public ICollection<PatientChronicDisease> ChronicDisease { get; set; }
        public ICollection<Article> Articles { get; set; }
        public ICollection<PatientVaccine> Vaccines { get; set; }
        public ICollection<PatientAllergy> Allergies { get; set; }
    }
}