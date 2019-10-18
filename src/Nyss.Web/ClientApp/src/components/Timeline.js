import React, { Fragment } from 'react'

const Timeline = ({ data }) => {
  return (
    <Fragment>
      <span>{`${data.region} ${data.district} ${data.village}`}</span>
    </Fragment>
  )
}

export default Timeline
