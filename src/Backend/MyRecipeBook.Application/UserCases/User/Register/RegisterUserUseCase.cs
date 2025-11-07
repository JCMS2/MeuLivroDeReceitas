using MyRecipeBook.Communication.Requests;
using MyRecipeBook.Communication.Responses;

namespace MyRecipeBook.Application.UserCases.User.Register
{
    public class RegisterUserUseCase
    {
        public ResponseRegisteredUserJson Execute(ResquestRegistreUserJson resquest)
        {
            Validate(resquest);


            return new ResponseRegisteredUserJson 
            {
                Nome=resquest.Nome,
            };
        }
        private void Validate(ResquestRegistreUserJson resquest)
        {
            var validator = new RegisterUserValidator();
           var result= validator.Validate(resquest);
            if (result.IsValid == false)
            {
                var erroMessages= result.Errors.Select(e => e.ErrorMessage);
                throw new Exception();
            }
        }
    }
}
