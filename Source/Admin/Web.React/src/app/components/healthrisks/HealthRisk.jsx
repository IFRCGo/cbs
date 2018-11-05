import React from 'react';
import { getHealthRiskById } from '../../js/utils/HealthRisk'; 

class HealthRisk extends React.Component{
    state = {
        healthRisk : null, 
        type : null
    }
    
    constructor(props) {
        super(props);
        //console.warn(props);

        //console.warn(this.props.type);  
        this.setState({ type : this.props.state});
    }

    async componentDidMount() {
        var params = this.props.match.params;

        if(params && params.healthRiskId) {
            this.setState({ healthRisk : await getHealthRiskById(params.healthRiskId), type : this.props.type });
        } else {
            this.setState({ healthRisk : null, type : this.props.type});
        }
    }

    render() {
        let showHealthRisk = null; 

        console.warn(this.props); 

        if(this.state.type === 'edit') {
            showHealthRisk = "edit";
        } else if(this.state.type === 'create') {
            showHealthRisk = "create";
        } else if(this.state.type === 'delete') {
            showHealthRisk = "delete"; 
        } else if(this.state.type === 'show') {
            showHealthRisk = "show";
        }

        return (
            <div>{showHealthRisk}
            </div>
        );
    }
}

export default HealthRisk;