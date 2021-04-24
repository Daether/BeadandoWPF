using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando
{/// <summary>
/// Számla adatait leíró osztály
/// </summary>
    class Invoice
    {
        /// <summary>
        /// A számla tulaj neve
        /// </summary>
        /// <value>
        /// String értéket tartalmazó változó.
        /// </value>
        public string OwnerName { get; set; }
        /// <summary>
        /// A számla egyenlege
        /// </summary>
        /// <value>
        /// Int értéket tartalmazó változó, alapértelmezett értéke 0.
        /// </value>
        public int Balance { get; set; } = 0;
        /// <summary>
        /// Üres konstruktor
        /// </summary>
        public Invoice() { }
    }
}
