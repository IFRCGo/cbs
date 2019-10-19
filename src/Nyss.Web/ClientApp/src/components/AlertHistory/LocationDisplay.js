import React, { Component } from 'react';

export class LocationDisplay extends Component {
  render() {
    const { data } = this.props
    return (
      <div className="w-25">
        {data.map((item, index) => (
          <div key={index}>
            {`${item.region} ${item.district} ${item.village}`}
          </div>
        ))}
      </div>
    )
  }
}
