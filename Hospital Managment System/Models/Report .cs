namespace Hospital_Managment_System.Models
{
    public class Report
    {
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public string Details { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
