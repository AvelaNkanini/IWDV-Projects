using MedApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly PatientContext patientContext;
        
        public PatientsController(PatientContext patientContext)
        {
            this.patientContext=patientContext;
        }

        [HttpGet]
        [Route("GetPatients")]
        public List<Patients> GetPatients()
        {
            return patientContext.Patients.ToList();
        }

        [HttpPost]
        [Route("AddPatient")]
        public string AddPatients(Patients patients)
        {
            string response=string.Empty;
            patientContext.Patients.Add(patients);
            patientContext.SaveChanges();
            return "Patient successfully added";
        }

        [HttpGet]
        [Route("GetPatient/{id}")]
        public Patients GetPatient(int id)
        {
            return patientContext.Patients.Where(x => x.id == id).FirstOrDefault();
        }

        [HttpPut]
        [Route("UpdatePatient/{id}")]
        public string UpdatePatients(Patients patients)
        {
            patientContext.Entry(patients).State= Microsoft.EntityFrameworkCore.EntityState.Modified;
            patientContext.SaveChanges();
            return "Patient successfully updated";
        }

        [HttpDelete]
        [Route("DeletePatient")]
        public string DeletePatients(int id)
        {
            Patients patients= patientContext.Patients.Where(x => x.id == id).FirstOrDefault();
            if (patients != null)
            {
                patientContext.Patients.Remove(patients);
                patientContext.SaveChanges();
                return "Patient successfully deleted.";
            }
            else
            {
                return "Patient not found.";

            }
        }
        
    }
}