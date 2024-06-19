namespace ZPL.Print.Test
{
    internal class ZplLabelCreate
    {
        public void ZLP(string ChemicalName, string ExpirationDate, string Pictogram_1, string Pictogram_2, string Pictogram_3, string Pictogram_4, string CodeH, string CodeP, string CompatibilityCode, string PrinterIp)
        {



            // Crear una nueva etiqueta ZPL
            var zplLabel = new ZplLabel()
            .AddLabelTemplate()
            .AddChemicalName($"{ChemicalName}")
            .AddExpirationDate($"{ExpirationDate}")
            .AddPictogram_1($"{Pictogram_1}")
            .AddPictogram_2($"{Pictogram_2}")
            .AddPictogram_3($"{Pictogram_3}")
            .AddPictogram_4($"{Pictogram_4}")
            .AddCodeH($"{CodeH}")
            .AddCodeP($"{CodeP}")
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
