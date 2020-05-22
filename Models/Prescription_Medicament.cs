using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APBD11.Models
{
    public class Prescription_Medicament
    {
        [Key]
        public int IdMedicament { get; set; }
        public Medicament Medicament { get; set; }
        public int IdPrescritpion { get; set; }
        public Prescription Prescription { get; set; }
        public int? Dose{ get; set; }
        [MaxLength(100)]
        public string Details { get; set; }
    }
}
