using System.IO;
using System.Reflection;

namespace BlazorDownloadFile.Helpers
{
    internal sealed class JavaScriptLoader
    {
        private const string Resource = "BlazorDownloadFile.Script.DownloadFileScript.js";

        public string JavaScript { get; private set; }

        private JavaScriptLoader()
        {
            var assembly = typeof(JavaScriptLoader).GetTypeInfo().Assembly;
            using var stream = assembly.GetManifestResourceStream(Resource);
            using var reader = new StreamReader(stream);
            JavaScript = reader.ReadToEnd();
        }
        public static JavaScriptLoader Instance { get; } = new JavaScriptLoader();
    }
}
