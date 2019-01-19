import React from 'react';
import { Table } from 'evergreen-ui';

const AlertRule = ({ rule }) => {
    return (
        <Table.Row>
            <Table.TextCell>{rule.alertRuleName}</Table.TextCell>
            <Table.TextCell>{rule.healthRiskId}</Table.TextCell>
            {/* <Table.TextCell>{rule.threshold}</Table.TextCell>
            <Table.TextCell>{rule.thresholdTimeframeInHours}</Table.TextCell>
            <Table.TextCell>{rule.distanceBetweenCasesInMeters}</Table.TextCell>
            <Table.TextCell>...</Table.TextCell> */}
        </Table.Row>
    );
};

export default AlertRule;
