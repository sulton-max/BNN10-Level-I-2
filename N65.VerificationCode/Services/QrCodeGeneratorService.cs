using QRCoder;

namespace N65.VerificationCode.Services;

public class QrCodeGeneratorService
{
    public void Generate(string input)
    {
        var qrCodeGenerator = new QRCodeGenerator();
        var qrCodeData = qrCodeGenerator.CreateQrCode(input, QRCodeGenerator.ECCLevel.Q);
        var qrCode = new PngByteQRCode(qrCodeData);
        var stream = new MemoryStream(qrCode.GetGraphic(30));
        using var qrCodeFileStream = File.Open($"{Guid.NewGuid()}.png", FileMode.CreateNew, FileAccess.Write);

        stream.CopyTo(qrCodeFileStream);
    }
}