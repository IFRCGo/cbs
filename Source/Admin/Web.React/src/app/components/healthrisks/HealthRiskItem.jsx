import React from 'react';

class HealthRiskItem extends React.Component{
    constructor(props) {
        super(props);
        this.state = { healthrisk : props.healthRisk }
    }

    componentDidMount() {

    }


    render() {
        return (
            <tr>
                <td>{ this.state.healthrisk.id }</td>
                <td>{ this.state.healthrisk.name }}</td>
                <td>{ this.state.healthrisk.caseDefinition }</td>
                <td />
            </tr>
        );
    }
}

export default HealthRiskItem;