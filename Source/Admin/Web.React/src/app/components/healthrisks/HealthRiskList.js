import React from 'react';
import { AllHealthRisks, DeleteHealthRisk, HealthRisk } from '../../../dolittle.imports'; 
import { CommandCoordinator } from '@dolittle/commands';
import { QueryCoordinator } from '@dolittle/queries';
import  queryCoordinator from '../../utils/QueryConfig'; 


export class HealthRiskList extends React.Component{
    constructor(props) {
        super(props);
        
        console.warn(queryCoordinator); 

        queryCoordinator.execute(new AllHealthRisks())
            .then(response => {
                console.warn(response); 
                if (response.success) {
                    this.risks = response.items;
                    this.sortRisks('id')
                } else {
                    console.error(response);
                }
            })
            .catch(response => {
                console.error(response);
            });

        /*this.queryCoordinator.execute(new AllHealthRisks())
            .then(response => {
                if (response.success) {
                    this.risks = response.items;
                    this.sortRisks('id')
                } else {
                    console.error(response);
                }
            })
            .catch(response => {
                console.error(response);
            });*/
    }
    
    render() {
        return (
          <div>This is the health risk component.</div>
        );
    }
}