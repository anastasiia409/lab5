using lab5.DB;
using lab5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lab5.Pages.Employees
{
    public class EditModel : PageModel
    {
        private readonly ProjectContext _db;
        public Employee? _employee { get; set; }
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
            _employee = await _db.Employees.FindAsync(id);
            if (_employee == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPost(Employee _employee)
        {
            if (ModelState.IsValid)
            {
                _db.Employees.Update(_employee);
                await _db.SaveChangesAsync();
                TempData["success"] = "Book was updated successfully";
                return RedirectToPage("Index");

            }
            return Page();

        }
    }
}
