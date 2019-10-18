import React, { Component, Fragment } from 'react'

export class LocationDisplay extends Component {
  render() {
    const { data } = this.props
    return (
      <Fragment>
        {data.map((item, index) => (
          <span
            key={index}
          >{`${item.region} ${item.district} ${item.village}`}</span>
        ))}
      </Fragment>
    )
  }
}
