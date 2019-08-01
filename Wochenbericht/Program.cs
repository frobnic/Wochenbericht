using System;
using System.Diagnostics;
using System.IO;

namespace Wochenbericht
{
    class Program
    {
        static void Main(string[] args)
        {
            // https://hope-this-helps.de/serendipity/archives/PDFtk-PDF-Formulare-automatisch-befuellen-426.html

            string cwd;
            string wd = "d:\\fb\\source\\repos\\Wochenbericht\\";
            string pdffile = wd + "Wochenbericht.pdf";
            string fdffile = wd + "Wochenbericht.fdf";
            string outfile = wd + "Wochenbericht_generiert.pdf";

            string fdf_head = "%FDF-1.2\n%âãÏÓ\n1 0 obj\n<<\n/FDF\n<<\n/Fields[\n";
            string fdf_tail = "]\n>>\n>>\nendobj\ntrailer\n\n<<\n/Root 1 0 R\n>>\n%% EOF";
            

            Console.WriteLine("Starting Wochenbericht");

            /*
            cwd = System.Environment.CurrentDirectory;
            Console.Write("Current Working Directory: ");
            Console.WriteLine(cwd);
            */

            // prüfen, ob FDF-Datei existiert, sonst ggf. erstellen
            if (! File.Exists(fdffile))
            {
                //  pdftk FORMULAR.pdf generate_fdf output FORMULAR.fdf
                Process P = new Process();
                P.StartInfo.FileName = "pdftk";
                P.StartInfo.Arguments = pdffile + " generate_fdf output " + fdffile;
                P.Start();
                P.WaitForExit();
                Console.WriteLine("Created FDF" + fdffile);
            }

            // file format: header, repeat "<< /T (fieldname) /V (content) >>", footer

            string jahr = "<< /T (Jahr) /V (2019) >>\n";
            jahr += "<</T (Name) /V (Paulsen, Frank)>>\n";
            jahr += "<</T (Gesamt stundenRow6) /V (10)>>\n";
            /*
            jahr += "<</T(Gesamt stundenRow16) /V (10)>>\n";
            jahr += "<</T(Gesamt stundenRow11) /V (10)>>\n";
            jahr += "<</T(Gesamt stundenRow21) /V (10)>>\n";
            */

            System.IO.File.WriteAllText(fdffile, fdf_head + jahr + fdf_tail);
            
            // pdftk FORMULAR.pdf fill_form FORMULAR.fdf output FORMULAR_FERTIG.pdf
            Process Q = new Process();
            Q.StartInfo.FileName = "pdftk";
            Q.StartInfo.Arguments = pdffile + " fill_form " + fdffile + " output " + outfile;
            Q.Start();
            Q.WaitForExit();
            Console.WriteLine("Created OUTPUT" + outfile);

            Q.StartInfo.FileName = outfile;
            Q.Start();
            Q.WaitForExit();

            /*
/T (Ausgeführte Arbeiten Urlaub Unterricht Unterweisungen uswRow19)
/T (Gesamt stundenRow1)
/T (Ausgeführte Arbeiten Urlaub Unterricht Unterweisungen uswRow18)
/T (Ausgef�hrte Arbeiten Urlaub Unterricht Unterweisungen uswRow17)
/T (Ausgef�hrte Arbeiten Urlaub Unterricht Unterweisungen uswRow16)
/T (Ausgef�hrte Arbeiten Urlaub Unterricht Unterweisungen uswRow15)
/T (Ausgef�hrte Arbeiten Urlaub Unterricht Unterweisungen uswRow14)
/T (Gesamt stundenWochenstunden)
/T (Ausgef�hrte Arbeiten Urlaub Unterricht Unterweisungen uswRow13)
/T (Ausgef�hrte Arbeiten Urlaub Unterricht Unterweisungen uswRow12)
/T (bis)
/T(Datum)
/T (Ausgef�hrte Arbeiten Urlaub Unterricht Unterweisungen uswRow11)
/T (Ausgef�hrte Arbeiten Urlaub Unterricht Unterweisungen uswRow10)
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

            */
        }
    }
}
