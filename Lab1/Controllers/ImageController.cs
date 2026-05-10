using Lab1.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Lab1.Controllers
{
    public class ImageController(UserManager<ApplicationUser> um,
        IWebHostEnvironment env) : Controller
    {
        public async Task<IActionResult> GetAvatar()
        {
            var user = await um.FindByNameAsync(User.Identity.Name);
            if (user.Avatar != null)
            {
                return File(user.Avatar, "image/*");
            }

            var root = env.WebRootPath;
            var path = Path.Combine(root, "Images", "user2.png");
            return File(path, "image.png"); //у преподавателя в примере image/png и все равно работает"
        }
    }
}
