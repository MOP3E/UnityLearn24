using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

namespace TowerDefense
{
    [Serializable]
    public class Progress
    {
        public List<SaveData> SaveDatas { get; set; }

        public Progress()
        {
            SaveDatas = new List<SaveData>();
        }

        /// <summary>
        /// Чтение прогресса игры из файла.
        /// </summary>
        /// <param name="folder">Папка прогресса игры.</param>
        /// <param name="filename">Имя файла прогресса игры.</param>
        public static Progress Load(string folder, string filename)
        {
            string fullname = Path.Combine(folder, filename);
            //сериализуемые настройки
            Progress progress;
            //XML-сериализатор
            XmlSerializer serializer = new XmlSerializer(typeof(Progress), new[] { typeof(SaveData) });

            //проверить, существует ли файл прогресса игры
            if (File.Exists(fullname))
            {
                try
                {
                    //попытаться десериализовать прогресс игры из файла
                    using (Stream fstream = new FileStream(fullname, FileMode.Open, FileAccess.Read))
                    {
                        progress = (Progress)serializer.Deserialize(fstream);
                    }
                }
                catch (Exception)
                {
                    //прогресс игры десериализовать не получилось - создать файл с пустым прогрессом игры
                    progress = new Progress();
                    Save(progress, folder, filename);
                }
            }
            else
            {
                //прогресс игры не существуеут - создать файл с пустым прогрессом игры
                progress = new Progress();
                Save(progress, folder, filename);
            }

            return progress;
        }

        /// <summary>
        /// Сохранение прогресса игры в файл.
        /// </summary>
        /// <param name="progress">Прогресс игры, который нужно сохранить.</param>
        /// <param name="folder">Папка прогресса игры.</param>
        /// <param name="filename">Имя файла прогресса игры.</param>
        public static void Save(Progress progress, string folder, string filename)
        {
            //если файл прогресса игры существует - удалить его
            string fullname = Path.Combine(folder, filename);
            if (File.Exists(fullname)) File.Delete(fullname);
            //создать папку с настройками
            Directory.CreateDirectory(folder);
            //сериализовать прогресс игры в файл
            XmlSerializer serializer = new XmlSerializer(typeof(Progress), new[] {typeof(SaveData)});
            using (Stream fstream = new FileStream(fullname, FileMode.Create, FileAccess.Write))
            {
                serializer.Serialize(fstream, progress);
            }
        }
    }
}
