namespace Service.Repositories
{
    public class BaseRepository
    {
        public DataContext Context { get; private set; }

        public BaseRepository(DataContext Context)
        {
            this.Context = Context;
        }
    }
}
