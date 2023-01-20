namespace TmaLib
{
    public class RepositoryBase
    {

        public async Task SaveChanges()
        {
            await _taskContext.SaveChangesAsync();
        }
    }
}