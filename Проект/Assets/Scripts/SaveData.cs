using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    [Serializable]
    public class SaveData
    {
        /// <summary>
        /// Номер уровня.
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// Очки за прохождение уровня.
        /// </summary>
        public int Score { get; set; }

        public SaveData()
        {
            Level = 0;
            Score = 0;
        }
    }
}
