import React from 'react';

class HealthRiskDetail extends React.Component{
    constructor(props) {
        super(props);
        console.warn(props);

        this.state = { healthRiskId : null }
    }

    componentDidMount() {
        var params = this.props.match.params;

        if(params && params.healthRiskId) {
            this.setState({ healthRiskId : params.healthRiskId });
        }
    }


    render() {
        return (
            "The health risk details works " + this.state.healthRiskId
        );
    }
}

export default HealthRiskDetail;