using lab5.DB;
using lab5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lab5.Pages.Employees
{
    public class CreateModel : PageModel
    {
        private readonly ProjectContext _db;
        public Employee _employee { get; set; } = null!;
        public CreateModel(ProjectContext db)
        {
            _db = db;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPost(Employee _employee)
        {
            if (ModelState.IsValid)
            {
                await _db.Employees.AddAsync(_employee);
                await _db.SaveChangesAsync();
                TempData["success"] = "Employee was added successfully";
                return RedirectToPage("Index");

            }
            return Page();
        }
    }
}
