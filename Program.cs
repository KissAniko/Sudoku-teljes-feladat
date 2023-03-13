using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudokuCLI_II
{
    internal class Program
    {
        static void Main(string[] args)


        /* 3. Olvassa be a feladvanyok.txt állományban lévő adatokat és tárolja el egy olyan
          adatszerkezetben, ami a további feladatok megoldására alkalmas! Határozza meg és írja ki
          a képernyőre a minta szerint, hogy hány feladvány található a forrásállományban! */
        {
            List<Feladvany> feladvanyok = new List<Feladvany>();
            StreamReader sr = new StreamReader("feladvanyok.txt");
            while (!sr.EndOfStream)
            {
                Feladvany uj = new Feladvany(sr.ReadLine());
                feladvanyok.Add(uj);
            }
            sr.Close();
            Console.WriteLine($" 3. feladat: Beolvasva {feladvanyok.Count} feladvány.");

            //----------------------------------------------------------------------------------------------------

            /* 4. feladat: Kérjen be a felhasználótól egy 4...9 intervallumba eső(4≤x≤9) egész számot!
                           A beolvasást addig ismételje, amíg a megfelelő értékhatárból érkező számot nem kapjuk!

                           Határozza meg,és írja a képernyőre, hogy ebből a méretből hányfeladvány található 
                           a forrásállományban!  */
                         
            int meret;
            do
            {
                Console.Write($"4. Feladat: Kérem a feladvány méretét [4..9]:");
                meret = int.Parse(Console.ReadLine());
            }
            while (meret < 4 || meret > 9);

            /*

            int feladvanyokSzama = 0;
            for (int i = 0; i < feladvanyok.Count; i++)
            {
                if (feladvanyok[i].Meret == meret)
                {
                    feladvanyokSzama++;
                }
            }
            Console.WriteLine($"{meret}*{meret} méretű feladványból {feladvanyokSzama} db van tárolva.");  */

            List<Feladvany> kivalogatottak = new List<Feladvany>();
            foreach (var vizsgaltFeladvany in feladvanyok)
            {
                if (vizsgaltFeladvany.Meret == meret)
                {
                    kivalogatottak.Add(vizsgaltFeladvany);
                }
            }
            Console.WriteLine($"{meret}x{meret} méretű feladványból {kivalogatottak.Count} darab van tárolva");


            //---------------------------------------------------------------------------------------------------------------

            Console.WriteLine();
            /* 6. feladat: Válasszon ki véletlenszerűen egy feladványt, amely az előző feladatban bekért méretű!
                           A kiválasztott feladványt jelenítse meg a képernyőn a minta szerint!Ha nem sikerült
                           véletlenszerű feladványt kiválasztani, akkor dolgozzon a legelső beolvasott feladvánnyal! */

            Random rnd = new Random();


            Feladvany kivalasztott;

            kivalasztott = feladvanyok[rnd.Next(feladvanyok.Count)];

            //Ha nem menne a Random
            //kivalasztott = feladvanyok[0];

            Console.WriteLine(kivalasztott.Kezdo);
            //kivalasztott.Kirajzol();

//---------------------------------------------------------------------------------------------------------------------------

            /* 6. feladat: Határozza meg és írja a képernyőre a kiválasztott feladvány kitöltöttségét % -os formában
                           a minta szerint!
                           A kitöltöttségen a kitöltött mezők arányát értjük az összes mező számához
                           viszonyítva! A százalékos értéket egész számra kerekítve jelenítse meg!  */

            Console.WriteLine() ;

            double kitoltottek = 0;
            for (int i = 0; i < kivalasztott.Kezdo.Length; i++)
            {
                if (kivalasztott.Kezdo[i] != '0')
                {
                    kitoltottek++;
                }
            }
            int szazalek = (int)Math.Round(kitoltottek / kivalasztott.Kezdo.Length * 100);
            Console.WriteLine($"6. feladat: Feladvány kitöltöttsége: {szazalek}%");

//---------------------------------------------------------------------------------------------------------------------------

            /* 7. feladat: A Feladvany osztály megfelelő metódusát felhasználva jelenítse meg a kiválasztott
                           feladványt a konzolon!   */

            Console.WriteLine();
            Console.WriteLine("7.feladat:");
            Console.WriteLine();

            kivalasztott.Kirajzol();

//--------------------------------------------------------------------------------------------------------------------------

            /*  8. feladat: Válogassa ki és írja ki fájlba az adott méretű feladványokat! Ha például a felhasználó a 4 - es
                            méretet adta meg, akkor a kimeneten egy sudoku4.txt állományba kerüljenek a 4x4 - es
                            méretű feladványok!Az állományban soronként egy feladvány kerüljön!  */

            Console.WriteLine();
            Console.WriteLine("8. feladat:");
            Console.WriteLine();

            StreamWriter sw = new StreamWriter("soduku" + meret + ".txt");
            foreach (var feladvany in kivalogatottak)                             
            {
                sw.WriteLine(feladvany.Kezdo);
            }
            sw.Close();
            Console.WriteLine($"sudoku{meret}.txt állomány  {kivalogatottak.Count}db feladvánnyal létrehozva");

            //---------------------------------------------------------------------------------------------------------------------

            /* 9. feladat: Készítsen grafikus alkalmazást a következő feladatok megoldására, amelynek projektjét
                           sudokuGUI néven mentse el!  */
        }
    }
}
