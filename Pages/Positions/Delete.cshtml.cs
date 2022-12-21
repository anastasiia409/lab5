using lab5.DB;
using lab5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lab5.Pages.Positions
{
    public class DeleteModel : PageModel
    {
        private readonly ProjectContext _db;
        public Position? _position { get; set; }
        public DeleteModel(ProjectContext db)
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

        public async Task<IActionResult> OnPost(int? id)
        {
            var _positionFromDb = await _db.Positions.FindAsync(id);
            if (_positionFromDb == null)
            {
                return NotFound();
            }
            _db.Positions.Remove(_positionFromDb);
            await _db.SaveChangesAsync();
            TempData["success"] = "Position was deleted successfully";
            return RedirectToPage("Index");

        }
    }
}
