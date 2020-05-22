using APBD11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD11.Services
{
    public interface IDrugsDb
    {
        public IEnumerable<Doctor> GetDoctors();
        public Doctor AddDoctor(Doctor doctor);
        public Doctor ModifyDoctor(Doctor doc);
        public void DeleteDoctor(int id);
        public void Seed();
    }
}
