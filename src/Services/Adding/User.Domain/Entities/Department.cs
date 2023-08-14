using User.Domain.Common;

namespace User.Domain.Entities
{
    public class Department : EntityBase
    {
        public int Id { get; set; }

        public string DepartmentName { get; set; }
    }
}
