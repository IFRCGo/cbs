import React, { Component } from 'react';
import { connect } from 'react-redux';
import { TextInputField, Button } from 'evergreen-ui';
import { CreateAlertRule } from '../../Features/AlertRules/CreateAlertRule';

class AddAlertRule extends Component {
    constructor(props) {
        super(props);

        this.state = {
            alertRuleName: "",
            healthRiskNumber: "",
            numberOfCasesThreshold: "",
            thresholdTimeframeInHours: ""
        };
    }

    addRule() {
        let request = {
            ...new CreateAlertRule(),
            alertRuleName: this.state.alertRuleName,
            healthRiskNumber: this.state.healthRiskNumber,
            numberOfCasesThreshold: this.state.numberOfCasesThreshold,
            thresholdTimeframeInHours: this.state.thresholdTimeframeInHours
        };

        this.props.requestCreateRule(request);
        this.resetState();
    }

    resetState() {
        this.setState({
            alertRuleName: "",
            healthRiskNumber: "",
            numberOfCasesThreshold: "",
            thresholdTimeframeInHours: ""
        });
    }

    render() {
        return (
            <div className="">
                <h1>Alert Rule</h1>
                <p>Here you can set rules for health risk alerts.</p>
                <TextInputField
                    label="Alert rule name"
                    placeholder="i.e. Acute watery diarrhoea"
                    onChange={e => this.setState({alertRuleName: e.target.value})}
                    value={this.state.alertRuleName} />
                <TextInputField
                    label="Health risk number"
                    placeholder="i.e. 1"
                    onChange={e => this.setState({healthRiskNumber: e.target.value})}
                    value={this.state.healthRiskNumber} />
                <TextInputField
                    label="Alert threshold"
                    placeholder="i.e. 2"
                    description="Number of cases to rise an alert"
                    onChange={e => this.setState({numberOfCasesThreshold: e.target.value})}
                    value={this.state.numberOfCasesThreshold} />
                <TextInputField
                    label="Threshold timeframe (in hours)"
                    description="Timeframe within which cases should be included"
                    placeholder="i.e. 24"
                    onChange={e => this.setState({thresholdTimeframeInHours: e.target.value})}
                    value={this.state.thresholdTimeframeInHours} />

                <Button appearance="primary" onClick={() => this.addRule()}>Create</Button>
                <Button appearance="default" onClick={() => this.resetState()}>Cancel</Button>
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
