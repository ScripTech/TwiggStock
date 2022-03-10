export interface DepartmentEntitie {
  id: number;
  name: string;
  slugName: string;
  groupEmail: string;
  isActive: string;
  createdOn: Date | string;
  updatedOn: Date | string;
  deletedOn?: Date | string;
}
