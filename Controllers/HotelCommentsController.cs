using COMP2139_Assignment1.Data;
using COMP2139_Assignment2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace COMP2139_Assignment2.Controllers
{
    public class HotelCommentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HotelCommentsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetCommentsHotel(int HotelsId)
        {

            var comments = await _context.HotelComments
                                .Where(c => c.HotelsId == HotelsId)
                                .OrderByDescending(c => c.DatePosted)
                                .ToListAsync();

            return Json(comments);
        }


        [HttpPost]
        public async Task<IActionResult> AddCommentHotel([FromBody] HotelComments comment)
        {

            if (ModelState.IsValid)
            {
                comment.DatePosted = DateTime.Now;
                _context.HotelComments.Add(comment);
                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Comment added successfully" });
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
            return Json(new { success = false, message = "Invalid comment data", error = errors });
        }

    }
}
