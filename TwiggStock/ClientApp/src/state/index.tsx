import {
  applyMiddleware,
  combineReducers,
  createStore,
} from "@reduxjs/toolkit";
import createSagaMiddleware from "redux-saga";
import { authReducer } from "./modules/Auth";
import { rootSaga } from "./RootSaga";
import { composeWithDevTools } from "redux-devtools-extension";
import { appReducer } from "./modules/app";
import { departmentsReducer } from "./modules/departments";
import { suppliersReducer } from "./modules/suppliers";

//export
export * from "./modules";

const rootReducer = combineReducers({
  app: appReducer,
  auth: authReducer,
  departments: departmentsReducer,
  suppliers: suppliersReducer,
});

export type AppState = ReturnType<typeof rootReducer>;

const sagaMiddleware = createSagaMiddleware();

const store = createStore(
  rootReducer,
  composeWithDevTools(applyMiddleware(sagaMiddleware))
);

sagaMiddleware.run(rootSaga);

export function configureStore() {
  return store;
}
