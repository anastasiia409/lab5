using lab5.DB;
using lab5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lab5.Pages.Positions
{
    public class CreateModel : PageModel
    {
        private readonly ProjectContext _db;
        public Position _position { get; set; } = null!;
        public CreateModel(ProjectContext db)
        {
            _db = db;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPost(Position _position)
        {
            if (ModelState.IsValid)
            {
                await _db.Positions.AddAsync(_position);
                await _db.SaveChangesAsync();
                TempData["success"] = "Position was added successfully";
                return RedirectToPage("Index");

            }
            return Page();
        }
    }
}
