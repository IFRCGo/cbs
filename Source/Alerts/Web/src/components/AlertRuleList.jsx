import React, { Component } from 'react';
import { connect } from 'react-redux';
import { Table } from 'evergreen-ui';
import { TableHead } from 'evergreen-ui/commonjs/table';
import TableBody from 'evergreen-ui/commonjs/table/src/TableBody';

import AlertRule from './AlertRule';

class AlertRuleList extends Component {
    render() {
        const { rules } = this.props;

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

export default connect(state => ({
    rules: state.root.rules,
}))(AlertRuleList);
