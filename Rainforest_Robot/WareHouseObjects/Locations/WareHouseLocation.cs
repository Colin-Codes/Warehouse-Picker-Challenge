

namespace Rainforest_Robot {
    class WareHouseLocation : WareHouseObject {
        public WareHouseLocation (int X, int Y, int Quantity = 0) : base(X, Y, Quantity) {

        }
            
        public int giveBag() {
            if (quantity > 0) {
                quantity -= 1;
                return 1;
            } else {
                return 0;
            }
        }
    }
}