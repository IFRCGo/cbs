import React from 'react'
import { Route, Switch } from 'react-router'

import Home from './components/Home';
import MapReports from './components/MapReports/MapReports';
import Layout from './components/Layout';
import { ActivityHistoryContainer } from './containers/ActivityHistoryContainer';
import AlertHistoryView from './views/AlertHistoryView'

export default props => (
  <Layout>
    <Switch>
      <Route exact path="/" component={Home} />
      <Route exact path='/map' component={MapReports} />
      <Route
        path='/activity-history'
        url={props.url}
        component={ActivityHistoryContainer}
      />
      <Route
        path='/alert-history'
        url={props.url}
        component={AlertHistoryView}
      />
    </Switch>
  </Layout>
)
