import { SuppliersApi } from "api/repositories/suppliersRepo/SuppliersApi";
import { call, put, takeLatest } from "redux-saga/effects";
import { ApiContractReponse, SuppliersEntitie } from "../../models";

import {
  suppliersRequestAction,
  suppliersRequestActionSuccess,
  suppliersRequestActionError,
  newSupplierRequestAction,
  newDepartamentRequestActionSuccess,
  deleteSupplierAction,
} from "./SuppliersSlice";

const api: SuppliersApi = new SuppliersApi();

function* getSuppliersAsync(action: typeof suppliersRequestAction) {
  if (suppliersRequestAction.match(action)) {
    const response: ApiContractReponse<SuppliersEntitie> = yield call(
      api.getResources,
      action.payload
    );

    if (response.result.data !== null) {
      yield put(suppliersRequestActionSuccess(response.result.data));
    } else {
      yield put(suppliersRequestActionError());
    }
  }
}

function* addNewDepartamentAsync(action: typeof newSupplierRequestAction) {
  if (newSupplierRequestAction.match(action)) {
    const response: ApiContractReponse<SuppliersEntitie> = yield call(
      api.createResource,
      action.payload
    );

    if (response.result !== null) {
      yield put(newDepartamentRequestActionSuccess(response.result.data));
    } else {
      yield put(suppliersRequestActionError());
    }
  }
}

function* handledeleteSuppllerAction(action: typeof deleteSupplierAction) {
  if (deleteSupplierAction.match(action)) {
    const response: ApiContractReponse<any> = yield call(
      api.deleteResource,
      action.payload
    );

    if (response.result !== null) {
    } else {
      yield put(suppliersRequestActionError());
    }
  }
}

export function* suppliersSaga() {
  yield takeLatest(suppliersRequestAction.type, getSuppliersAsync);
  yield takeLatest(newSupplierRequestAction.type, addNewDepartamentAsync);
  yield takeLatest(deleteSupplierAction.type, handledeleteSuppllerAction);
}
