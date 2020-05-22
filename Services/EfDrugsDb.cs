using APBD11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD11.Services
{
    public class EfDrugsDb : IDrugsDb
    {
        private readonly DrugsDbContext _context;
        public EfDrugsDb(DrugsDbContext context)
        {
            _context = context;
        }

        public Doctor AddDoctor(Doctor doctor)
        {
            if (doctor.FirstName.Equals(""))
            {
                throw new Exception();
            }
            if (doctor.LastName.Equals(""))
            {
                throw new Exception();
            }
            if (doctor.Email.Equals(""))
            {
                throw new Exception();
            }

            doctor.IdDoctor = _context.Doctors.Max().IdDoctor + 1;
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
            return doctor;
        }

        public void DeleteDoctor(int id)
        {
            var doc = _context.Doctors.FirstOrDefault(doc => doc.IdDoctor == id);
            if (doc == null)
            {
                throw new Exception();
            }
            _context.Doctors.Remove(doc);
            _context.SaveChanges();
        }

        public IEnumerable<Doctor> GetDoctors()
        {
            return _context.Doctors.ToList();
        }

        public Doctor ModifyDoctor(Doctor doc)
        {
            var dok = _context.Doctors.FirstOrDefault(dok => dok.IdDoctor == doc.IdDoctor);
            if (dok == null)
            {
                throw new Exception();
            }

            dok.FirstName = doc.FirstName != null ? doc.FirstName : dok.FirstName;
            dok.LastName = doc.LastName != null ? doc.LastName : dok.LastName;
            dok.Email = doc.Email != null ? doc.Email : dok.Email;

            _context.Doctors.Update(dok);
            _context.SaveChanges();

            return dok;
        }

        public void Seed()
        {
            var doc1 = new Doctor
            {
                IdDoctor = 1,
                FirstName = "Wasiej",
                LastName = "Maciak",
                Email = "Wasiej.Maciak@doktor.pl"
            };

            var doc2 = new Doctor
            {
                IdDoctor = 2,
                FirstName = "Silip",
                LastName = "Ftachurski",
                Email = "ftachursky@doktor.pl"
            };

            _context.Doctors.Add(doc1);
            _context.Doctors.Add(doc2);

            var pat1 = new Patient
            {
                IdPatient = 1,
                FirstName = "Maciej",
                LastName = "Wasiak",
                Birthdate = DateTime.Now
            };

            var pat2 = new Patient
            {
                IdPatient = 2,
                FirstName = "Filip",
                LastName = "Stachurski",
                Birthdate = DateTime.Now
            };

            _context.Patients.Add(pat1);
            _context.Patients.Add(pat2);

            var pre1 = new Prescription
            {
                IdPrescritpion = 1,
                Date = DateTime.Now,
                DueDate = DateTime.Now,
                IdPatient = 1,
                IdDoctor = 2
            };

            var pre2 = new Prescription
            {
                IdPrescritpion = 2,
                Date = DateTime.Now,
                DueDate = DateTime.Now,
                IdPatient = 2,
                IdDoctor = 1
            };

            _context.Prescriptions.Add(pre1);
            _context.Prescriptions.Add(pre2);

            var med1 = new Medicament
            {
                IdMedicament = 1,
                Name = "wasiakozol",
                Description = "na brak weny programistycznej",
                Type = "silnie uzalezniajacy"
            };

            var med2 = new Medicament
            {
                IdMedicament = 2,
                Name = "klonozepam",
                Description = "na leb",
                Type = "silnie uzalezniajacy"
            };

            _context.Medicaments.Add(med1);
            _context.Medicaments.Add(med2);

            var pm1 = new Prescription_Medicament
            {
                IdMedicament = 1,
                IdPrescritpion = 1,
                Dose = 1000,
                Details = "brak"
            };

            var pm2 = new Prescription_Medicament
            {
                IdMedicament = 2,
                IdPrescritpion = 2,
                Dose = 10,
                Details = "brak"
            };

            _context.Prescriptions_Medicaments.Add(pm1);
            _context.Prescriptions_Medicaments.Add(pm2);
        }
    }
}
