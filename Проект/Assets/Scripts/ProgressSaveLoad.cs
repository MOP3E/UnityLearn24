using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace TowerDefense
{
    public class ProgressSaveLoad : MonoSingleton<ProgressSaveLoad>
    {
        /// <summary>
        /// Папка для хранения файла прогресса.
        /// </summary>
        private string Folder => System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Tower Defense");

        /// <summary>
        /// Имя файла прогресса.
        /// </summary>
        private const string FILE = "progress.xml";

        /// <summary>
        /// Сохранить прогресс прохождения игры.
        /// </summary>
        public void SaveProgress()
        {
            //сформировать сохраняемые данные
            Progress progress = new Progress();
            for (int i = 0; i < LevelSequenceController.Instance.TotalStatistics.Length; i++)
            {
                progress.SaveDatas.Add(new SaveData { Level = i, Score = LevelSequenceController.Instance.TotalStatistics[i] });
            }
            //сохранить на диск
            Debug.Log($"progress.SaveDatas.Count = {progress.SaveDatas.Count}");
            Progress.Save(progress, Folder, FILE);
        }

        /// <summary>
        /// Загрузить прогресс прохождения игры.
        /// </summary>
        public void LoadProgress()
        {
            //прочитать с диска сохранённые данные
            Progress progress = Progress.Load(Folder, FILE);

            //записать в контроллер эпизода
            for (int i = 0; i < LevelSequenceController.Instance.TotalStatistics.Length; i++)
            {
                foreach (SaveData saveData in progress.SaveDatas)
                {
                    if (saveData.Level == i)
                    {
                        LevelSequenceController.Instance.TotalStatistics[i] = saveData.Score;
                    }
                }
            }
        }
    }
}
