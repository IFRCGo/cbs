import React from 'react';
import { Table } from 'evergreen-ui';

const AlertRule = ({ rule }) => {
    return (
        <Table.Row key={rule.Id}>
            <Table.TextCell>{rule.Name}</Table.TextCell>
            <Table.TextCell>{rule.HealthRiskId}</Table.TextCell>
            <Table.TextCell>{rule.Threshold}</Table.TextCell>
            <Table.TextCell>{rule.TimeFrame}</Table.TextCell>
            <Table.TextCell>{rule.DistanceBetweenCases}</Table.TextCell>
            <Table.TextCell>...</Table.TextCell>
        </Table.Row>
    );
};

export default AlertRule;
