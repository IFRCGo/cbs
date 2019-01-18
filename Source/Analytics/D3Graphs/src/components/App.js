import React, { Component } from 'react';
import Log from './Log.js';

export default class App extends Component {
  constructor(props) {
    super(props);
    
    this.state = {
      name: props.name
    };
  }
  //<LiveImage image={"/camera/image.jpg"} interval={10*60*1000} />
  render() {
    const { name } = this.state;
    
    return (
            <div>
            <h2>1.750L water, 250ml acid!!!</h2>
            <p>ph</p>
            <Log width={800} height={300} datapoints={-5760} dataurl={"/logs/ph.json"}  />
            <br/>
            
            <p>Hello: "{name}"</p>
            </div>
            );
  }
}

