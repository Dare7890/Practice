﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanks
{
    interface ITanks
    {
        Position CurrentPosition { get; }
        void AddTanks(PaintEventArgs e);
        bool IsHitBorder(List<Position> borderList);
    }
}
