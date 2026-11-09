using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrainingTracker.Models;

namespace TrainingTracker.Pages.TrainingRecordPages;

public class IndexModel : PageModel
{
    private readonly TrainingTrackerContext _context;

    public IndexModel(TrainingTrackerContext context)
    {
        _context = context;
    }

    public IList<TrainingRecord> TrainingRecord { get; set; } = default!;

    public async Task OnGetAsync()
    {
        TrainingRecord = await _context.TrainingRecord.ToListAsync();
    }
}
