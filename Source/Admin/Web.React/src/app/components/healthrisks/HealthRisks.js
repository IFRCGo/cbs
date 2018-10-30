import React from 'react';

import { HealthRiskList, HealthRiskItem } from './index';


export class HealthRisks extends React.Component{
    
    constructor(props) {
        super(props);
        console.warn(props);

    }

    componentDidMount() {

    }

    render() {
        return (
            <HealthRiskList render={(healthRisk) => 
                <HealthRiskItem healthRisk={healthRisk}></HealthRiskItem>
            }></HealthRiskList>
        );
    }
}