using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellularAutomata2D.Types {
    enum AlgorithmMode {
        TheGameOfLife,
        GrainGrowthNeumann,
        GrainGrowthMoore,
        GrainGrowthHexLeft,
        GrainGrowthHexRight,
        GrainGrowthHexRandom,
        GrainGrowthPegLeft,
        GrainGrowthPegRight,
        GrainGrowthPegRandom
    }
}
