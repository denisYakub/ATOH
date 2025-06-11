namespace ATOH.Interfaces
{
    public interface IRepository<T>
    {
        T Get(string login, string password);
        Guid GetToken(Guid id);
        T Get(Guid token);
        T Get(string login);
        bool IsLoginUnique(string login);
        void Update(T user);
        void Create(T user);
        void CreateToken(Guid id);
        void DeleteToken(Guid id);
        void Delete(T user);
        bool IsAdminToken(Guid token);
        IEnumerable<T> GetAllActive(); 
        IEnumerable<T> GetAllOlder(DateTime date);
        void SaveChanges();
    }
}
