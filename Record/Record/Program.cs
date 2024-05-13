

using Record;
using System.ComponentModel;

Console.WriteLine("Welcome to your personal record App.");

Console.WriteLine(" ");

 var recordApp = new RecordApp();
var passWordChecker = new PassWordCheck();

try
{

    passWordChecker.Check();
    recordApp.Run();
}

catch(Exception ex)
{
    Console.WriteLine("Something unexpected went wrong, closing the app...");
}















