using System.Net.Sockets;


namespace ZPL.Print.Test
{
    public class ZebraPrinter
    {
        private string _printerIp;
        private int _printerPort;

        public ZebraPrinter(string printerIp, int printerPort = 9100)
        {
            _printerIp = printerIp;
            _printerPort = printerPort;
        }

        public void Send(string zplCommands)
        {
            using (var tcpClient = new TcpClient())
            {
                try
                {
                    tcpClient.Connect(_printerIp, _printerPort);
                    Console.WriteLine("Conexión establecida.");

                    using (var writer = new StreamWriter(tcpClient.GetStream()))
                    {
                        writer.Write(zplCommands);
                        writer.Flush();
                        Console.WriteLine("Datos enviados a la impresora.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al enviar la etiqueta: {ex.Message}");
                }
                finally
                {
                    tcpClient.Close();
                    Console.WriteLine("Conexión cerrada.");
                }
            }
        }
    }
}
