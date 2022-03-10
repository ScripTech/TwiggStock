import { DepartmentEntitie } from "../../models";

export interface DepartamentsState {
  departments: Array<DepartmentEntitie>;
  isLoading: boolean;
  hasErrors: boolean;
  pullRequestIsLoading: boolean;
  loadingDelete: boolean;
}
