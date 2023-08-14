using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class PlayerStatistics : IComparable
    {
        /// <summary>
        /// Имя игрока.
        /// </summary>
        public String PlayerName { get; set; }

        private int _alive;

        /// <summary>
        /// Игрок выжил.
        /// </summary>
        public int Alive
        {
            get => _alive;
            set
            {
                _alive = value == 0 ? 0 : 1;
                AliveChanged?.Invoke(this, EventArgs.Empty);
                ScoreChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Игрок выжил изменилось.
        /// </summary>
        public event EventHandler AliveChanged;

        private int _fullHealth;

        /// <summary>
        /// Игрок сохранил полную жизнь.
        /// </summary>
        public int FullHealth
        {
            get => _fullHealth;
            set
            {
                _fullHealth = _alive == 0 ? 0 : (value == 0 ? 0 : 1);
                FullHealthChanged?.Invoke(this, EventArgs.Empty);
                ScoreChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Игрок сохранил полную жизнь изменилось.
        /// </summary>
        public event EventHandler FullHealthChanged;

        private int _speedup;

        /// <summary>
        /// Игрок использовал ускорение.
        /// </summary>
        public int Speedup
        {
            get => _speedup;
            set
            {
                _speedup = _alive == 0 ? 0 : (value == 0 ? 0 : 1);
                SpeedupChanged?.Invoke(this, EventArgs.Empty);
                ScoreChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Игрок использовал ускорение изменилось.
        /// </summary>
        public event EventHandler SpeedupChanged;

        /// <summary>
        /// Суммарные очки за прохождение уровня.
        /// </summary>
        public int Score => Alive + FullHealth + Speedup;

        /// <summary>
        /// Суммарные очки изменилось.
        /// </summary>
        public event EventHandler ScoreChanged;

        /// <summary>
        /// Обнуление статистики.
        /// </summary>
        public void Reset()
        {
            Alive = 0;
            FullHealth = 0;
            Speedup = 0;
        }

        public int CompareTo(object other)
        {
            if (other == null) return 1;
            PlayerStatistics statistics = (PlayerStatistics)other;

            return (_alive + _fullHealth + _speedup).CompareTo(statistics._alive + statistics._fullHealth + statistics._speedup);
        }
    }
}
