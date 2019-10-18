import React from 'react'

import { List } from './List'
import { LocationDisplay } from './LocationDisplay'

export const Timeline = ({ data }) => {
  return (
    <div class='d-flex flex-row'>
      <LocationDisplay data={data} />
      <List data={data} />
    </div>
  )
}
