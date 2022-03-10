import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { User } from "../Auth";
import { ApiError, AppState } from "./AppTypes";

let initialState: AppState = {
  error: null,
  user: {
    avatar: "",
    firstname: "",
    lastname: "",
    emailAddrees: "",
    contact: "",
    identifier: "",
  },
};

const appSlice = createSlice({
  name: "appSlice",
  initialState: initialState,
  reducers: {
    setUserData(state, action: PayloadAction<User>) {
      state.user = action.payload.user;
    },
    showError(state, action: PayloadAction<ApiError>) {
      console.log(action.payload);
      state.error = action.payload;
    },
    hideError(state) {
      state.error = null;
    },
  },
});

export const { showError, hideError } = appSlice.actions;

export const appReducer = appSlice.reducer;
