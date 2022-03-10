export interface ApiError {
  title: string;
  type: string;
  code: number | string | undefined;
  innerError: string;
  message: string;
  visibleToHuman: boolean;
  errors: Array<any> | any;
}

export interface AppState {
  error: ApiError | null;
  user: {
    avatar: string;
    identifier?: string;
    firstname: string;
    lastname: string;
    emailAddrees: string;
    contact?: string;
  };
}
