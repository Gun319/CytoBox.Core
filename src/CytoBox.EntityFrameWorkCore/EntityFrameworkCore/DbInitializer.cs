namespace CytoBox.EntityFrameWorkCore.EntityFrameworkCore
{
    public static class DbInitializer
    {
        public static async Task<string> Initialize(AppDbContext context)
        {
            try
            {

                await context.SaveChangesAsync();
                return "SaveChange Success";
            }
            catch (Exception ex)
            {
                return ex.ToString();
                throw;
            }
        }
    }
}
