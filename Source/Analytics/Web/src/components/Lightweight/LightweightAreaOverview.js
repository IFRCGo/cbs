import React, { Component } from 'react';
import HealthRiskSelector from '../healthRisk/HealthRiskSelector';

export default class LightweightAreaOverview extends Component {
    constructor(props) {
        super(props);
    }

    render() {
        return (
            <div>
                <HealthRiskSelector />
            </div>
        );
    }
}