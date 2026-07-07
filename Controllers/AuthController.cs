using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using WebApplication1.Data;
using WebApplication1.Dto;

namespace WebApplication1.Controllers
{
    public class AuthController(AppDbContext _context) : Controller
    {
     
        public IActionResult Login()
        {
            ViewBag.SuccessMessage = TempData["SuccessMessage"];
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public async Task<IActionResult> CreateUserAsync(UserDto dto)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);

            if (existingUser == null) {
               var user = new Models.User
               {
                   UserName = dto.UserName,
                   Email = dto.Email,
                   Password = dto.Password
               };
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
               

            }
            else
            {
                ViewBag.ErrorMessage = "user already exits"; // controller --> veiw
                return View("Register");
            }

            TempData["SuccessMessage"] = "User register successfully . Please log in."; // controller --> controller
            return RedirectToAction("Login");   

        }


        public async Task<IActionResult> LoginUser(UserDto dto)
        {
            var isUserExits = await _context.Users.FirstOrDefaultAsync(x => x.Email == dto.Email);
            if (isUserExits==null)
            {
                ViewBag.ErrorMessage = "User with email does not exit ";
                return View("Login");


            }
            else
            {
                if (isUserExits.Password == dto.Password)
                {

                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    ViewBag.ErrorMessage = "Incorrect Password";
                    return View("Login");
                }
            }
        }
    }
}
