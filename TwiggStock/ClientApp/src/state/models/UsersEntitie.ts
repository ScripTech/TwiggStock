export interface UsersEntitie {
  id: number;
  uuid: string;
  firstname: string;
  lastname: string;
  login: string;
  mailNotification: string;
  email_verified_at: string;
  last_login_on: string;
  language: string;
  createdOn: Date | string;
  updatedOn: Date | string;
  deletedOn?: Date | string;
}


