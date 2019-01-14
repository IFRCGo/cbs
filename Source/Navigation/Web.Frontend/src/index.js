import React from 'react';
import ReactDOM from 'react-dom';
import {BrowserRouter} from 'react-router-dom';
import {StoreManager} from 'repertoire';
import {Provider} from 'react-redux';

import {Application} from '@ifrc-cbs/common-react-ui';
import Reporting from '@ifrc-cbs/reporting';

import '@ifrc-cbs/common-react-ui/src/assets/main.scss';

const routes = [
  {
    component: Reporting,
    path: '/reporting/:filter',
    exact: false
  }
];

const storeManager = new StoreManager(routes);

ReactDOM.render(<Provider store={storeManager.getStore()}>
  <BrowserRouter>
    <Application routes={routes} store={storeManager.getStore()}/>
  </BrowserRouter>
</Provider>, document.getElementById('app'));
