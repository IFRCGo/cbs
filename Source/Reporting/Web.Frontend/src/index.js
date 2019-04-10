
import React from 'react';
import ReactDOM from "react-dom";
import { BrowserRouter, Route } from "react-router-dom";
import { Provider } from "react-redux";
import { routes } from "./utils/routes";
import rootReducer from "./reducers";
import { createStore, applyMiddleware } from "redux";
import thunk from "redux-thunk";

import "./assets/react-leaflet.scss";
import "./assets/main.scss";
import Reporting from './components/Reporting';

const store = createStore(rootReducer, applyMiddleware(thunk));

ReactDOM.render(
    <Provider store={store}>
        <BrowserRouter>
            <Route path="/" exact component={Reporting} />  
        </BrowserRouter>
    </Provider>,
    document.getElementById("app")
);
