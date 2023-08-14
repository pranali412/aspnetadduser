using User.Domain.Common;

namespace User.Domain.Entities
{
    public class Role : EntityBase
    {
        public int Id { get; set; }
        public string RoleName { get; set; }


    }
}
