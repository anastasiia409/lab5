using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using lab5.DB;
using lab5.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace lab5.Pages.EmployeeProjects
{
    public class CreateModel : PageModel
    {
        private readonly ProjectContext _db;
        public EmployeeProject _eprojects { get; set; } = null!;
        public SelectList _items { get; set; } = null!;
        public SelectList _items1 { get; set; } = null!;
        public SelectList _items2 { get; set; } = null!;


        public CreateModel(ProjectContext db)
        {
            _db = db;
        }

        public IActionResult OnGet()
        {
            _items = new SelectList(_db.Employees, "Id", "Name");
            _items1 = new SelectList(_db.Projects, "Id", "Name");
            _items2 = new SelectList(_db.Positions, "Id", "Name");

            return Page();
        }

        public async Task<IActionResult> OnPost(EmployeeProject _eproject)
        {

            if (_eproject.EmployeeId != 0 && _eproject.ProjectId != 0 && _eproject.PositionId != 0)
            {
                await _db.EmployeeProjects.AddAsync(_eproject);
                await _db.SaveChangesAsync();
                TempData["success"] = "Employee's project was created successfully";
                return RedirectToPage("Index");
            }
            _items = new SelectList(_db.Employees, "Id", "Name");
            _items1 = new SelectList(_db.Projects, "Id", "Name");
            _items2 = new SelectList(_db.Positions, "Id", "Name");
            
            return Page();

        }

    }
}
