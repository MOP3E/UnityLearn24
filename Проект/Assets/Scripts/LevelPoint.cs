using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense
{
    public class LevelPoint : MonoBehaviour
    {
        /// <summary>
        /// ����� ������.
        /// </summary>
        [SerializeField] private int _level;

        /// <summary>
        /// ����� ������.
        /// </summary>
        public int Level => _level;

        /// <summary>
        /// ����� ��� ������ ����� ������.
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
