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
        command.numberOfCasesThreshold = 1;
        command.thresholdTimeframeInHours = 24;
        command.healthRiskNumber = this.state.healthRiskNumber;
        command.distanceBetweenCasesInMeters = 500;

        this.commandCoordinator.handle(command).then(result => {
            console.log(result, "Created");
        });
    }

    updateState(updates) {
        this.setState(...this.state, ...updates);
    }

    render() {
        return (
            <div className="">
                <h1>Alert Rule</h1>
                <p>Here you can set rules for health risk alerts.</p>
                <TextInputField
                    label="Health risk name"
                    onChange={e => this.setState({healthRiskName: e.target.value})}
                    value={this.state.healthRiskName} />
                <TextInputField
                    label="Health risk number"
                    onChange={e => this.setState({healthRiskNumber: e.target.value})}
                    value={this.state.healthRiskNumber} />

                {/* The 3 inputs beneath are not included in the MVP */}
                {/* <TextInputField
                label="Alert threshold"
                description="Number of cases to rise an alert" />
            <TextInputField
                label="Threshold intervall"
                description="I want to cound threshold of cases that is notified within this timeframe" />
            <TextInputField
                label="Max distance between cases (km)" /> */}
                <Button appearance="default">Cancel</Button>
                <Button appearance="primary" onClick={() => this.addRule()}>Create</Button>
            </div>
        );
    }
}

export default AddAlertRule;
