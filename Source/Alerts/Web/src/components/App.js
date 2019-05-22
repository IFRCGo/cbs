import React, { Component } from 'react';
import AlertRules from './AlertsRule/AlertRuleList';

class App extends Component {

    render() {
        return (
            <div className="alerts">
                <AlertRules/>
            </div>
        );
    }
}
export default App;
