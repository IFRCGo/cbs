import React from 'react';
import Helmet from 'react-helmet';

import ErrorComponent from './Error';

export default () => (
  <React.Fragment>
    <Helmet>
      <meta name="robots" content="noindex"/>
    </Helmet>
    <React.Fragment>
      <div className="container">
        <div className="row">
          <div className="col-md-12" style={{minHeight: '500px'}}>
            <ErrorComponent id="not-found" title="Page Not Found"/>
          </div>
        </div>
      </div>
    </React.Fragment>

  </React.Fragment>
);
