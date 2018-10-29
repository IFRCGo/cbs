import React from 'react';
import { AllHealthRisks, DeleteHealthRisk, HealthRisk } from '../../../dolittle.imports'; 
import { CommandCoordinator } from '@dolittle/commands';
import { QueryCoordinator } from '@dolittle/queries';
import  queryCoordinator from '../../utils/QueryConfig'; 


export class HealthRiskList extends React.Component{
    constructor(props) {
        super(props);
        console.warn(props);
    }

    async componentDidMount() {
       
    }

    async showHealthRisk() { 
        return (await this._getAllHealthRisks()).map(healthrisk => {
            return this.props.render(healthrisk);
        });
    }

    _getAllHealthRisks = async () => { 
        var result =  await queryCoordinator.execute(new AllHealthRisks());

        console.warn(result); 

        if(result.success) { 
            return result.items; 
        } else {
            return []; 
        }
    }; 

    render() {
        return (
            this.showHealthRisk().then(x => {
                return x; 
            })
        );
    }
}