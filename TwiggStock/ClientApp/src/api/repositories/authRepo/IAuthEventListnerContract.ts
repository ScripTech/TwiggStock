import { ApiContractReponse } from "state/models";
import { User } from "../../../state/modules/Auth/AuthTypes";
import { AuthRequest } from "./TypesAuthEvent";

export interface IAuthEventListnerContract {
  /**
   * Authenticated User
   *
   * @return list of vessels
   */
  passwordAuthentication(
    request: AuthRequest
  ): Promise<ApiContractReponse<User>>;
}
