import React from 'react'
import { Route, Switch } from 'react-router'

import Home from './components/Home'
import Layout from './components/Layout'
import { ActivityHistoryContainer } from './containers/ActivityHistoryContainer'
import MapReports from './components/MapReports/MapReports'

export default props => (
  <Layout>
    <Switch>
      <Route
        path='/activity-history'
        url={props.url}
        component={ActivityHistoryContainer}
      />
      <Route exact path='/' url={props.url} component={Home} />
      <Route exact path='/map' url={props.url} component={MapReports} />
    </Switch>
  </Layout>
)
