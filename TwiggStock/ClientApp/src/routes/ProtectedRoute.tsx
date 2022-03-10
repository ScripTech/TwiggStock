import React from "react";
import { Redirect, Route } from "react-router-dom";
import { CookieManager } from "../utils/CookieSession";

let isAuth = CookieManager.getCookie("auth-signed-key") !== "";

const ProtectedRoute = ({
  isAuthenticated,
  component: Componet,
  ...rest
}: any) => {
  if (isAuthenticated) {
    return <Route {...rest} render={(props) => <Componet {...props} />} />;
  } else {
    return (
      <Redirect
        to={{
          pathname: "/auth/login",
        }}
      />
    );
  }
};

export default ProtectedRoute;
