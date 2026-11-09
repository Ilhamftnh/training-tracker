using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrainingTracker.Models;

namespace TrainingTracker.Pages.TrainingRecordPages;

public class CreateModel : PageModel
{
    private readonly TrainingTrackerContext _context;

    public CreateModel(TrainingTrackerContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public TrainingRecord TrainingRecord { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.TrainingRecord.Add(TrainingRecord);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
