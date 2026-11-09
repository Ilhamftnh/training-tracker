using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrainingTracker.Models;

namespace TrainingTracker.Pages.TrainingRecordPages;

public class DeleteModel : PageModel
{
    private readonly TrainingTrackerContext _context;

    public DeleteModel(TrainingTrackerContext context)
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
        else
        {
            TrainingRecord = trainingrecord;
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var trainingrecord = await _context.TrainingRecord.FindAsync(id);
        if (trainingrecord != null)
        {
            TrainingRecord = trainingrecord;
            _context.TrainingRecord.Remove(TrainingRecord);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
