using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using lab5.DB;
using lab5.Models;

namespace lab5.Pages.Projects
{
    public class DeleteModel : PageModel
    {
        private readonly ProjectContext _db;
        public Project? _project { get; set; }
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

            _project = await _db.Projects.FindAsync(id);
            if (_project == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPost(int? id)
        {
            var _projectFromDb = await _db.Projects.FindAsync(id);
            if (_projectFromDb == null)
            {
                return NotFound();
            }
            _db.Projects.Remove(_projectFromDb);
            await _db.SaveChangesAsync();
            TempData["success"] = "Project was deleted successfully";
            return RedirectToPage("Index");

        }
    }
}
