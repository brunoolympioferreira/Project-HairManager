export class LocalStorageUtils {
  public obterUsuario() {
    return JSON.parse(localStorage.getItem('hairManager.user'));
  }

  public salvarDadosLocaisUsuario(response: any) {
    this.salvarTokenUsuario(response.token);
    if (response.nome) {
      this.salvarNomeUsuario(response.nome);
    }
  }

  public limparDadosLocaisUsuario() {
    localStorage.removeItem('hairManager.token');
    localStorage.removeItem('hairManager.user');
  }

  public obterTokenUsuario(): string {
    return localStorage.getItem('hairManager.token');
  }

  public salvarTokenUsuario(token: string) {
    localStorage.setItem('hairManager.token', token);
  }

  public salvarNomeUsuario(userName: string) {
    localStorage.setItem('hairManager.userName', JSON.stringify(userName));
  }
}
