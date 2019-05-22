import React, { Component } from 'react';
import { connect } from 'react-redux';
import AlertRules from './AlertsRule/AlertRuleList';

class App extends Component {
    componentWillMount() {
        // this.props.requestRules();
    }

    render() {
        return (
            <div className="alerts">
                <AlertRules/>
            </div>
        );
    }
}
export default App;
// export default connect(
//     state => ({
//         baseUrl: state.root.baseUrl,
//     }),
//     dispatch => ({
//         requestRules: () => {
//             dispatch({ type: 'REQUEST_RULES' });
//         },
//     })
// )(App);
