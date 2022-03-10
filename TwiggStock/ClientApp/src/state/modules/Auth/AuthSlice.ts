import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { CookieManager } from "utils";
import { AuthState, User } from "./AuthTypes";

let initialState: AuthState = {
  privateKey: "",
  apelido: "",
  createdOn: "",
  nomeCompleto: "",
  emailAddrees: "",
  nome: "",
  phoneNumber: "",
  phoneNumberConfirmed: false,
  telefoneAlternativo: "",
  twoFactorEnabled: false,
  isLoading: false,
  isAuthenticated:
    CookieManager.getCookie("sealink-signed-user") === "" ? false : true,
  isAuthFailed: false,
};

const authSlice = createSlice({
  name: "authSlice",
  initialState: initialState,
  reducers: {
    loginPasswordActionRequest(
      state,
      _action: PayloadAction<{ login: string; password: string }>
    ) {
      state.isLoading = true;
      state.isAuthenticated = false;
      state.isAuthFailed = false;
    },
    loginPasswordActionRequestSuccess(state, action: PayloadAction<User>) {
      state.nome = action.payload.user.firstname;
      state.apelido = action.payload.user.lastname;
      state.emailAddrees = action.payload.user.emailAddrees;
      state.isLoading = false;
      state.isAuthenticated =
        CookieManager.getCookie("sealink-signed-user") !== undefined
          ? true
          : false;
      state.isAuthFailed = false;
    },
    loginPasswordActionRequestError(state) {
      state.isLoading = false;
      state.isAuthenticated = false;
      state.isAuthFailed = true;
    },

    logoutRequest(state) {
      state.isAuthenticated = false;
      state.nome = "";
      state.apelido = "";
      state.emailAddrees = "";
    },
  },
});

export const {
  logoutRequest,
  loginPasswordActionRequest,
  loginPasswordActionRequestSuccess,
  loginPasswordActionRequestError,
} = authSlice.actions;

export const authReducer = authSlice.reducer;
