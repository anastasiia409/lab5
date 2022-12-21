using lab5.DB;
using lab5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lab5.Pages.Employees
{
    public class DeleteModel : PageModel
    {
        
        private readonly ProjectContext _db;
        public Employee _employee { get; set; }
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

            _employee = await _db.Employees.FindAsync(id);
            if (_employee == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPost(int? id)
        {
            var _employeeFromDb = await _db.Employees.FindAsync(id);
            if (_employeeFromDb == null)
            {
                return NotFound();
            }
            _db.Employees.Remove(_employeeFromDb);
            await _db.SaveChangesAsync();
            TempData["success"] = "Employee was deleted successfully";
            return RedirectToPage("Index");

        }
    }
}
