using MongoDB.Driver;
using WebApiCaso.Models;

namespace WebApiCaso.Services
{
    public class IniciativeService
    {
        private readonly ILogger<UserService> _logger;
        private readonly IMongoCollection<Iniciative> _iniciativesCollection;
        
        public IniciativeService(
            ILogger<UserService> logger,
            IMongoDatabase database)
        {
            _logger = logger;
            _iniciativesCollection = database.GetCollection<Iniciative>("Iniciatives");
        }
        public async Task<List<Iniciative>> GetAsync() =>
            await _iniciativesCollection.Find(_ => true).ToListAsync();
        
        public async Task<Iniciative?> GetAsync(string title) =>
        await _iniciativesCollection.Find(x => x.Title == title).FirstOrDefaultAsync();

        public async Task CreateAsync(Iniciative newIniciative) =>
           await _iniciativesCollection.InsertOneAsync(newIniciative);
        public async Task RemoveAsync(string title) =>
            await _iniciativesCollection.DeleteOneAsync(x => x.Title == title);
    }
    
}
