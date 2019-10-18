import React from "react";
import { Route } from "react-router";
import Layout from "./components/Layout";
import Home from "./components/Home";
import MapReports from "./components/MapReports/MapReports";

export default () => (
  <Layout>
    <Route exact path="/" component={Home} />
    <Route exact path="/map" component={MapReports} />
  </Layout>
);
