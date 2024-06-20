using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace ZPL.Print.Test
{
    internal class ZplLabelCreate
    {
        public void ZLP(string ChemicalName, string ExpirationDate, string Pictogram_1, string Pictogram_2, string Pictogram_3, string Pictogram_4, string CodeH, string CodeP, string CompatibilityCode, string PrinterIp)
        {

            string P_regex = @"(?<TextoP>(?<Code>P\d{3,})(?<Separador>\s*-\s*)\s*(?<Texto>[^P]+))";
            string H_regex = @"(?<TextoH>(?<Code>H\d{3,})(?<Separador>\s*–\s*)\s*(?<Texto>[^H]+))";

            Regex Pregex = new Regex(P_regex);

            Regex Hregex = new Regex(H_regex);

            // Obtener todas las coincidencias
            MatchCollection matchesP = Pregex.Matches(CodeP);

            // Obtener todas las coincidencias
            MatchCollection matchesH = Pregex.Matches(CodeH);

            // Crear una lista para almacenar los primeros 5 matches
            List<string> PfirstFiveMatches = new List<string>();

            // Crear una lista para almacenar los primeros 5 matches
            List<string> HfirstFiveMatches = new List<string>();


            for (int i = 0; i < Math.Min(5, matchesP.Count); i++)
            {
                PfirstFiveMatches.Add(matchesP[i].Groups["TextoP"].Value);
            }

            for (int i = 0; i < Math.Min(5, matchesH.Count); i++)
            {
                HfirstFiveMatches.Add(matchesH[i].Groups["TextoH"].Value);
            }

            // Concatenar los primeros 5 matches en una sola cadena
            string TextP = string.Join(", ", PfirstFiveMatches);
            // Concatenar los primeros 5 matches en una sola cadena
            string TextH = string.Join(", ", PfirstFiveMatches);



            // Crear una nueva etiqueta ZPL
            var zplLabel = new ZplLabel()
            .AddLabelTemplate()
            .AddChemicalName($"{ChemicalName}")
            .AddExpirationDate($"{ExpirationDate}")
            .AddPictogram_1($"{Pictogram_1}")
            .AddPictogram_2($"{Pictogram_2}")
            .AddPictogram_3($"{Pictogram_3}")
            .AddPictogram_4($"{Pictogram_4}")
            .AddCodeH($"{TextP}")
            .AddCodeP($"{TextH}")
            .AddCompatibilityCode($"{CompatibilityCode}");

            // Generar los comandos ZPL
            string zplCommands = zplLabel.Build();

            // Dirección IP y puerto de la impresora Zebra
            //string printerIp = "172.30.36.3";
            string _printerIp = $"{PrinterIp}";

            // Crear una instancia de ZebraPrinter y enviar los comandos ZPL
            var zebraPrinter = new ZebraPrinter(_printerIp);
            zebraPrinter.Send(zplCommands);
        }
    }
}
