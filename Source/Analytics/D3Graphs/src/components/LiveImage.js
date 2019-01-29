import React, { Component } from 'react';

export default class LiveImage extends React.Component {
  constructor(props) {
    super(props);
    
    this.loadImage = () => {
      const component = this;
      
      const img = new Image();
      img.crossOrigin = "Anonymous";
      img.onload = function () {
        var canvas = document.createElement("canvas");
        canvas.width =this.width;
        canvas.height =this.height;
        
        var ctx = canvas.getContext("2d");
        ctx.drawImage(this, 0, 0);
        
        var dataURL = canvas.toDataURL("image/jpeg", 1.0);
        component.setState({liveImage: dataURL});
      };
      
      img.src = `${this.props.image}?${new Date().getTime()}`;
      this.setState({ loadingImage: img });
    }
    
    this.state = {
    loadingImage: null,
    liveImage: null
    };
  }
  
  componentDidMount() {
    this.loadImage();
    this.interval = setInterval(this.loadImage, this.props.interval);
  }
  componentWillUnmount() {
    clearInterval(this.interval);
  }
  
  render() {
    return (
            <img src={this.state.liveImage} {...this.props} />
            );
  }
}
