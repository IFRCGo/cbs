import React from 'react';
import { BrowserRouter as Router, Route, Link, Switch } from "react-router-dom";

import logo from './logo.svg';
import './App.css';
import './assets/bootstrap.css';

import { QueryCoordinator } from '@dolittle/queries';
import { CommandCoordinator } from '@dolittle/commands';
import AddDataVerifier from './dolittle/Admin/AddDataVerifier';
import { Navigation } from 'cbs-navigation';

import Navbar from './app/components/Navbar';
import HealthRisks from './app/components/healthrisks/HealthRisks'
import HealthRisk from './app/components/healthrisks/HealthRisk'
import Project from './app/components/projects/Project'
import ProjectList from './app/components/projects/ProjectList'

class App extends React.Component {
  render() {
    return (
      <Router>
        <div className="App">
            <Navigation />
            <Navbar />
            <div class="container"> 
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
                      <Route path={`${url}/list`} component={HealthRisks} />
                      <Route path={`${url}/create`} render= {(props) => <HealthRisk {...props} type="create"></HealthRisk>}/>
                      <Route path={`${url}/edit/:healthRiskId`} render= {(props) => <HealthRisk {...props} type="edit"></HealthRisk>}/>
                      <Route path={`${url}/delete/:healthRiskId`} render= {(props) => <HealthRisk {...props} type="delete"></HealthRisk>}/>
                      <Route path={`${url}/show/:healthRiskId`} render= {(props) => <HealthRisk {...props} type="show"></HealthRisk>}/>
                    </>
                  )}
                  />
              </Switch>
            </div>
        </div>
      </Router>
    );
  }
}

export default App;
