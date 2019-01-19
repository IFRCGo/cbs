import React, { Component } from 'react';
import { connect } from 'react-redux';
import AlertRuleOverview from './AlertRuleOverview';
import AddAlertRule from './AddAlertRule';

class App extends Component {
    render() {
        return (
            <div className="alerts">
                <AddAlertRule />
                <AlertRuleOverview />
            </div>
        );
    }
}

export default connect(state => ({
    baseUrl: state.root.baseUrl,
}))(App);
