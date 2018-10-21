import React, { Component } from 'react';
import logo from './logo.svg';
import { QueryCoordinator } from '@dolittle/queries';
import { CommandCoordinator } from '@dolittle/commands';
import './App.css';
import { AddDataVerifier } from './dolittle.imports'; 
import { Navigation } from 'cbs-navigation'; 
import { BrowserRouter as Router, Route, Link, Switch } from "react-router-dom";
import { HealthRiskList, ProjectList, Project } from './components'; 


class App extends Component {
  render() {
    return (
      <Router>
        <div className="App">
            <Navigation></Navigation>

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
                    <Route exact path={`${url}/`} component={HealthRiskList} />
                    <Route path={`${url}/list`} component={HealthRiskList} />
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
