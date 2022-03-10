import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { SuppliersEntitie } from "models";
import { SuppliersState } from "./SuppliersTypes";

let initialState: SuppliersState = {
  suppliers: [],
  isLoading: false,
  pullRequestIsLoading: false,
  hasErrors: false,
  loadingDelete: false,
};

const suppliersSlice = createSlice({
  name: "suppliersSlice",
  initialState: initialState,
  reducers: {
    suppliersRequestAction(state, action: PayloadAction<any>) {
      state.isLoading = true;
      state.hasErrors = false;
    },
    suppliersRequestActionSuccess(
      state,
      action: PayloadAction<Array<SuppliersEntitie>>
    ) {
      state.isLoading = false;
      state.hasErrors = false;
      state.suppliers = action.payload;
    },
    suppliersRequestActionError(state) {
      state.isLoading = false;
      state.hasErrors = true;
    },
    newSupplierRequestAction(state, action: PayloadAction<any>) {},
    newDepartamentRequestActionSuccess(state, action: PayloadAction<any>) {},
    deleteSupplierAction(state, action: PayloadAction<any>) {},
  },
});

export const {
  suppliersRequestAction,
  suppliersRequestActionSuccess,
  suppliersRequestActionError,
  newSupplierRequestAction,
  newDepartamentRequestActionSuccess,
  deleteSupplierAction,
} = suppliersSlice.actions;

export const suppliersReducer = suppliersSlice.reducer;
