using MongoDB.Driver;
using WebApiCaso.Models;

namespace WebApiCaso.Services
{
    public class UserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly IMongoCollection<User> _usersCollection;

        public UserService(
            ILogger<UserService> logger,
            IMongoDatabase database)
        {
            _logger = logger;
            _usersCollection = database.GetCollection<User>("Users");
        }
        public async Task<List<User>> GetAsync() =>
            await _usersCollection.Find(_ => true).ToListAsync();

        public async Task CreateAsync(User newUser) =>
            await _usersCollection.InsertOneAsync(newUser);



    }

}
