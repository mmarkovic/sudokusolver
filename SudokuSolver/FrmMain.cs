using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Text;
using System.Windows.Forms;

namespace SudokuSolver
{
    public partial class FmMain : Form
    {
        private Thread tSolver;
        private cSudokusolver meinSolver;
        private Sudokubrett meinBrett;

        delegate void felderMitWertenFüllenCallBack();

        public FmMain()
        {
            ausgangspositionErstellen();
            InitializeComponent();
        }

        private void ausgangspositionErstellen()
        {
            tSolver = new Thread(LöseSudoku);
            meinBrett = new Sudokubrett();
            meinSolver = new cSudokusolver(ref meinBrett);
        }

        private void tboxTextChanged(TextBox tbox, short positionX, short positionY)
        {
            if (tbox.Text.Length > 0)
            {
                if (!istZahl(tbox.Text))
                {
                    MessageBox.Show("Nur Zahlenwerte eingeben", "Formatfehler", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    tbox.Text = "";
                }
                else if(tbox.Text.Length == 1)
                {
                    meinBrett.WerteSetzen(positionX, positionY, int.Parse(tbox.Text));
                }
            }
            else
            {
                meinBrett.WerteSetzen(positionX, positionY, -1);
            }
        }

        private bool istZahl(String text)
        {
            try
            {
                int temp = int.Parse(text);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        #region TextboxChanged
        private void tbox11_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 1, 1);
        }

        private void tbox12_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 1, 2);
        }

        private void tbox13_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 1, 3);
        }

        private void tbox14_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 1, 4);
        }

        private void tbox15_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 1, 5);
        }

        private void tbox16_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 1, 6);
        }

        private void tbox17_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 1, 7);
        }

        private void tbox18_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 1, 8);
        }

        private void tbox19_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 1, 9);
        }

        private void tbox21_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 2, 1);
        }

        private void tbox22_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 2, 2);
        }

        private void tbox23_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 2, 3);
        }

        private void tbox24_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 2, 4);
        }

        private void tbox25_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 2, 5);
        }

        private void tbox26_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 2, 6);
        }

        private void tbox27_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 2, 7);
        }

        private void tbox28_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 2, 8);
        }

        private void tbox29_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 2, 9);
        }

        private void tbox31_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 3, 1);
        }

        private void tbox32_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 3, 2);
        }

        private void tbox33_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 3, 3);
        }

        private void tbox34_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 3, 4);
        }

        private void tbox35_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 3, 5);
        }

        private void tbox36_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 3, 6);
        }

        private void tbox37_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 3, 7);
        }

        private void tbox38_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 3, 8);
        }

        private void tbox39_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 3, 9);
        }

        private void tbox41_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 4, 1);
        }

        private void tbox42_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 4, 2);
        }

        private void tbox43_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 4, 3);
        }

        private void tbox44_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 4, 4);
        }

        private void tbox45_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 4, 5);
        }

        private void tbox46_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 4, 6);
        }

        private void tbox47_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 4, 7);
        }

        private void tbox48_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 4, 8);
        }

        private void tbox49_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 4, 9);
        }

        private void tbox51_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 5, 1);
        }

        private void tbox52_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 5, 2);
        }

        private void tbox53_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 5, 3);
        }

        private void tbox54_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 5, 4);
        }

        private void tbox55_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 5, 5);
        }

        private void tbox56_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 5, 6);
        }

        private void tbox57_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 5, 7);
        }

        private void tbox58_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 5, 8);
        }

        private void tbox59_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 5, 9);
        }

        private void tbox61_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 6, 1);
        }

        private void tbox62_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 6, 2);
        }

        private void tbox63_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 6, 3);
        }

        private void tbox64_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 6, 4);
        }

        private void tbox65_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 6, 5);
        }

        private void tbox66_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 6, 6);
        }

        private void tbox67_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 6, 7);
        }

        private void tbox68_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 6, 8);
        }

        private void tbox69_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 6, 9);
        }

        private void tbox71_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 7, 1);
        }

        private void tbox72_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 7, 2);
        }

        private void tbox73_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 7, 3);
        }

        private void tbox74_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 7, 4);
        }

        private void tbox75_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 7, 5);
        }

        private void tbox76_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 7, 6);
        }

        private void tbox77_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 7, 7);
        }

        private void tbox78_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 7, 8);
        }

        private void tbox79_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 7, 9);
        }

        private void tbox81_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 8, 1);
        }

        private void tbox82_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 8, 2);
        }

        private void tbox83_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 8, 3);
        }

        private void tbox84_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 8, 4);
        }

        private void tbox85_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 8, 5);
        }

        private void tbox86_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 8, 6);
        }

        private void tbox87_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 8, 7);
        }

        private void tbox88_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 8, 8);
        }

        private void tbox89_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 8, 9);
        }

        private void tbox91_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 9, 1);
        }

        private void tbox92_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 9, 2);
        }

        private void tbox93_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 9, 3);
        }

        private void tbox94_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 9, 4);
        }

        private void tbox95_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 9, 5);
        }

        private void tbox96_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 9, 6);
        }

        private void tbox97_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 9, 7);
        }

        private void tbox98_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 9, 8);
        }

        private void tbox99_TextChanged(object sender, EventArgs e)
        {
            tboxTextChanged((TextBox)sender, 9, 9);
        }
        #endregion

        private void btnSolve_Click(object sender, EventArgs e)
        {
            if (tSolver.ThreadState != ThreadState.Running)
            {
                if (tSolver.ThreadState == ThreadState.Stopped)
                    ausgangspositionErstellen();

                feldvordergrundfarbeAufSchwarz();
                tSolver.Start();

                btnSolve.Enabled = false;
                btnReset.Enabled = false;
            }
        }

        private void LöseSudoku()
        {
            felderMitWertenFüllenCallBack delegator;

            switch(meinSolver.SolveSudoku())
            {
                case eLösungsweg.sofort:
                    felderVorformatieren(Color.LightBlue);
                    delegator = new felderMitWertenFüllenCallBack(felderMitWertenFüllen);
                    this.Invoke(delegator);
                    break;

                case eLösungsweg.backward:
                    meinBrett = meinSolver.Lösungsbrett;
                    felderVorformatieren(Color.Red);
                    delegator = new felderMitWertenFüllenCallBack(felderMitWertenFüllen);
                    this.Invoke(delegator);
                    break;

                default:
                    MessageBox.Show("Es konnte keine Lösung gefunden werden :,(", "Shit happens!",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
            }

            delegator = new felderMitWertenFüllenCallBack(schaltflächenAktivieren);
            Invoke(delegator);
        }

        private void schaltflächenAktivieren()
        {
            btnReset.Enabled = true;
            btnSolve.Enabled = true;
        }

        /// <summary>
        /// Setzt die Feldvordergrundfarbe auf Schwarz
        /// </summary>
        private void feldvordergrundfarbeAufSchwarz()
        {
            Color farbe = Color.Black;

            tbox11.ForeColor = farbe;
            tbox12.ForeColor = farbe;
            tbox13.ForeColor = farbe;
            tbox14.ForeColor = farbe;
            tbox15.ForeColor = farbe;
            tbox16.ForeColor = farbe;
            tbox17.ForeColor = farbe;
            tbox18.ForeColor = farbe;
            tbox19.ForeColor = farbe;
            tbox21.ForeColor = farbe;
            tbox22.ForeColor = farbe;
            tbox23.ForeColor = farbe;
            tbox24.ForeColor = farbe;
            tbox25.ForeColor = farbe;
            tbox26.ForeColor = farbe;
            tbox27.ForeColor = farbe;
            tbox28.ForeColor = farbe;
            tbox29.ForeColor = farbe;
            tbox31.ForeColor = farbe;
            tbox32.ForeColor = farbe;
            tbox33.ForeColor = farbe;
            tbox34.ForeColor = farbe;
            tbox35.ForeColor = farbe;
            tbox36.ForeColor = farbe;
            tbox37.ForeColor = farbe;
            tbox38.ForeColor = farbe;
            tbox39.ForeColor = farbe;
            tbox41.ForeColor = farbe;
            tbox42.ForeColor = farbe;
            tbox43.ForeColor = farbe;
            tbox44.ForeColor = farbe;
            tbox45.ForeColor = farbe;
            tbox46.ForeColor = farbe;
            tbox47.ForeColor = farbe;
            tbox48.ForeColor = farbe;
            tbox49.ForeColor = farbe;
            tbox51.ForeColor = farbe;
            tbox52.ForeColor = farbe;
            tbox53.ForeColor = farbe;
            tbox54.ForeColor = farbe;
            tbox55.ForeColor = farbe;
            tbox56.ForeColor = farbe;
            tbox57.ForeColor = farbe;
            tbox58.ForeColor = farbe;
            tbox59.ForeColor = farbe;
            tbox61.ForeColor = farbe;
            tbox62.ForeColor = farbe;
            tbox63.ForeColor = farbe;
            tbox64.ForeColor = farbe;
            tbox65.ForeColor = farbe;
            tbox66.ForeColor = farbe;
            tbox67.ForeColor = farbe;
            tbox68.ForeColor = farbe;
            tbox69.ForeColor = farbe;
            tbox71.ForeColor = farbe;
            tbox72.ForeColor = farbe;
            tbox73.ForeColor = farbe;
            tbox74.ForeColor = farbe;
            tbox75.ForeColor = farbe;
            tbox76.ForeColor = farbe;
            tbox77.ForeColor = farbe;
            tbox78.ForeColor = farbe;
            tbox79.ForeColor = farbe;
            tbox81.ForeColor = farbe;
            tbox82.ForeColor = farbe;
            tbox83.ForeColor = farbe;
            tbox84.ForeColor = farbe;
            tbox85.ForeColor = farbe;
            tbox86.ForeColor = farbe;
            tbox87.ForeColor = farbe;
            tbox88.ForeColor = farbe;
            tbox89.ForeColor = farbe;
            tbox91.ForeColor = farbe;
            tbox92.ForeColor = farbe;
            tbox93.ForeColor = farbe;
            tbox94.ForeColor = farbe;
            tbox95.ForeColor = farbe;
            tbox96.ForeColor = farbe;
            tbox97.ForeColor = farbe;
            tbox98.ForeColor = farbe;
            tbox99.ForeColor = farbe;
        }

        private void feldinhaltLöschen()
        {
            tbox11.Text = "";
            tbox12.Text = "";
            tbox13.Text = "";
            tbox14.Text = "";
            tbox15.Text = "";
            tbox16.Text = "";
            tbox17.Text = "";
            tbox18.Text = "";
            tbox19.Text = "";
            tbox21.Text = "";
            tbox22.Text = "";
            tbox23.Text = "";
            tbox24.Text = "";
            tbox25.Text = "";
            tbox26.Text = "";
            tbox27.Text = "";
            tbox28.Text = "";
            tbox29.Text = "";
            tbox31.Text = "";
            tbox32.Text = "";
            tbox33.Text = "";
            tbox34.Text = "";
            tbox35.Text = "";
            tbox36.Text = "";
            tbox37.Text = "";
            tbox38.Text = "";
            tbox39.Text = "";
            tbox41.Text = "";
            tbox42.Text = "";
            tbox43.Text = "";
            tbox44.Text = "";
            tbox45.Text = "";
            tbox46.Text = "";
            tbox47.Text = "";
            tbox48.Text = "";
            tbox49.Text = "";
            tbox51.Text = "";
            tbox52.Text = "";
            tbox53.Text = "";
            tbox54.Text = "";
            tbox55.Text = "";
            tbox56.Text = "";
            tbox57.Text = "";
            tbox58.Text = "";
            tbox59.Text = "";
            tbox61.Text = "";
            tbox62.Text = "";
            tbox63.Text = "";
            tbox64.Text = "";
            tbox65.Text = "";
            tbox66.Text = "";
            tbox67.Text = "";
            tbox68.Text = "";
            tbox69.Text = "";
            tbox71.Text = "";
            tbox72.Text = "";
            tbox73.Text = "";
            tbox74.Text = "";
            tbox75.Text = "";
            tbox76.Text = "";
            tbox77.Text = "";
            tbox78.Text = "";
            tbox79.Text = "";
            tbox81.Text = "";
            tbox82.Text = "";
            tbox83.Text = "";
            tbox84.Text = "";
            tbox85.Text = "";
            tbox86.Text = "";
            tbox87.Text = "";
            tbox88.Text = "";
            tbox89.Text = "";
            tbox91.Text = "";
            tbox92.Text = "";
            tbox93.Text = "";
            tbox94.Text = "";
            tbox95.Text = "";
            tbox96.Text = "";
            tbox97.Text = "";
            tbox98.Text = "";
            tbox99.Text = "";
        }

        private void felderVorformatieren(Color lösungsFarbe)
        {
            if (tbox11.Text.Length == 0) tbox11.ForeColor = lösungsFarbe;
            if (tbox12.Text.Length == 0) tbox12.ForeColor = lösungsFarbe;
            if (tbox13.Text.Length == 0) tbox13.ForeColor = lösungsFarbe;
            if (tbox14.Text.Length == 0) tbox14.ForeColor = lösungsFarbe;
            if (tbox15.Text.Length == 0) tbox15.ForeColor = lösungsFarbe;
            if (tbox16.Text.Length == 0) tbox16.ForeColor = lösungsFarbe;
            if (tbox17.Text.Length == 0) tbox17.ForeColor = lösungsFarbe;
            if (tbox18.Text.Length == 0) tbox18.ForeColor = lösungsFarbe;
            if (tbox19.Text.Length == 0) tbox19.ForeColor = lösungsFarbe;
            if (tbox21.Text.Length == 0) tbox21.ForeColor = lösungsFarbe;
            if (tbox22.Text.Length == 0) tbox22.ForeColor = lösungsFarbe;
            if (tbox23.Text.Length == 0) tbox23.ForeColor = lösungsFarbe;
            if (tbox24.Text.Length == 0) tbox24.ForeColor = lösungsFarbe;
            if (tbox25.Text.Length == 0) tbox25.ForeColor = lösungsFarbe;
            if (tbox26.Text.Length == 0) tbox26.ForeColor = lösungsFarbe;
            if (tbox27.Text.Length == 0) tbox27.ForeColor = lösungsFarbe;
            if (tbox28.Text.Length == 0) tbox28.ForeColor = lösungsFarbe;
            if (tbox29.Text.Length == 0) tbox29.ForeColor = lösungsFarbe;
            if (tbox31.Text.Length == 0) tbox31.ForeColor = lösungsFarbe;
            if (tbox32.Text.Length == 0) tbox32.ForeColor = lösungsFarbe;
            if (tbox33.Text.Length == 0) tbox33.ForeColor = lösungsFarbe;
            if (tbox34.Text.Length == 0) tbox34.ForeColor = lösungsFarbe;
            if (tbox35.Text.Length == 0) tbox35.ForeColor = lösungsFarbe;
            if (tbox36.Text.Length == 0) tbox36.ForeColor = lösungsFarbe;
            if (tbox37.Text.Length == 0) tbox37.ForeColor = lösungsFarbe;
            if (tbox38.Text.Length == 0) tbox38.ForeColor = lösungsFarbe;
            if (tbox39.Text.Length == 0) tbox39.ForeColor = lösungsFarbe;
            if (tbox41.Text.Length == 0) tbox41.ForeColor = lösungsFarbe;
            if (tbox42.Text.Length == 0) tbox42.ForeColor = lösungsFarbe;
            if (tbox43.Text.Length == 0) tbox43.ForeColor = lösungsFarbe;
            if (tbox44.Text.Length == 0) tbox44.ForeColor = lösungsFarbe;
            if (tbox45.Text.Length == 0) tbox45.ForeColor = lösungsFarbe;
            if (tbox46.Text.Length == 0) tbox46.ForeColor = lösungsFarbe;
            if (tbox47.Text.Length == 0) tbox47.ForeColor = lösungsFarbe;
            if (tbox48.Text.Length == 0) tbox48.ForeColor = lösungsFarbe;
            if (tbox49.Text.Length == 0) tbox49.ForeColor = lösungsFarbe;
            if (tbox51.Text.Length == 0) tbox51.ForeColor = lösungsFarbe;
            if (tbox52.Text.Length == 0) tbox52.ForeColor = lösungsFarbe;
            if (tbox53.Text.Length == 0) tbox53.ForeColor = lösungsFarbe;
            if (tbox54.Text.Length == 0) tbox54.ForeColor = lösungsFarbe;
            if (tbox55.Text.Length == 0) tbox55.ForeColor = lösungsFarbe;
            if (tbox56.Text.Length == 0) tbox56.ForeColor = lösungsFarbe;
            if (tbox57.Text.Length == 0) tbox57.ForeColor = lösungsFarbe;
            if (tbox58.Text.Length == 0) tbox58.ForeColor = lösungsFarbe;
            if (tbox59.Text.Length == 0) tbox59.ForeColor = lösungsFarbe;
            if (tbox61.Text.Length == 0) tbox61.ForeColor = lösungsFarbe;
            if (tbox62.Text.Length == 0) tbox62.ForeColor = lösungsFarbe;
            if (tbox63.Text.Length == 0) tbox63.ForeColor = lösungsFarbe;
            if (tbox64.Text.Length == 0) tbox64.ForeColor = lösungsFarbe;
            if (tbox65.Text.Length == 0) tbox65.ForeColor = lösungsFarbe;
            if (tbox66.Text.Length == 0) tbox66.ForeColor = lösungsFarbe;
            if (tbox67.Text.Length == 0) tbox67.ForeColor = lösungsFarbe;
            if (tbox68.Text.Length == 0) tbox68.ForeColor = lösungsFarbe;
            if (tbox69.Text.Length == 0) tbox69.ForeColor = lösungsFarbe;
            if (tbox71.Text.Length == 0) tbox71.ForeColor = lösungsFarbe;
            if (tbox72.Text.Length == 0) tbox72.ForeColor = lösungsFarbe;
            if (tbox73.Text.Length == 0) tbox73.ForeColor = lösungsFarbe;
            if (tbox74.Text.Length == 0) tbox74.ForeColor = lösungsFarbe;
            if (tbox75.Text.Length == 0) tbox75.ForeColor = lösungsFarbe;
            if (tbox76.Text.Length == 0) tbox76.ForeColor = lösungsFarbe;
            if (tbox77.Text.Length == 0) tbox77.ForeColor = lösungsFarbe;
            if (tbox78.Text.Length == 0) tbox78.ForeColor = lösungsFarbe;
            if (tbox79.Text.Length == 0) tbox79.ForeColor = lösungsFarbe;
            if (tbox81.Text.Length == 0) tbox81.ForeColor = lösungsFarbe;
            if (tbox82.Text.Length == 0) tbox82.ForeColor = lösungsFarbe;
            if (tbox83.Text.Length == 0) tbox83.ForeColor = lösungsFarbe;
            if (tbox84.Text.Length == 0) tbox84.ForeColor = lösungsFarbe;
            if (tbox85.Text.Length == 0) tbox85.ForeColor = lösungsFarbe;
            if (tbox86.Text.Length == 0) tbox86.ForeColor = lösungsFarbe;
            if (tbox87.Text.Length == 0) tbox87.ForeColor = lösungsFarbe;
            if (tbox88.Text.Length == 0) tbox88.ForeColor = lösungsFarbe;
            if (tbox89.Text.Length == 0) tbox89.ForeColor = lösungsFarbe;
            if (tbox91.Text.Length == 0) tbox91.ForeColor = lösungsFarbe;
            if (tbox92.Text.Length == 0) tbox92.ForeColor = lösungsFarbe;
            if (tbox93.Text.Length == 0) tbox93.ForeColor = lösungsFarbe;
            if (tbox94.Text.Length == 0) tbox94.ForeColor = lösungsFarbe;
            if (tbox95.Text.Length == 0) tbox95.ForeColor = lösungsFarbe;
            if (tbox96.Text.Length == 0) tbox96.ForeColor = lösungsFarbe;
            if (tbox97.Text.Length == 0) tbox97.ForeColor = lösungsFarbe;
            if (tbox98.Text.Length == 0) tbox98.ForeColor = lösungsFarbe;
            if (tbox99.Text.Length == 0) tbox99.ForeColor = lösungsFarbe;
        }

        private void felderMitWertenFüllen()
        {
            tbox11.Text = meinBrett.GetWert(1,1).ToString();
            tbox12.Text = meinBrett.GetWert(1,2).ToString();
            tbox13.Text = meinBrett.GetWert(1,3).ToString();
            tbox14.Text = meinBrett.GetWert(1,4).ToString();
            tbox15.Text = meinBrett.GetWert(1,5).ToString();
            tbox16.Text = meinBrett.GetWert(1,6).ToString();
            tbox17.Text = meinBrett.GetWert(1,7).ToString();
            tbox18.Text = meinBrett.GetWert(1,8).ToString();
            tbox19.Text = meinBrett.GetWert(1,9).ToString();
            tbox21.Text = meinBrett.GetWert(2,1).ToString();
            tbox22.Text = meinBrett.GetWert(2,2).ToString();
            tbox23.Text = meinBrett.GetWert(2,3).ToString();
            tbox24.Text = meinBrett.GetWert(2,4).ToString();
            tbox25.Text = meinBrett.GetWert(2,5).ToString();
            tbox26.Text = meinBrett.GetWert(2,6).ToString();
            tbox27.Text = meinBrett.GetWert(2,7).ToString();
            tbox28.Text = meinBrett.GetWert(2,8).ToString();
            tbox29.Text = meinBrett.GetWert(2,9).ToString();
            tbox31.Text = meinBrett.GetWert(3,1).ToString();
            tbox32.Text = meinBrett.GetWert(3,2).ToString();
            tbox33.Text = meinBrett.GetWert(3,3).ToString();
            tbox34.Text = meinBrett.GetWert(3,4).ToString();
            tbox35.Text = meinBrett.GetWert(3,5).ToString();
            tbox36.Text = meinBrett.GetWert(3,6).ToString();
            tbox37.Text = meinBrett.GetWert(3,7).ToString();
            tbox38.Text = meinBrett.GetWert(3,8).ToString();
            tbox39.Text = meinBrett.GetWert(3,9).ToString();
            tbox41.Text = meinBrett.GetWert(4,1).ToString();
            tbox42.Text = meinBrett.GetWert(4,2).ToString();
            tbox43.Text = meinBrett.GetWert(4,3).ToString();
            tbox44.Text = meinBrett.GetWert(4,4).ToString();
            tbox45.Text = meinBrett.GetWert(4,5).ToString();
            tbox46.Text = meinBrett.GetWert(4,6).ToString();
            tbox47.Text = meinBrett.GetWert(4,7).ToString();
            tbox48.Text = meinBrett.GetWert(4,8).ToString();
            tbox49.Text = meinBrett.GetWert(4,9).ToString();
            tbox51.Text = meinBrett.GetWert(5,1).ToString();
            tbox52.Text = meinBrett.GetWert(5,2).ToString();
            tbox53.Text = meinBrett.GetWert(5,3).ToString();
            tbox54.Text = meinBrett.GetWert(5,4).ToString();
            tbox55.Text = meinBrett.GetWert(5,5).ToString();
            tbox56.Text = meinBrett.GetWert(5,6).ToString();
            tbox57.Text = meinBrett.GetWert(5,7).ToString();
            tbox58.Text = meinBrett.GetWert(5,8).ToString();
            tbox59.Text = meinBrett.GetWert(5,9).ToString();
            tbox61.Text = meinBrett.GetWert(6,1).ToString();
            tbox62.Text = meinBrett.GetWert(6,2).ToString();
            tbox63.Text = meinBrett.GetWert(6,3).ToString();
            tbox64.Text = meinBrett.GetWert(6,4).ToString();
            tbox65.Text = meinBrett.GetWert(6,5).ToString();
            tbox66.Text = meinBrett.GetWert(6,6).ToString();
            tbox67.Text = meinBrett.GetWert(6,7).ToString();
            tbox68.Text = meinBrett.GetWert(6,8).ToString();
            tbox69.Text = meinBrett.GetWert(6,9).ToString();
            tbox71.Text = meinBrett.GetWert(7,1).ToString();
            tbox72.Text = meinBrett.GetWert(7,2).ToString();
            tbox73.Text = meinBrett.GetWert(7,3).ToString();
            tbox74.Text = meinBrett.GetWert(7,4).ToString();
            tbox75.Text = meinBrett.GetWert(7,5).ToString();
            tbox76.Text = meinBrett.GetWert(7,6).ToString();
            tbox77.Text = meinBrett.GetWert(7,7).ToString();
            tbox78.Text = meinBrett.GetWert(7,8).ToString();
            tbox79.Text = meinBrett.GetWert(7,9).ToString();
            tbox81.Text = meinBrett.GetWert(8,1).ToString();
            tbox82.Text = meinBrett.GetWert(8,2).ToString();
            tbox83.Text = meinBrett.GetWert(8,3).ToString();
            tbox84.Text = meinBrett.GetWert(8,4).ToString();
            tbox85.Text = meinBrett.GetWert(8,5).ToString();
            tbox86.Text = meinBrett.GetWert(8,6).ToString();
            tbox87.Text = meinBrett.GetWert(8,7).ToString();
            tbox88.Text = meinBrett.GetWert(8,8).ToString();
            tbox89.Text = meinBrett.GetWert(8,9).ToString();
            tbox91.Text = meinBrett.GetWert(9,1).ToString();
            tbox92.Text = meinBrett.GetWert(9,2).ToString();
            tbox93.Text = meinBrett.GetWert(9,3).ToString();
            tbox94.Text = meinBrett.GetWert(9,4).ToString();
            tbox95.Text = meinBrett.GetWert(9,5).ToString();
            tbox96.Text = meinBrett.GetWert(9,6).ToString();
            tbox97.Text = meinBrett.GetWert(9,7).ToString();
            tbox98.Text = meinBrett.GetWert(9,8).ToString();
            tbox99.Text = meinBrett.GetWert(9,9).ToString();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            feldvordergrundfarbeAufSchwarz();
            feldinhaltLöschen();
        }
    }
}