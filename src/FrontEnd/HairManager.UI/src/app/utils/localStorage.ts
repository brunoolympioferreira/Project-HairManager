export class LocalStorageUtils {
  public obterUsuario() {
    return JSON.parse(localStorage.getItem('hairManager.user'));
  }

  public salvarDadosLocaisUsuario(response: any) {
    this.salvarTokenUsuario(response.token);
    //this.salvarUsuario(response.userToken);
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

  // public salvarUsuario(user: string) {
  //   localStorage.setItem('hairManager.user', JSON.stringify(user));
  // }
}
