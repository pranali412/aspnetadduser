using User.Domain.Common;

namespace User.Domain.Entities
{
    public class Userr : EntityBase
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string EmailAddress { get; set; }
        public string EmergencyContactName { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public string MobilePhoneNumber { get; set; }
        public string EmergencyContactNumber { get; set; }
        public string OfficePhoneNumber { get; set; }
        public string Ext { get; set; }
        public string DirectPhoneNumber { get; set; }
        public int PurchaseBogie { get; set; }
        public int SalesBogie { get; set; }
        public string RoleId { get; set; }




    }

}
