using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense
{
    public class ResultPanelController : MonoSingleton<ResultPanelController>
    {
        /// <summary>
        /// Поле заголовка окна результатов.
        /// </summary>
        [SerializeField] private Text _caption;

        /// <summary>
        /// Окно с сообщением об успешном прохождении.
        /// </summary>
        [SerializeField] private GameObject _success;

        /// <summary>
        /// Окно с сообщением о поражении.
        /// </summary>
        [SerializeField] private GameObject _fail;

        /// <summary>
        /// Start запускается перед первым кадром.
        /// </summary>
        private void Start()
        {
            //запустить игровую активность
            LevelSequenceController.Instance.Pause = false;
            //отключить окно статистики
            gameObject.SetActive(false);
        }

        public void ShowLevelStatistics(PlayerStatistics statistics, bool success)
        {
            //остановить игровую активность
            LevelSequenceController.Instance.Pause = true;
            
            //переключение окна
            _success.SetActive(success);
            _fail.SetActive(!success);

            //настройка текста в окне
            _caption.text = success ? $"Уровень пройден на {statistics.Score}/3" : "Поражение";

            //отобразить окно статистики
            gameObject.SetActive(true);
        }

        /// <summary>
        /// Нажатие на кнопку окна результатов.
        /// </summary>
        public void OnButonPressed()
        {
            //отключить окно статистики
            gameObject.SetActive(false);

            //запустить игровую активность
            LevelSequenceController.Instance.Pause = false;

            //вне зависимости от того, успешно или нет - вернуться в главное меню
            LevelSequenceController.Instance.ReturnToLevelsMap();
        }
    }
}
