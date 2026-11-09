using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrainingTracker.Models;

namespace TrainingTracker.Pages.TrainingRecordPages;

public class EditModel : PageModel
{
    private readonly TrainingTrackerContext _context;

    public EditModel(TrainingTrackerContext context)
    {
        _context = context;
    }

    [BindProperty]
    public TrainingRecord TrainingRecord { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var trainingrecord = await _context.TrainingRecord.FirstOrDefaultAsync(m => m.Id == id);
        if (trainingrecord is null)
        {
            return NotFound();
        }
        TrainingRecord = trainingrecord;
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Attach(TrainingRecord).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TrainingRecordExists(TrainingRecord.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }

    private bool TrainingRecordExists(int id)
    {
        return _context.TrainingRecord.Any(e => e.Id == id);
    }
}
