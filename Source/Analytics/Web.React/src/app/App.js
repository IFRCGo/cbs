import React, { Component } from 'react';
import {json} from 'd3-fetch';
import logo from '../logo.svg';
import './App.css';
import Epicurve from './Epicurve.js';
//import Bubble from './Bar.js';

class App extends Component {
  
  constructor(props) {
    super(props);
    
    this.state = {
      data : null
    };
  }

  componentDidMount () {
    var that = this;
    json("data/epicurve.json").then(function(data) {
      //console.log(data); // [{"Hello": "world"}, …]
      that.setState({
        data: data
      });
    });
  }

  render() {
    

    return (
      <div className="App">
        <header className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
          <h1 className="App-title">Welcome to React</h1>
        </header>
        <p className="App-intro">
          To get started, edit <code>src/App.js</code> and save to reload.
          <Epicurve width={500} height={500} data={this.state.data}/>
        </p>
      </div>
    );
  }
}

export default App;
