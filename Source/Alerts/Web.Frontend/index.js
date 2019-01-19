import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter } from 'react-router-dom';
import { Provider } from 'react-redux';
import { Application } from '@ifrc-cbs/common-react-ui';

import App from './src/App';
import store from './src/store';

import '@ifrc-cbs/common-react-ui/src/assets/main.scss';
import './src/assets/main.scss';

const routes = [
    {
        component: Rules,
        path: '/alerts/',
        exact: false,
    },
];

ReactDOM.render(
    <Provider store={store}>
        <BrowserRouter>
            <Application routes={routes} store={store}>
                <App />
            </Application>
        </BrowserRouter>
    </Provider>,
    document.getElementById('app')
);
