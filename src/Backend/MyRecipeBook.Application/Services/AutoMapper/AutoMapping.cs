using AutoMapper;
using MyRecipeBook.Communication.Requests;

namespace MyRecipeBook.Application.Services.AutoMapper
{
    // Classe de configuração do AutoMapper.
    // Define como converter um objeto em outro automaticamente.
    public class AutoMapping : Profile
    {
        // Construtor: é executado quando a classe é instanciada.
        public AutoMapping()
        {
            RequestToDomain();
        }

        // Método que define as regras de conversão da Requisição para o Domínio.
        private void RequestToDomain()
        {
            // Cria o mapa: De 'ResquestRegistreUserJson' -> Para 'Domain.Entities.User'.
            CreateMap<ResquestRegistreUserJson, Domain.Entities.User>()
                // Regra especial para o campo Password:
                // Ignora o mapeamento automático da senha.
                // Motivo: A senha da requisição vem em texto puro e precisa ser criptografada antes de ir para a entidade.
                .ForMember(dest => dest.Password, opt => opt.Ignore());
        }
    }
}