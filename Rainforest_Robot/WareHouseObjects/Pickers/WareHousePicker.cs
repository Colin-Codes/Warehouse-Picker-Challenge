using System;

namespace Rainforest_Robot {
    class WareHousePicker : WareHouseObject {

        string status;

        public string Status {
            get;
        }

        public WareHousePicker (int _X, int _Y, int _Quantity = 0) : base(_X, _Y, _Quantity) {
              
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

        public bool hasReachedLocation(int locationX, int locationY) {
            if (locationX == x && locationY == y) {
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

        public int dropBags(int dropPointX, int dropPointY) {
            if (hasReachedLocation(dropPointX, dropPointY) == false) {
                status = "BROKEN";
            }
            int droppedBags = Quantity;
            quantity = 0;
            return droppedBags;
        }

        public new string Report() {
            // For debugging purposes
            return "X: " + x + ", Y:  " + y + ", Q: " + quantity + ", Status: " + status;
        }
    }
}