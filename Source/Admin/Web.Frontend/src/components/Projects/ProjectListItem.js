import React from 'react';
import { Table, Pane } from 'evergreen-ui';

const ProjectListItem = (props) => {
    return (
        <Pane>
            <Table.Row height={40} isSelectable>
                <Table.TextCell>{props.data.projectName}</Table.TextCell>
                <Table.TextCell>{props.data.dataOwner}</Table.TextCell>
                <Table.TextCell>{props.data.geographicalScope}</Table.TextCell>
                <Table.TextCell>{props.data.healthRisk}</Table.TextCell>
            </Table.Row>
        </Pane>
    )
};

export default ProjectListItem;
