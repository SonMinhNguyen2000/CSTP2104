using MySql.Data.MySqlClient;

namespace Shared.Interfaces;

public interface IDataService
{
    public void Query(string query);
    public void Bind(string key, string value);
    public void ClearQuery();
    public MySqlDataReader Execute();
    public void RunTestScript(string fn);
    public void Close();
}