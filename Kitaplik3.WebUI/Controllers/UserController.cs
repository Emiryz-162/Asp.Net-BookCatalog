using Kitaplik3.Business.Concrete;
using Kitaplik3.Entities.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Kitaplik3.Business.Validators;
using AutoMapper;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Kitaplik3.DTOs.UserDTOs;

namespace Kitaplik3.WebUI.Controllers
{
    public class UserController : Controller
    {
        UserManager _userManager = new();
        private readonly UserValidator _validator = new UserValidator();
        private readonly UserRegisterDtoValidator _registerValidator;
        private readonly IMapper _mapper;

        public UserController(IMapper mapper)
        {
            _userManager = new UserManager();
            _registerValidator = new UserRegisterDtoValidator();
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Register()
        {
            // Eğer kullanıcı zaten giriş yapmışsa, ana sayfaya yönlendir
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Kitaplar", "Kitap");
            }

            return View(new UserRegisterDto());
        }

        [HttpPost]
        public IActionResult Register(UserRegisterDto dto)
        {
            // Eğer kullanıcı zaten giriş yapmışsa, ana sayfaya yönlendir
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Kitaplar", "Kitap");
            }

            ValidationResult result = _registerValidator.Validate(dto);
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(dto);
            }

            // DTO'yu Entity'ye çevir
            var user = _mapper.Map<User>(dto);
            _userManager.Add(user);
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            // Eğer kullanıcı zaten giriş yapmışsa, ana sayfaya yönlendir
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Kitaplar", "Kitap");
            }

            return View(new UserLoginDto());
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto dto)
        {
            // Eğer kullanıcı zaten giriş yapmışsa, ana sayfaya yönlendir
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Kitaplar", "Kitap");
            }

            List<User> users = _userManager.GetAll();
            var user = users.FirstOrDefault(x => x.Email == dto.Email && x.Password == dto.Password);

            if (user != null)
            {
                // ✨ Cookie oluştur
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Name, user.Name + " " + user.Surname),
                    new Claim(ClaimTypes.Role, user.Role) // "User" rolü
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    claimsPrincipal
                );

                return RedirectToAction("Kitaplar", "Kitap");
            }

            ViewBag.ErrorMessage = "Email veya şifre hatalı!";
            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}