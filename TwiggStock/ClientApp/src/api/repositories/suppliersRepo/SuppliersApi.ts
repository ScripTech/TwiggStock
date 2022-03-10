import { ApiRoutes, DataParser } from "api-helpers";
import { devHttpPublicClient } from "api-http-client";
import { ApiContractReponse } from "models";
import { SuppliersEntitie } from "state/models/SuppliersEntitie";
import { IBaseRepositoryContract } from "../IBaseRepositoryContract";

const PublicHttpClient = devHttpPublicClient();

export interface SuppliersRequest {
  name: string;
  email: string;
  isActive: boolean;
}
export interface DepartmentResponse {}

export class SuppliersApi
  implements IBaseRepositoryContract<SuppliersEntitie, SuppliersRequest>
{
  getResources(
    request?: SuppliersRequest
  ): Promise<ApiContractReponse<SuppliersEntitie[]>> {
    const response = PublicHttpClient.get(ApiRoutes.suppliers.list)
      .then((responseApi: any) => {
        const resp: ApiContractReponse<Array<SuppliersEntitie>> = {
          error: null,
          result: {
            message: DataParser.parseToCamelCase<Array<SuppliersEntitie>>(
              responseApi.data.messages
            ),
            data: DataParser.parseToCamelCase<Array<SuppliersEntitie>>(
              responseApi.data.response
            ),
          },
        };
        return resp;
      })
      .catch((error: any) => {
        const resp: ApiContractReponse<Array<SuppliersEntitie>> = {
          error: error.message,
          result: {
            message: null,
            data: null,
          },
        };

        return resp;
      });

    return response;
  }
  createResource(
    request: SuppliersRequest
  ): Promise<ApiContractReponse<SuppliersEntitie>> {
    const response = PublicHttpClient.post(ApiRoutes.suppliers.new, request)
      .then((responseApi: any) => {
        const resp: ApiContractReponse<SuppliersEntitie> = {
          error: null,
          result: {
            message: DataParser.parseToCamelCase<SuppliersEntitie>(
              responseApi.data.messages
            ),
            data: DataParser.parseToCamelCase<SuppliersEntitie>(
              responseApi.data.response
            ),
          },
        };
        return resp;
      })
      .catch((error: any) => {
        const resp: ApiContractReponse<SuppliersEntitie> = {
          error: error.message,
          result: {
            message: null,
            data: [],
          },
        };

        return resp;
      });

    return response;
  }
  getResourceByID(id: string): Promise<ApiContractReponse<SuppliersEntitie>> {
    throw new Error("Method not implemented.");
  }
  getResourceByName(
    name: string
  ): Promise<ApiContractReponse<SuppliersEntitie>> {
    throw new Error("Method not implemented.");
  }
  updateResource(
    request?: SuppliersRequest
  ): Promise<ApiContractReponse<SuppliersEntitie>> {
    throw new Error("Method not implemented.");
  }
  deleteResource(request: {
    id: number;
    email: string;
  }): Promise<ApiContractReponse<any>> {
    throw new Error("Method not implemented.");
  }
}
