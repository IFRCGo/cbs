import React from 'react';
import ReactDOM from "react-dom";
import { BrowserRouter, Route } from "react-router-dom";
import { Provider } from "react-redux";
import rootReducer from "./reducers";
import { createStore, applyMiddleware } from "redux";
import thunk from "redux-thunk";
import {QueryCoordinator} from '@dolittle/queries';

import "./assets/react-leaflet.scss";
import "./assets/main.scss";
import CountryOverview from './components/CountryOverview/CountryOverview';
import LightweightAreaOverview from './components/Lightweight/LightweightAreaOverview';

QueryCoordinator.apiBaseUrl = process.env.API_BASE_URL;

const store = createStore(rootReducer, applyMiddleware(thunk));

ReactDOM.render(
    <Provider store={store}>
        <BrowserRouter>
            <div>
                <Route path="/analytics/" exact component={CountryOverview} />
                <Route path="/analytics/lite/" exact component={LightweightAreaOverview} />
            </div>
        </BrowserRouter>
    </Provider>,
    document.getElementById("app")
);
