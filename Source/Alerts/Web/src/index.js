import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter, Route } from 'react-router-dom';
import { Provider } from 'react-redux';

import App from './components/App';
import AlertOverview from './components/Alerts/AlertOverview';
import RegisterDataOwner from './components/RegisterDataOwner';
import AlertMenu from './components/AlertMenu';
import CBSNavigation from './components/Navigation/CBSNavigation';
import AddAlertRule from './components/AddAlertRule';
import store from './store';

import './assets/main.scss';
import AlertRuleOverview from './components/AlertRuleOverview';

ReactDOM.render(
    <Provider store={store}>
        <BrowserRouter>
            <CBSNavigation />
            <AlertMenu />

            <Route path="/alerts/rules" exact component={AlertRuleOverview} />
            <Route path="/alerts/addrule" exact component={AddAlertRule} />
            <Route path="/alerts" exact component={AlertOverview} />
            <Route path="/alerts/registerdataowner" exact component={RegisterDataOwner} />
        </BrowserRouter>
    </Provider>,
    document.getElementById('root')
);