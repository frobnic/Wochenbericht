using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Wochenbericht
{
    class Program
    {
        static void Main(string[] args)
        {

            // https://hope-this-helps.de/serendipity/archives/PDFtk-PDF-Formulare-automatisch-befuellen-426.html
            // 

            /*
             * prüfen, ob FDF-Datei existiert, sonst ggf. erstellen mit
             * pdftk FORMULAR.pdf generate_fdf output FORMULAR.fdf
             * 
             */

            string wd  = "d:\\fb\\source\\repos\\Wochenbericht\\";
            string pdffile = wd + "Wochenbericht.pdf";
            string fdffile = wd + "Wochenbericht.fdf";
            string outfile = wd + "Wochenbericht_generiert.fdf";

            string fdf_head = "%FDF-1.2\n%âãÏÓ\n1 0 obj\n<<\n/FDF\n<<\n/Fields[\n";
            string fdf_tail = "]\n>>\n>>\nendobj\ntrailer\n\n<<\n/Root 1 0 R\n>>\n%% EOF";

            Console.WriteLine(pdffile + "generate_fdf output " + fdffile);
            /*
            CWD = System.Environment.CurrentDirectory;

            Console.Write("Current Working Directory: ");
            Console.WriteLine(CWD);
            */

            Process P = new Process();
            P.StartInfo.FileName = "pdftk";
            P.StartInfo.Arguments = pdffile + " generate_fdf output " + fdffile;
            P.Start();


            /*
/T (Jahr)
/T (Gesamt stundenRow6)
/T (Ausgeführte Arbeiten Urlaub Unterricht Unterweisungen uswRow19)
/T (Gesamt stundenRow1)
/T (Ausgeführte Arbeiten Urlaub Unterricht Unterweisungen uswRow18)
/T (Ausgef�hrte Arbeiten Urlaub Unterricht Unterweisungen uswRow17)
/T (Ausgef�hrte Arbeiten Urlaub Unterricht Unterweisungen uswRow16)
/T (Ausgef�hrte Arbeiten Urlaub Unterricht Unterweisungen uswRow15)
/T (Name)
/T (Ausgef�hrte Arbeiten Urlaub Unterricht Unterweisungen uswRow14)
/T (Gesamt stundenWochenstunden)
/T (Ausgef�hrte Arbeiten Urlaub Unterricht Unterweisungen uswRow13)
/T (Ausgef�hrte Arbeiten Urlaub Unterricht Unterweisungen uswRow12)
/T (bis)
/T (Ausgef�hrte Arbeiten Urlaub Unterricht Unterweisungen uswRow11)
/T (Gesamt stundenRow16)
/T (Ausgef�hrte Arbeiten Urlaub Unterricht Unterweisungen uswRow10)
/T (Gesamt stundenRow11)
/T (Datum)
/T (Ausgef�hrte Arbeiten Urlaub Unterricht Unterweisungen uswRow9)
/T (Ausgef�hrte Arbeiten Urlaub Unterricht Unterweisungen uswRow8)
/T (Ausgef�hrte Arbeiten Urlaub Unterricht Unterweisungen uswRow7)
/T (Ausgef�hrte Arbeiten Urlaub Unterricht Unterweisungen uswRow6)
/T (Ausgef�hrte Arbeiten Urlaub Unterricht Unterweisungen uswRow5)
/T (Ausgef�hrte Arbeiten Urlaub Unterricht Unterweisungen uswRow4)
/T (Ausgef�hrte Arbeiten Urlaub Unterricht Unterweisungen uswRow3)
/T (Ausgef�hrte Arbeiten Urlaub Unterricht Unterweisungen uswRow2)
/T (Ausgef�hrte Arbeiten Urlaub Unterricht Unterweisungen uswRow1)
/T (Ausgef�hrte Arbeiten Urlaub Unterricht Unterweisungen uswRow25)
/T (Ausgef�hrte Arbeiten Urlaub Unterricht Unterweisungen uswRow24)
/T (Ausgef�hrte Arbeiten Urlaub Unterricht Unterweisungen uswRow23)
/T (Ausgef�hrte Arbeiten Urlaub Unterricht Unterweisungen uswRow22)
/T (Fachbereich)
/T (FachinformatikerWoche vom)
/T (Ausgef�hrte Arbeiten Urlaub Unterricht Unterweisungen uswRow21)
/T (Ausgef�hrte Arbeiten Urlaub Unterricht Unterweisungen uswRow20)
/T (Gesamt stundenRow21)

            */
        }
    }
}
