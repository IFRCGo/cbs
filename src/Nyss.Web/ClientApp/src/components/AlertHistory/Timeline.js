import React, { Fragment } from 'react';

import { List } from './List';
import { LocationDisplay } from './LocationDisplay';

export const Timeline = ({ data }) => {
  return (
    <Fragment>
      <LocationDisplay data={data} />
      <List />
    </Fragment>
  )
}
