import React, { Component } from 'react';
import { Button } from 'evergreen-ui';
import AlertRuleList from './AlertRuleList';

class AlertRuleOverview extends Component {
    render() {
        return (
            <div>
                <h1>Alert rule overview</h1>
                <p>Here are the alert rules you have registered</p>
                {/* Here we will add the search */}
                {/* <Button
                    appearance="primary"
                    onClick={() => {
                        console.log('click');
                    }}
                >
                    Add alert rule
                </Button> */}
                <AlertRuleList />
            </div>
        );
    }
}

export default AlertRuleOverview;
