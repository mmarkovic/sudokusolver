using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SudokuSolver
{
    class cSudokusolver
    {
        Feldm�glichkeiten feldm�glichkeiten;
        Sudokubrett brett;

        /// <summary>
        /// Konstruktor
        /// </summary>
        public cSudokusolver(ref Sudokubrett brett)
        {
            this.feldm�glichkeiten = new Feldm�glichkeiten();
            this.brett = brett;
        }

        /// <summary>
        /// Zugriffsoperator f�r das Brett
        /// </summary>
        public Sudokubrett L�sungsbrett
        {
            get
            {
                return this.brett;
            }
        }

        /// <summary>
        /// Entfernt alle Feldm�glichkeiten f�r bereits vordefinierte Werte
        /// </summary>
        private void m�glichkeitenF�rBesetzteFelderL�schen()
        {
            for (int x = 1; x <= 9; x++)
            {
                for (int y = 1; y <= 9; y++)
                {
                    if (brett.GetWert(x, y) != -1)
                    {
                        feldm�glichkeiten.AlleWerteAbziehen(x, y);
                    }
                }
            }
        }

        /// <summary>
        /// L�st das Sudokuproblem. Wenn die Prozedur erfolgreich war, wird true zur�ckgegeben
        /// ansonsten false.
        /// </summary>
        public eL�sungsweg SolveSudoku()
        {
            int kleinsteAnzahlM�glichkeiten = 1;

            do
            {
                m�glichkeitenF�rBesetzteFelderL�schen();

                horizontaleFelderBearbeiten();
                vertikaleFelderBearbeiten();
                quadrantFelderBearbeiten();
                gefundeneWerteAbspeichern();

                kleinsteAnzahlM�glichkeiten = getKleinsteAnzahlM�glichkeiten();
            }
            while(kleinsteAnzahlM�glichkeiten == 1);

            if (brett.IstBrettGel�st())
                return eL�sungsweg.sofort;

            if (l�seSudokuBacktrack())
                return eL�sungsweg.backward;

            return eL�sungsweg.kein;
        }

        /// <summary>
        /// L�st das Sudokuproblem rekursiv.
        /// </summary>
        private bool l�seSudokuBacktrack()
        {
            bool sudokuGel�st = false;
            int xPosition = 0, yPosition = 0;

            setPostionKleinsteAnzM�glichkeiten(ref xPosition, ref yPosition);

            if (xPosition == 0 && yPosition == 0)
                return false;

            ArrayList m�glicheWerte = feldm�glichkeiten.GetM�glicheWerte(xPosition, yPosition);

            for (int i = 0; i < m�glicheWerte.Count; i++)
            {
                Sudokubrett tmpBoard = brett.Kopieren();
                Feldm�glichkeiten tmpPosibilities = feldm�glichkeiten.Kopieren();

                if (setAuswahlWertRekursiv(xPosition, yPosition, (int)m�glicheWerte[i]))
                {
                    sudokuGel�st = true;
                    break;
                }
                else
                {
                    brett = tmpBoard;
                    feldm�glichkeiten = tmpPosibilities;
                    m�glicheWerte = feldm�glichkeiten.GetM�glicheWerte(xPosition, yPosition);
                }
            }

            return sudokuGel�st;
        }

        private bool setAuswahlWertRekursiv(int xPosition, int yPosition, int value)
        {
            int kleinsteAnzahlM�glichkeiten = 1;
            brett.WerteSetzen(xPosition, yPosition, value);

            do 
            {
#if DEBUG
                printDebugBoard();
#endif
                m�glichkeitenF�rBesetzteFelderL�schen();
                horizontaleFelderBearbeiten();
                vertikaleFelderBearbeiten();
                quadrantFelderBearbeiten();
                gefundeneWerteAbspeichern();

                if (!wurdeBrettKorrektAusgef�hlt()) 
                {   return false;
                }

                kleinsteAnzahlM�glichkeiten = getKleinsteAnzahlM�glichkeiten();
            }
            while (kleinsteAnzahlM�glichkeiten == 1);

            if (brett.IstBrettGel�st()) 
            {  return true;
            }
            else 
            {  return l�seSudokuBacktrack();
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
        /// Zieht an einer horizontalen Stelle die �bergebene Zahl aus der Auswahl ab.
        /// </summary>
        private void horizontalZahlabziehen(int abzuziehendeZahl, int zeilennummer)
        {
            // Feld = x
            for (int feld = 1; feld <= 9; feld++)
            {
                if (brett.GetWert(feld, zeilennummer) == -1)
                {
                    feldm�glichkeiten.WertAbziehen(abzuziehendeZahl, feld, zeilennummer);
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
        /// Zieht an einer vertikalen Stelle die �bergebene Zahl aus der Auswahl ab.
        /// </summary>
        private void vertikalZahlabziehen(int abzuziehendeZahl, int spaltennummer)
        {
            // Feld = y
            for (int feld = 1; feld <= 9; feld++)
            {
                if (brett.GetWert(spaltennummer, feld) == -1)
                {
                    feldm�glichkeiten.WertAbziehen(abzuziehendeZahl, spaltennummer, feld);
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
        /// Berechnet die Start- und Grenzwerte f�r den Durchgang der Schlaufen innerhalb
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
                        feldm�glichkeiten.WertAbziehen(abzuziehendeZahl, x, y);
                    }
                }
            }
        }

        /// <summary>
        /// Gibt die kleinste Anzahl M�glichkeiten, welche f�r ein Feld �brig geblieben sind
        /// zur�ck. Felder, die keine weiteren M�glichkeiten haben (sprich = 0), werden NICHT
        /// berr�cksichtigt.
        /// </summary>
        private int getKleinsteAnzahlM�glichkeiten()
        {
            int kleinsteAnzahl = 9;
            int aktuellerWert = 0;

            for (int x = 1; x <= 9; x++)
            {
                for (int y = 1; y <= 9; y++)
                {
                    aktuellerWert = feldm�glichkeiten.GetAnzahlM�glicheWerte(x, y);
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
        /// Auswahlm�glichkeit f�r weitere Z�ge.
        /// </summary>
        private void setPostionKleinsteAnzM�glichkeiten(ref int xPosition, ref int yPosition)
        {
            int anzahlM�glichkeiten = getKleinsteAnzahlM�glichkeiten();

            for (int x = 1; x <= 9; x++)
            {
                for (int y = 1; y <= 9; y++)
                {
                    if (anzahlM�glichkeiten == feldm�glichkeiten.GetAnzahlM�glicheWerte(x, y))
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
                    if (feldm�glichkeiten.GetAnzahlM�glicheWerte(x, y) == 1)
                    {
                        ArrayList al = feldm�glichkeiten.GetM�glicheWerte(x,y);
                        brett.WerteSetzen(x, y, (int)al[0]);
                    }
                }
            }
        }

        /// <summary>
        /// Pr�ft ob das Brett korrekt ausgef�llt wurde.
        /// </summary>
        private bool wurdeBrettKorrektAusgef�hlt()
        {
            return (
                istHorizontaleFolgeKorrekt() &&
                istVertikaleFolgeKorrekt() &&
                istQuadrantFolgeKorrekt()
                );
        }

        /// <summary>
        /// Pr�ft ob alle Reihen konsistent sind
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
        /// Pr�ft ob alle Spalten konsistent sind
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
        /// Pr�ft ob alle Quadranten konsistent sind
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