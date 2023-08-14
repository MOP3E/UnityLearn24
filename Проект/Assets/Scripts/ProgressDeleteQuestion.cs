using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class ProgressDeleteQuestion : MonoBehaviour
    {
        /// <summary>
        /// Главное меню.
        /// </summary>
        [SerializeField] private GameObject _mainMenu;
        
        /// <summary>
        /// Удалить прогресс и начать новую игру.
        /// </summary>
        public void YesButton()
        {
            //обнулить прогресс по уровням и перейти на карту
            for (int i = 0; i < LevelSequenceController.Instance.TotalStatistics.Length; i++)
            {
                LevelSequenceController.Instance.TotalStatistics[i] = 0;
            }
            LevelSequenceController.Instance.ReturnToLevelsMap();
        }

        /// <summary>
        /// Не начинать новую игру.
        /// </summary>
        public void NoButton()
        {
            //ничего не делать и переключиться в главное меню
            gameObject.SetActive(false);
            _mainMenu.SetActive(true);
        }
    }
}
