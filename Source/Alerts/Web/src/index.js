import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter, Route } from 'react-router-dom';
import { Provider } from 'react-redux';

import App from './components/App';
import store from './store';

import './assets/main.scss';

const routes = [
    {
        component: App,
        route: '/alerts/',
        exact: false,
    }
];

ReactDOM.render(
    <Provider store={store}>
        <BrowserRouter>
            <Route path="/alerts/" exact component={App} />
        </BrowserRouter>
    </Provider>,
    document.getElementById('root')
);
