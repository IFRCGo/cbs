import React, { Component } from 'react';
import { render } from "react-dom";

export default class App extends Component {
  constructor(props) {
    super(props);
    
    this.state = {
    };
  }
  
  render() {
    return (
            <div>
            <img src="/camera/image.jpg"/>
            </div>
            );
  }
}

