import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter } from 'react-router-dom';
import { Provider } from 'react-redux';
import { Application } from '@ifrc-cbs/common-react-ui';

import App from './src/components/App';
import store from './src/store';

import '@ifrc-cbs/common-react-ui/src/assets/main.scss';
import './src/assets/main.scss';

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
            <Application routes={routes} />
        </BrowserRouter>
    </Provider>,
    document.getElementById('app')
);
