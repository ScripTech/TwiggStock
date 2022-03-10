import { SuppliersEntitie } from "models";

export interface SuppliersState {
  suppliers: Array<SuppliersEntitie>;
  isLoading: boolean;
  pullRequestIsLoading: boolean;
  hasErrors: boolean;
  loadingDelete: boolean;
}
