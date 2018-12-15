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
        private string color = null;

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
            if (this.color == null) this.color = ColorManager.GetHexColor(Cell.i, grainId);

            return this.color;
        }

        // Setters

        public bool SetStatus(bool status) {
            this.status = status;

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
            this.Refresh();

            return true;
        }

        // Operations

        public static void RefreshAutoIncrement() {
            Cell.i = 0;
        }

        public void RecalculateColor() {
            this.color = ColorManager.GetHexColor(Cell.i, grainId);
        }

        public void Refresh() {
            this.grainId = ++Cell.i;
            this.color = null;
        }
    }
}
