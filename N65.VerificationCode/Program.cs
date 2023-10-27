using Microsoft.Extensions.DependencyInjection;
using N65.VerificationCode.Models;
using N65.VerificationCode.Services;

var services = new ServiceCollection();

services.AddDataProtection();
services.AddSingleton<VerificationCodeGeneratorService>();
services.AddSingleton<VerificationTokenGeneratorService>();
services.AddSingleton<QrCodeGeneratorService>();

var provider = services.BuildServiceProvider();

var verificationCodeGeneratorService = provider.GetRequiredService<VerificationCodeGeneratorService>();
var verificationTokenGeneratorService = provider.GetRequiredService<VerificationTokenGeneratorService>();

var userId = Guid.Parse("6179E6B5-60E8-4DB7-92E5-3378BCC040CB");
var testVerificationCode =
    "CfDJ8BlVOX9w-1dLoVk-rlqK4ZBPn5UsZh32Mio-aMPFLpNFJ3sOspbV3aHbbpcWg_Q-IcppW9-w41kZGbCvVto-wUXkEE_x2VNI5T0oTcBBYqgKbHnZsTMZtLcdYpEIK2__DrA-Kb3qcS5piTEgi6pW5wS16Mn_4Oviaoe8hmpBuiccIYA3vAlk3rl2AfmoFwgvRfKk9jmhU2WA27lRwb7QGmBciRWqt2A8mFsFS2begvQV8yKqxQ7IjIHZoWoyZ8Kk7w";

var verificationCode = verificationCodeGeneratorService.Generate;
var verificationToken = verificationTokenGeneratorService.Generate(userId, VerificationType.Email, DateTimeOffset.UtcNow.AddMinutes(5));
var testVerificationModel = verificationTokenGeneratorService.Decrypt(testVerificationCode);

Console.WriteLine(verificationCode);
Console.WriteLine(verificationToken);

Console.WriteLine("Frontend link example : " + $"https:example.com/verify?verificationToken={verificationCode}");
Console.WriteLine("Frontend link example : " + $"https:example.com/verify?verificationToken={verificationToken}");

Console.WriteLine("Backend link example : " + $"https:example.com/api/accounts/{userId}/emails/verification/{verificationCode}");
Console.WriteLine("Backend link example : " + $"https:example.com/api/accounts/verification/{verificationToken}");

var qrCodeGeneratorService = provider.GetRequiredService<QrCodeGeneratorService>();

qrCodeGeneratorService.Generate(verificationCode);
qrCodeGeneratorService.Generate(verificationToken);
qrCodeGeneratorService.Generate($"https:example.com/api/accounts/{userId}/emails/verification/{verificationToken}");