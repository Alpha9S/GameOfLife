using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_of_Life
{
    class Cell
    {
        private int x, y;
        private bool condition;
        public Cell(int x, int y, bool condition){
            this.x = x;
            this.y = y;
            this.condition = false;
        }

        public int getX
        {
            get { return this.x; }
        }

        public int getY
        {
            get { return this.y; }
        }

        public bool getCondition
        {
            get { return this.condition; }
        }
    }
}
