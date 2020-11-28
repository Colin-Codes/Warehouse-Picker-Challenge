

namespace Rainforest_Robot {
    abstract class WareHouseObject {
        private int x;
        public int X {
            get;
        }

        private int y;
        public int Y {
            get;
        }

        private int quantity;
        public int Quantity {
            get;
        }    
        public WareHouseObject (int X, int Y, int Quantity = 0) {
            x = X;
            y = Y;
            quantity = Quantity;
        }    

        public string Report () {
            return "X: " + x + ", Y:  " + y + ", Q: " + quantity + " ";
        }
    }
}