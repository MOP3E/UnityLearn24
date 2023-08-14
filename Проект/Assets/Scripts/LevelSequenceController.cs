using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TowerDefense
{
    public class LevelSequenceController : MonoSingleton<LevelSequenceController>
    {
        /// <summary>
        /// Имя сцены с главным меню.
        /// </summary>
        public static string MainMenuSceneName = "MainMenu";

        /// <summary>
        /// Имя сцены с главным меню.
        /// </summary>
        public static string LevelsMapSceneName = "LevelsMap";

        /// <summary>
        /// Текущий эпизод.
        /// </summary>
        [SerializeField] private Episode _currentEpisode;

        /// <summary>
        /// Текущий эпизод.
        /// </summary>
        public Episode CurrentEpisode => _currentEpisode;

        /// <summary>
        /// Номер текущего уровня.
        /// </summary>
        public int CurrentLevel { get; private set; }

        /// <summary>
        /// Результат прохождения последнего уровня.
        /// </summary>
        public bool LastLevelResult { get; private set; }

        /// <summary>
        /// Статистика пройденного уровня.
        /// </summary>
        public PlayerStatistics LevelStatistics { get; private set; }

        /// <summary>
        /// Имя игрока.
        /// </summary>
        public string PlayerName { get; set; } = "Пилот";

        /// <summary>
        /// Статистика эпизода.
        /// </summary>
        public int[] TotalStatistics { get; private set; }
        
        //public List<PlayerStatistics> Records { get; private set; }

        /// <summary>
        /// Космический корабль игрока.
        /// </summary>
        public static Walker PlayerWalker { get; set; }

        /// <summary>
        /// Пауза в игре.
        /// </summary>
        public bool Pause { get; set; }
        
        protected override void Awake()
        {
            base.Awake();
            TotalStatistics = new int[CurrentEpisode.Levles.Length];
            //Records = new List<PlayerStatistics>();
        }

        //public void EpisodeStart(Episode e)
        //{
        //    CurrentEpisode = e;
        //    CurrentLevel = 0;

        //    //обнулить игровую статистику перед началом эпизода
        //    LevelStatistics = new PlayerStatistics();
        //    TotalStatistics = new PlayerStatistics { PlayerName = this.PlayerName };

        //    SceneManager.LoadScene(e.Levles[CurrentLevel]);
        //}

        public void LevelStart(int level)
        {
            CurrentLevel = level;
            LevelStatistics ??= new PlayerStatistics();
            LevelStatistics.Reset();
            SceneManager.LoadScene(CurrentEpisode.Levles[CurrentLevel]);
        }

        public void LevelRestart()
        {
            LevelStatistics.Reset();
            SceneManager.LoadScene(CurrentEpisode.Levles[CurrentLevel]);
        }

        public void ReturnToLevelsMap()
        {
            SceneManager.LoadScene(LevelsMapSceneName);
        }

        public void ReturnToMainMenu()
        {
            SceneManager.LoadScene(MainMenuSceneName);
        }

        public void FinishCurrentLevel(bool success)
        {
            LastLevelResult = success;


            CalculateStatistics(success);
            if (success && TotalStatistics[CurrentLevel] < LevelStatistics.Score) TotalStatistics[CurrentLevel] = LevelStatistics.Score;

            ResultPanelController.Instance.ShowLevelStatistics(LevelStatistics, success);
        }

        //public void LevelAdvance()
        //{
        //    LevelStatistics.Reset();
        //    CurrentLevel++;
        //    if(CurrentLevel < CurrentEpisode.Levles.Length)
        //        SceneManager.LoadScene(CurrentEpisode.Levles[CurrentLevel]);
        //    else
        //    {
        //        if (RecordTest())
        //        {
        //            while (Records.Count > 2)
        //            {
        //                Records.RemoveAt(Records.Count - 1);
        //            }
        //            Records.Add(TotalStatistics);
        //            Records.Sort();
        //        }
        //        SceneManager.LoadScene(MainMenuSceneName);
        //    }
        //}

        ///// <summary>
        ///// Проверить, не является ли результат прохождения эпизода рекордом.
        ///// </summary>
        //private bool RecordTest()
        //{
        //    //если рекордов меньше трёх, рекорд есть всегда
        //    if (Records.Count < 3) return true;

        //    //проверить, не является ли результат прохождения эпизода рекордом
        //    bool isRecord = false;
        //    foreach (PlayerStatistics statistics in Records)
        //    {
        //        if (TotalStatistics.CompareTo(statistics) > 0)
        //        {
        //            isRecord = true;
        //            break;
        //        }
        //    }

        //    return isRecord;
        //}

        /// <summary>
        /// Подсчёт статитстики.
        /// </summary>
        private void CalculateStatistics(bool success)
        {
            if (success)
            {
                LevelStatistics.Alive = 1;
                LevelStatistics.FullHealth = TdPlayer.Instance.FullHealth ? 1 : 0;
                //TODO: доделать когда будет сделана кнопка ускорения
                LevelStatistics.Speedup = 0;
            }
            else
            {
                LevelStatistics.Alive = 0;
                LevelStatistics.FullHealth = 0;
                //TODO: доделать когда будет сделана кнопка ускорения
                LevelStatistics.Speedup = 0;
            }
        }
    }
}
