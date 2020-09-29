using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SudokuSolver
{
    class Feldmöglichkeiten
    {
        private ArrayList feldmöglichkeiten;

        /// <summary>
        /// Konstruktor
        /// </summary>
        public Feldmöglichkeiten()
        {
            this.feldmöglichkeiten = new ArrayList();

            for (int i = 0; i < 9; i++)
            {
                this.feldmöglichkeiten.Insert(i, new ArrayList());
                ArrayList al = (ArrayList)feldmöglichkeiten[i];

                for (int j = 0; j < 9; j++)
                {
                    ArrayList al2 = new ArrayList();
                    
                    for(int k=1;k<=9;k++)
                        al2.Add(k);

                    al.Insert(j, al2);
                }
            }
        }

        /// <summary>
        /// Gibt die möglichen Werte eines Felder in einer ArrayListe zurück.
        /// </summary>
        public ArrayList GetMöglicheWerte(int xPosition, int yPosition)
        {
            if (xPosition <= 9 && xPosition > 0 && yPosition <= 9 && yPosition > 0)
            {
                ArrayList al = (ArrayList)feldmöglichkeiten[xPosition-1];
                return (ArrayList)al[yPosition-1];
            }
            else
            {
                throw new ArgumentException("Angegebene Position ungültig");
            }
        }

        /// <summary>
        /// Setzt die übergene Werte in das entsprechende Feld
        /// </summary>
        private void setMöglicheWerte(int xPosition, int yPosition, ArrayList werte)
        {
            ArrayList values = (ArrayList)werte.Clone();

            if (xPosition <= 9 && xPosition > 0 && yPosition <= 9 && yPosition > 0)
            {
                ArrayList al = (ArrayList)feldmöglichkeiten[xPosition - 1];
                al[yPosition - 1] = values;
            }
            else
            {
                throw new ArgumentException("Angegebene Position ungültig");
            }
        }

        /// <summary>
        /// Gibt die Anzahl möglicher Werte eines Feldes zurück.
        /// </summary>
        public int GetAnzahlMöglicheWerte(int xPosition, int yPosition)
        {
            return GetMöglicheWerte(xPosition, yPosition).Count;
        }

        /// <summary>
        /// Zieht von einer bestehenden Auswahl einen spezifischen Wert ab.
        /// </summary>
        public void WertAbziehen(int wert, int xPosition, int yPosition)
        {
            if (xPosition <= 9 && xPosition > 0 && yPosition <= 9 && yPosition > 0)
            {
                ArrayList al = (ArrayList)feldmöglichkeiten[xPosition-1];
                ArrayList feldzahlen = (ArrayList)al[yPosition-1];
                feldzahlen.Remove(wert);
            }
            else
            {
                throw new ArgumentException("Angegebene Position ungültig");
            }
        }

        /// <summary>
        /// Entfernt von einer Position alle möglichen Werte.
        /// </summary>
        /// <param name="xPosition">X Position</param>
        public void AlleWerteAbziehen(int xPosition, int yPosition)
        {
            if (xPosition <= 9 && xPosition > 0 && yPosition <= 9 && yPosition > 0)
            {
                ArrayList al = (ArrayList)feldmöglichkeiten[xPosition - 1];
                ArrayList feldzahlen = (ArrayList)al[yPosition - 1];
                feldzahlen.Clear();
            }
            else
            {
                throw new ArgumentException("Angegebene Position ungültig");
            }
        }

        /// <summary>
        /// Gibt eine Kopie der aktuellen Instanz zurück
        /// </summary>
        public Feldmöglichkeiten Kopieren()
        {
            Feldmöglichkeiten kopie = new Feldmöglichkeiten();

            for (int x = 1; x <= 9; x++)
            {
                for (int y = 1; y <= 9; y++)
                {
                    kopie.setMöglicheWerte(x, y, this.GetMöglicheWerte(x, y));
                }
            }

            return kopie;
        }
    }
}