using CustomMediatr.Library.Interfaces;

namespace CustomMediatr.Api.Command.Queries
{
    public class UsernameUpdateCommand : IRequest<int>
    {
        public string Username { get; init; }

        public UsernameUpdateCommand(string username)
        {
            Username = username ?? throw new ArgumentNullException(nameof(username));
        }
    }

}
