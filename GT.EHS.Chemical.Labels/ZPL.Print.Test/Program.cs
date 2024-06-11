﻿using System.Net.Sockets;
class Program
{
    static void Main()
    {
        // Definir los datos ZPL
        var zplData = @"^XA
^FX Cuadrado de contorno
^FO30,18^GB1180,885,3^FS

^FX Rectangulo Negro
^FO50,18
^GB700,130,130^FS

^FX Texto Del Rectangulo Negro
^LRY
^FO60,50^CFG
^ADN,50,25
^FDNombre del Quimico^FS

^FX Texto De Atencion
^FO750,160^CFG
^ADN,50,30
^FD ATENCION ^FS

^FX Texto De Rev
^FO1000,880^CFG
^ADN,10,10
^FD ETI-023 Rev. C ^FS

^FX Cuadrados de fecha de expiracion y texto.
^FO30,830
^GB700,70,1^FS
^FO35,850^CFG
^ADN,30,10
^FD Fecha de expiracion: ^FS

^FX Cuadrados de pictogramas

^FO50,200
^GB110,110,1^FS

^FO55,205
^GFA,1300,1300,13,,R06,R0F,Q01F8,Q03FC,Q07FE,Q0IF,P01IF8,P03F9FC,P07F0FE,P0FE07F,O01FC03F8,O03F801FC,O07FI0FE,O0FEI07F,N01FCI03F8,N03F8I01FC,N07FK0FE,N0FEK07F,M01FCK03F8,M03F8K01FC,M07FM0FE,M0FEM07F,L01FCM03F8,L03F8001FC001FC,L07FI07FEI0FE,L0FEI0IF8007F,K01FC001IF8003F8,K03F8001IF8001FC,K07FI01IF8I0FE,K0FEI01IF8I07F,J01FCI01IF8I03F8,J03F8I01IF8I01FC,J07FK0IF8J0FE,J0FEK0IFK07F,I01FCK0IFK03F8,I03F8K0IFK01FC,I07FL0IFL0FE,I0FEL0IFL07F,001FCL0IFL03F8,003F8L07FFL01FC,007FM07FEM0FE,00FEM07FEM07F,01FCM07FEM03F8,03F8M07FEM01FC,07FN07FEN0FE,0FEN07FEN07F,1FCN03FEN03F8,3F8N03FCN01FC,7FO03FCO0FE,:3F8N03FCN01FC,1FCN03FCN03F8,0FEN01FCN07F,07FN01F8N0FE,03F8N0FN01FC,01FCW03F8,00FEW07F,007FW0FE,003F8M06M01FC,001FCL01F8L03F8,I0FEL03FCL07F,I07FL07FEL0FE,I03F8K07FEK01FC,I01FCK07FFK03F8,J0FEK07FFK07F,J07FK07FFK0FE,J03F8J07FEJ01FC,J01FCJ07FEJ03F8,K0FEJ03FCJ07F,K07FK0F8J0FE,K03F8O01FC,K01FCO03F8,L0FEO07F,L07FO0FE,L03F8M01FC,L01FCM03F8,M0FEM07F,M07FM0FE,M03F8K01FC,M01FCK03F8,N0FEK07F,N07FK0FE,N03F8I01FC,N01FCI03F8,O0FEI07F,O07FI0FE,O03F801FC,O01FC03F8,P0FE07F,P07F0FE,P03F9FC,P01IF8,Q0IF,Q07FE,Q03FC,Q01F8,R0F,R06,,^FS

^FO50,310
^GB110,110,1^FS

^FO55,315
^GFA,1300,1300,13,,R02,R07,R0F8,Q03FC,Q07FE,Q0IF,P01IF8,P03F9FC,P07F0FE,P0FE07F,O01FC03F8,O03F801FC,O07FI0FE,O0FEI07F,N01FCI03F8,N03F8I01FC,N07FK0FE,N0FEK07F,M01FCK03F8,M03F8K01FC,M07FM0FE,M0FE003FE007F,L01FC01E03803F8,L03F803800C01FC,L07F006I0600FE,L0FE00CI03807F,K01FC018J0C03F8,K03F803K0601FC,K07F006K0300FE,K0FE00D8J01807F,J01FC019K04803F8,J03F801BK06801FC,J07F001AK02800FE,J0FEI0EK038007F,I01FCI0EK038003F8,I03F8I07K07I01FC,I07FJ07K06J0FE,I0FEJ037E03E6J07F,001FC007037F07F603803F8,003F800F827F07F20F801FC,007FI08C23E03E218C00FE,00FE0018623C01C210C007F,01FC003833K0630E003F8,03F800381F80300CE0E001FC,07FI03007C0701F802I0FE,0FEI037E1F0787E3F2I07F,1FCI01E3878F9F0F1EI03F8,3F8L0E2CFD23CK01FC,3FM03E40127M0FE,7FN0E4013CM0FE,3F8M027073M01FC,1FCM023FC7M03F8,0FEM0F0707CL07F,07FL079801C7L0FE,03F8I0F1E3E03E1C38001FC,01FC001FF8E38E387FE003F8,00FE00300380F80F002007F,007F00340EK0381A00FE,003F801C18L0C1E01FC,001FC0063M061803F8,I0FE0063M021007F,I07F0022M03300FE,I03F803EM01E01FC,I01FC018N0C03F8,J0FES07F,J07FS0FE,J03F8Q01FC,J01FCQ03F8,K0FEQ07F,K07FQ0FE,K03F8O01FC,K01FCO03F8,L0FEO07F,L07FO0FE,L03F8M01FC,L01FCM03F8,M0FEM07F,M07FM0FE,M03F8K01FC,M01FCK03F8,N0FEK07F,N07FK0FE,N03F8I01FC,N01FCI03F8,O0FEI07F,O07FI0FE,O03F801FC,O01FC03F8,P0FE07F,P07F0FE,P03F9FC,P01IF8,Q0IF,Q07FE,Q03FC,Q01F8,R0F,R06,,^FS


^FO160,200
^GB110,110,1^FS

^FO165,205
^GFA,1300,1300,13,,R06,R07,R0F8,Q01FC,Q03FE,Q07FF,P01IF8,P03F9FC,P07F0FE,P0FE07F,O01FC03F8,O03F801FC,O07FI0FE,O0FEI07F,N01FCI03F8,N03F8I01FC,N07FK0FE,N0FE01F807F,M01FC07FE03F8,M03F80IF01FC,M07F01IF80FE,M0FE03IFC07F,L01FC07IFE03F8,L03F807JF01FC,L07F00KF00FE,L0FE00KF007F,K01FC00KF803F8,K03F800KF801FC,K07FI0KF800FE,K0FEI0KF8007F,J01FCI0KF8003F8,J03F8I0KF8001FC,J07FJ0KFJ0FE,J0FEJ0KFJ07F,I01FCJ0KFJ03F8,I03F8J07JFJ01FC,I07FK07IFEK0FE,I0FEK07IFEK07F,001FCK03IFEK03F8,003F8K03IFCK01FC,007FL01FDFCL0FE,00FEM0FDF8L07F,01FCM0FCFM03F8,03F8M0FCFM01FC,07FN0F8FN0FE,0FEN0F8FN07F,1FCM03FCF8M03F8,3F8M0FFC7FM01FC,7FM07FFC7FEM0FE,7FM0IF8IF8L0FE,3F8K0F3FF8IF1CJ01FC,1FCJ07F9FFA7FCFFJ03F8,0FEJ0FFC7FAFF9FF8I07F,07FI01IF330703FFCI0FE,03F8001IF880407FFE001FC,01FC001IFCI03IFE003F8,00FE001JF0063IFE007F,007F001JF6007IFE00FE,003F801JF800JFE01FC,001FC01JF800JFE03F8,I0FE00JF8017IFC07F,I07F007FFE0437IF80FE,I03F803FFB0401IF01FC,I01FC01FF87051FFE03F8,J0FE00FE0F8FC3FC07F,J07F007C7F8FF8F80FE,J03F8033FF8FFE301FC,J01FC00IFAIF003F8,K0FE00IFAIFC07F,K07F007FF9IF80FE,K03F803FF9IF01FC,K01FC01FF9FFC03F8,L0FE00FFDFF807F,L07F007FDFF00FE,L03F803FCFE01FC,L01FC01FDFC03F8,M0FE00FDF807F,M07F007DF00FE,M03F803DE01FC,M01FC039C03F8,N0FE019807F,N07F00900FE,N03F8I01FC,N01FCI03F8,O0FEI07F,O07FI0FE,O03F801FC,O01FC03F8,P0FE07F,P07F0FE,P03F9FC,P01IF8,Q0IF,Q07FE,Q03FC,Q01F8,R0F,R06,,^FS

^FO160,310
^GB110,110,1^FS

^FO160,315
^GFA,1300,1300,13,,R06,R07,R0F8,Q01FC,Q07FE,Q0IF,P01IF8,P03F9FC,P07F0FE,P0FE07F,O01FC03F8,O03F801FC,O07FI0FE,O0FEI07F,N01FCI03F8,N03F8I01FC,N07FK0FE,N0FEK07F,M01FCK03F8,M03F8K01FC,M07FM0FE,M0FEM07F,L01FCM03F8,L03F8M01FC,L07FO0FE,L0FEO07F,K01FCO03F8,K03F8O01FC,K07FQ0FE,K0FE002N07F,J01FC002N03F8,J03F800142L01FC,J07FI01C22L0FE,J0FEJ0C24L07F,I01FCJ0C2CL03F8,I03F8I0CC38L01FC,I07FJ0663N0FE,I0FEJ03E3N07F,001FCK0E302L03F8,003F8K06304L01FC,007FK047708M0FE,00FEJ01F76F8M07F,01FCK07IFN03F8,03F8K01FFCN01FC,07FM07F8O0FE,0FEM03FP07F,1FCM03EP03F8,3F8M03EP01FC,7FN03EI012L0FE,7FN03E004N0FE,3F8M03EP01FC,1FCM03E0101L03F8,0FEM03EP07F,07FM03EJ08K0FE,03F8L03F04M01FC,01FCL07FC006K03F8,00FEK01FF100FK07F,007FK0318007F8J0FE,003F8L0103FFJ01FC,001FCL0183FEJ03F8,I0FEL0FF7FFCI07F,I07FK03KFCI0FE,I03F8I0NF001FC,I01FC003NF003F8,J0FES07F,J07FS0FE,J03F8Q01FC,J01FCQ03F8,K0FEQ07F,K07FQ0FE,K03F8O01FC,K01FCO03F8,L0FEO07F,L07FO0FE,L03F8M01FC,L01FCM03F8,M0FEM07F,M07FM0FE,M03F8K01FC,M01FCK03F8,N0FEK07F,N07FK0FE,N03F8I01FC,N01FCI03F8,O0FEI07F,O07FI0FE,O03F801FC,O01FC03F8,P0FE07F,P07F0FE,P03F9FC,P01IF8,Q0IF,Q07FE,Q03FC,Q01F8,R0F,R06,,^FS


^XZ";

        // Crear una instancia de TcpClient y conectar a la impresora
        using (var tcpClient = new TcpClient())
        {
           
            
            try
            {
                tcpClient.Connect("172.30.36.3", 9100);
                Console.WriteLine("Conexión establecida.");

                // Enviar los datos ZPL a la impresora
                using (var writer = new StreamWriter(tcpClient.GetStream()))
                {
                    writer.Write(zplData);
                    writer.Flush();
                    Console.WriteLine("Datos enviados a la impresora.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                // Cerrar la conexión
                tcpClient.Close();
                Console.WriteLine("Conexión cerrada.");
            }
        }
    }
}
