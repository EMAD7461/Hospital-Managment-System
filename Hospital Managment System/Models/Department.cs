namespace Hospital_Managment_System.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        List<Doctor> Doctors { get; set; }
    }
}
