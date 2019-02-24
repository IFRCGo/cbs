import React from 'react';
import {CommandCoordinator} from '@dolittle/commands';
import {QueryCoordinator} from '@dolittle/queries';

import Messages from './SMS/Messages';
import Gateways from './SMS/Gateways/Gateways';

CommandCoordinator.apiBaseUrl = process.env.API_BASE_URL;
QueryCoordinator.apiBaseUrl = process.env.API_BASE_URL;

class App extends React.Component {
  render() {
    return (
      <React.Fragment>
        <h1>Notification gateway</h1>
        <Messages />
        <Gateways />
      </React.Fragment>
    );
  }
}

export default App;
