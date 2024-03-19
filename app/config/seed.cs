using Users.Model;
namespace Seed.Data{
    public static class SeedData
{
    public static List<User> Users => new List<User>
    {
        new User { Name = "Eduardo"},
        // Agrega más datos de User si es necesario
    };
}
}