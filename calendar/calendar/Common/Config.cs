namespace calendar.Common
{
        // global한 영역에 DB접근을 위한 정보 저장 =>DataBaseHelper가 ToString()할때 사용됨
        public static class Config
        {
                public static readonly string ServerIP = "localhost";
                public static readonly string DataBase = "calendarDB";
                public static readonly string ID = "root";
                public static readonly string PW = "1234";
        }
}
