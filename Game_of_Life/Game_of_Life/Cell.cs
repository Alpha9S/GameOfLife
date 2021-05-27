using System;
using System.Windows.Shapes;

namespace Game_of_Life
{
    class Cell
    {
        private int x, y;
        private bool isAlive;
        private Ellipse circle;
        public Cell(int x, int y, bool condition){
            this.x = x;
            this.y = y;
            this.isAlive = condition;
        }

        /// <summary>
        /// getter for the y property
        /// </summary>
        public int X
        {
            get { return this.x; }
        }

        /// <summary>
        /// getter for the x property
        /// </summary>
        public int Y
        {
            get { return this.y; }
        }

        /// <summary>
        /// getter and setter for the condition property
        /// </summary>
        public bool IsAlive
        {
            get { return isAlive; }
            set { isAlive = value; }
        }

        /// <summary>
        /// getter and setter for the circle property
        /// </summary>
        public Ellipse Circle
        {
            get { return circle; }
            set { circle = value; }
        }
    }
}
