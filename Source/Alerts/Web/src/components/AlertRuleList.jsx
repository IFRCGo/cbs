import React, { Component } from 'react';
import { connect } from 'react-redux';
import { Table } from 'evergreen-ui';
import { TableHead } from 'evergreen-ui/commonjs/table';
import TableBody from 'evergreen-ui/commonjs/table/src/TableBody';
import { QueryCoordinator } from '@dolittle/queries/dist/commonjs';
import { AllAlertRules } from '../../Features/AlertRules/AllAlertRules';


import AlertRule from './AlertRule';

class AlertRuleList extends Component {
    constructor(props) {
        super(props);

        QueryCoordinator.apiBaseUrl = "http://localhost:5000";
        this.queryCoordinator = new QueryCoordinator();

        let query = new AllAlertRules();

        this.queryCoordinator.execute(query).then(result => {
            this.setState({rules: result.items});
        })

        this.state = {
            rules: []
        };
    }

    render() {
        const { rules } = this.state;
        return (
            <Table>
                <TableHead>
                    <Table.TextHeaderCell>Alert rule name</Table.TextHeaderCell>
                    <Table.TextHeaderCell>Health risk ID</Table.TextHeaderCell>
                    {/* <Table.TextHeaderCell>Alert threshold</Table.TextHeaderCell>
                    <Table.TextHeaderCell>Timeframe</Table.TextHeaderCell>
                    <Table.TextHeaderCell>Distance between cases</Table.TextHeaderCell>
                    <Table.TextHeaderCell /> */}
                </TableHead>
                <TableBody>
                    {rules.map(rule => (
                        <AlertRule key={rule.id} rule={rule} />
                    ))}
                </TableBody>
            </Table>
        );
    }
}

export default connect(state => ({
    rules: state.root.rules,
}))(AlertRuleList);
