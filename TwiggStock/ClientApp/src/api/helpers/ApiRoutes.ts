/**
 * Api endpoints
 *
 * @auth Edilson Mucanze
 */
export const ApiRoutes = {
  auth: {
    authentication: "auth/userAuth",
    tokenValidation: "",
  },
  departments: {
    list: "/departments",
    new: "/departments/new",
    getById: "/departments/${id}",
    delete: "/departments/delete/{id}",
    remove: "/departments/remove/{id}",
    recovery: "/departments/recovery/{id}",
  },
  suppliers: {
    list: "/suppliers",
    new: "/suppliers/new",
    getById: "/suppliers/${id}",
    delete: "/suppliers/delete/{id}",
    remove: "/suppliers/remove/{id}",
    recovery: "/suppliers/recovery/{id}",
  },
};
