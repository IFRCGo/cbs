import React, { Component } from 'react';
import Camera from './Camera.js';
import LiveImage from './LiveImage.js';
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
            <p>pH Short</p>
            <Log width={800} height={300} datapoints={-720} dataurl={"/logs/ph_short.json"} />
            <br/>
            <p>pH long</p>
            <Log width={800} height={300} datapoints={-480} dataurl={"/logs/ph.json"} />
            <br/>
            <p>pump run</p>
            <Log width={800} height={300} datapoints={-480} dataurl={"/logs/pump_run.json"}  />
            <br/>
            <p>pump</p>
            <Log width={800} height={300} datapoints={-48} dataurl={"/logs/pump.json"}  />
            <br/>
            <p>ph very long</p>
            <Log width={800} height={300} datapoints={-5760} dataurl={"/logs/ph.json"}  />
            <br/>
            
            <p>I am {name}</p>
            </div>
            );
  }
}

