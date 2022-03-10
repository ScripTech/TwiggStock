import React, { Component } from "react";
import { BrowserRouter as Router, Route, Switch } from "react-router-dom";
import { Layout } from "./components/Layout";
import { Home } from "./components/Home";
import { FetchData } from "./components/FetchData";
import { Counter } from "./components/Counter";

import "./custom.css";
import LoginView from "features/auth/LoginView";
import RegisterView from "features/auth/RegisterView";
import ProtectedRoute from "routes/ProtectedRoute";
import SuppliersView from "features/Suppliers/SuppliersView";
import DepartmentsView from "features/Departments/DepartmentsView";
import CategoriesView from "features/Categories/CategoriesView";
import StockView from "features/Stocks/StockView";

const NotFound = () => {
  return (
    <div className='p-2 bg-dp-primary bg-opacity-30 rounded'>
      <span className='font-semibold'>Acho que você esta perdido aqui.</span>{" "}
      <a href='/' className='text-blue-800'>
        Vá para a página inicial!
      </a>
      <p className='small text-muted'>Dev by Edilson Mucanze</p>
    </div>
  );
};

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <Router>
        <Layout>
          <Switch>
            <Route exact path='/auth/login' component={LoginView} />
            <Route exact path='/auth/register' component={RegisterView} />
            <ProtectedRoute
              isAuthenticated={true}
              exact
              path='/'
              component={Home}
            />
            <ProtectedRoute
              isAuthenticated={true}
              exact
              path='/suppliers'
              component={SuppliersView}
            />
            <ProtectedRoute
              isAuthenticated={true}
              exact
              path='/departments'
              component={DepartmentsView}
            />
            <ProtectedRoute
              isAuthenticated={true}
              exact
              path='/categories'
              component={CategoriesView}
            />
            <ProtectedRoute
              isAuthenticated={true}
              exact
              path='/stock'
              component={StockView}
            />
            <ProtectedRoute
              isAuthenticated={true}
              exact
              path='/categories'
              component={CategoriesView}
            />
            <Route component={NotFound} />
          </Switch>
        </Layout>
      </Router>
    );
  }
}
