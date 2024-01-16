using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvcClinicRegistrationManagementSystem.BLL.Interface;
using mvcClinicRegistrationManagementSystem.DAL.Context;
using mvcClinicRegistrationManagementSystem.DAL.Model;

namespace mvcClinicRegistrationManagementSystem.PL.Controllers
{
    public class AdminController : Controller
    {
      

       
        private readonly IAppointmentReposatory _appointmentRepo;
        private readonly IPatientReposatory _patientRepo;
        private readonly ISpecializationReposatory _specializationRepo;
        private readonly IDoctorReposatory _doctorRepo;

        private readonly ApplicationDbContext _context;
        public AdminController(ApplicationDbContext context)
        {
            _context = context;
           
        }


        //This is the index view :
        public IActionResult Index()
        {
            var appointments = _context.Appointment
                .Include(a => a.Patient)
                .Include(a => a.Specialization)
                .Include(a => a.Doctor)
                .ToList();

            return View(appointments);
        }


        //ApproveAppointment sets the status of the appointment to "Approved":

            [HttpPost]
            public IActionResult ApproveAppointment(int AppoID)
            {
                var appointment = _context.Appointment.Find(AppoID);

                if (appointment != null)
                {
                    appointment.Status = "Approved";
                    _context.SaveChanges();
                }

                return RedirectToAction(nameof(Index));
            }



        //RescheduleAppointment updates the date and time of the appointment with the provided values:



        [HttpPost]
        public IActionResult RescheduleAppointment(int AppoID, DateTime newDateTime)
        {
            var appointment = _context.Appointment.Find(AppoID);

            if (appointment != null)
            {
                appointment.Date = newDateTime.Date;
                appointment.Time = newDateTime.ToString("HH:mm");

                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }




        //CancelAppointment sets the status of the appointment to "Canceled":
        [HttpPost]
            public IActionResult CancelAppointment(int AppoID)
            {
                var appointment = _context.Appointment.Find(AppoID);

                if (appointment != null)
                {
                    appointment.Status = "Canceled";
                    _context.SaveChanges();
                }

                return RedirectToAction(nameof(Index));
            }


        //==========================================================================================

        // Doctor Management
            [HttpGet]
            public IActionResult DoctorList()
            {
                var doctors = _context.Doctor.ToList();
                return View(doctors);
            }

            [HttpGet]
            public IActionResult AddDoctor()
            {
                
                return View();
            }

            [HttpPost]
            public IActionResult AddDoctor(Doctor doctor)
            {
                
                _context.Doctor.Add(doctor);
                _context.SaveChanges();

                return RedirectToAction(nameof(DoctorList));
            }

            [HttpGet]
            public IActionResult EditDoctor(int doctorId)
            {
                var doctor = _context.Doctor.Find(doctorId);
                return View(doctor);
            }

            [HttpPost]
            public IActionResult EditDoctor(Doctor doctor)
            {
                
                _context.Doctor.Update(doctor);
                _context.SaveChanges();

                return RedirectToAction(nameof(DoctorList));
            }

            [HttpPost]
            public IActionResult DeleteDoctor(int doctorId)
            {
                
                var doctor = _context.Doctor.Find(doctorId);
                if (doctor != null)
                {
                    _context.Doctor.Remove(doctor);
                    _context.SaveChanges();
                }

                return RedirectToAction(nameof(DoctorList));
            }


            //============================================================
            // Specialization Management
            [HttpGet]
            public IActionResult SpecializationList()
            {
                var specializations = _context.Specialization.ToList();
                return View(specializations);
            }

            [HttpGet]
            public IActionResult AddSpecialization()
            {
                
                return View();
            }

            [HttpPost]
            public IActionResult AddSpecialization(Specialization specialization)
            {
                
                _context.Specialization.Add(specialization);
                _context.SaveChanges();

                return RedirectToAction(nameof(SpecializationList));
            }

            [HttpGet]
            public IActionResult EditSpecialization(int specializationId)
            {
               
                var specialization = _context.Specialization.Find(specializationId);
                return View(specialization);
            }

            [HttpPost]
            public IActionResult EditSpecialization(Specialization specialization)
            {
                
                _context.Specialization.Update(specialization);
                _context.SaveChanges();

                return RedirectToAction(nameof(SpecializationList));
               
            }

            [HttpPost]
            public IActionResult DeleteSpecialization(int specializationId)
            {
               
                var specialization = _context.Specialization.Find(specializationId);
                if (specialization != null)
                {
                    _context.Specialization.Remove(specialization);
                    _context.SaveChanges();
                }

                return RedirectToAction(nameof(SpecializationList));
            }
     }
}