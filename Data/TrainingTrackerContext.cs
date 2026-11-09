using Microsoft.EntityFrameworkCore;

public class TrainingTrackerContext(DbContextOptions<TrainingTrackerContext> options) : DbContext(options)
{
    public DbSet<TrainingTracker.Models.TrainingRecord> TrainingRecord { get; set; } = default!;
}
