import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter, Route } from 'react-router-dom';
import { Provider } from 'react-redux';

import App from './components/App';
import RuleForm from './components/Alerts/AlertForm';
import RegisterDataOwner from './components/RegisterDataOwner';
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
        component: RegisterDataOwner,
        route: '/alerts/RegisterDataOwner',
        exact: false,
    }
];

ReactDOM.render(
    <Provider store={store}>
        <BrowserRouter>
            <Route path="/alerts/ListeRules" exact component={App} />
            <Route path="/alerts/" exact component={App} />
            <Route path="/alerts/AddRule" exact component={RuleForm} />
            <Route path="/alerts/RegisterDataOwner" exact component={RegisterDataOwner} />
        </BrowserRouter>
    </Provider>,
    document.getElementById('root')
);
