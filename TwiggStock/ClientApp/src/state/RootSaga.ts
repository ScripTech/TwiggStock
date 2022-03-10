import { all } from "redux-saga/effects";
import { authSaga } from "./modules/Auth";
import { departmentsSaga } from "./modules/departments";
import { suppliersSaga } from "./modules/suppliers";

export function* rootSaga() {
  yield all([authSaga(), departmentsSaga(), suppliersSaga()]);
}
