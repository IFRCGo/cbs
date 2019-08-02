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
                <option key={healthRisk.name} value={healthRisk.name}> {healthRisk.name} </option>)
        );
    }

    render() {
        return (
            <div className="tableContainer">
                <h2 className="headline">Reports for one health risk </h2>

                Select health risk: 
                    <Select 
                        native
                        className="headline-select"
                        value={this.state.selected}
                        onChange={this.saveSelectedValue.bind(this)}
                    >
                        {this.renderOptions()}
                    </Select>

                <h3>Reports for the last 7 days</h3>
                <ReportsPerHealthRiskPerDay selectedHealthRisk={this.state.selected} />
                <h3>Reports for the last 4 weeks</h3>
                <ReportsPerHealthRiskPerRegionLast4Weeks selectedHealthRisk={this.state.selected} />
            </div>
        );
    }
}