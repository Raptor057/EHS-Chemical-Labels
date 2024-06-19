using System.Text;

namespace ZPL.Print.Test
{
    public class ZplLabel
    {
        private StringBuilder _zpl;

        public ZplLabel()
        {
            _zpl = new StringBuilder();
            _zpl.Append("^XA"); // Iniciar etiqueta
        }

        public ZplLabel Plantilla()
        {
            _zpl.AppendFormat(@"
                ^FX Cuadrado de contorno
                ^FO30,18^GB1180,885,3^FS

                ^FX Rectangulo Negro
                ^FO50,18
                ^GB700,130,130^FS


                ^FX Texto De Atencion
                ^FO750,160^CFG
                ^ADN,50,30
                ^FD ATENCION ^FS

                ^FX Texto De Rev
                ^FO1000,880^CFG
                ^ADN,10,10
                ^FD ETI-023 Rev. C ^FS

                ^FX Cuadrados de pictogramas

                ^FO50,200
                ^GB110,110,1^FS

                ^FO55,205
                

                ^FO50,310
                ^GB110,110,1^FS

                ^FO55,315
               


                ^FO160,200
                ^GB110,110,1^FS

                ^FO165,205
                

                ^FO160,310
                ^GB110,110,1^FS

                ^FO160,315
                
                ");
            return this;
        }

        public ZplLabel ChemicalName(string text)
        {
            _zpl.AppendFormat($"^LRY^FO60,50^CFG^ADN,50,25^FD{text}^FS");
            return this;
        }
        public ZplLabel ExpirationDate(string dateTime)
        {
            _zpl.AppendFormat($"^FO30,830 " +
                $"^GB700,70,1^FS " +
                $"^FO35,850^CFG " +
                $"^ADN,30,10 " +
                $"^FD Fecha de expiracion: {dateTime}^FS");
            return this;
        }
        #region
        public ZplLabel AddPictogram_1(string text,int x = 55, int y = 205)
        {
            _zpl.AppendFormat("^FO{0},{1},{2}", x, y, text);
            return this;
        }
        public ZplLabel AddPictogram_2(string text, int x = 55, int y = 315)
        {
            _zpl.AppendFormat("^FO{0},{1},{2}", x, y, text);
            return this;
        }
        public ZplLabel AddPictogram_3(string text, int x = 165, int y = 205)
        {
            _zpl.AppendFormat("^FO{0},{1},{2}", x, y, text);
            return this;
        }
        public ZplLabel AddPictogram_4(string text, int x = 160, int y = 315)
        {
            _zpl.AppendFormat("^FO{0},{1},{2}", x, y, text);
            return this;
        }

        #endregion

        public string Build()
        {
            return _zpl.Append("^XZ").ToString(); // Finalizar etiqueta
        }
    }

}
