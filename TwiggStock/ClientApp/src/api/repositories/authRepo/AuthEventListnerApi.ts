import { ApiRoutes, DataParser } from "api/helpers";
import { devHttpPublicClient } from "api/HttpClient";
import { ApiContractReponse } from "state/models";
import { User } from "state/modules/Auth";
import { IAuthEventListnerContract } from "./IAuthEventListnerContract";
import { AuthRequest } from "./TypesAuthEvent";

const PublicHttpClient = devHttpPublicClient();

export class AuthEventListnerApi implements IAuthEventListnerContract {
  passwordAuthentication(
    request: AuthRequest
  ): Promise<ApiContractReponse<User>> {
    const resquestData = {
      login: request.login,
      password: request.password,
    };

    const response = PublicHttpClient.post(
      ApiRoutes.auth.authentication,
      resquestData
    )
      .then((responseApi) => {
        if (responseApi.data.data.result) {
          const resp: ApiContractReponse<User> = {
            error: null,
            result: {
              message: null,
              data: DataParser.parseToCamelCase<User>(
                responseApi.data.data.result
              ),
            },
          };

          return resp;
        } else {
          const resp: ApiContractReponse<User> = {
            error: "error",
            result: {
              message: null,
              data: null,
            },
          };

          return resp;
        }
      })
      .catch((error) => {
        const resp: ApiContractReponse<User> = {
          error: error,
          result: {
            message: null,
            data: null,
          },
        };
        return resp;
      });
    return response;
  }
}
