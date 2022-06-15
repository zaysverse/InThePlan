using System.Data;

namespace calendar.Interfaces
{
    public interface IDataBaseManager
    {
        void Load();
        DataTable Select(string query);
        int Insert(string query);
        int Update(string query);
        int Create(string query);
        int Delete(string query);
        void SaveImg(byte[] data);
    }
}
