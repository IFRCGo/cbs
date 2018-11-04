import React from 'react';
import { getAllHealthRisks } from '../../js/utils/HealthRisk'; 

class HealthRiskList extends React.Component{
    constructor(props) {
        super(props);
        this.state = { elements: [] };
    }

    async showHealthRisks() {
        return (await getAllHealthRisks()).map(healthrisk => {
            return this.props.render(healthrisk);
        });
    }

    async componentDidMount() {
        this.setState({ elements : await this.showHealthRisks() });
    }

    render() {
        return (
            <table className="table table-bordered table-striped">
                <thead>
                    <tr>
                        <th> ID
                            <span></span>
                        </th>
                        <th>Health risk</th>
                        <th>Case Definition</th>
                        <th>Key Actions</th>
                    </tr>
                </thead>
                <tbody>
                { this.state.elements.map(el => {
                    return el
                }) }
                </tbody>
            </table>            
        );
    }
}

export default HealthRiskList;