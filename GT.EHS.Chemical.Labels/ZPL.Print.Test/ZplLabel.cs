using System.Text;

namespace ZPL.Print.Test
{
    public class ZplLabel
    {
        private StringBuilder _zpl;

        /// <summary>
        /// Iniciar etiqueta
        /// </summary>
        public ZplLabel()
        {
            _zpl = new StringBuilder();
            _zpl.Append("^XA");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ZplLabel AddLabelTemplate()
        {
            _zpl.AppendFormat(@"
                ^FX Cuadrado de contorno
                ^FO30,18^GB1180,885,3^FS


                ^FX Rectangulo Negro
                ^FO30,18
                ^GB1180,130,130^FS


                 ^FX Texto De Atencion
                 ^FO800,160^CFG
                 ^ADN,50,30
                 ^FD ATENCION ^FS


                ^FX Texto De Rev
                ^FO1000,880^CFG
                ^ADN,10,10
                ^FD ETI-023 Rev. C ^FS


                ^FX Texto De Codigo de Compatibilidad
                ^FO910,720^CFG
                ^ADN,50,5
                ^FDCodigo de Compatibilidad^FS


                ^FX Cuadro Codigo de Compatibilidad
                ^FO910,780
                ^GB280,80,1^FS
                ");
            return this;
        }

        public ZplLabel AddChemicalName(string text)
        {
            _zpl.AppendFormat($"" +
                $"^LRY" +
                $"^FO60,50^CFG" +
                $"^ADN,50,25^FD{text}" +
                $"^FS");
            return this;
        }

        #region Pictogramas
        /// <summary>
        /// Cuadro y pictograma 1 de 180 x 180
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public ZplLabel AddPictogram_1(string text)
        {
            _zpl.AppendFormat($"" +
                $"^FO30,150^GB180,180,1^FS" +
                $"^FO30,150{text}");
            return this;
        }

        /// <summary>
        /// Cuadro y pictograma 2 de 180 x 180
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public ZplLabel AddPictogram_2(string text)
        {
            _zpl.AppendFormat($"" +
                $"^FO210,150^GB180,180,1^FS" +
                $"^FO210,150{text}");
            return this;
        }

        /// <summary>
        /// Cuadro y pictograma 3 de 180 x 180
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public ZplLabel AddPictogram_3(string text)
        {
            _zpl.AppendFormat($"" +
                $"^FO390,150" +
                $"^GB180,180,1^FS" +
                $"^FO390,150{text}");
            return this;
        }

        /// <summary>
        /// Cuadro y pictograma 4 de 180 x 180
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public ZplLabel AddPictogram_4(string text)
        {
            _zpl.AppendFormat($"" +
                $"^FO570,150" +
                $"^GB180,180,1^FS" +
                $"^FO570,150{text}");
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        #endregion
        public ZplLabel AddCodeP(string text)
        {
            _zpl.AppendFormat($"" +
                $"^CF0,35^FO35,340" +
                $"^FB720, 14,," +
                $"^FD{ text}^FS");
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public ZplLabel AddCodeH(string text)
        {
            _zpl.AppendFormat($"" +
                $"^CF0,28" +
                $"^FO760, 220" +
                $"^FB400,22,," +
                $"^FD{ text}^FS");
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public ZplLabel AddCompatibilityCode(string code)
        {
            _zpl.AppendFormat($"" +
                $"^FO930,800^CFG" +
                $"^ADN, 50, 30" +
                $"^FD{code}^ FS");
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public ZplLabel AddExpirationDate(string dateTime)
        {
            _zpl.AppendFormat($"" +
                $"^FO30,830 " +
                $"^GB700,70,1^FS " +
                $"^FO35,850^CFG " +
                $"^ADN,30,10 " +
                $"^FD Fecha de expiracion: {dateTime}^FS");
            return this;
        }

        /// <summary>
        /// Finalizar etiqueta
        /// </summary>
        /// <returns></returns>
        public string Build()
        {
            return _zpl.Append("^XZ").ToString();
        }
    }

}
