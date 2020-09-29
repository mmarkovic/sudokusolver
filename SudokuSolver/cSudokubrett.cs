using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SudokuSolver
{
    class Sudokubrett
    {
        int[,] brett;

        /// <summary>
        /// Konstruktor
        /// </summary>
        public Sudokubrett()
        {
            brett = new int[9, 9];
            ausgangspositionErstellen();
        }

        /// <summary>
        /// Setzt alle Werte auf -1
        /// </summary>
        private void ausgangspositionErstellen()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int k = 0; k < 9; k++)
                {
                    brett[i, k] = -1;
                }
            }
        }

        /// <summary>
        /// Setzt einen Wert an einer definierten Position
        /// </summary>
        public void WerteSetzen(int xPosition, int yPosition, int wert)
        {
            if (xPosition <= 9 && xPosition > 0 &&
                yPosition <= 9 && yPosition > 0 &&
                (wert <= 9 && wert > 0) || (wert == -1))
            {
                brett[xPosition-1, yPosition-1] = wert;
            }
            else
            {
                throw new ArgumentException("Ungültige Parameter für Wertdefinition.");
            }
        }

        /// <summary>
        /// Gibt den Wert einer Position zurück. -1 bedeutet dabei leer.
        /// </summary>
        public int GetWert(int xPosition, int yPosition)
        {
            if (xPosition <= 9 && xPosition > 0 &&
                yPosition <= 9 && yPosition > 0)
            {
                return brett[xPosition-1, yPosition-1];
            }
            else
            {
                throw new ArgumentException("Ungültige Parameter für Werterückgabe.");
            }
        }
        
        /// <summary>
        /// Gibt an ob das Brett gelöst wurde. Trifft zu wenn alle Felder einen Wert haben.
        /// </summary>
        public bool IstBrettGelöst()
        {
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    if (brett[x, y] == -1)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Gibt eine Kopie des Sudokubretts zurück.
        /// </summary>
        public Sudokubrett Kopieren()
        {
            Sudokubrett kopie = new Sudokubrett();

            for (int x = 1; x <= 9; x++)
            {
                for (int y = 1; y <= 9; y++)
                {
                    kopie.WerteSetzen(x,y, this.GetWert(x,y));
                }
            }

            return kopie;
        }
    }
}