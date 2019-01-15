import React from 'react';
import Helmet from 'react-helmet';

import Header from './Header';
import Main from './Main';
import Footer from './Footer';

export default class Application extends React.Component {
  render() {
    let maybeGraphURL = null;
    if (window.location.href) {
      maybeGraphURL = (
        <meta
          property="og:url"
          content={window.location.href}
        />
      );
    }

    return (
      <div id="application">
        <Helmet>
          {maybeGraphURL}
        </Helmet>
        <Header />
        <Main routes={this.props.routes} store={this.props.store} />
        <Footer />
      </div>
    );
  }
}
