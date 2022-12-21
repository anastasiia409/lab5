using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using lab5.Models;
using lab5.DB;

namespace lab5.Pages.Projects
{
    public class EditModel : PageModel
    {
        private readonly ProjectContext _db;
        public Project? _project { get; set; }
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
            _project = await _db.Projects.FindAsync(id);
            if (_project == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPost(Project _project)
        {
            if (ModelState.IsValid)
            {
                _db.Projects.Update(_project);
                await _db.SaveChangesAsync();
                TempData["success"] = "Project was updated successfully";
                return RedirectToPage("Index");

            }
            return Page();

        }
    }
}
