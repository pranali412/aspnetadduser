namespace User.Domain.ViewModel
{
    public class AppointmentVm
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public string EMailId { get; set; }
        public string ContactNo { get; set; }
        public string Department { get; set; }
        public string AssignDoctor { get; set; }
        public DateTime AppointmentDate { get; set; }
        public DateTime AppointmentTime { get; set; }
    }
}
