using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SudokuSolver
{
    class cSudokusolver
    {
        Feldmöglichkeiten feldmöglichkeiten;
        Sudokubrett brett;

        /// <summary>
        /// Konstruktor
        /// </summary>
        public cSudokusolver(ref Sudokubrett brett)
        {
            this.feldmöglichkeiten = new Feldmöglichkeiten();
            this.brett = brett;
        }

        /// <summary>
        /// Zugriffsoperator für das Brett
        /// </summary>
        public Sudokubrett Lösungsbrett
        {
            get
            {
                return this.brett;
            }
        }

        /// <summary>
        /// Entfernt alle Feldmöglichkeiten für bereits vordefinierte Werte
        /// </summary>
        private void möglichkeitenFürBesetzteFelderLöschen()
        {
            for (int x = 1; x <= 9; x++)
            {
                for (int y = 1; y <= 9; y++)
                {
                    if (brett.GetWert(x, y) != -1)
                    {
                        feldmöglichkeiten.AlleWerteAbziehen(x, y);
                    }
                }
            }
        }

        /// <summary>
        /// Löst das Sudokuproblem. Wenn die Prozedur erfolgreich war, wird true zurückgegeben
        /// ansonsten false.
        /// </summary>
        public eLösungsweg SolveSudoku()
        {
            int kleinsteAnzahlMöglichkeiten = 1;

            do
            {
                möglichkeitenFürBesetzteFelderLöschen();

                horizontaleFelderBearbeiten();
                vertikaleFelderBearbeiten();
                quadrantFelderBearbeiten();
                gefundeneWerteAbspeichern();

                kleinsteAnzahlMöglichkeiten = getKleinsteAnzahlMöglichkeiten();
            }
            while(kleinsteAnzahlMöglichkeiten == 1);

            if (brett.IstBrettGelöst())
                return eLösungsweg.sofort;

            if (löseSudokuBacktrack())
                return eLösungsweg.backward;

            return eLösungsweg.kein;
        }

        /// <summary>
        /// Löst das Sudokuproblem rekursiv.
        /// </summary>
        private bool löseSudokuBacktrack()
        {
            bool sudokuGelöst = false;
            int xPosition = 0, yPosition = 0;

            setPostionKleinsteAnzMöglichkeiten(ref xPosition, ref yPosition);

            if (xPosition == 0 && yPosition == 0)
                return false;

            ArrayList möglicheWerte = feldmöglichkeiten.GetMöglicheWerte(xPosition, yPosition);

            for (int i = 0; i < möglicheWerte.Count; i++)
            {
                Sudokubrett tmpBoard = brett.Kopieren();
                Feldmöglichkeiten tmpPosibilities = feldmöglichkeiten.Kopieren();

                if (setAuswahlWertRekursiv(xPosition, yPosition, (int)möglicheWerte[i]))
                {
                    sudokuGelöst = true;
                    break;
                }
                else
                {
                    brett = tmpBoard;
                    feldmöglichkeiten = tmpPosibilities;
                    möglicheWerte = feldmöglichkeiten.GetMöglicheWerte(xPosition, yPosition);
                }
            }

            return sudokuGelöst;
        }

        private bool setAuswahlWertRekursiv(int xPosition, int yPosition, int value)
        {
            int kleinsteAnzahlMöglichkeiten = 1;
            brett.WerteSetzen(xPosition, yPosition, value);

            do 
            {
#if DEBUG
                printDebugBoard();
#endif
                möglichkeitenFürBesetzteFelderLöschen();
                horizontaleFelderBearbeiten();
                vertikaleFelderBearbeiten();
                quadrantFelderBearbeiten();
                gefundeneWerteAbspeichern();

                if (!wurdeBrettKorrektAusgefühlt()) 
                {   return false;
                }

                kleinsteAnzahlMöglichkeiten = getKleinsteAnzahlMöglichkeiten();
            }
            while (kleinsteAnzahlMöglichkeiten == 1);

            if (brett.IstBrettGelöst()) 
            {  return true;
            }
            else 
            {  return löseSudokuBacktrack();
            }
        }

#if DEBUG
        private void printDebugBoard()
        {
            for (int y = 1; y <= 9; y++)
            {
                for (int x = 1; x <= 9; x++)
                {
                    int wert = brett.GetWert(x, y);

                    if (wert > 0)
                        System.Diagnostics.Debug.Write(wert.ToString() + " ");
                    else
                        System.Diagnostics.Debug.Write("- ");
                }
                System.Diagnostics.Debug.WriteLine("");
            }
            System.Diagnostics.Debug.WriteLine("--- --- --- ---");
        }
#endif

        /// <summary>
        /// Geht alle horzontaleFelder zur Bearbeitung durch.
        /// </summary>
        private void horizontaleFelderBearbeiten()
        {
            // Zeile = y
            for (int zeile = 1; zeile <= 9; zeile++)
            {
                // Feld = x
                for (int feld = 1; feld <= 9; feld++)
                {
                    if(brett.GetWert(feld,zeile) != -1)
                    {
                        horizontalZahlabziehen(brett.GetWert(feld, zeile), zeile);
                    }
                }
            }
        }

        /// <summary>
        /// Zieht an einer horizontalen Stelle die übergebene Zahl aus der Auswahl ab.
        /// </summary>
        private void horizontalZahlabziehen(int abzuziehendeZahl, int zeilennummer)
        {
            // Feld = x
            for (int feld = 1; feld <= 9; feld++)
            {
                if (brett.GetWert(feld, zeilennummer) == -1)
                {
                    feldmöglichkeiten.WertAbziehen(abzuziehendeZahl, feld, zeilennummer);
                }
            }
        }

        /// <summary>
        /// Geht alle vertikale Felder zur Bearbeitung durch.
        /// </summary>
        private void vertikaleFelderBearbeiten()
        {
            // Spalte = x
            for (int spalte = 1; spalte <= 9; spalte++)
            {
                // Feld = y
                for (int feld = 1; feld <= 9; feld++)
                {
                    if (brett.GetWert(spalte, feld) != -1)
                    {
                        vertikalZahlabziehen(brett.GetWert(spalte, feld), spalte);
                    }
                }
            }
        }

        /// <summary>
        /// Zieht an einer vertikalen Stelle die übergebene Zahl aus der Auswahl ab.
        /// </summary>
        private void vertikalZahlabziehen(int abzuziehendeZahl, int spaltennummer)
        {
            // Feld = y
            for (int feld = 1; feld <= 9; feld++)
            {
                if (brett.GetWert(spaltennummer, feld) == -1)
                {
                    feldmöglichkeiten.WertAbziehen(abzuziehendeZahl, spaltennummer, feld);
                }
            }
        }

        /// <summary>
        /// Geht alle Felder innerhalb eines Quadranten zur Bearbeitung durch.
        /// </summary>
        private void quadrantFelderBearbeiten()
        {
            for(int quadrant =1 ; quadrant <= 9; quadrant++)
            {
                int startX = 0, startY = 0, stopX = 0, stopY = 0;
                schlaufenlimitSetzen(quadrant, ref startX, ref stopX, ref startY, ref stopY);

                for (int x = startX; x <= stopX; x++)
                {
                    for (int y = startY; y <= stopY; y++)
                    {
                        if (brett.GetWert(x, y) != -1)
                        {
                            quadrantZahlabziehen(brett.GetWert(x, y), quadrant);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Berechnet die Start- und Grenzwerte für den Durchgang der Schlaufen innerhalb
        /// eines Quadranten
        /// </summary>
        private void schlaufenlimitSetzen(int quadrant, ref int startX, ref int stopX,
            ref int startY, ref int stopY)
        {
            if (quadrant % 3 > 0)
            {
                startX = 1 + (quadrant % 3 - 1) * 3;
                stopX = startX + 2;
            }
            else
            {
                startX = 7;
                stopX = 9;
            }

            switch (quadrant)
            {
                case 1: case 2: case 3:
                    startY = 1;
                    stopY = 3;
                    break;

                case 4: case 5: case 6:
                    startY = 4;
                    stopY = 6;
                    break;

                case 7: case 8: case 9:
                    startY = 7;
                    stopY = 9;
                    break;
            }
        }

        /// <summary>
        /// Zieht eine Zahl aus der Auswahl eines Quadranten ab. Die Quadranten sind wie folgt
        /// geordnet:
        /// 1 2 3
        /// 4 5 6
        /// 7 8 9
        /// </summary>
        private void quadrantZahlabziehen(int abzuziehendeZahl, int quadrantennummer)
        {
            int startX = 0, startY = 0, stopX = 0, stopY = 0;
            schlaufenlimitSetzen(quadrantennummer, ref startX, ref stopX, ref startY, ref stopY);

            for (int x = startX; x <= stopX; x++)
            {
                for (int y = startY; y <= stopY; y++)
                {
                    if (brett.GetWert(x, y) == -1)
                    {
                        feldmöglichkeiten.WertAbziehen(abzuziehendeZahl, x, y);
                    }
                }
            }
        }

        /// <summary>
        /// Gibt die kleinste Anzahl Möglichkeiten, welche für ein Feld übrig geblieben sind
        /// zurück. Felder, die keine weiteren Möglichkeiten haben (sprich = 0), werden NICHT
        /// berrücksichtigt.
        /// </summary>
        private int getKleinsteAnzahlMöglichkeiten()
        {
            int kleinsteAnzahl = 9;
            int aktuellerWert = 0;

            for (int x = 1; x <= 9; x++)
            {
                for (int y = 1; y <= 9; y++)
                {
                    aktuellerWert = feldmöglichkeiten.GetAnzahlMöglicheWerte(x, y);
                    if (aktuellerWert > 0 && aktuellerWert < kleinsteAnzahl)
                    {
                        kleinsteAnzahl = aktuellerWert;
                    }
                }
            }

            return kleinsteAnzahl;
        }

        /// <summary>
        /// Setzt die X- und Y-Koordinaten des Feldes mit der Anzahl
        /// Auswahlmöglichkeit für weitere Züge.
        /// </summary>
        private void setPostionKleinsteAnzMöglichkeiten(ref int xPosition, ref int yPosition)
        {
            int anzahlMöglichkeiten = getKleinsteAnzahlMöglichkeiten();

            for (int x = 1; x <= 9; x++)
            {
                for (int y = 1; y <= 9; y++)
                {
                    if (anzahlMöglichkeiten == feldmöglichkeiten.GetAnzahlMöglicheWerte(x, y))
                    {
                        xPosition = x;
                        yPosition = y;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Speichert definitive Werte ins Brett ab.
        /// </summary>
        private void gefundeneWerteAbspeichern()
        {
            for (int x = 1; x <= 9; x++)
            {
                for (int y = 1; y <= 9; y++)
                {
                    if (feldmöglichkeiten.GetAnzahlMöglicheWerte(x, y) == 1)
                    {
                        ArrayList al = feldmöglichkeiten.GetMöglicheWerte(x,y);
                        brett.WerteSetzen(x, y, (int)al[0]);
                    }
                }
            }
        }

        /// <summary>
        /// Prüft ob das Brett korrekt ausgefüllt wurde.
        /// </summary>
        private bool wurdeBrettKorrektAusgefühlt()
        {
            return (
                istHorizontaleFolgeKorrekt() &&
                istVertikaleFolgeKorrekt() &&
                istQuadrantFolgeKorrekt()
                );
        }

        /// <summary>
        /// Prüft ob alle Reihen konsistent sind
        /// </summary>
        private bool istHorizontaleFolgeKorrekt()
        {
            for (int x = 1; x <= 9; x++)
            {
                int aktuellerWert = 0;
                bool[] belegtezahlen = new bool[9];

                for(int i = 0; i < 9; i++)
                    belegtezahlen[i] = false;

                for (int y = 1; y <= 9; y++)
                {
                    aktuellerWert = brett.GetWert(x, y);
                    if (aktuellerWert != -1)
                    {
                        if (belegtezahlen[aktuellerWert-1])
                            return false;
                        else
                            belegtezahlen[aktuellerWert-1] = true;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Prüft ob alle Spalten konsistent sind
        /// </summary>
        private bool istVertikaleFolgeKorrekt()
        {
            for (int y = 1; y <= 9; y++)
            {
                int aktuellerWert = 0;
                bool[] belegtezahlen = new bool[9];

                for (int i = 0; i < 9; i++)
                    belegtezahlen[i] = false;

                for (int x = 1; x <= 9; x++)
                {
                    aktuellerWert = brett.GetWert(x, y);
                    if (aktuellerWert != -1)
                    {
                        if (belegtezahlen[aktuellerWert-1])
                            return false;
                        else
                            belegtezahlen[aktuellerWert-1] = true;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Prüft ob alle Quadranten konsistent sind
        /// </summary>
        private bool istQuadrantFolgeKorrekt()
        {
            for (int quadrantennummer = 1; quadrantennummer <= 9; quadrantennummer++)
            {
                int startX = 0, startY = 0, stopX = 0, stopY = 0;
                schlaufenlimitSetzen(quadrantennummer, ref startX, ref stopX, ref startY, ref stopY);

                for (int x = startX; x <= stopX; x++)
                {
                    int aktuellerWert = 0;
                    bool[] belegtezahlen = new bool[9];

                    for (int i = 0; i < 9; i++)
                        belegtezahlen[i] = false;

                    for (int y = startY; y <= stopY; y++)
                    {
                        aktuellerWert = brett.GetWert(x, y);
                        if (aktuellerWert != -1)
                        {
                            if (belegtezahlen[aktuellerWert-1])
                                return false;
                            else
                                belegtezahlen[aktuellerWert-1] = true;
                        }
                    }
                }
            }

            return true;
        }
    }
}