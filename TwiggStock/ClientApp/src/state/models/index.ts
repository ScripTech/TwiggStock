export type { DepartmentEntitie } from "./DepartmentsEntitie";
export type { UsersEntitie } from "./UsersEntitie";
export type { SuppliersEntitie } from "./SuppliersEntitie";

export interface ApiContractReponse<T> {
  error: any;
  result: {
    message: any;
    data: T | any | null;
  };
}
