

namespace Api.Net_Core.Html {

    public class HtmlUtils {

        public static string CarregaArquivoHTML(string nomeArquivo) {

            var nomeCompletoArquivo = $"Html/{nomeArquivo}.html";
            using (var arquivo = File.OpenText(nomeCompletoArquivo)) {
                return arquivo.ReadToEnd();
            }
        }

    }
}
