using calendar.Interfaces;
using System.Collections.Generic;
using System.Data;

namespace calendar.Common
{
        public class DataBaseSelectFactory<T> where T : class, new()
        {
                private IDataBaseManager _dataBaseManager;
                public DataBaseSelectFactory(IDataBaseManager dataBaseManager)
                {
                        this._dataBaseManager = dataBaseManager;
                }
                public List<T> Select(string Query) 
                {
                        var dt = this._dataBaseManager.Select(Query);

                        return AutoMapper.Mapper.DynamicMap<IDataReader, List<T>>(dt.CreateDataReader());
                }
        }
}
