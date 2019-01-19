import React from 'react';
import { NavLink } from 'react-router-dom';
import { Pane, Heading, TextInput, Button } from 'evergreen-ui';

const ListHeader = () => {
    return (
        <Pane display="flex" marginBottom={32}>
            <Pane display="flex" flex={1}>
                <Heading size={800}>Projects</Heading>
            </Pane>
            <Pane display="flex">
                <TextInput height={32} placeholder="Search" />
                <Button marginLeft={16} appearance="primary"><NavLink to="/projects/add-project">Add Project</NavLink></Button>
            </Pane>
        </Pane>
    );
};

export default ListHeader;
