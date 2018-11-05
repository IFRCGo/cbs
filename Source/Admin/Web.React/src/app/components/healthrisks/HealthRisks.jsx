import React from 'react';
import { Link } from 'react-router-dom';
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
            <div style={{ textAlign:"left"}}> 
                <h3>
                    Health Risks
                </h3>

                <Link to={`/healthrisk/create/`} ><button type="button" class="btn btn-primary pull-right">Add Health Risk</button></Link>

                <HealthRiskList render={(healthRisk) =>  <HealthRiskItem healthRisk={healthRisk}/>} />
            </div>
       
        );
    }
}

export default HealthRisks;