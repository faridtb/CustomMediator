using CustomMediatr.Api.Models;
using CustomMediatr.Library.Interfaces;

namespace CustomMediatr.Api.Query.Queries
{
    public class GetUserByIdQuery : IRequest<UserViewModel>
    {
        public int Id { get; init; }

        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }
}
