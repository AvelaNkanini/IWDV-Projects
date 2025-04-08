using Microsoft.EntityFrameworkCore;

namespace MedApp.Models
{
    public class PatientContext : DbContext
    {
        public PatientContext(DbContextOptions<PatientContext> options) : base(options) 
        {

        }

        public DbSet<Patients> Patients { get; set; }
    }
}
