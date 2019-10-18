import React, { Component, Fragment } from 'react';


export class LocationDisplay extends Component {
  render() {
    const { data } = this.props
    return (
      <Fragment>
        <span>{`${data.region} ${data.district} ${data.village}`}</span>
      </Fragment>
    )
  }
}
