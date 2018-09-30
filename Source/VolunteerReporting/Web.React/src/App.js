import React, {Component} from 'react';
import {BrowserRouter as Router, Route} from 'react-router-dom';
import {BaseController} from 'repertoire';

class App extends Component {

  render() {
    return (
      <Router>
        <div>
          {this.props.routes.map((route, index) => {
            let component;
            if (route.component instanceof BaseController) {
              component = route.component.component;
            } else {
              component = route.component;
            }

            return Array.isArray(route.path) ?
              <div key={index}>{route.path.map((childRoute, childIndex) => {
                return <Route
                  key={childIndex}
                  path={childRoute}
                  exact={route.exact}
                  component={component}
                />
              })}</div>:
              <Route
                  key={index}
                  path={route.path}
                  exact={route.exact}
                  component={component}
                />
          })}
        </div>
      </Router>
    );
  }
}

export default App;
