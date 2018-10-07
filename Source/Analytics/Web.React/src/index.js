import React from 'react';
import ReactDOM from 'react-dom';
import {Provider} from 'react-redux';
import {BrowserRouter} from 'react-router-dom';
import {StoreManager} from 'repertoire';

import App from './components/App.js';
import Analytics from './components/Analytics.js';

import './assets/main.scss';

const routes = [{
  path: '*',
  component: Analytics
}];

const storeManager = new StoreManager(routes);

ReactDOM.render (<Provider store={storeManager.getStore()}>
    <BrowserRouter>
      <App routes={routes}/>
    </BrowserRouter>
  </Provider>, document.getElementById('app'));
