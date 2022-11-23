using CustomMediatr.Api.Models;
using CustomMediatr.Api.Query.Queries;
using CustomMediatr.Library.Interfaces;

namespace CustomMediatr.Api.Query.Handlers
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserViewModel>
    {
        public Task<UserViewModel> Handle(GetUserByIdQuery request)
        {
            // get data from db  firs(x=>x.id == request.id)

            return Task.FromResult(new UserViewModel
            {
                Fullname = "Resad Dagli",
                Username = "admin"
            });
        }
    }
}
