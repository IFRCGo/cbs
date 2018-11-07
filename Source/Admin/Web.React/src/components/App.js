import React, {Component} from 'react';
import {BrowserRouter as Router, Route} from 'react-router-dom';
import {BaseController} from 'repertoire';
import { Navigation }  from 'cbs-navigation';

class App extends Component {

  render() {
    return (
      <Router basename={process.env.PUBLIC_URL || '/'}>
        <div>
        <Navigation />
          {this.props.routes.map((route, index) => {
            let component;
            if (route.component instanceof BaseController) {
              component = route.component.component;
            } else {
              component = route.component;
            }

            return <Route
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
