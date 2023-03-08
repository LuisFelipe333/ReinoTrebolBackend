using System.Text.RegularExpressions;

namespace ReinoTrebolBackend.Resources
{
    public class Validator
    {
        public dynamic VerifyValues(string name, string lastName, string identification, int age, int magicalAff)
        {
            bool approve = true;
            string message = "";
            if (name.Length > 20 || !Regex.IsMatch(name, "^[a-zA-Z]*$"))
                message += "Nombre no cumple con los parametros \n";

            if (lastName.Length > 20 || !Regex.IsMatch(lastName, "^[a-zA-Z]*$"))
                message += "Apellido no cumple con los parametros \n";

            if (identification.Length > 10 || !Regex.IsMatch(identification, "^[a-zA-Z0-9]*$"))
                message += "Identificacion no cumple con los parametros \n";

            if (age < 0 || age > 99)
                message += "Edad no cumple con los parametros \n";

            if (magicalAff < 1 || magicalAff > 5)
                message += "Afinidad Magica no cumple con los parametros \n";

            if (message != "")
                approve = false;

            return new
            {
                exito = approve,
                message = message
            };
        }
    }
}
