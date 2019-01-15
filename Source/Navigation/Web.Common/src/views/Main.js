import React from 'react';
import {Switch, Route} from 'react-router-dom';

import Home from './Home.js';
import lazyLoad from '../lib/lazyLoad.js';

export default class Main extends React.Component {
  render() {
    const NotFound = lazyLoad(import('./NotFound'));
    const reduxStore = this.props.store;

    return (
      <Switch>
        <Route exact path="/" component={Home}/>

        {this.props.routes.map((route, index) => {
          let ConnectedComponent;

          if (route.component.component) {
            ConnectedComponent = route.component.component;
          } else {
            ConnectedComponent = route.component;
          }

          const FinalComponent = function(...args) {
            const props = Object.assign({}, args[0], {store: reduxStore});

            return <ConnectedComponent {...props} />;
          };

          return Array.isArray(route.path) ?
            <div key={index}>{
              route.path.map((childRoute, childIndex) => {
                return (<Route
                  key={childIndex}
                  path={childRoute}
                  exact={route.exact}
                  component={FinalComponent}
                />);
              })
            }</div> : <Route
              key={index}
              path={route.path}
              exact={route.exact}
              component={FinalComponent}
            />
        })}
        <Route component={NotFound}/>
      </Switch>

    );
  }
};
