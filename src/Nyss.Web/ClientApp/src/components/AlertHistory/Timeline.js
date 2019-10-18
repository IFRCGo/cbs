import React from 'react'

import { List } from './List'
import { LocationDisplay } from './LocationDisplay'
import FetchData from '../FetchData'

export const Timeline = ({ data }) => {
  return (
    <div className='d-flex flex-row'>
      <LocationDisplay data={data} />
      <List />
    </div>
  )
}
