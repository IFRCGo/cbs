import React from 'react';
import { AllHealthRisks } from '../../../dolittle/HealthRisks/AllHealthRisks';
import  { default as execute } from '../../js/utils/QueryConfig';


class HealthRiskList extends React.Component{
    constructor(props) {
        super(props);
        console.warn(props);
        this.state = { elements: [] };
    }

    _getAllHealthRisks = async () => {
        var result =  await execute(new AllHealthRisks());

        if(result.success) {
            return result.items;
        } else {
            return [];
        }
    };

    async showHealthRisks() {
        return (await this._getAllHealthRisks()).map(healthrisk => {
            console.warn(healthrisk); 
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