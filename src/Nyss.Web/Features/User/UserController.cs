namespace Nyss.Web.Features.User
{
    public class UserController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        //Todo: Make action that returns list of users
    }
}
