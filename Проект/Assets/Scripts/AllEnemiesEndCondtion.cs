using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    /// <summary>
    /// Состояние уровня - все враги закончились.
    /// </summary>
    public class AllEnemiesEndCondtion : MonoBehaviour, ILevelCondition
    {
        /// <summary>
        /// Генераторы волн врагов на уровне.
        /// </summary>
        [SerializeField] private WaveController[] _waves;


        public bool IsCompleted
        {
            get
            {
                //1. Все генераторы врагов закончили работу.
                foreach (WaveController wave in _waves)
                {
                    if (!wave.Complete) return false;
                }

                //2. Все враги исчезли с карты.
                if (Destructible.AllDestructibles == null) return false; //если null - генерация врагов ещё не начиналась
                foreach (Destructible destructible in Destructible.AllDestructibles)
                {
                    if (destructible is Walker) return false;
                }

                return true;
            }
        }
    }
}
