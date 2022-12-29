namespace HairManager.Exceptions.ExceptionsBase;
public class LoginInvalidoException : HairManagerException
{
	public LoginInvalidoException() : base(ResourceMensagensDeErro.LOGIN_INVALIDO) { }
}
