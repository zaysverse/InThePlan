using calendar.Common;

namespace calendar.Helper
{
        public class DataBaseHelper
        {
                public static DataBaseHelper CreateDataBase()
                {
                        return new DataBaseHelper();
                }
                public override string ToString()
                {
                        return $"SERVER={Config.ServerIP};DATABASE={Config.DataBase};UID={Config.ID};PASSWORD={Config.PW}";
                }
        }
}
