using MediatR;

namespace User.Application.Features.Users.Queries.GetDrDropdownlist
{
    public class GetDrDropdownlistQuerry : IRequest<ResponseModel>
    {
        public int Page { get; set; }
        public bool GetAll { get; set; }
        public int PageSize { get; set; }
    }
}
