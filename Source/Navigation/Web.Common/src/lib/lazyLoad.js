import React from 'react';
import Loadable from 'react-loadable';

import Spinner from '../views/Spinner';
import ErrorComponent from '../views/Error';

/**
 * Return a lazy-loaded component which shows a spinner while loading and which
 * does some error handling.
 */
export default loader => {
  return Loadable({
    loader: () => loader,
    loading: props => {
      if (props.error) {
        return (
          <ErrorComponent
            title="Error"
            message="Load error"
          />
        );
      } else if (props.pastDelay) {
        return <Spinner/>;
      }

      return null;
    },
  });
};
