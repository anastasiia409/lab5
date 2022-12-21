using lab5.DB;
using lab5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lab5.Pages.Positions
{
    public class EditModel : PageModel
    {
        private readonly ProjectContext _db;
        public Position? _position { get; set; }
        public EditModel(ProjectContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }
            _position = await _db.Positions.FindAsync(id);
            if (_position == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPost(Position _position)
        {
            if (ModelState.IsValid)
            {
                _db.Positions.Update(_position);
                await _db.SaveChangesAsync();
                TempData["success"] = "Position was updated successfully";
                return RedirectToPage("Index");

            }
            return Page();

        }
    }
}
