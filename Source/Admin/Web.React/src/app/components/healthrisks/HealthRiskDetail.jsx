import React from 'react';
import { getHealthRiskById } from '../../js/utils/HealthRisk'; 

class HealthRiskDetail extends React.Component{
    constructor(props) {
        super(props);
        console.warn(props);

        this.state = { healthRiskId : null }
    }

    async componentDidMount() {
        var params = this.props.match.params;

        if(params && params.healthRiskId) {
            this.setState({ healthRisk : await getHealthRiskById(params.healthRiskId) });
        }
    }


    render() {
        return (
            "The health risk details works " + this.state.healthRisk
        );
    }
}

export default HealthRiskDetail;