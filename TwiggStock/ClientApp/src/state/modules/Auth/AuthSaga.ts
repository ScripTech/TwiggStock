import { call, put, takeLatest } from "redux-saga/effects";
import { AuthEventListnerApi } from "../../../api/repositories/authRepo/AuthEventListnerApi";
import { ApiContractReponse } from "../../models";
import {
  loginPasswordActionRequestError,
  loginPasswordActionRequestSuccess,
  loginPasswordActionRequest,
} from "./AuthSlice";
import { User } from "./AuthTypes";

const api: AuthEventListnerApi = new AuthEventListnerApi();

function* authenticationEventRequest(
  action: typeof loginPasswordActionRequest
) {
  if (loginPasswordActionRequest.match(action)) {
    const response: ApiContractReponse<User> = yield call(
      api.passwordAuthentication,
      action.payload
    );
    if (response.result !== null) {
      yield put(loginPasswordActionRequestSuccess(response.result.data));
    } else {
      yield put(loginPasswordActionRequestError());
    }
  }
}

// function* logoutUserRequest(action: typeof logoutRequest) {
//   if (logoutRequest.match(action)) {
//     yield call(api.userLogout);
//   }
// }

export function* authSaga() {
  yield takeLatest(loginPasswordActionRequest.type, authenticationEventRequest);
  // yield takeLatest(logoutRequest.type, logoutUserRequest);
}
