import React, { Component } from 'react';
import { connect } from 'react-redux';
import AlertRuleOverview from './AlertRuleOverview';
import AddAlertRule from './AddAlertRule';

class App extends Component {
    componentWillMount() {
        this.props.requestRules();
    }

    render() {
        return (
            <div className="alerts">
                <AddAlertRule />
                <AlertRuleOverview />
            </div>
        );
    }
}

export default connect(
    state => ({
        baseUrl: state.root.baseUrl,
    }),
    dispatch => ({
        requestRules: () => {
            dispatch({ type: 'REQUEST_RULES' });
        },
    })
)(App);
