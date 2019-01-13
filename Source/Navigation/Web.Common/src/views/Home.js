import React from 'react';
import Helmet from 'react-helmet';
import {Link} from 'react-router-dom';

export default () => {
  const title = 'CBS';
  const description = '';

  return (
    <React.Fragment>
      <Helmet>
        <title>{title}</title>
        <meta property="og:title" content={title}/>
        <meta property="og:description" content={description}/>
        <meta name="description" content={description}/>
      </Helmet>
      <article id="introduction" className="container">
        <div className="row">
          <div className="col-md-12" style={{minHeight: '600px'}}>
            <h1>Welcome to CBS</h1>
          </div>
        </div>
      </article>
    </React.Fragment>
  );
};
