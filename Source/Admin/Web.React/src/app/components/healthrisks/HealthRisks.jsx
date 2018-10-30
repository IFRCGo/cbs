import React from 'react';

import HealthRiskList from './HealthRiskList';
import HealthRiskItem from './HealthRiskItem';


class HealthRisks extends React.Component{
    
    constructor(props) {
        super(props);
        console.warn(props);

    }

    componentDidMount() {

    }

    render() {
        return (
            <HealthRiskList render={(healthRisk) =>  <HealthRiskItem healthRisk={healthRisk}/>} />
        );
    }
}

export default HealthRisks;