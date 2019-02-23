import React from 'react';
import {CommandCoordinator} from '@dolittle/commands';
import {QueryCoordinator} from '@dolittle/queries';

import Messages from './SMS/Messages';

CommandCoordinator.apiBaseUrl = process.env.API_BASE_URL;
QueryCoordinator.apiBaseUrl = process.env.API_BASE_URL;

class App extends React.Component {
  render() {
    return (
      <React.Fragment>
        <h1>Notification gateway</h1>
        <Messages />
      </React.Fragment>
    );
  }
}

export default App;
