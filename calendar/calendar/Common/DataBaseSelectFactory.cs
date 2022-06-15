using calendar.Interfaces;
using calendar.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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

        public ObservableCollection<Plan> SelectPlan(string id)
        {
            ObservableCollection<Plan> planData = new ObservableCollection<Plan>();

            var dt = this._dataBaseManager.Select("SELECT *FROM " + $"{id}_tb");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                planData.Add(new Plan { 완료 = false, 날짜 = dr["day"].ToString(), What = dr["what"].ToString(), Tag = dr["tag"].ToString(), 장소 = dr["place"].ToString() });
            }
            return planData;
        }

        public ObservableCollection<BitmapImage> SelectImg()
        {
            ObservableCollection<BitmapImage> imgData = new ObservableCollection<BitmapImage>();

            var dt = this._dataBaseManager.Select("SELECT *FROM img_tb");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                byte[] bytes = dr["img"] as byte[];
                BitmapImage image = ConvertByteArrayToBitmapImage(bytes);

                imgData.Add(image);
            }
            return imgData;
        }

        public static BitmapImage ConvertByteArrayToBitmapImage(byte[] bytes)
        {
            var stream = new MemoryStream(bytes);
            stream.Seek(0, SeekOrigin.Begin);
            var image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = stream;
            image.EndInit();
            return image;
        }

        //조건 선택된 Plan , m으로 update
        public void UpdatePlan(string id, Plan p, ViewModels.MainViewModel m)
        {
            this._dataBaseManager.Update($"UPDATE " + $"{id}_tb" + " SET day='" + $"{m.FixDate.ToString("yyyy-MM-dd")}" + "',what='" + $"{m.FixWhat}" + "',tag='" + $"{m.FixTag}" + "',place='" + $"{m.FixPlace}"
                + "' WHERE day='" + $"{p.날짜}" + "' AND what='" + $"{p.What.ToString()}" + "' AND tag='" + $"{p.Tag}" + "' AND place='" + $"{p.장소}"+"'");
        }

    }
}
