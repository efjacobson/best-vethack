using best_vethack3.Models;
using best_vethack3.Models.Domain;
using best_vethack3.Models.Request;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace best_vethack3.Services
{
    public class UserService
    {
        private readonly ApplicationUserManager _applicationUserManager;
        private readonly IAuthenticationManager _authenticationManager;

        private static ApplicationUserManager GetUserManager()
        {
            return HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
        }

        public async Task<bool> SignIn(LoginRequest model)
        {
            ApplicationUser user = await _applicationUserManager.FindAsync(model.EmailAddress, model.Password);
            if (user == null)
            {
                return false;
            }
            await SignInAsync(user, model.IsPersistent);
            return true;
        }

        private async Task SignInAsync(ApplicationUser applicationUser, bool isPersistent)
        {
            _authenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            ClaimsIdentity claimsIdentity = await _applicationUserManager.CreateIdentityAsync(applicationUser, DefaultAuthenticationTypes.ApplicationCookie);
            _authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, claimsIdentity);
        }
    }
}