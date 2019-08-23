import React, { Component } from 'react';
import Grid from '@material-ui/core/Grid';
import { Link } from 'react-router-dom';
import HealthRiskSelector from '../healthRisk/HealthRiskSelector';
import CBSNavigation from '../../../node_modules/navigation/lib/index.js';

export default class LightweightAreaOverview extends Component {
    constructor(props) {
        super(props);
    }

    render() {
        return (
            <Grid container justify="center">
                <Grid item xs={12}>
                    <CBSNavigation activeMenuItem="analytics/#" />
                </Grid>

                <Grid container item xs={10} justify="center">
                    <div className="lightweight">
                        <h1 className="jumbotron">Light Area Overview</h1>
                        <p>This is the light version of the country overview page. If you want the normal version click <Link to="/analytics/">here</Link></p>
                    </div>
                </Grid>
                <Grid item xs={10}>
                    <HealthRiskSelector />
                </Grid>
            </Grid>
        );
    }
}