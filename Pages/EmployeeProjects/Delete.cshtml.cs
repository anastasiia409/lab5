using lab5.DB;
using lab5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lab5.Pages.EmployeeProjects
{
    public class DeleteModel : PageModel
    {
        private readonly ProjectContext _db;
        public EmployeeProject? _eproject { get; set; }
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
            _eproject = await _db.EmployeeProjects.FindAsync(id);
            if (_eproject == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPost(int? id)
        {
            var _eprojectFromDb = await _db.EmployeeProjects.FindAsync(id);
            if (_eprojectFromDb == null)
            {
                return Page();
            }
            _db.EmployeeProjects.Remove(_eprojectFromDb);
            await _db.SaveChangesAsync();
            TempData["success"] = "Information about employee's project was deleted successfully";
            return RedirectToPage("Index");

        }
    }
}
