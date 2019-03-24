using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CellularAutomata2D.Classes;
using CellularAutomata2D.Utils;
using CellularAutomata2D.Types;
using System.Threading;

namespace CellularAutomata2D {
    public partial class Interface : Form {
        // Configuration consts

        private const int SIZE = 50;

        // GUI generation params

        private Grid grid;
        private Bitmap bitmap;
        private Graphics g;
        private int scale = 1;

        // Current state params

        private BoundaryConditionType boundaryConditionType;
        private AlgorithmMode algorithmMode;

        // Realtime operations params

        private Thread t;
        private bool work = false;

        // Constructor

        public Interface() {
            InitializeComponent();

            this.grid = new Grid(SIZE, SIZE);
            this.scale = visualBox.Size.Width / SIZE;

            this.bitmap = new Bitmap(visualBox.Size.Width, visualBox.Size.Height);
            this.g = Graphics.FromImage(this.bitmap);
            visualBox.Image = this.bitmap;

            this.Draw();
            visualBox.Refresh();
        }

        // Helpers

        private void Draw() {
            int[] gridSize = this.grid.GetGridSize();

            try {
                this.g.Clear(Color.White);
                for (int i = 0; i < gridSize[0]; i++) {
                    for (int j = 0; j < gridSize[1]; j++) {
                        if (this.grid.GetCorrectGridElement(i, j).GetStatus()) {
                            this.g.FillRectangle(new SolidBrush(ColorTranslator.FromHtml(this.grid.GetCorrectGridElement(i, j).GetGrainColor())), i * scale, j * scale, scale, scale);
                        }
                    }
                }
            } catch (InvalidOperationException e) {

            }

        }

        private void RecalculateView() {
            this.grid.RecalculateCells(this.boundaryConditionType, this.algorithmMode);

            this.Draw();
            float avgSize = this.grid.GetAverangeGrainSize();
            int borderLength = this.grid.GetGrainsBorderLength();

            try {
                this.Invoke(new MethodInvoker(
                    delegate {
                        sizeAvg.Text = "Avg size " + Convert.ToString(avgSize);
                        borderLengthSum.Text = "Border sum " + Convert.ToString(borderLength);
                        visualBox.Refresh();
                    }
                ));
            } catch (System.ObjectDisposedException e) {
                t.Abort();
                this.Close();
            } catch (System.InvalidOperationException e) {
                t.Abort();
                this.Close();
            }

            this.RecalculateView();
        }

        // Events

        private void VisualBox_Click(object sender, EventArgs e) {
            MouseEventArgs mouse = (MouseEventArgs)e;
            Point coordinates = mouse.Location;
            int x = coordinates.X / scale;
            int y = coordinates.Y / scale;

            switch (mode.Text) {
                case "static":
                    this.grid.SetCorrectGridElement(x, y, true);
                    this.grid.SetCorrectGridElement(x + 1, y + 1, true);
                    this.grid.SetCorrectGridElement(x + 1, y, true);
                    this.grid.SetCorrectGridElement(x, y + 1, true);
                    break;

                case "oscillator":
                    this.grid.SetCorrectGridElement(x, y, true);
                    this.grid.SetCorrectGridElement(x + 1, y, true);
                    this.grid.SetCorrectGridElement(x + 2, y, true);
                    break;

                case "spaceship":
                    this.grid.SetCorrectGridElement(x, y, true);
                    this.grid.SetCorrectGridElement(x + 1, y + 1, true);
                    this.grid.SetCorrectGridElement(x - 1, y + 2, true);
                    this.grid.SetCorrectGridElement(x, y + 2, true);
                    this.grid.SetCorrectGridElement(x + 1, y + 2, true);
                    break;

                default:
                    this.grid.ChangeGridElement(x, y);
                    break;
            }

            this.Draw();
            visualBox.Refresh();
        }

        private void NextStep_Click(object sender, EventArgs e) {
            if (this.work) return;

            this.grid.RecalculateCells(this.boundaryConditionType, this.algorithmMode);

            this.Draw();

            float avgSize = this.grid.GetAverangeGrainSize();
            int borderLength = this.grid.GetGrainsBorderLength();

            sizeAvg.Text = "Avg size " + Convert.ToString(avgSize);
            borderLengthSum.Text = "Border sum " + Convert.ToString(borderLength);
            visualBox.Refresh();
        }

        private void Reset_Click(object sender, EventArgs e) {
            if (this.work) return;

            this.grid.FillCells(FillCellsType.Empty);

            this.Draw();
            visualBox.Refresh();
        }

        private void Random_Click(object sender, EventArgs e) {
            if (this.work) return;

            this.grid.FillCells(FillCellsType.ChaosRandom);

            this.Draw();
            visualBox.Refresh();
        }

        private void PlayPause_Click(object sender, EventArgs e) {
            this.work = !this.work;

            if (this.work) {
                playPause.Text = "Pause";
                t = new Thread(this.RecalculateView);
                t.Start();
            } else {
                playPause.Text = "Play";
                t.Abort();
            }
        }

        private void BoundaryCondition_SelectedIndexChanged(object sender, EventArgs e) {
            switch (boundaryCondition.Text) {
                case "periodic":
                    this.boundaryConditionType = BoundaryConditionType.Periodic;
                    break;

                case "setfalse":
                    this.boundaryConditionType = BoundaryConditionType.NonPeriodic;
                    break;
            }
        }

        private void Neighboorhood_SelectedIndexChanged(object sender, EventArgs e) {
            switch (neighboorhood.Text) {
                case "thegameoflife":
                    this.algorithmMode = AlgorithmMode.TheGameOfLife;
                    break;

                case "neumann":
                    this.algorithmMode = AlgorithmMode.GrainGrowthNeumann;
                    break;

                case "moore":
                    this.algorithmMode = AlgorithmMode.GrainGrowthMoore;
                    break;

                case "hexleft":
                    this.algorithmMode = AlgorithmMode.GrainGrowthHexLeft;
                    break;

                case "hexright":
                    this.algorithmMode = AlgorithmMode.GrainGrowthHexRight;
                    break;

                case "hexrandom":
                    this.algorithmMode = AlgorithmMode.GrainGrowthHexRandom;
                    break;

                case "pexleft":
                    this.algorithmMode = AlgorithmMode.GrainGrowthPegLeft;
                    break;

                case "pexright":
                    this.algorithmMode = AlgorithmMode.GrainGrowthPegRight;
                    break;

                case "pexrandom":
                    this.algorithmMode = AlgorithmMode.GrainGrowthPegRandom;
                    break;
            }
        }

        private void GenerateGrains_Click(object sender, EventArgs e) {
            int[] fillParams = { Convert.ToInt32(grains.Text), Convert.ToInt32(radius.Text) };
            this.grid.FillCells(FillCellsType.SmartRandom, fillParams);

            this.Draw();
            visualBox.Refresh();
        }
    }
}
