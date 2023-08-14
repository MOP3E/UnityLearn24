using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense
{
    public class LevelPoint : MonoBehaviour
    {
        /// <summary>
        /// Номер уровня.
        /// </summary>
        [SerializeField] private int _level;

        /// <summary>
        /// Номер уровня.
        /// </summary>
        public int Level => _level;

        /// <summary>
        /// Текст для вывода очков уровня.
        /// </summary>
        [SerializeField] private Text _scoreText;

        public void LevelStart()
        {
            if(_level < LevelSequenceController.Instance.CurrentEpisode.Levles.Length)
                LevelSequenceController.Instance.LevelStart(_level);
        }

        public void DrawScore(int score)
        {
            _scoreText.text = $"{score}/3";
        }
    }
}
