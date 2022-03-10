import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { DepartmentRequest } from "api-repositories";
import { DepartmentEntitie } from "../../models";
import { DepartamentsState } from "./DepartamentsTypes";

let initialState: DepartamentsState = {
  departments: [],
  isLoading: false,
  pullRequestIsLoading: false,
  hasErrors: false,
  loadingDelete: false,
};

const departmentsSlice = createSlice({
  name: "departmentsSlice",
  initialState: initialState,
  reducers: {
    addNewDepartament(state, action: PayloadAction<DepartmentEntitie>) {
      state.departments.unshift(action.payload);
    },

    newDepartamentRequestAction(
      state,
      _action: PayloadAction<DepartmentRequest>
    ) {
      state.pullRequestIsLoading = true;
      state.hasErrors = false;
    },

    newDepartamentRequestActionSuccess(
      state,
      action: PayloadAction<DepartmentEntitie>
    ) {
      state.isLoading = false;
      state.hasErrors = false;
      state.departments.unshift(action.payload);
    },

    deleteDepartmentAction(
      state,
      action: PayloadAction<{ key: number; email: string; id: number }>
    ) {
      state.loadingDelete = true;
      state.departments = state.departments.filter((data, key) => {
        if (key !== action.payload.key) {
          return data;
        }
        return null;
      });
    },

    departmentsRequestAction(state) {
      state.isLoading = true;
      state.hasErrors = false;
    },
    departmentsRequestActionSuccess(
      state,
      action: PayloadAction<Array<DepartmentEntitie>>
    ) {
      state.isLoading = false;
      state.hasErrors = false;
      state.departments = action.payload;
    },
    departmentsRequestActionError(state) {
      state.isLoading = false;
      state.hasErrors = true;
    },
  },
});

export const {
  addNewDepartament,
  newDepartamentRequestAction,
  newDepartamentRequestActionSuccess,

  deleteDepartmentAction,

  departmentsRequestAction,
  departmentsRequestActionSuccess,
  departmentsRequestActionError,
} = departmentsSlice.actions;

export const departmentsReducer = departmentsSlice.reducer;
