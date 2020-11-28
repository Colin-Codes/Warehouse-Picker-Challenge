

namespace Rainforest_Robot {
    class WareHousePicker : WareHouseObject {
        public WareHousePicker (int X, int Y, int Quantity = 0) : base(X, Y, Quantity) {
            Quantity = 0;            
        }
    }
}