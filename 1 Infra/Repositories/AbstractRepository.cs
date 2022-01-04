using System.Threading.Tasks;

namespace FilmesAPI.Infra.Repositories
{
    public class AbstractRepository
    {
        protected AppDbContext context;

        public AbstractRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<int> Insert<T>(T value)
        {
            this.context.Add(value);
            return await this.context.SaveChangesAsync();
        }

        public async Task<int> Update<T>(T value)
        {
            this.context.Update(value);
            return await this.context.SaveChangesAsync();
        }

        public async Task<int> Delete<T>(T value)
        {
            this.context.Remove(value);
            return await this.context.SaveChangesAsync();
        }
    }
}
