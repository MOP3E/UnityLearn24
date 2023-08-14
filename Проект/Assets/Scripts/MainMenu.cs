using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense
{
    public class MainMenu : MonoBehaviour
    {
        /// <summary>
        /// Меню для запроса удаления прогресса.
        /// </summary>
        [SerializeField] private GameObject _progressDeleteQuestion;

        /// <summary>
        /// Кнопка продолжения игры.
        /// </summary>
        [SerializeField] private Button _continueButton;

        private void Start()
        {
            //загрузить прогресс из файла
            ProgressSaveLoad.Instance.LoadProgress();

            //переключить кнопку продолжения игры
            int score = 0;
            foreach (int i in LevelSequenceController.Instance.TotalStatistics) score += i;
            _continueButton.interactable = score > 0;
        }

        public void StartButton()
        {
            int score = 0;
            foreach (int i in LevelSequenceController.Instance.TotalStatistics)
            {
                score += i;
            }

            if (score != 0)
            {
                gameObject.SetActive(false);
                _progressDeleteQuestion.SetActive(true);
            }
            else
            {
                LevelSequenceController.Instance.ReturnToLevelsMap();
            }
        }

        /// <summary>
        /// Кнопка продолжения игры.
        /// </summary>
        public void ContinueButton()
        {
            LevelSequenceController.Instance.ReturnToLevelsMap();
        }

        /// <summary>
        /// Кнопка выхода из игры.
        /// </summary>
        public void ExitButton()
        {
            Application.Quit(0);
        }
    }
}
