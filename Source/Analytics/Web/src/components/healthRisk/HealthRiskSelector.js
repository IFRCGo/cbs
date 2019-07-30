import React, { Component } from 'react';
import { AllHealthRisks } from '../../Features/HealthRisks/AllHealthRisks';
import { QueryCoordinator } from '@dolittle/queries/dist/commonjs/QueryCoordinator';
import Select from '@material-ui/core/Select';
import MenuItem from '@material-ui/core/MenuItem';
import ReportsPerHealthRiskPerDay from '../Reports/ReportsPerHealthRiskPerDay';
import ReportsPerHealthRiskPerRegionLast4Weeks from '../Reports/ReportsPerHealthRiskPerRegionLast4Weeks';

export default class HealthRiskSelector extends Component {
    constructor(props) {
        super(props);

        this.state = {
            healthRisks: [],
            selected: ''
        };
    }

    componentDidMount() {
        const query = new AllHealthRisks();
        const queryCoordinator = new QueryCoordinator();

        queryCoordinator.execute(query).then(res => {
            if (res.items[0] != null) {
                this.setState({ healthRisks: res.items, selected: res.items[0].name });
            } else {
                this.setState({ healthRisks: res.items, selected: null });
            }
        });
    }

    saveSelectedValue(event) {
        this.setState({
            selected: event.target.value
        });
    }

    renderOptions() {
        return this.state.healthRisks.map(
            healthRisk => (
                <MenuItem
                    key={healthRisk.healthRiskNumber}
                    value={healthRisk.name}
                >{healthRisk.name}</MenuItem>)
        );
    }

    render() {
        return (
            <>
                <h2 className="headerText">Reports for
                <Select className="headerSelect"
                        value={this.state.selected}
                        onChange={this.saveSelectedValue.bind(this)}
                    >
                        {this.renderOptions()}
                    </Select>
                </h2>
                <div className="tableContainer">
                    <h5>Reports for the last 7 days</h5>
                    <ReportsPerHealthRiskPerDay healthRisk={this.state.selected} />
                    <h5>Reports for the last 4 weeks</h5>
                    <ReportsPerHealthRiskPerRegionLast4Weeks healthRisk={this.state.selected} />
                </div>
            </>
        );
    }
}