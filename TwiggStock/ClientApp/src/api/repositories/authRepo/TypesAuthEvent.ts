// Types
export interface AuthRequest {
  login: string;
  password: string;
}

export interface AuthResponse {
  id: string;
  username: string;
  email: string;
  emailConfirmed: true;
}
