using System;

namespace Domain
{
    public class Test
    {
        public Guid Id { get; set; }
        public int PatientId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int HospitalId { get; set; }
        public int VaccineId { get; set; }
        public string Variation { get; set; }
    }
}