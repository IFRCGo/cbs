import React, { Component } from 'react';
import { connect } from 'react-redux';

class App extends Component {
    render() {
        return <div>{this.props.baseUrl}</div>;
    }
}

export default connect(state => ({
    baseUrl: state.root.baseUrl,
}))(App);
