import React from 'react';
import { getHealthRiskById } from '../../js/utils/HealthRisk'; 

class HealthRiskShow extends React.Component{
    constructor(props) {
        super(props);
        console.warn(props);

        this.state = { healthRiskId : null }
        console.warn(this.props.type); 
        
    }

    async componentDidMount() {

        var params = this.props.match.params;

        if(params && params.healthRiskId) {
            this.setState({ healthRisk : await getHealthRiskById(params.healthRiskId) });
        }
    }


    render() {
        return (
            <div class="form-group">
                { "The health risk details works " + this.state.healthRisk} 

            </div>
        );
    }
}

export default HealthRiskShow;