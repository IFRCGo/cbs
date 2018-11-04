import React from 'react';
import { Link } from 'react-router-dom';


class HealthRiskItem extends React.Component{
    constructor(props) {
        super(props);
        this.state = { healthrisk : props.healthRisk }
    }

    render() {
        return (
            <tr>
                <td>{ this.state.healthrisk.id }</td>
                <td>{ this.state.healthrisk.name }}</td>
                <td>{ this.state.healthrisk.caseDefinition }</td>
                <td><Link to={`/healthrisk/detail/${this.state.healthrisk.id}`}>Edit</Link></td>
            </tr>
        );
    }
}

export default HealthRiskItem;