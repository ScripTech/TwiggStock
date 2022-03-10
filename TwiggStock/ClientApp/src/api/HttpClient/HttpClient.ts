import { default as axios } from "axios";
import { Constants } from "../helpers";

const devHttpClient = axios.create({
  baseURL: Constants.DEVELOPMENT_SERVER_URL,
  withCredentials: false,
  headers: {
    "Content-Type": "application/json;charset=UTF-8",
  },
});

const prodHttpClient = axios.create({
  baseURL: Constants.PRODUCTION_SERVER_URL,
  headers: {
    "Content-Type": "application/json",
    "Access-Control-Allow-Origin": "*",
    appPrivateKey: Constants.PROD_SERVER.APP_PrivateKey,
    app_token: Constants.PROD_SERVER.APP_TOKEN,
    app_client_lang: Constants.APP_CLIENT_LANG,
  },
});

export { prodHttpClient, devHttpClient };
