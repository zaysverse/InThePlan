using System.Data;

namespace calendar.Interfaces
{
        public interface IDataBaseManager
        {
                void Load();
                DataTable Select(string query);
                int Insert(string query);
                int Update(string query);
        }
}
