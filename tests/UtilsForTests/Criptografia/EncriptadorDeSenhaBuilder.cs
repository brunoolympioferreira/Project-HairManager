using HairManager.Application.Utils.Criptografia;

namespace UtilsForTests.Criptografia;
public class EncriptadorDeSenhaBuilder
{
    public static EncriptadorDeSenha Instancia()
    {
        return new EncriptadorDeSenha("ABCD123");
    }
}
