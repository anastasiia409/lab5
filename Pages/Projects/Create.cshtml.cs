using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using lab5.Models;
using lab5.DB;

namespace lab5.Pages.Projects
{
    public class CreateModel : PageModel
    {
        private readonly ProjectContext _db;
        public Project _project { get; set; } = null!;
        public CreateModel(ProjectContext db)
        {
            _db = db;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPost(Project _project)
        {
            if (ModelState.IsValid)
            {
                await _db.Projects.AddAsync(_project);
                await _db.SaveChangesAsync();
                TempData["success"] = "Project was added successfully";
                return RedirectToPage("Index");

            }
            return Page();
        }
    }
}
