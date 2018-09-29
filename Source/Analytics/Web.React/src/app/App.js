import React, { Component } from 'react';
import logo from '../logo.svg';
import './App.css';
import Epicurve from './Epicurve.js';
import Bubble from './Bar.js';

class App extends Component {
  render() {
    return (
      <div className="App">
        <header className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
          <h1 className="App-title">Welcome to React</h1>
        </header>
        <p className="App-intro">
          To get started, edit <code>src/App.js</code> and save to reload.
          <Bubble width={500} height={500} data={[5, 8, 14, 15, 22, 34]}/>
        </p>
      </div>
    );
  }
}

export default App;
