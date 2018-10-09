import React, { Component } from 'react';
import logo from './logo.svg';
import { QueryCoordinator } from '@dolittle/queries';
import { CommandCoordinator } from '@dolittle/commands';
import './App.css';
import { AddDataVerifier } from './dolittle.imports'; 
import { Navigation } from 'cbs-navigation'; 

class App extends Component {
  render() {
    return (
      <div className="App">
        <Navigation></Navigation>
      </div>
    );
  }
}

export default App;
