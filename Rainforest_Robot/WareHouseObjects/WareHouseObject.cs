

namespace Rainforest_Robot {
    abstract class WareHouseObject {
        protected int x;
        public int X {
            get {
                return x;
            }
        }

        protected int y;
        public int Y {
            get {
                return y;
            }
        }

        protected int quantity;
        public int Quantity {
            get {
                return quantity;
            }
        }    
        public WareHouseObject (int _X, int _Y, int _Quantity = 0) {
            x = _X;
            y = _Y;
            quantity = _Quantity;
        }    

        public string Report () {
            // For debugging purposes
            return "X: " + x + ", Y:  " + y + ", Q: " + quantity;
        }
    }
}