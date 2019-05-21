import React, { Component } from 'react';
import { connect } from 'react-redux';
import Alert from './AlertsRule/AlertRuleList';
import AlertMenu from './AlertMenu';
import CBSNavigation from './Navigation/CBSNavigation';

class App extends Component {
    componentWillMount() {
        this.props.requestRules();
    }

    render() {
        return (
            <div className="alerts">
                <CBSNavigation />
                <AlertMenu/>
                <Alert/>
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
