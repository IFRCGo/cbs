import React from 'react';
import { Route, Switch } from 'react-router';

import { MainContainer } from './components/AlertHistory/MainContainer';
import Home from './components/Home';
import Layout from './components/Layout';

export default () => (
  <Layout>
    <Switch>
      <Route path="/activity-history" component={MainContainer} />
      <Route exact path="/" component={Home} />
    </Switch>
  </Layout>
)
