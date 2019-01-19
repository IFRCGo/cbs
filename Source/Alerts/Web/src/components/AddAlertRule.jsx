import React, { Component } from 'react';
import { connect } from 'react-redux';
import { TextInputField, Button } from 'evergreen-ui';
import { CreateAlertRule } from '../../Features/AlertRules/CreateAlertRule';

class AddAlertRule extends Component {
    constructor(props) {
        super(props);

        this.state = {
            healthRiskName: '',
            healthRiskNumber: '',
        };
    }

    addRule() {
        let rule = {
            ...new CreateAlertRule(),
            alertRuleName: this.state.healthRiskName,
            healthRiskNumber: this.state.healthRiskNumber,
        };

        this.props.requestCreateRule(rule);
    }

    resetState() {
        this.setState({
            healthRiskName: '',
            healthRiskNumber: '',
        });
    }

    render() {
        return (
            <div className="">
                <h1>Alert Rule</h1>
                <p>Here you can set rules for health risk alerts.</p>
                <TextInputField
                    label="Health risk name"
                    onChange={e => this.setState({ healthRiskName: e.target.value })}
                    value={this.state.healthRiskName}
                />
                <TextInputField
                    label="Health risk number"
                    onChange={e => this.setState({ healthRiskNumber: e.target.value })}
                    value={this.state.healthRiskNumber}
                />

                {/* The 3 inputs beneath are not included in the MVP */}
                {/* <TextInputField
                label="Alert threshold"
                description="Number of cases to rise an alert" />
            <TextInputField
                label="Threshold intervall"
                description="I want to cound threshold of cases that is notified within this timeframe" />
            <TextInputField
                label="Max distance between cases (km)" /> */}
                <Button appearance="default" onClick={() => this.resetState()}>
                    Cancel
                </Button>
                <Button appearance="primary" onClick={() => this.addRule()}>
                    Create
                </Button>
            </div>
        );
    }
}

export default connect(
    _ => ({}),
    dispatch => ({
        requestCreateRule: rule => dispatch({ type: 'REQUEST_CREATE_RULE', payload: rule }),
    })
)(AddAlertRule);
