import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter, Route } from 'react-router-dom';
import { Provider } from 'react-redux';

import App from './components/App';
import RuleForm from './components/AlertsRule/AlertRuleForm';
import AlertOverview from './components/Alerts/AlertOverview';
import RegisterDataOwner from './components/RegisterDataOwner';
import AlertMenu from './components/AlertMenu';
import CBSNavigation from './components/Navigation/CBSNavigation';
import store from './store';

import './assets/main.scss';

const routes = [
    {
        component: App,
        route: '/alerts/ListeRules',
        exact: false,
    },
    {
        component: RuleForm,
        route: '/alerts/AddRule',
        exact: false,
    },
    {
        component: AlertOverview,
        route: '/alerts',
        exact: false,
    }
];

ReactDOM.render(
    <Provider store={store}>
        <BrowserRouter>
            <CBSNavigation />
            <AlertMenu />

            <Route path="/alerts/ListeRules" exact component={App} />
            <Route path="/alerts/AddRule" exact component={RuleForm} />
            <Route path="/alerts" exact component={AlertOverview} />
            <Route path="/alerts/RegisterDataOwner" exact component={RegisterDataOwner} />
        </BrowserRouter>
    </Provider>,
    document.getElementById('root')
);