import React from 'react';
import ReactDOM from 'react-dom';
import {BrowserRouter} from 'react-router-dom';
import {StoreManager} from 'repertoire';
import {Provider} from 'react-redux';
import {Application} from '@ifrc-cbs/common-react-ui';

import Projects from './src/components/Projects';
import HealthRisks from './src/components/HealthRisks';
import AddProjectPage from './src/components/Projects/AddProjectPage';

import '@ifrc-cbs/common-react-ui/src/assets/main.scss';
import './src/assets/main.scss';

const routes = [{
    component: Projects,
    path: '/projects/',
    exact: true
  },
  {
    component: HealthRisks,
    path: '/healthrisks/',
    exact: false
  },
  {
    component: AddProjectPage,
    path: '/projects/add-project',
    exact: true
  }
];

const storeManager = new StoreManager(routes);

ReactDOM.render(<Provider store={storeManager.getStore()}>
  <BrowserRouter>
    <Application routes={routes} store={storeManager.getStore()}/>
  </BrowserRouter>
</Provider>, document.getElementById('app'));
