using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodingChallenge1.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;

namespace CodingChallenge1.IOC
{
    public class DependencyLoader
    {
        public static void LoadModules()
        {
            var container = ChallengeContainer.getChallengeContainer();
            LoadDependency(container);
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        private static void LoadDependency(Container container)
        {
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            container.Register<ApplicationDbContext, ApplicationDbContext>(Lifestyle.Scoped);
            container.Register<IUserStore<ApplicationUser>>(() => new UserStore<ApplicationUser>());
            container.Register<IAuthenticationManager>(() => HttpContext.Current.GetOwinContext().Authentication);

        }
    }
}