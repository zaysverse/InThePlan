using calendar.Helper;
using calendar.Interfaces;
using MySql.Data.MySqlClient;
using System.Data;
using System.Diagnostics;

namespace calendar.Common
{
    public class MySqlManager : IDataBaseManager
    {
        private string connectionPath;
        public void Load()
        {
            connectionPath = DataBaseHelper.CreateDataBase().ToString();
        }
        private int Command(string query)
        {
            using (var connection = new MySqlConnection(connectionPath))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                if (command.ExecuteNonQuery() == 1)
                {
                    Debug.WriteLine("성공");

                    return 1;
                }
                else
                {
                    //Debug.WriteLine("실패");
                    return 0;
                }
            }
        }
        public int Insert(string query)
        {
            return Command(query);
        }


        public DataTable Select(string query)
        {
            DataTable table = new DataTable();
            using (var connection = new MySqlConnection(connectionPath))
            {
                connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);

                adapter.Fill(table);
            }
            return table;
        }

        public int Update(string query)
        {
            return Command(query);
        }

        public int Create(string query)
        {
            return Command(query);
        }

        public int Delete(string query)
        {
            return Command(query);
        }

        public void SaveImg(byte[] data)
        {       
            using (var connection = new MySqlConnection(connectionPath))
            {
                connection.Open();
                using (var cmd = new MySqlCommand("INSERT INTO img_tb SET img = @image", connection))
                {
                    cmd.Parameters.Add("@image", MySqlDbType.Blob).Value = data;
                    cmd.ExecuteNonQuery();
                }

            }
        }
    }
}
