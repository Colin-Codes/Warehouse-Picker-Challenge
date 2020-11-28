

namespace Rainforest_Robot {
    class WareHousePicker : WareHouseObject {

        string status;

        string Status {
            get;
        }

        public WareHousePicker (int X, int Y, int Quantity = 0) : base(X, Y, Quantity) {
            Quantity = 0;     
            status = "OK";      
        }

        public void goNorth() {
            y += 1;
        }

        public void goSouth() {
            y -= 1;
        }

        public void goEast() {
            x += 1;
        }

        public void goWest() {
            x -= 1;
        }

        public bool hasReachedCrate(int crateX, int crateY) {
            if (crateX == x && crateY == y) {
                return true;
            } else {
                return false;
            }
        }

        public void pickBags(int pickedBags) {
            if (pickedBags < 0) {
                status = "BROKEN";
            } else {
                quantity += pickedBags;
            }
        }

        public string Report () {
            // For debugging purposes
            return "X: " + x + ", Y:  " + y + ", Q: " + quantity + ", Status: " + status;
        }
    }
}