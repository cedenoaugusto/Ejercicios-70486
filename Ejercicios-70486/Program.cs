using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using OfficeOpenXml;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
//using System.Runtime.Serialization.Formatters.Binary;
using System.Globalization;

//.net 4.5
//System.Web.dll
//MimeMapping.GetMimeMapping Method (String)

//Path.GetExtension(PathToFile)

namespace Ejercicios_70486
{

    public class Program
    {

        public static void Main(string[] args)
        {
            string montoPropuesto="000034388662.00",
                   montoPesos="000000034389.00",
                   plazo="2036",
                   plazoMaximo="1060",
                   tasa="08.00",
                   tasaComision="00.00";

					

            montoPropuesto = montoPropuesto.Replace(",", "").Replace(".", "");
            var longitud = montoPropuesto.Length;
            montoPropuesto = montoPropuesto.Substring(0, longitud - 2) + "." +
                              montoPropuesto.Substring(longitud - 2, 2);

            decimal decMontoPropuesto;
            decimal.TryParse(montoPropuesto, out decMontoPropuesto);

            int codMoneda = 1;
            if (codMoneda == 1)
            {
                montoPropuesto = Math.Round(double.Parse(montoPropuesto), 0).ToString().PadLeft(13, '0') + "00";//<=  MontoFinanciar
                montoPesos = Math.Round(double.Parse(montoPropuesto), 0).ToString().PadLeft(13, '0') + "00"; //<= ContraValor
            }
            else
            {
                montoPropuesto = Math.Round(double.Parse(montoPropuesto), 0).ToString().Replace(".", "").PadLeft(15, '0');
                montoPesos = Math.Round(double.Parse(montoPropuesto), 0).ToString().PadLeft(15, '0');
            }

            if (tasa.Length > 0)
                tasa = tasa.PadLeft(5, '0');


            tasa = tasa.Replace(",", "").Replace(".", "").PadLeft(5, '0');

            tasaComision = tasaComision.Replace(",", "").Replace(".", "").PadLeft(9, '0');

            //var tasaComision = "00.12";

            //var decTasaComision = decimal.Parse(tasaComision.PadRight(10, '0')).ToString().PadLeft(9, '0');


            double decNumero = 878.78;
            var numberString = string.Format(CultureInfo.GetCultureInfo("es-CL"), decNumero.ToString());
            var numberInt = numberString.Replace(",", "");

            #region email
            var bMailValido = IsValidEmail("cedeno.augusto@gmail.com");

            var bMailInValido = IsValidEmail("cedeno.atyrtyrtyugustogmail.com");
            bMailInValido = IsValidEmail("cedeno.atyrtyrtyugustogmail@com");
            #endregion

            #region FormatearNumero
            var bMostrarFormatearNumero = false;
            if (bMostrarFormatearNumero)
            {
                var numero1 = 1233423423423;

                var numero2 = 989867342.3423423;

                Console.WriteLine(String.Format("{0:0.00}", numero1));
                Console.WriteLine(String.Format("{0:0.00}", numero2));
                Console.WriteLine(String.Format("{0:000,000.00}", numero1));
                Console.WriteLine(String.Format("{0:000,000.00}", numero2));
            }
            #endregion

            //CrearArchivo();
            //InsertarEnArchivo("hola");
            //LeerArchivo();

            Console.ReadLine();

            return;

            #region resto de programa
            //string tasa = string.Empty;
            //string nuevovalor;
            //decimal tasaParse = 0;
            //decimal.TryParse(tasa, out tasaParse);
            //nuevovalor = (tasaParse).ToString().PadLeft(4, '0');


            int[] ints = { 10, 45, 15, 39, 21, 26 };
            var result = ints.OrderBy(a => a);
            foreach (var i in result)
            {
                System.Console.Write(i + " ");
            }


            var x = new App();
            App.Principal();

            int codPostal = 8320000;
            uint codPostal2 = 8330132;

            string monto = "1.000,00";
            decimal dMonto = decimal.Parse(monto);
            var montoFormateado = dMonto.ToString("##########.00");

            const int constante = 8;

            //generar el documento
            //convertirlo con este metoodo
            //o
            //invocar el metodo que genera el documento desde el DM. Ojo pero lo guarda?

            //metodo 1
            var ff = File.AppendText("c:\\temp\\ejemplo.txt");
            ff.Close();

            var file = new FileStream("c:\\temp\\ejemplo.txt", FileMode.OpenOrCreate);

            var mem = new MemoryStream();

            file.CopyTo(mem);

            // getting the internal buffer (no additional copying)
            byte[] buffer = mem.GetBuffer();
            long length = mem.Length; // the actual length of the data 
            // (the array may be longer)

            // if you need the array to be exactly as long as the data
            byte[] truncated = mem.ToArray(); // makes another copy
            file.Close();


            //var fil = File.AppendAllText()

            //metodo 2
            var file2 = new FileStream("c:\\temp\\ejemplo.txt", FileMode.Open);
            using (var memoryStream = new MemoryStream())
            {
                file2.CopyTo(memoryStream);
                //file2.Close();
                memoryStream.ToArray(); //<= return this
            }


            var list = new List<string>() { "Cat", "Rat", "Caballo", "Mouse" };
            var l = list.Where(g => g == "Cat");
            Console.WriteLine(list.FirstOrDefault());
            var texto = "fgofkg  ., ogokfgo    t, rrtrrt gggg";
            var arregloCad1 = texto.Split(',');
            var arregloCad2 = texto.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);


            //
            // This query produces no results so FirstOrDefault is null.
            //
            var query1 = from element in list
                         where element.Length > 10
                         select element;
            Console.WriteLine(query1.FirstOrDefault() == null);

            //
            // This query produces one result, so FirstOrDefault is a string.
            //
            var query2 = from element in list
                         where element.Length > 3
                         select element;
            Console.WriteLine(query2.FirstOrDefault());

            //
            // This array has no elements, so FirstOrDefault is zero.
            //
            int[] array = new int[0];
            Console.WriteLine(array.FirstOrDefault());


            //var f = new funciones();
            //f.ConvertWordToPDF();


            //ThreadPoolExample.Metodo();

            //Formatos de numeros: http://www.csharp-examples.net/string-format-double/
            //Console.WriteLine(String.Format("{0:0,0.0}", 12345.67));
            //Console.WriteLine(String.Format("{0:0,0}", 12345.67));
            //Console.WriteLine((19950000.0).ToString("N", new CultureInfo("en-US")));
            //Console.WriteLine(String.Format("{0:0000000.00}", 1456.1293)); //Completa con 0
            //Console.WriteLine(String.Format("{0,10:0.00}", 56.1293)); //Completa con espacios

            //Console.WriteLine(String.Format("{0:0.00;minus 0.00;zero}", 123.4567));   // "123.46"
            //Console.WriteLine(String.Format("{0:0.00;minus 0.00;zero}", -123.4567));  // "minus 123.46"
            //Console.WriteLine(String.Format("{0:0.00;minus 0.00;zero}", 0.0));        // "zero"


            //int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            //int oddNumbers = numbers.Count(n => n % 2 == 1);

            //var firstNumbersLessThan6 = numbers.TakeWhile(n => n < 6);
            //Console.WriteLine(firstNumbersLessThan6);

            //var firstSmallNumbers = numbers.TakeWhile((n, index) => n >= index);

            //string x="A    ", y="a";
            //x = Console.ReadLine();
            //y = Console.ReadLine();

            //Console.Write( 
            //    (string.Compare(x.Trim(), y, StringComparison.OrdinalIgnoreCase) == 0 ? "Igual":"Difer")
            //    );
            #endregion

            Console.WriteLine("Fin.");
            Console.ReadLine();
        }

        public static bool IsValidEmail(string strIn)
        {
            bool invalid = false;
            if (String.IsNullOrEmpty(strIn))
                return false;

            // Use IdnMapping class to convert Unicode domain names.
            try
            {
                string patron =
                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

                invalid = Regex.IsMatch(strIn, patron);
            }
            catch (Exception e)
            {
                return false;
            }
            return invalid;
        }

        public static void CrearArchivo()
        {
            var ruta = System.AppDomain.CurrentDomain.BaseDirectory + "\\log.txt";

            if (!File.Exists(ruta))
            {
                var r = File.Create(ruta);
                r.Close();
            }

        }

        public static void InsertarEnArchivo(string cadena)
        {
            var ruta = System.AppDomain.CurrentDomain.BaseDirectory + "\\log.txt";
            File.AppendAllText(ruta, cadena + " " + System.DateTime.Now.ToString() + Environment.NewLine);
        }

        public static void LeerArchivo()
        {
            var ruta = System.AppDomain.CurrentDomain.BaseDirectory + "\\log.txt";
            var file = new System.IO.StreamReader(ruta);

            string line;

            while ((line = file.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }

            file.Close();
        }
    }


    //class funciones
    //{
    //    public void ConvertWordToPDF()
    //    {
    //        var dir = Directory.GetCurrentDirectory();

    //        // Create a new Microsoft Word application object
    //        Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();

    //        // C# doesn't have optional arguments so we'll need a dummy value
    //        object oMissing = System.Reflection.Missing.Value;

    //        // Get list of Word files in specified directory
    //        DirectoryInfo dirInfo = new DirectoryInfo(@"C:\\Users\\augusto.cedeno\\Desktop\\Google Drive\\Certificacion 70-483\\Ejercicios-70486\\Ejercicios-70486\\archivos");

    //        FileInfo[] wordFiles = dirInfo.GetFiles("TempNotas.doc");

    //        word.Visible = false;
    //        word.ScreenUpdating = false;

    //        var i = 0;

    //        foreach (FileInfo wordFile in wordFiles)
    //        {
    //            // Cast as Object for word Open method
    //            Object filename = (Object)wordFile.FullName;

    //            // Use the dummy value as a placeholder for optional arguments
    //            Document doc = word.Documents.Open(ref filename, ref oMissing,
    //                ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
    //                ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
    //                ref oMissing, ref oMissing, ref oMissing, ref oMissing);
    //            doc.Activate();

    //            object outputFileName = wordFile.FullName.Replace(".doc", ".pdf");
    //            object fileFormat = WdSaveFormat.wdFormatPDF;

    //            // Save document into PDF Format
    //            doc.SaveAs(ref outputFileName,
    //                ref fileFormat, ref oMissing, ref oMissing,
    //                ref oMissing, ref oMissing, ref oMissing, ref oMissing,
    //                ref oMissing, ref oMissing, ref oMissing, ref oMissing,
    //                ref oMissing, ref oMissing, ref oMissing, ref oMissing);

    //            // Close the Word document, but leave the Word application open.
    //            // doc has to be cast to type _Document so that it will find the
    //            // correct Close method.                
    //            object saveChanges = WdSaveOptions.wdDoNotSaveChanges;
    //            ((_Document)doc).Close(ref saveChanges, ref oMissing, ref oMissing);
    //            doc = null;
    //        }

    //        // word has to be cast to type _Application so that it will find
    //        // the correct Quit method.
    //        ((_Application)word).Quit(ref oMissing, ref oMissing, ref oMissing);
    //        word = null;
    //    }
    //}

    public class Fibonacci
    {
        private int _n;
        private int _fibOfN;
        private ManualResetEvent _doneEvent;

        public int N { get { return _n; } }
        public int FibOfN { get { return _fibOfN; } }

        // Constructor. 
        public Fibonacci(int n, ManualResetEvent doneEvent)
        {
            _n = n;
            _doneEvent = doneEvent;
        }

        // Wrapper method for use with thread pool. 
        public void ThreadPoolCallback(Object threadContext)
        {
            int threadIndex = (int)threadContext;
            Console.WriteLine("thread {0} started...", threadIndex);
            _fibOfN = Calculate(_n);
            Console.WriteLine("thread {0} result calculated...", threadIndex);
            _doneEvent.Set();
        }

        // Recursive method that calculates the Nth Fibonacci number. 
        public int Calculate(int n)
        {
            if (n <= 1)
            {
                return n;
            }

            return Calculate(n - 1) + Calculate(n - 2);
        }
    }

    public class ThreadPoolExample
    {
        public static void MiMetodo()
        {
            const int iFibonacciCalculations = 10;

            // One event is used for each Fibonacci object.
            ManualResetEvent[] doneEvents = new ManualResetEvent[iFibonacciCalculations];
            Fibonacci[] fibArray = new Fibonacci[iFibonacciCalculations];
            Random r = new Random();

            // Configure and start threads using ThreadPool.
            Console.WriteLine("launching {0} tasks...", iFibonacciCalculations);
            for (int i = 0; i < iFibonacciCalculations; i++)
            {
                doneEvents[i] = new ManualResetEvent(false);
                Fibonacci f = new Fibonacci(r.Next(20, 40), doneEvents[i]);
                fibArray[i] = f;
                ThreadPool.QueueUserWorkItem(f.ThreadPoolCallback, i);
            }

            // Wait for all threads in pool to calculate.
            WaitHandle.WaitAll(doneEvents);
            Console.WriteLine("All calculations are complete.");

            // Display the results. 
            for (int i = 0; i < iFibonacciCalculations; i++)
            {
                Fibonacci f = fibArray[i];
                Console.WriteLine("Fibonacci({0}) = {1}", f.N, f.FibOfN);
            }
        }
    }


    //public abstract class Shape
    //{
    //    public abstract void Paint(Graphics g, Rectangle r);
    //}
    //public class Ellipse : Shape
    //{
    //    public override void Paint(Graphics g, Rectangle r)
    //    {
    //        g.DrawEllipse(r);
    //    }
    //}
    //public class Box : Shape
    //{
    //    public override void Paint(Graphics g, Rectangle r)
    //    {
    //        g.DrawRect(r);
    //    }
    //}
}
