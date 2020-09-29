using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuSolver
{
    enum eLösungsweg
    {
        /// <summary>
        /// Trifft zu, wenn keine Lösung gefunden wurde
        /// </summary>
        kein,

        /// <summary>
        /// Tifft zu, wenn eine Lösung ohne Backwarding gefunden
        /// werden konnte.
        /// </summary>
        sofort,

        /// <summary>
        /// Trifft zu, wenn eine Lösung mittels Backwarding gefunden
        /// wurde.
        /// </summary>
        backward
    }
}
