import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import HealthRiskSelector from '../healthRisk/HealthRiskSelector';
import CBSNavigation from '../Navigation/CBSNavigation';
import './LightweightAreaOverview.scss';

export default class LightweightAreaOverview extends Component {
    constructor(props) {
        super(props);
    }

    render() {
        return (
            <div>
                <CBSNavigation activeMenuItem="analytics/#" />
                <div className="lightweight">
                    <h2 className="header">Light Area Overview</h2>
                    <p className="description">This is the light version of the country overview page. If you want the normal version click <Link to="/analytics">here</Link></p>
                </div>
                <HealthRiskSelector />
            </div>
        );
    }
}