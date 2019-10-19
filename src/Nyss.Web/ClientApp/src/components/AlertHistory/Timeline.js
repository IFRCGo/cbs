import React from 'react';

import { List } from './List';
import { LocationDisplay } from './LocationDisplay';

export const Timeline = ({ data }) => {
  return (
    <div className="d-flex flex-row justify-content-around">
      <LocationDisplay data={data} />
      <List villages={data} />
    </div>
  )
}
