using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class LevelPointsRedrawScore : MonoBehaviour
    {
        /// <summary>
        /// Точки запуска уровней.
        /// </summary>
        [SerializeField] private LevelPoint[] _levelPoints;

        /// <summary> 
        /// Start запускается перед первым кадром.
        /// </summary>
        private void Start()
        {
            //обновить точки запуска уровней
            if(LevelSequenceController.Instance == null) return;

            int prevScore = 1;
            for (int i = 0; i < LevelSequenceController.Instance.TotalStatistics.Length; i++)
            {
                foreach (LevelPoint levelPoint in _levelPoints)
                {
                    if (levelPoint.Level == i)
                    {
                        if (prevScore > 0)
                        {
                            //если предыдущий уровень закончен не с нулевым результатом - вывыести точку доступа к текущему уровню на экран
                            levelPoint.DrawScore(LevelSequenceController.Instance.TotalStatistics[i]);
                        }
                        else
                        {
                            //если предыдущий уровень закончен с нулевым результатом - отключить точку доступа к уровню
                            levelPoint.gameObject.SetActive(false);
                        }

                        prevScore = LevelSequenceController.Instance.TotalStatistics[i];
                    }
                }
            }

            //сохранить прогресс прохождения на диск
            ProgressSaveLoad.Instance.SaveProgress();
        }
    }
}
