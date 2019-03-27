import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter } from 'react-router-dom';
import { Provider } from 'react-redux';
import { Application } from '@ifrc-cbs/common-react-ui';
import { routes } from './src/utils/routes';
import rootReducer from './src/reducers'
import { createStore, applyMiddleware } from "redux";
import thunk from "redux-thunk";

import '@ifrc-cbs/common-react-ui/src/assets/main.scss';
import './src/assets/main.scss';

const store = createStore(
  rootReducer,
  applyMiddleware(thunk)
);

ReactDOM.render(
  <Provider store={store}>
    <BrowserRouter>
      <Application routes={routes} />
    </BrowserRouter>
  </Provider>,
  document.getElementById('app'));