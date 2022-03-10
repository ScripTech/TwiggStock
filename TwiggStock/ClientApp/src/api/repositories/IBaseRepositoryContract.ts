import { ApiContractReponse } from "state/models";

export interface IBaseRepositoryContract<T, U> {
  // This a generic implementation for
  // a function interface contract
  //
  // T - stands for Data type to Return
  // U - stands for Data type to use as query body type
  //

  /**
   * Get Resource
   * @param {U} args
   * @return {Array<T>}
   */
  getResources(request?: U): Promise<ApiContractReponse<Array<T>>>;

  /**
   * Create new Resouce
   * @param {U} args
   * @return {Promise<ApiContractReponse<T>>}
   */
  createResource(request: U): Promise<ApiContractReponse<T>>;

  /**
   * Get Resource By ID
   *
   * @param {number} id
   * @return {T} T
   */
  getResourceByID(id: string): Promise<ApiContractReponse<T>>;

  /**
   * Get Resource by name
   *
   * @param {string} name
   * @return {Promise<ApiContractReponse<T>>} T
   */
  getResourceByName(name: string): Promise<ApiContractReponse<T>>;

  /**
   * Update Resource
   *
   * @param {U} args
   * @return {Promise<ApiContractReponse<T>>} Promise<ApiContractReponse<T>>
   */
  updateResource(request?: U): Promise<ApiContractReponse<T>>;

  /**
   * Delete Resource
   *
   * @param {U} args
   * @return {Promise<ApiContractReponse<T>>} Promise<ApiContractReponse<any>>
   */
  deleteResource(request: {
    id: number;
    email: string;
  }): Promise<ApiContractReponse<any>>;
}
