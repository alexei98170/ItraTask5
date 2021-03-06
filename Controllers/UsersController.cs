using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using IdentityApp.Models;
using IdentityApp.ViewModels;
using System;

namespace CustomIdentityApp.Controllers
{
    public class UsersController : Controller
    {
        UserManager<ApplicationUser> _userManager;
        SignInManager<ApplicationUser> _signInManager;
        public UsersController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index() => View(_userManager.Users.ToList());



        [Authorize]
        public async Task<ActionResult> Delete(string id)
        {



            int identificator = 0;

            foreach (var user in _userManager.Users.ToList())
            {
                if (user.IsChecked == true)
                {
                    ApplicationUser ouruser = await _userManager.FindByNameAsync(User.Identity.Name);
                    if (ouruser == user)
                    {
                        IdentityResult result = await _userManager.DeleteAsync(user);
                        await _signInManager.SignOutAsync();
                        identificator = 1;
                    }
                    else
                    {
                        await _userManager.UpdateSecurityStampAsync(user);

                        IdentityResult result = await _userManager.DeleteAsync(user);
                    }
                }

            }
            if (identificator == 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [Authorize]

        public async Task<ActionResult> Block(string id)
        {



            int identificator = 0;

            foreach (var user in _userManager.Users.ToList())
            {
                if (user.IsChecked == true)
                {
                    ApplicationUser ouruser = await _userManager.FindByNameAsync(User.Identity.Name);
                    user.Status = "blocked";
                    user.IsBlocked = true;
                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        if (ouruser == user)
                        {
                            await _signInManager.SignOutAsync();
                        }
                        else
                        {
                            await _userManager.UpdateSecurityStampAsync(user);
                        }
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }

            }
            if (identificator == 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }


        [Authorize]

        public async Task<ActionResult> UnBlock(string id)
        {
            foreach (var user in _userManager.Users.ToList())
            {
                if (user.IsChecked == true)
                {
                    user.Status = "unblocked";
                    user.IsBlocked = false;
                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }

            }
            return RedirectToAction("Index");




        }
        [Authorize]
        public async Task<ActionResult> Select(string id)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(id);
            if (user.IsChecked)
                user.IsChecked = false;
            else
                user.IsChecked = true;

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return RedirectToAction("Index");
        }
        [Authorize]
        public async Task<ActionResult> SelectAll(int id)
        {
            foreach (var user in _userManager.Users.ToList())
            {
                if (id == 2)
                    user.IsChecked = false;
                else
<<<<<<< HEAD
                    user.IsChecked = true;
=======
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }

            }
            return RedirectToAction("Index");
        }
        [Authorize]
        public async Task<ActionResult> RemoveAll()
        {
            foreach (var user in _userManager.Users.ToList())
            {
                user.IsChecked = false;
>>>>>>> 8fd4a6dbe2df0f7f653b7e7465f0bf71ecc57590

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }

<<<<<<< HEAD
            }
            return RedirectToAction("Index");
        }
=======

            }
            return RedirectToAction("Index");
        }


>>>>>>> 8fd4a6dbe2df0f7f653b7e7465f0bf71ecc57590
    }
}  
