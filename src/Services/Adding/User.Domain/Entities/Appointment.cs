using System.ComponentModel;
using User.Domain.Common;

namespace User.Domain.Entities
{
    public class Appointment : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public string EMailId { get; set; }
        public string ContactNo { get; set; }
        public int DepartmentId { get; set; }
        public int AssignDoctor { get; set; }
        public string AppointmentDate { get; set; }
        public string AppointmentTime { get; set; }
    }
    public enum Gender
    {
        [Description("Male")]
        Male = 1,
        [Description("Female")]
        Female = 2,
        [Description("Other")]
        Other = 3,
    }

}

