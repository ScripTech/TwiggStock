import { DepartamentsApi } from "api-repositories";
import { call, put, takeLatest } from "redux-saga/effects";
import { ApiContractReponse, DepartmentEntitie } from "../../models";
import {
  deleteDepartmentAction,
  departmentsRequestAction,
  departmentsRequestActionError,
  departmentsRequestActionSuccess,
  newDepartamentRequestAction,
  newDepartamentRequestActionSuccess,
} from "./DepartamentsSlice";

const api: DepartamentsApi = new DepartamentsApi();

function* getDepartamentsAsync(action: typeof departmentsRequestAction) {
  if (departmentsRequestAction.match(action)) {
    const response: ApiContractReponse<DepartmentEntitie> = yield call(
      api.getResources,
      action.payload
    );

    if (response.result.data !== null) {
      yield put(departmentsRequestActionSuccess(response.result.data));
    } else {
      yield put(departmentsRequestActionError());
    }
  }
}

function* addNewDepartamentAsync(action: typeof newDepartamentRequestAction) {
  if (newDepartamentRequestAction.match(action)) {
    const response: ApiContractReponse<DepartmentEntitie> = yield call(
      api.createResource,
      action.payload
    );

    if (response.result !== null) {
      yield put(newDepartamentRequestActionSuccess(response.result.data));
    } else {
      yield put(departmentsRequestActionError());
    }
  }
}

function* handledeleteDepartmentAction(action: typeof deleteDepartmentAction) {
  if (deleteDepartmentAction.match(action)) {
    const response: ApiContractReponse<any> = yield call(
      api.deleteResource,
      action.payload
    );

    if (response.result !== null) {
    } else {
      yield put(departmentsRequestActionError());
    }
  }
}

export function* departmentsSaga() {
  yield takeLatest(departmentsRequestAction.type, getDepartamentsAsync);
  yield takeLatest(newDepartamentRequestAction.type, addNewDepartamentAsync);
  yield takeLatest(deleteDepartmentAction.type, handledeleteDepartmentAction);
}
