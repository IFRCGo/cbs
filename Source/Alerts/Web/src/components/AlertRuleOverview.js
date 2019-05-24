import React, { Component } from 'react';
import { connect } from 'react-redux';
import { Button, Table, TableHead } from 'evergreen-ui';
import { Link } from 'react-router-dom';
import AlertRule from './AlertRule';


class AlertRuleOverview extends Component {

    componentDidMount() {
        this.props.requestRules();
    }

    render() {
        const { rules = []} = this.props;
        return (
            <div>
                <h1>Alert rule overview</h1>
                <p>Here are the alert rules you have registered</p>
                <Button
                    appearance="default"
                    iconBefore="plus"
                    is={Link}
                    to="/alerts/addrule">
                    Add alert rule
                </Button>
                <Table>
                    <TableHead>
                        <Table.TextHeaderCell>Alert rule name</Table.TextHeaderCell>
                        <Table.TextHeaderCell>Health risk</Table.TextHeaderCell>
                        <Table.TextHeaderCell>Alert threshold</Table.TextHeaderCell>
                        <Table.TextHeaderCell>Timeframe</Table.TextHeaderCell>
                    </TableHead>
                    <Table.Body>
                        {rules.map(rule => (
                            <AlertRule rule={rule} key={rule.id} />
                        ))}
                    </Table.Body>
                </Table>
            </div>
        );
    }
}

export default connect(
    state => ({
        rules: state.root.rules
    }),
    dispatch => ({
        requestRules: () => dispatch({ type: 'REQUEST_RULES'})
    })
)(AlertRuleOverview);
