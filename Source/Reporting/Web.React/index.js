import React from "react";
import ReactDOM from "react-dom";
import { BrowserRouter } from "react-router-dom";
import { StoreManager } from "repertoire";
import { Provider } from "react-redux";
import { Application } from "@ifrc-cbs/common-react-ui";
import Reporting from "./src/components/Reporting";
import Projects from "@ifrc-cbs/admin";
import UserManagement from "./src/components/userManagement/UserManagement";
import AddDataCollector from "./src/components/userManagement/AddDataCollector";

import "@ifrc-cbs/common-react-ui/src/assets/main.scss";
import "./src/assets/main.scss";

const routes = [
    {
        component: Reporting,
        path: "/reporting/:filter",
        exact: false
    },

    {
        component: Projects,
        path: "/projects",
        exact: false
    },
    {
        component: UserManagement,
        path: "/users",
        exact: true
    },
    { component: AddDataCollector, path: "/users/add", exact: true },
    { component: AddDataCollector, path: "/users/edit/:id", exact: false }
];

const storeManager = new StoreManager(routes);

ReactDOM.render(
    <Provider store={storeManager.getStore()}>
        <BrowserRouter>
            <Application routes={routes} store={storeManager.getStore()} />
        </BrowserRouter>
    </Provider>,
    document.getElementById("app")
);
