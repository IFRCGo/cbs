import React, { Component } from 'react';
import { TextInputField, Button } from 'evergreen-ui';
import { CommandCoordinator } from '@dolittle/commands/dist/commonjs';
import { CreateAlertRule } from '../../Features/AlertRules/CreateAlertRule';

class AddAlertRule extends Component {
    constructor(props) {
        super(props);

        CommandCoordinator.apiBaseUrl = "http://localhost:5000";
        this.commandCoordinator = new CommandCoordinator();
        

        this.state = {
            healthRiskName: "",
            healthRiskNumber: ""
        };
    }

    addRule() {
        let command = new CreateAlertRule();

        command.alertRuleName = this.state.healthRiskName;
        command.numberOfCasesThreshold = this.state.numberOfCasesThreshold;
        command.thresholdTimeframeInHours = this.state.thresholdTimeframeInHours;
        command.healthRiskNumber = this.state.healthRiskNumber;

        this.commandCoordinator.handle(command);
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
                    onChange={e => this.setState({healthRiskName: e.target.value})}
                    value={this.state.healthRiskName} />
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
                    label="Threshold interval (in hours)"
                    description="Timeframe within cases should be included"
                    placeholder="i.e. 24"
                    onChange={e => this.setState({thresholdTimeframeInHours: e.target.value})}
                    value={this.state.thresholdTimeframeInHours} />

                <Button appearance="primary" onClick={() => this.addRule()}>Create</Button>
                <Button appearance="default" onClick={() => this.resetState()}>Cancel</Button>
            </div>
        );
    }
}

export default AddAlertRule;
