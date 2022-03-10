import { prodHttpClient, devHttpClient } from "./HttpClient";

export const devHttpPublicClient = () => {
  return devHttpClient;
};

export const prodHttpPublicClient = () => {
  return prodHttpClient;
};
