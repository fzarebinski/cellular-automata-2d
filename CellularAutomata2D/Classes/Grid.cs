using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CellularAutomata2D.Types;

namespace CellularAutomata2D.Classes {
    class Grid {
        private Cell[,] cells;

        // Constructors

        public Grid(int height, int width) {
            Cell.RefreshAutoIncrement(); // every new grid has separated increment GrainIds

            this.cells = new Cell[height, width];

            for (int i = 0; i < this.cells.GetLength(0); i++) {
                for (int j = 0; j < this.cells.GetLength(1); j++) {
                    this.cells[i, j] = new Cell();
                }
            }
        }

        public Grid(Grid grid) {
            Cell.RefreshAutoIncrement(); // every new grid has separated increment GrainIds

            int[] size = grid.GetGridSize();
            this.cells = new Cell[size[0], size[1]];

            for (int i = 0; i < this.cells.GetLength(0); i++) {
                for (int j = 0; j < this.cells.GetLength(1); j++) {
                    this.cells[i, j] = new Cell();
                }
            }
        }

        // Getters

        public int[] GetGridSize() {
            int[] size = { this.cells.GetLength(0), this.cells.GetLength(1) };
            return size;
        }

        public Cell[,] GetGrid() {
            return this.cells;
        }

        public Cell GetGridElement(int i, int j) {
            return this.cells[i, j];
        }

        // Smart getters

        public bool GetCorrectValue(int i, int j, BoundaryConditionType boundaryConditionType = BoundaryConditionType.Periodic) {
            switch (boundaryConditionType) {
                case BoundaryConditionType.Periodic:
                    if (i < 0) i = (this.cells.GetLength(0) + i) % this.cells.GetLength(0);
                    if (i >= this.cells.GetLength(0)) i = i % this.cells.GetLength(0);

                    if (j < 0) j = (this.cells.GetLength(1) + j) % this.cells.GetLength(1);
                    if (j >= this.cells.GetLength(1)) j = j % this.cells.GetLength(1);
                    break;

                case BoundaryConditionType.NonPeriodic:
                    if (i < 0 || i >= this.cells.GetLength(0) || j < 0 || j >= this.cells.GetLength(1)) {
                        return false;
                    }
                    break;
            }

            return this.cells[i, j].GetStatus();
        }

        public Cell GetCorrectGridElement(int i, int j, BoundaryConditionType boundaryConditionType = BoundaryConditionType.Periodic) {
            switch (boundaryConditionType) {
                case BoundaryConditionType.Periodic:
                    if (i < 0) i = (this.cells.GetLength(0) + i) % this.cells.GetLength(0);
                    if (i >= this.cells.GetLength(0)) i = i % this.cells.GetLength(0);

                    if (j < 0) j = (this.cells.GetLength(1) + j) % this.cells.GetLength(1);
                    if (j >= this.cells.GetLength(1)) j = j % this.cells.GetLength(1);
                    break;

                case BoundaryConditionType.NonPeriodic:
                    if (i < 0 || i >= this.cells.GetLength(0) || j < 0 || j >= this.cells.GetLength(1)) {
                        return null;
                    }
                    break;
            }

            return this.cells[i, j];
        }

        // Setters

        public bool SetCorrectGridElement(int i, int j, bool value, BoundaryConditionType boundaryConditionType = BoundaryConditionType.Periodic) {
            switch (boundaryConditionType) {
                case BoundaryConditionType.Periodic:
                    if (i < 0) i = (this.cells.GetLength(0) + i) % this.cells.GetLength(0);
                    if (i >= this.cells.GetLength(0)) i = i % this.cells.GetLength(0);

                    if (j < 0) j = (this.cells.GetLength(1) + j) % this.cells.GetLength(1);
                    if (j >= this.cells.GetLength(1)) j = j % this.cells.GetLength(1);
                    break;

                case BoundaryConditionType.NonPeriodic:
                    if (i < 0 || i >= this.cells.GetLength(0) || j < 0 || j >= this.cells.GetLength(1)) {
                        return false;
                    }
                    break;
            }

            this.cells[i, j].SetStatus(value);
            return true;
        }

        // Switchers

        public bool ChangeGridElement(int i, int j) {
            if (i < 0 || i >= this.cells.GetLength(0) || j < 0 || j >= this.cells.GetLength(1)) {
                return false;
            }

            this.cells[i, j].ChangeStatus();
            return true;
        }

        // Math operations

        public Dictionary<int, int> GetGrainSizes() {
            Dictionary<int, int> grainsSize = new Dictionary<int, int>();

            for (int i = 0; i < this.cells.GetLength(0); i++) {
                for (int j = 0; j < this.cells.GetLength(1); j++) {
                    if (this.GetCorrectValue(i, j)) {
                        int grainId = this.GetCorrectGridElement(i, j).GetGrainId();
                        if (grainsSize.ContainsKey(grainId)) {
                            grainsSize[grainId]++;
                        } else {
                            grainsSize.Add(grainId, 1);
                        }
                    }
                }
            }

            return grainsSize;
        }

        public Dictionary<int, int> GetGrainBorderLengths() {
            Dictionary<int, int> grainBorderLenghts = new Dictionary<int, int>();

            for (int i = 0; i < this.cells.GetLength(0); i++) {
                for (int j = 0; j < this.cells.GetLength(1); j++) {
                    if (this.GetCorrectValue(i, j)) {
                        int grainId = this.GetCorrectGridElement(i, j).GetGrainId();
                        int counted = 0;

                        counted += this.GetCorrectValue(i - 1, j) && grainId != this.GetCorrectGridElement(i - 1, j).GetGrainId() ? 1 : 0;
                        counted += this.GetCorrectValue(i + 1, j) && grainId != this.GetCorrectGridElement(i + 1, j).GetGrainId() ? 1 : 0;
                        counted += this.GetCorrectValue(i, j - 1) && grainId != this.GetCorrectGridElement(i, j - 1).GetGrainId() ? 1 : 0;
                        counted += this.GetCorrectValue(i, j + 1) && grainId != this.GetCorrectGridElement(i, j + 1).GetGrainId() ? 1 : 0;

                        if (counted == 0) continue;

                        if (grainBorderLenghts.ContainsKey(grainId)) {
                            grainBorderLenghts[grainId] += counted;
                        } else {
                            grainBorderLenghts.Add(grainId, counted);
                        }
                    }
                }
            }

            return grainBorderLenghts;
        }

        public int GetGrainsBorderLength() {
            Dictionary<int, int> grainBorderLengths = this.GetGrainBorderLengths();

            int sum = 0;

            foreach (KeyValuePair<int, int> grainBorderLength in grainBorderLengths) {
                sum += grainBorderLength.Value;
            }

            return sum / 2; // two elements contains the same border, so it is counted twice
        }

        public float GetAverangeGrainSize() {
            Dictionary<int, int> grainsSize = this.GetGrainSizes();

            int sum = 0;

            foreach (KeyValuePair<int, int> grainSize in grainsSize) {
                sum += grainSize.Value;
            }

            return (float)sum / grainsSize.Count;
        }

        // Cells operations

        public void RecalculateCells(BoundaryConditionType boundaryConditionType = BoundaryConditionType.Periodic, AlgorithmMode algorithMode = AlgorithmMode.TheGameOfLife) {
            int[] gridSize = this.GetGridSize();
            Grid newGrid = new Grid(gridSize[0], gridSize[1]);

            for (int i = 0; i < gridSize[0]; i++) {
                for (int j = 0; j < gridSize[1]; j++) {
                    newGrid.SetCorrectGridElement(i, j, this.CheckNeighbourhoods(i, j, algorithMode, boundaryConditionType));
                    newGrid.GetCorrectGridElement(i, j, boundaryConditionType).SetGrainId(this.GetCorrectGridElement(i, j, boundaryConditionType).GetGrainId());
                }
            }

            this.cells = newGrid.cells;
        }

        public void FillCells(FillCellsType fillCellsType, int[] fillParams = null) {
            int[] gridSize = this.GetGridSize();
            Random random = new Random();

            switch (fillCellsType) {
                case FillCellsType.ChaosRandom:
                    for (int i = 0; i < gridSize[0]; i++) {
                        for (int j = 0; j < gridSize[1]; j++) {
                            bool value = random.Next(0, 2) == 1;
                            this.SetCorrectGridElement(i, j, value);

                            this.GetCorrectGridElement(i, j).Refresh();
                        }
                    }
                    break;

                case FillCellsType.Empty:
                    for (int i = 0; i < gridSize[0]; i++) {
                        for (int j = 0; j < gridSize[1]; j++) {
                            this.SetCorrectGridElement(i, j, false);

                            this.GetCorrectGridElement(i, j).Refresh();
                        }
                    }
                    break;

                case FillCellsType.SmartRandom:
                    int grainsToCreate = fillParams[0];
                    int space = fillParams[1];
                    space += 1;

                    int[] max = this.GetGridSize();
                    int[] position = { random.Next(0, max[0]), random.Next(0, max[1]) };
                    int local = 0;
                    bool reverse = random.Next(0, 2) == 1;
                    int localMax = reverse ? max[1] / space : max[0] / space;

                    for (int i = 0; i < grainsToCreate; i++) {
                        this.SetCorrectGridElement(position[0], position[1], true);
                        this.GetCorrectGridElement(position[0], position[1]).Refresh();

                        local++;

                        if (reverse) {
                            if (local == localMax) {
                                position[0] += space;
                                local = 0;
                            } else {
                                position[1] += space;
                            }
                        } else {
                            if (local == localMax) {
                                position[1] += space;
                                local = 0;
                            } else {
                                position[0] += space;
                            }
                        }
                    }

                    break;

            }

        }

        // Neighbourhoods

        private int[,] GetAlgorithmConditions(int i, int j, AlgorithmMode algorithmMode) {
            switch (algorithmMode) {
                case AlgorithmMode.TheGameOfLife: {
                        int[,] conditions = {
                            { i - 1, j - 1},
                            { i - 1, j},
                            { i - 1, j + 1},
                            { i, j - 1},
                            { i, j + 1},
                            { i + 1, j - 1},
                            { i + 1, j},
                            { i + 1, j + 1}
                        };

                        return conditions;
                    }

                case AlgorithmMode.GrainGrowthNeumann: {
                        int[,] conditions = {
                            { i - 1, j},
                            { i, j - 1},
                            { i, j + 1},
                            { i + 1, j}
                        };

                        return conditions;
                    }

                case AlgorithmMode.GrainGrowthMoore: {
                        int[,] conditions = {
                            { i - 1, j - 1},
                            { i - 1, j},
                            { i - 1, j + 1},
                            { i, j - 1},
                            { i, j + 1},
                            { i + 1, j - 1},
                            { i + 1, j},
                            { i + 1, j + 1}
                        };

                        return conditions;
                    }

                case AlgorithmMode.GrainGrowthHexLeft: {
                        int[,] conditions = {
                            { i - 1, j - 1},
                            { i - 1, j},
                            { i, j - 1},
                            { i, j + 1},
                            { i + 1, j},
                            { i + 1, j + 1}
                        };

                        return conditions;
                    }

                case AlgorithmMode.GrainGrowthHexRight: {
                        int[,] conditions = {
                            { i - 1, j},
                            { i - 1, j + 1},
                            { i, j - 1},
                            { i, j + 1},
                            { i + 1, j - 1},
                            { i + 1, j}
                        };

                        return conditions;
                    }

                case AlgorithmMode.GrainGrowthPegLeft: {
                        int[,] conditions = {
                            { i - 1, j - 1},
                            { i - 1, j},
                            { i - 1, j + 1},
                            { i, j - 1},
                            { i, j + 1}
                        };

                        return conditions;
                    }

                case AlgorithmMode.GrainGrowthPegRight: {
                        int[,] conditions = {
                            { i, j - 1},
                            { i, j + 1},
                            { i + 1, j - 1},
                            { i + 1, j},
                            { i + 1, j + 1}
                        };

                        return conditions;
                    }

            }

            return null;
        }

        private int GetBestGrainId(Dictionary<int, int> grainIds) {
            int[] keys = grainIds.Keys.ToArray();
            int grainIdKey = -1;

            foreach (KeyValuePair<int, int> grainId in grainIds) {
                if (grainIdKey == -1) {
                    grainIdKey = grainId.Key;
                } else if (grainIds[grainIdKey] < grainId.Value) {
                    grainIdKey = grainId.Key;
                }
            }

            return grainIdKey;
        }

        private int CheckConditions(int[,] conditions, Cell cell = null, BoundaryConditionType boundaryConditionType = BoundaryConditionType.Periodic) {
            Dictionary<int, int> grainIds = new Dictionary<int, int>();

            if (cell != null && cell.GetStatus()) {
                grainIds.Add(cell.GetGrainId(), 1);
            }

            for (int i = 0; i < conditions.GetLength(0); i++) {
                if (this.GetCorrectValue(conditions[i, 0], conditions[i, 1], boundaryConditionType)) {
                    int grainId = this.GetCorrectGridElement(conditions[i, 0], conditions[i, 1], boundaryConditionType).GetGrainId();
                    if (grainIds.ContainsKey(grainId)) {
                        grainIds[grainId]++;
                    } else {
                        grainIds.Add(grainId, 1);
                    }
                }
            }

            return this.GetBestGrainId(grainIds);
        }

        public int CountNeighbourhoods(int i, int j, BoundaryConditionType boundaryConditionTyoe = BoundaryConditionType.Periodic) {
            int counted = 0;
            counted += this.GetCorrectValue(i - 1, j - 1, boundaryConditionTyoe) ? 1 : 0;
            counted += this.GetCorrectValue(i - 1, j, boundaryConditionTyoe) ? 1 : 0;
            counted += this.GetCorrectValue(i - 1, j + 1, boundaryConditionTyoe) ? 1 : 0;
            counted += this.GetCorrectValue(i, j - 1, boundaryConditionTyoe) ? 1 : 0;
            counted += this.GetCorrectValue(i, j + 1, boundaryConditionTyoe) ? 1 : 0;
            counted += this.GetCorrectValue(i + 1, j - 1, boundaryConditionTyoe) ? 1 : 0;
            counted += this.GetCorrectValue(i + 1, j, boundaryConditionTyoe) ? 1 : 0;
            counted += this.GetCorrectValue(i + 1, j + 1, boundaryConditionTyoe) ? 1 : 0;

            return counted;
        }

        public bool CheckNeighbourhoods(int i, int j, AlgorithmMode algorithmMode, BoundaryConditionType boundaryConditionType = BoundaryConditionType.Periodic) {
            Dictionary<int, int> grainIds = new Dictionary<int, int>();
            int grainId = -1;

            switch (algorithmMode) {
                case AlgorithmMode.TheGameOfLife:
                    grainId = this.CheckConditions(this.GetAlgorithmConditions(i, j, algorithmMode), this.GetCorrectGridElement(i, j), boundaryConditionType);

                    if (this.CountNeighbourhoods(i, j, boundaryConditionType) == 3 || (this.GetCorrectValue(i, j, boundaryConditionType) && this.CountNeighbourhoods(i, j, boundaryConditionType) == 2)) {
                        grainId = this.CheckConditions(this.GetAlgorithmConditions(i, j, algorithmMode), this.GetCorrectGridElement(i, j), boundaryConditionType);

                        if (grainId == -1) return false;

                        this.GetCorrectGridElement(i, j, boundaryConditionType).SetGrainId(grainId);

                        return true;
                    }

                    return false;

                default: // all grain growth algorithms
                    grainId = this.CheckConditions(this.GetAlgorithmConditions(i, j, algorithmMode), this.GetCorrectGridElement(i, j), boundaryConditionType);

                    if (grainId == -1) return false;

                    this.GetCorrectGridElement(i, j, boundaryConditionType).SetGrainId(grainId);

                    return true;
            }
        }
    }
}
