import React from 'react';
import { Route, Switch } from 'react-router';

import Home from './components/Home';
import MapReports from './components/MapReports/MapReports';
import Layout from './components/Layout';
import { ActivityHistoryContainer } from './containers/ActivityHistoryContainer';

export default () => (
  <Layout>
    <Switch>
      <Route path="/activity-history" component={ActivityHistoryContainer} />
      <Route exact path="/" component={Home} />
      <Route exact path='/map' component={MapReports} />
    </Switch>
  </Layout>
)
