using BubbleNewsSite.Models;
using Microsoft.AspNetCore.Identity;


namespace BubbleNewsSite.Util
{

    public class GetUserIdHelper
    {
        private readonly UserManager<User> _userManager;

        public GetUserIdHelper(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public void GetUserId()
        {
            
        }
    }
}
