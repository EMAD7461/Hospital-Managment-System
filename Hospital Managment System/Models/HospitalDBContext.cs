using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Managment_System.Models
{
    public class HospitalDBContext : IdentityDbContext<ApplicationUser>
    {
        public HospitalDBContext(DbContextOptions<HospitalDBContext> options): base(options) { }
       
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }    

        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Nurse> Nurses { get; set; }

        public DbSet<Role> Role { get; set; }

    }
}
