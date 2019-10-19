import React from 'react';
import { Route, Switch } from 'react-router';

import Home from './components/Home';
import Layout from './components/Layout';
import { ActivityHistoryContainer } from './containers/ActivityHistoryContainer';
import MapReports from './components/MapReports/MapReports';
import AlertHistoryView from './views/alert-history-view/AlertHistoryView'

export default () => (
  <Layout>
    <Switch>
      <Route exact path="/" component={ Home } />
      <Route exact path='/map' component={ MapReports } />
      <Route path="/activity-history" component={ ActivityHistoryContainer } />
      <Route path="/alert-history" component={ AlertHistoryView } />
    </Switch>
  </Layout>
)
