using COMP2139_Assignment1.Data;
using COMP2139_Assignment2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace COMP2139_Assignment2.Controllers
{
    public class FlightCommentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FlightCommentsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetCommentsFlight(int FlightId)
        {

            var comments = await _context.FlightComments
                                .Where(c => c.FlightId == FlightId)
                                .OrderByDescending(c => c.DatePosted)
                                .ToListAsync();

            return Json(comments);
        }


        [HttpPost]
        public async Task<IActionResult> AddCommentFlight([FromBody] FlightComments comment)
        {

            if (ModelState.IsValid)
            {
                comment.DatePosted = DateTime.Now;
                _context.FlightComments.Add(comment);
                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Comment added successfully" });
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
            return Json(new { success = false, message = "Invalid comment data", error = errors });
        }
    }
}
