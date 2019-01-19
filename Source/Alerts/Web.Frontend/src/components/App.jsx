import React, { Component } from 'react';
import { connect } from 'react-redux';
import AlertRuleOverview from './AlertRuleOverview';

class App extends Component {
    render() {
        return (
            <div className="alerts">
                <AlertRuleOverview />
            </div>
        );
    }
}

export default connect(state => ({
    baseUrl: state.root.baseUrl,
}))(App);
