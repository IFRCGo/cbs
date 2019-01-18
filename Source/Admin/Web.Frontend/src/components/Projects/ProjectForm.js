import React, { Component } from 'react';
import { Pane, Heading, TextInputField, Combobox, Text, Button, BackButton } from 'evergreen-ui';

export default class ProjectForm extends Component {
    constructor(props) {
        super(props)
        this.state = {
            projectName: '',
            dataOwner: '',
            HealthRisks: [],
            laguange: '',
            startDate: '',
            endDate: '',
            coordinates: ''
        }
    }

    onDateOwnerChange(e) {
        e.preventDefault();
        const dataOwner = e.target.value;
        this.setState(() => ({ dataOwner }));
    }

    onProjectNameChange(e) {
        const projectName = e.target.value;
        this.setState(() => ({ projectName }));
    }

    render() {
        return (
            <Pane>
                <Heading marginBottom={32} size={800}>Add Project</Heading>
                {/* TOP PART */}
                <Pane display="flex">
                    <TextInputField
                        marginRight={55}
                        width="50%"
                        label="Default text input field"
                        description="This is a description."
                        placeholder="Placeholder text"
                        onChange={this.onProjectNameChange}
                    />
                    <Pane display="flex" flexDirection="column" width="50%">
                        <Heading size={400}>Data Owner</Heading>
                        <Text>This is a description</Text>
                        <Combobox
                            marginRight={55}
                            width="100%"
                            items={['Abo', 'Eric', 'Adam', 'Peter']}
                            onChange={this.onDateOwnerChange}
                            placeholder="Type your name here"
                            autocompleteProps={{
                                // Used for the title in the autocomplete.
                                title: 'Data Owner'
                            }}
                        />
                    </Pane>
                </Pane>
                <Pane>
                    {/* 2ND PART */}
                    {/* TAG INPUT HERE */}
                    {/* LANGUAGE HERE */}
                </Pane>
                <Pane display="flex" flexDirection="column">
                    {/* TIMESTAMP INPUT HERE */}
                    {/* MAP INTEGRATION HERE */}
                </Pane>
                <BackButton />
                <Button marginLeft={32} appearance="primary">Add</Button>
            </Pane>
        )
    }
}
