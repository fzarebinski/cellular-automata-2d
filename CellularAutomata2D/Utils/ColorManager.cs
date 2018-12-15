using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellularAutomata2D.Utils {
    class ColorManager {
        private const int COLORS = 16581375;

        public static string GetHexColor(int colors, int iterator) {
            int colorNumber = (ColorManager.COLORS / colors) * iterator;
            string hexColorNumber = colorNumber.ToString("X");
            StringBuilder hexColor = new StringBuilder("#000000");

            for (int i = 0, j = 6; i < hexColorNumber.Length && j > 0; i++, j--) {
                hexColor[j] = hexColorNumber[i];
            }

            return hexColor.ToString();
        }
    }
}
