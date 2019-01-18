import React from 'react';
import Helmet from 'react-helmet';
import PropTypes from 'prop-types';
import {utils} from '@ifrc-cbs/common-react-ui';
import AlertsController from '../AlertsController';
import { removeAllListeners } from 'cluster';

const {parseQueryString} = utils;

class Rules extends React.Component {
  static get contextTypes () {
    return {
      router: PropTypes.shape({
        history: PropTypes.shape({
          push: PropTypes.func.isRequired,
          replace: PropTypes.func.isRequired,
          createHref: PropTypes.func.isRequired
        }).isRequired
      }).isRequired
    };
  }

  constructor(component) {
    super(component);

    this.state = {
    };
  }

  static parseLocationString(location = {}) {
    const params = {};

    if (location.search) {
      const {sortBy, order} = parseQueryString(location.search.substring(1));

      if (sortBy && order) {
        params.sortBy = sortBy;
        params.direction = order;
      }
    }

    return params;
  }

  render() {
    const title = 'Rules';
    const description = '';

    return (
      <React.Fragment>
        <Helmet>
          <title>{title}</title>
          <meta property="og:title" content={title}/>
          <meta property="og:description" content={description}/>
          <meta name="description" content={description}/>
        </Helmet>
        <article id="rules-list">
          <section className="container">
            <h3>CBS Alerts</h3>
          </section>
        </article>
      </React.Fragment>
    );
  }
}

export default new AlertsController(Rules);
