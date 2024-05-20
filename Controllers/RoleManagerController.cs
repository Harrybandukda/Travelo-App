using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace COMP2139_Assignment1.Controllers
{
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class RoleManagerController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;


        public RoleManagerController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return View(roles);
        }

        [HttpGet]
        public async Task<IActionResult> Dashboard()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> AddRoles(string roleName)
        {
            if (!String.IsNullOrWhiteSpace(roleName))
            {
                IdentityRole newRole = new IdentityRole(roleName.Trim());
                var result = await _roleManager.CreateAsync(newRole);
                if (result.Succeeded)
                {
                    // Return the details of the new role in JSON format
                    return Json(new { id = newRole.Id, name = newRole.Name });
                }
            }
            // Handle failure case: return an error message in JSON format
            return Json(new { error = "Role creation failed. Please try again." });
        }

    }
}