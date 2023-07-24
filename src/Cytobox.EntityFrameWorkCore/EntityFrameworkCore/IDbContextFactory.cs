namespace Cytobox.EntityFrameWorkCore.EntityFrameworkCore
{
    public interface IDbContextFactory
    {
        AppDbContext WriteContext();

        AppDbContext ReadContext();
    }
}
