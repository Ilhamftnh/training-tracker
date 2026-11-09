using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrainingTracker.Models;

namespace TrainingTracker.Pages.TrainingRecordPages;

public class DetailsModel : PageModel
{
    private readonly TrainingTrackerContext _context;
    public DetailsModel(TrainingTrackerContext context)
    {
        _context = context;
    }

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
}
