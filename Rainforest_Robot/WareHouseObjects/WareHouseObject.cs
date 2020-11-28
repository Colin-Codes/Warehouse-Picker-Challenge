

namespace Rainforest_Robot {
    abstract class WareHouseObject {
        protected int x;
        public int X {
            get;
        }

        protected int y;
        public int Y {
            get;
        }

        protected int quantity;
        public int Quantity {
            get;
        }    
        public WareHouseObject (int X, int Y, int Quantity = 0) {
            x = X;
            y = Y;
            quantity = Quantity;
        }    

        public string Report () {
            // For debugging purposes
            return "X: " + x + ", Y:  " + y + ", Q: " + quantity;
        }
    }
}