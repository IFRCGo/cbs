import React from 'react';
import { Route, Switch } from 'react-router';

import { MainContainer } from './components/AlertHistory/MainContainer';
import Home from './components/Home';
import MapReports from './components/MapReports/MapReports';

export default () => (
  <Layout>
    <Switch>
      <Route path="/activity-history" component={MainContainer} />
      <Route exact path="/" component={Home} />
      <Route exact path='/map' component={MapReports} />
    </Switch>
  </Layout>
)
