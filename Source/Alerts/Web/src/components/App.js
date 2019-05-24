import React, { Component } from 'react';
import { BrowserRouter, Route } from 'react-router-dom';
import CBSNavigation from './Navigation/CBSNavigation';
import AlertMenu from './AlertMenu';
import AlertRuleOverview from './AlertRuleOverview';
import AddAlertRule from './AddAlertRule';
import AlertOverview from './AlertOverview';
import RegisterDataOwner from './RegisterDataOwner';


class App extends Component {

    render() {
        return (
            <BrowserRouter>
                <CBSNavigation />
                <AlertMenu />

                <Route path="/alerts/rules" exact component={AlertRuleOverview} />
                <Route path="/alerts/addrule" exact component={AddAlertRule} />
                <Route path="/alerts" exact component={AlertOverview} />
                <Route path="/alerts/registerdataowner" exact component={RegisterDataOwner} />
            </BrowserRouter>
        );
    }
}
export default App;
