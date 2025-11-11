using System.Globalization;

namespace MyRecipeBook.API.Middleware
{
    public class CultureMiddware
    {
        private readonly RequestDelegate _next;

        public CultureMiddware(RequestDelegate next)
        {
            _next = next;
        }

        // Método principal do middleware.
        public async Task Invoke(HttpContext context)
        {
            // Obtém uma lista de todas as culturas suportadas pelo sistema.
            var supportedLanguages = CultureInfo.GetCultures(CultureTypes.AllCultures);

            // Tenta ler o idioma do cabeçalho 'Accept-Language'.
            var requestedCulture = context.Request.Headers.AcceptLanguage.FirstOrDefault();

            // Define "en" (Inglês) como a cultura padrão.
            // (Note que a variável 'cultireInfo' ainda tem o erro de digitação).
            var cultireInfo = new CultureInfo("en");

            // Verifica se um idioma foi solicitado E se ele existe na lista de 'supportedLanguages'.
            if (string.IsNullOrWhiteSpace(requestedCulture) == false &&
                supportedLanguages.Any(c => c.Name.Equals(requestedCulture)))
            {
                // Se for válido, define a cultura para a solicitada.
                cultireInfo = new CultureInfo(requestedCulture);
            }

            // Define a cultura para formatação de datas, números, moedas, etc.
            CultureInfo.CurrentCulture = cultireInfo;

            // Define a cultura para buscar arquivos de tradução (recursos .resx).
            CultureInfo.CurrentUICulture = cultireInfo;

            // Continua o processamento da requisição.
            await _next(context);
        }
    }
}