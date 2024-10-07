using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Validacion_WEB.Datos;

namespace Validacion_WEB.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        //debemos utilizar los objetos de Identity que configuramos en program.
        public AccountController(UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        // para que cualquier usuario este autenticado o no
        // pueda invocar esta acción. colocamos
        // para eso agregamos el using correspondiente
        // Microsoft.AspNetCore.Authorization;
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegistroViewModel modelo)
        {
            if (!ModelState.IsValid)
            {
                return View(modelo);
            }
            var usuario = new IdentityUser()
            {
                Email = modelo.Email,
                UserName = modelo.Email
            };
            var resultado = await userManager.CreateAsync(usuario, password:
            modelo.Password);
            if (resultado.Succeeded)
            {
                await signInManager.SignInAsync(usuario, isPersistent: true);
                return RedirectToAction("Admin", "Admin");
            }
            else
            {
                foreach (var error in resultado.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(modelo);
            }


        }


        // agregamos para login
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel modelo)
        {
            if (!ModelState.IsValid)
            {
                return View(modelo);
            }
            //lockouOnfailure si el usuario se equivoca varias veces
            // colocando el password podemos cerrar la cuenta
            var resultado = await signInManager.PasswordSignInAsync(modelo.Email,
            modelo.Password, modelo.Recuerdame, lockoutOnFailure: false);

            if (resultado.Succeeded)
            {
                return RedirectToAction("Admin", "Admin");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Nombre o Passwork incorrectos");
                return View(modelo);
            }
        }
    }
}

