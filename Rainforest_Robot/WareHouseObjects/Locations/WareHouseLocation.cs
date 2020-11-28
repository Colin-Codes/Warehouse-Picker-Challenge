

namespace Rainforest_Robot {
    class WareHouseLocation : WareHouseObject {
        public WareHouseLocation (int _X, int _Y, int _Quantity = 0) : base(_X, _Y, _Quantity) {

        }
            
        public int giveBag() {
            if (quantity > 0) {
                quantity -= 1;
                return 1;
            } else {
                return 0;
            }
        }

        public void receiveBags(int receivedBags) {
            quantity += receivedBags;
        }
    }
}