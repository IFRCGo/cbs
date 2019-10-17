import React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';
import MapReport from './components/MapReport';

export default () => (
  <Layout>
    <Route exact path='/' component={Home} />
    <Route exact path='/map' compoment={MapReport} />
  </Layout>
);
