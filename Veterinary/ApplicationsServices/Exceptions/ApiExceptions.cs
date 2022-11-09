using System.Globalization;

namespace ApplicationsServices.Exceptions
{
    //API:Las API permiten que sus productos y servicios se comuniquen con otros, sin necesidad de saber cómo están implementados. 
    //Exceptions=Error
    public class ApiExceptions : Exception
    {
        public ApiExceptions() : base() { }
        public ApiExceptions(string message) : base(message) { }
        public ApiExceptions(string message, params object[] args) : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {

        }
    }
}
