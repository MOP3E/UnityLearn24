﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense
{
    internal class EventArgsFloatValue : EventArgs
    {
        public float Value = 0;

        public override string ToString()
        {
            return Value.ToString(CultureInfo.CurrentCulture);
        }
    }
}
