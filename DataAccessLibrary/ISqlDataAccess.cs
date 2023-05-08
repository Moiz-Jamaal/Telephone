namespace DataAccessLibrary
{
    public interface ISqlDataAccess
    {
        string ConnectionStringName { get; set; }

        Task<List<T>> LoadData<T, U>(string Sql, U parameters);
        Task<string> SaveData<T>(string Sql, T parameters);
    }
}