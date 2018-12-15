using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CellularAutomata2D.Utils;

namespace CellularAutomata2D.Classes {
    class Cell {
        private int grainId = -1;
        private bool status = false;
        private string color = "#000000";

        private static int i = 0;

        // Constructor

        public Cell() {
            this.grainId = ++Cell.i;
        }

        // Getters

        public bool GetStatus() {
            return this.status;
        }

        public int GetGrainId() {
            return this.grainId;
        }

        public string GetGrainColor() {
            return this.color;
        }

        // Setters

        public bool SetStatus(bool status) {
            this.status = status;

            if (this.status && this.color == "#000000") this.RecalculateColor();
            return true;
        }

        public bool SetGrainId(int grainId) {
            this.grainId = grainId;

            this.color = ColorManager.GetHexColor(Cell.i, grainId);
            return true;
        }

        // Switchers

        public bool ChangeStatus() {
            this.status = !this.status;
            return true;
        }

        // Operations

        public static bool RefreshAutoIncrement() {
            Cell.i = 0;
            return true;
        }

        public void RecalculateColor() {
            this.color = ColorManager.GetHexColor(Cell.i, grainId);
        }
    }
}
