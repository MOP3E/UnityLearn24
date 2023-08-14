using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class MapUi : MonoBehaviour
    {
        /// <summary>
        /// Нажатие на кнопку возвращения в главное меню.
        /// </summary>
        public void ReturnToMainMenuButton()
        {
            if(LevelSequenceController.Instance == null) return;
            LevelSequenceController.Instance.ReturnToMainMenu();
        }
    }
}
