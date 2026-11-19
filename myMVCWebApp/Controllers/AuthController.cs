
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myMVCWebApp.Data;
using myMVCWebApp.Dto;
using myMVCWebApp.Models;

namespace myMVCWebApp.Controllers
{
    public class AuthController : Controller
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegisterUser(UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return View("Registration", userDto);
            }

            var user = new User
            {
                Username = userDto.Username,
                Email = userDto.Email,
                PasswordHash = ""
            };

            var passwordHasher = new PasswordHasher<User>();

            user.PasswordHash = passwordHasher.HashPassword(user, userDto.Password);

            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            return RedirectToAction("Login");
        }


    }
}