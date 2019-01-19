import React, { Component } from 'react';
import { Table } from 'evergreen-ui';
import { TableHead } from 'evergreen-ui/commonjs/table';
import TableBody from 'evergreen-ui/commonjs/table/src/TableBody';
import AlertRule from './AlertRule';

class AlertRuleList extends Component {
    render() {
        function rule(id) {
            return {
                Id: id,
                Name: 'Ebola',
                HealthRiskId: '1',
                Threshold: '1',
                TimeFrame: '24 hours',
                DistanceBetweenCases: '2 km',
            };
        }
        const rules = [rule(0), rule(1), rule(2), rule(3)];

        return (
            <Table>
                <TableHead>
                    <Table.TextHeaderCell>Alert rule name</Table.TextHeaderCell>
                    <Table.TextHeaderCell>Health risk ID</Table.TextHeaderCell>
                    <Table.TextHeaderCell>Alert threshold</Table.TextHeaderCell>
                    <Table.TextHeaderCell>Timeframe</Table.TextHeaderCell>
                    <Table.TextHeaderCell>Distance between cases</Table.TextHeaderCell>
                    <Table.TextHeaderCell />
                </TableHead>
                <TableBody>
                    {rules.map(rule => (
                        <AlertRule key={rule.Id} rule={rule} />
                    ))}
                </TableBody>
            </Table>
        );
    }
}

export default AlertRuleList;
