using ExtractionStore.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExtractionStore.Startup))]
namespace ExtractionStore
{
    public partial class Startup
    {
        //allow for user roles
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }


        //create default user roles and Admin user for login   
        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            //creating first Admin role and creating a default Admin user    
            if (!roleManager.RoleExists("Admin"))
            {

                //create Admin role   
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                //create an Admin super user who will maintain the website                  
                var user = new ApplicationUser();
                user.UserName = "bpsheeri@go.olemiss.edu";
                user.Email = "bpsheeri@go.olemiss.edu";

                string userPWD = "Rebels_17";

                var chkUser = UserManager.Create(user, userPWD);

                //add default user to Admin role   
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");

                }
            }
        }
    }
}