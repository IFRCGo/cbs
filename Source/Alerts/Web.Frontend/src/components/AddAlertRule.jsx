import React, { Component } from 'react';
import { TextInputField, Button } from 'evergreen-ui';

class AddAlertRule extends Component {
    render() {
        return (
            <div className="">
                <h1>Alert Rule</h1>
                <p>Here you can set rules for health risk alerts.</p>
                <TextInputField label="Health risk name" />
                <TextInputField label="Health risk number" />
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
                <Button appearance="primary">Save</Button>
            </div>
        );
    }
}

export default AddAlertRule;
