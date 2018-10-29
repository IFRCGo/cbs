import React from 'react';
import { AllHealthRisks, DeleteHealthRisk, HealthRisk } from '../../../dolittle.imports'; 
import { CommandCoordinator } from '@dolittle/commands';
import { QueryCoordinator } from '@dolittle/queries';
import  queryCoordinator from '../../utils/QueryConfig'; 

import { HealthRiskItem, HealthRiskList} from './index';


export class HealthRisks extends React.Component{
    
    constructor(props) {
        super(props);
        console.warn(props);

    }

    componentDidMount() {

    }

    show = async () => {


    }


    render() {
        return (
            <tbody>
                <HealthRiskList render={(healthRisk) => {
                    console.warn(healthRisk); 
                    return  <HealthRiskItem healthRisk={healthRisk}></HealthRiskItem>
                }
                }></HealthRiskList>
            </tbody>
            
        );
    }
}