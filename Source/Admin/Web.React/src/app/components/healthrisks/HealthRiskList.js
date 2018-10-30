import React from 'react';
import ReactDOM from "react-dom";
import { AllHealthRisks } from '../../../dolittle.imports'; 
import  queryCoordinator from '../../utils/QueryConfig'; 


export class HealthRiskList extends React.Component{
    constructor(props) {
        super(props);
        console.warn(props);
        this.state = { elements: [] };
    }

    _getAllHealthRisks = async () => { 
        var result =  await queryCoordinator.execute(new AllHealthRisks());

        if(result.success) { 
            return result.items; 
        } else {
            return []; 
        }
    }

    async showHealthRisks() { 
        return (await this._getAllHealthRisks()).map(healthrisk => {
            return this.props.render(healthrisk);
        });
    }

    
    
    async componentDidMount() {
        this.setState({ elements : await this.showHealthRisks() });
     }

    render() {
        return (
            <table class="table table-bordered table-striped">
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