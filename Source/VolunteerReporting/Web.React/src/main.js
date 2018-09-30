import React from 'react';
import ReactDOM from 'react-dom';
import {Provider} from 'react-redux';
import {BrowserRouter} from 'react-router-dom';
import {StoreManager} from 'repertoire';

import App from './App.js';
import VolunteerReporting from './case-report/index.js';

import './assets/main.scss';

const routes = [{
  path: ['/', '/list/:filter'],
  exact: true,
  component: VolunteerReporting
}];

const storeManager = new StoreManager(routes);

ReactDOM.render (<Provider store={storeManager.getStore()}>
    <BrowserRouter>
      <App routes={routes}/>
    </BrowserRouter>
  </Provider>, document.getElementById('app'));
