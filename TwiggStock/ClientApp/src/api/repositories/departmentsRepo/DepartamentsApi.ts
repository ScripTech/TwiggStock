import { ApiRoutes, DataParser } from "api-helpers";
import { devHttpPublicClient } from "api-http-client";
import { ApiContractReponse, DepartmentEntitie } from "state/models";
import { IBaseRepositoryContract } from "../IBaseRepositoryContract";
import { DepartmentRequest } from "./DepartamentsTypes";

const PublicHttpClient = devHttpPublicClient();
export class DepartamentsApi
  implements IBaseRepositoryContract<DepartmentEntitie, DepartmentRequest>
{
  createResource(
    request: DepartmentRequest
  ): Promise<ApiContractReponse<DepartmentEntitie>> {
    const response = PublicHttpClient.post(ApiRoutes.departments.new, request)
      .then((responseApi: any) => {
        const resp: ApiContractReponse<DepartmentEntitie> = {
          error: null,
          result: {
            message: DataParser.parseToCamelCase<DepartmentEntitie>(
              responseApi.data.messages
            ),
            data: DataParser.parseToCamelCase<DepartmentEntitie>(
              responseApi.data.response
            ),
          },
        };
        return resp;
      })
      .catch((error: any) => {
        const resp: ApiContractReponse<DepartmentEntitie> = {
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
  /**
   * Get Resource
   * @param {U} args
   * @return {Array<T>}
   */
  getResources(
    request?: DepartmentRequest
  ): Promise<ApiContractReponse<Array<DepartmentEntitie>>> {
    const response = PublicHttpClient.get(ApiRoutes.departments.list)
      .then((responseApi: any) => {
        const resp: ApiContractReponse<Array<DepartmentEntitie>> = {
          error: null,
          result: {
            message: DataParser.parseToCamelCase<Array<DepartmentEntitie>>(
              responseApi.data.messages
            ),
            data: DataParser.parseToCamelCase<Array<DepartmentEntitie>>(
              responseApi.data.response
            ),
          },
        };
        return resp;
      })
      .catch((error: any) => {
        const resp: ApiContractReponse<Array<DepartmentEntitie>> = {
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

  /**
   * Get Resource By ID
   *
   * @param {number} id
   * @return {T} T
   */
  getResourceByID(id: string): Promise<ApiContractReponse<DepartmentEntitie>> {
    const response = PublicHttpClient.get(ApiRoutes.departments.getById + id)
      .then((responseApi: any) => {
        const resp: ApiContractReponse<DepartmentEntitie> = {
          error: null,
          result: {
            message: {},
            data: DataParser.parseToCamelCase<DepartmentEntitie>(
              responseApi.data
            ),
          },
        };

        return resp;
      })
      .catch((error: any) => {
        const resp: ApiContractReponse<DepartmentEntitie> = {
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

  /**
   * Get Resource by name
   *
   * @param {string} name
   * @return {Promise<ApiContractReponse<T>>} T
   */
  getResourceByName(
    name: string
  ): Promise<ApiContractReponse<DepartmentEntitie>> {
    throw new Error("Method not implemented.");
  }

  /**
   * Update Resource
   *
   * @param {U} args
   * @return {Promise<ApiContractReponse<T>>} Promise<ApiContractReponse<T>>
   */
  updateResource(
    request?: DepartmentRequest
  ): Promise<ApiContractReponse<DepartmentEntitie>> {
    throw new Error("Method not implemented.");
  }

  /**
   * Delete Resource
   *
   * @partam {U} args
   * @return {Promise<ApiContractReponse<T>>} Promise<ApiContractReponse<any>>
   */
  deleteResource(request: {
    id: number;
    email: string;
  }): Promise<ApiContractReponse<any>> {
    const response = PublicHttpClient.post(
      ApiRoutes.departments.list + "/" + request.id + "/delete"
    )
      .then((responseApi: any) => {
        const resp: ApiContractReponse<any> = {
          error: null,
          result: {
            message: {},
            data: DataParser.parseToCamelCase<any>(responseApi.data),
          },
        };
        return resp;
      })
      .catch((error: any) => {
        const resp: ApiContractReponse<any> = {
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
}
