//using QRCoder;
//using System.Drawing;
//using System.IO;

//public class QrCodeService
//{
//    public string GerarQRCode(string url)
//    {
//        // Cria o objeto QRCodeGenerator
//        QRCodeGenerator qrGenerator = new QRCodeGenerator();
//        QRCodeGenerator.QRCode qrCode = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);

//        // Cria uma imagem do QR Code
//        using (Bitmap qrCodeImage = qrCode.GetGraphic(20))
//        {
//            // Converte a imagem para base64 para retornar via API
//            using (MemoryStream ms = new MemoryStream())
//            {
//                qrCodeImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
//                byte[] byteArray = ms.ToArray();
//                string base64String = Convert.ToBase64String(byteArray);
//                return base64String;
//            }
//        }
//    }
//}
