import React from 'react';

import {CommandCoordinator} from '@dolittle/commands';
import {QueryCoordinator} from '@dolittle/queries';

CommandCoordinator.apiBaseUrl = process.env.API_BASE_URL;
QueryCoordinator.apiBaseUrl = process.env.API_BASE_URL;

class App extends React.Component {
  render() {
    return (
      <h1>Hello NotificationGateway!</h1>
    );
  }
}

export default App;
