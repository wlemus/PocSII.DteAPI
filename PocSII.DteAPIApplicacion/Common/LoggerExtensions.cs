
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;


namespace PocSII.DteAPIApplicacion.Common {

    public static class LoggerExtensions {
        public static void LogErrorWithDetails(this ILogger logger, Exception ex, string message = "",
            [CallerMemberName] string methodName = "",
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0) {
            logger.LogError(ex, $"{message} | Error en el archivo {System.IO.Path.GetFileName(filePath)} en la línea {lineNumber}, método {methodName}");
        }
        public static void LogErrorWithDetails(this ILogger logger,  string message = "",
           [CallerMemberName] string methodName = "",
           [CallerFilePath] string filePath = "",
           [CallerLineNumber] int lineNumber = 0) {
            logger.LogError($"{message} | Error en el archivo {System.IO.Path.GetFileName(filePath)} en la línea {lineNumber}, método {methodName}");
        }
        public static void LogInformationWithDetails(this ILogger logger, string message,
            [CallerMemberName] string methodName = "",
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0) {
            logger.LogInformation($"{message} | Información en el archivo {System.IO.Path.GetFileName(filePath)} en la línea {lineNumber}, método {methodName}");
        }
    }

}
