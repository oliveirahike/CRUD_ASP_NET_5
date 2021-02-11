using CRUD_ASP_NET_5_Data.Factories;
using CRUD_ASP_NET_5_Data.Interfaces;
using CRUD_ASP_NET_5_Shared.Models;
using CRUD_ASP_NET_5_Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CRUD_ASP_NET_5_Web.Controllers
{
    public class HomeController : Controller
    {
        #region Interfaces
        private readonly IDbUsers DbUsers;
        #endregion

        #region Constructors

        public HomeController(Configurations configurations)
        {
            DbUsers = FactoryDbUsers.GetDbUsers(configurations);
        }

        #endregion

        #region Home Page
        public IActionResult Index()
        {
            return View(ProcessHomePage());
        }

        private UsersViewModel ProcessHomePage()
        {
            return new UsersViewModel()
            {
                Users = DbUsers.GetUsers()
            };
        }

        #endregion

        #region Save
        public IActionResult Save(UsersViewModel model)
        {
            if (DbUsers.SaveUser(model.User))
            {
                return Redirect("Index");
            }
            else
            {
                return Redirect("Error");
            }
        }
        #endregion

        #region Error 

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #endregion
    }
}
