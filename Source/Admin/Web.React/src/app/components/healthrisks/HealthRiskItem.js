import React from 'react';
import { AllHealthRisks, DeleteHealthRisk, HealthRisk } from '../../../dolittle.imports'; 
import { CommandCoordinator } from '@dolittle/commands';
import { QueryCoordinator } from '@dolittle/queries';
import  queryCoordinator from '../../utils/QueryConfig'; 


export class HealthRiskItem extends React.Component{
    constructor(props) {
        super(props);
        console.warn(props);


    }

    componentDidMount() {

    }


    render() {
        return (
          <div>This is the health risk item component.</div>
        );
    }
}