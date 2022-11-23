using CustomMediatr.Api.Command.Queries;
using CustomMediatr.Library.Interfaces;

namespace CustomMediatr.Api.Command.Handlers
{
    public class UsernameUpdateCommandHandler : IRequestHandler<UsernameUpdateCommand, int>
    {
        public Task<int> Handle(UsernameUpdateCommand request)
        {
            // db de update oldu
            return Task.FromResult(1);
        }
    }

}
