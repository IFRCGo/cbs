import React from 'react';
import { connect } from 'react-redux';

const Home = props => (
  <div>
    <h1>Welcome to Nyss - the CBS platform</h1>
    <p>First of all thank you for wanting to contribute!;
    <br/>We hope you will have a great couple of days with us.</p>
    <p>If you have any questions, please reach out to the people in blue (tech/ux) and red (domain) t-shirts!</p>
    <a href='https://trello.com/invite/b/00j1CXLz/ec14ccda710559537037b4c7565b60c3/red-cross-codeathon-brussels-2019'>Join our trello board for an oveview of tasks</a>
  </div>
);

export default connect()(Home);
