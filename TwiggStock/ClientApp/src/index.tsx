import 'bootstrap/dist/css/bootstrap.css';
import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter } from 'react-router-dom';
import App from './App';
import registerServiceWorker from './registerServiceWorker';

const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href') ?? null;
const rootElement = document.getElementById('root');

import { Provider } from "react-redux";
import { configureStore } from "state";

const store = configureStore();

ReactDOM.render(
  <Provider store={store}>
    <App isAuthenticated={true} />
  </Provider>,
  document.getElementById("root")
);

registerServiceWorker();

