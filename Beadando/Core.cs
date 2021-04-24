using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Beadando
{/// <summary>
/// Műveleteket tartalmazó osztály
/// </summary>
    public class Core
    {
        /// <summary>
        /// Üres konstruktor
        /// </summary>
        public Core() { }
        /// <summary>
        /// segédváltozó metódus returnhez
        /// </summary>
        int ertek = 0;

        //Invoice i = new Invoice();

        /// <summary>
        /// Feltöltés a beírt értékkel a számla egyenlegére
        /// </summary>
        /// <param name="e1">érték1:amit hozzáadunk az egyenleghez</param>
        /// <param name="e2">érték2:az egyenleg jelenlegi értéke</param>
        /// <returns>A két érték összegével tér vissza(int).</returns>
        public int Feltolt(string e1, string e2)
        {
            
            if (e1 == "")
            {
               return ertek=-1;
            }
                int sz1 = Convert.ToInt32(e1);
                int sz2 = Convert.ToInt32(e2);
            if (sz1 >= 0)
            {
                ertek = sz1 + sz2;
                return ertek;
            }

            else {return ertek=-1; }
        }
        /// <summary>
        /// Beírt érték kivétele a számla egyenlegről.
        /// </summary>
        /// <param name="ossz">Egyenleg, amiből kivonunk</param>
        /// <param name="kivon">Beírt szám, amit kivonunk</param>
        /// <returns>A kivonás erredményével tér vissza(int).</returns>
        public int Kivesz(string ossz, string kivon)
        {
            if (kivon == "")
            {
                return ertek = -1;
            }
            
            int SzOssz = Convert.ToInt32(ossz);
            int SzKivon = Convert.ToInt32(kivon);

                if (SzOssz >= 0 && SzKivon >= 0)
                {
                ertek = SzOssz - SzKivon;
                return ertek;
                }
                else
                {
                return ertek = -1;
                }

        }

    }
}
