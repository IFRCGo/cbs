import React from 'react'
import { Route, Switch } from 'react-router'

import Home from './components/Home'
import Layout from './components/Layout'
import MapReports from './components/MapReports/MapReports'
import AlertHistoryView from './views/alert-history-view/AlertHistoryView'

export default props => (
  <Layout>
    <Switch>
      <Route exact path='/' url={props.url} component={Home} />
      <Route exact path='/map' url={props.url} component={MapReports} />
      <Route
        path='/alert-history'
        url={props.url}
        component={() => <AlertHistoryView url={props.url}/>}
      />
    </Switch>
  </Layout>
)
