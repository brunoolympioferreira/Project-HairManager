namespace HairManager.Comunication.Requests;

public class RequestRegistrarUsuarioDTO
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public string ConfirmeSenha { get; set; }
    public bool Status { get; set; }
}
