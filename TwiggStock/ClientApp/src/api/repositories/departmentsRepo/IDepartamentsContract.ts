import { IBaseRepositoryContract } from "..";

export interface IDepartamentsContract extends IBaseRepositoryContract<{}, {}> {
  /**
   * List Departaments
   *
   * @return {Array<DepartamentEntitie>}
   */
  getResources(request: any): any;
}
