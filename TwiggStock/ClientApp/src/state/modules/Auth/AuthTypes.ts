export interface AuthState {
  nome: string;
  apelido: string;
  nomeCompleto: string;
  emailAddrees: string;
  phoneNumber: string;
  phoneNumberConfirmed: boolean;
  telefoneAlternativo: string;
  twoFactorEnabled: boolean;
  createdOn: string;

  privateKey: string; // temporary token

  isLoading: boolean;
  isAuthenticated: boolean | any;
  isAuthFailed: boolean;
}

export interface User {
  user: {
    avatar: string;
    firstname: string;
    lastname: string;
    emailAddrees: string;
    accountStatus: boolean;
  };
}
