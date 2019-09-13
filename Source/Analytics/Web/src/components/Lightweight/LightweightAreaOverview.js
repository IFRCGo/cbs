import React, { Component } from 'react';
import Grid from '@material-ui/core/Grid';
import { Link } from 'react-router-dom';
import HealthRiskSelector from '../healthRisk/HealthRiskSelector';
import CBSNavigation from 'navigation';

export default class LightweightAreaOverview extends Component {
    constructor(props) {
        super(props);

        this.state = {
            username: 'Unknown'
        };
    }

    componentDidMount() {
        fetch(`${process.env.API_BASE_URL}/identity`).then(async response => this.setState({
            username: await response.text()
        }));
    }

    render() {
        return (
            <Grid container justify="center">
                <Grid item xs={12}>
                    <CBSNavigation activeMenuItem="analytics/#" username={this.state.username} baseUrl={process.env.API_BASE_URL} />
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