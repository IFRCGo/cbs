import React from 'react';
import { BrowserRouter as Router, Route, Link, Switch } from "react-router-dom";

import logo from './logo.svg';
import './App.css';
import './assets/bootstrap.css'; //?????

import { QueryCoordinator } from '@dolittle/queries';
import { CommandCoordinator } from '@dolittle/commands';
import AddDataVerifier from './dolittle/Admin/AddDataVerifier';
import { Navigation } from 'cbs-navigation';

import Navbar from './app/components/Navbar';
import HealthRisks from './app/components/healthrisks/HealthRisks'
import HealthRiskDetail from './app/components/healthrisks/HealthRiskDetail'
import Project from './app/components/projects/Project'
import ProjectList from './app/components/projects/ProjectList'

class App extends React.Component {
  render() {
    return (
      <Router>
        <div className="App">
            <Navigation />
            <Navbar />
            <Switch>
              <Route
                path="/project"
                render={({ match: { url } }) => (
                  <>
                    <Route exact path={`${url}/`} component={Project} />
                    <Route path={`${url}/list`} component={ProjectList} />
                  </>
                )}
              />
              <Route 
                path="/healthrisk"
                render={({ match: { url } }) => (
                  <>
                    <Route exact path={`${url}/`} component={HealthRisks} />
                    <Route path={`${url}/detail/:healthRiskId`} component={HealthRiskDetail} />
                    <Route path={`${url}/list`} component={HealthRisks} />
                  </>
                )}
                />
            </Switch>
        </div>
      </Router>
    );
  }
}

export default App;
