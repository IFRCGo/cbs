import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import HealthRiskSelector from '../healthRisk/HealthRiskSelector';
import CBSNavigation from '../Navigation/CBSNavigation';

export default class LightweightAreaOverview extends Component {
    constructor(props) {
        super(props);
    }

    render() {
        return (
            <div className="lightweightContainer">
                <CBSNavigation activeMenuItem="analytics/" />
                <h2 className="lightweight-header">Light Area Overview</h2>
                <p className="lightweight-description">This is the light version of the country overview page. If you want the normal version click <Link to="/analytics">here</Link></p>
                <HealthRiskSelector />
            </div>
        );
    }
}