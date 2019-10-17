import React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';

export default () => (
  <Layout>
    <Route exact path='/' component={Home} />
  </Layout>
);
