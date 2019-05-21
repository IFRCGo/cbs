import React, { Component } from 'react';
import './cbs-navigation-v1.scss';

const BASE_URL = process.env.API_BASE_URL;

class CBSNavigation extends Component {
    
    constructor(props) {
        super(props);

        this.state = {
            username:"Unknown"
        };
    }


    fetchData() {
        if (process.env.environment !== 'production') {
            this.url = `http://www.mocky.io/v2/5cdc46d52d00003b12f5a6da`;
            fetch(this.url, { method: "GET" }).then(response => response.json())
            .then(json =>
                this.setState({
                    username: json.name
                })
            )
            .catch(_ =>
                this.setState({
                    isLoading: false,
                    isError: true
                })
            );

          }
        else {
            this.url = `${BASE_URL}/identity`;
            fetch(this.url, { method: "GET" }).then(response => response.text())
            .then(text =>
                this.setState({
                    username: text
                })
            )
            .catch(_ =>
                this.setState({
                    isLoading: false,
                    isError: true
                })
            );

          }

        this.setState({ isLoading: true });
    }

    componentDidMount() {
        this.fetchData();
    }

  render() {
    return (
  <header className="navigation-header">
    <figure className="logo">
        <svg xmlns="http://www.w3.org/2000/svg" width="700" height="400" viewBox="0 0 175 100">
            <rect width="175" height="100" fill="#fff" />
            <path d="M20,50h66m-33,-33v66" fill="none" stroke="#c00" stroke-width="20" />
            <circle cx="132" cy="50" r="34" fill="#c00" />
            <circle cx="142" cy="50" r="28" fill="#fff" />
            <path d="M7,7H168V93H7z" fill="none" stroke="#c00" stroke-width="3" />
        </svg>
    </figure>
    <nav>
        <a href="/admin/">Project administration</a>
        <a href="/reporting/datacollectors/">User management</a>
        <a href="/reporting/case-reports/">Volunteer reporting</a>
        <a href="/alerts/">Alerts</a>
        <a href="/analytics/">Analytics</a>
    </nav>

    <div className="login-status">
        <div className="logged-in">
            <p>
                Logged in as:
            </p>
            <p>{this.state.username}</p>
            <button>Logout</button>
        </div>
    </div>
  </header>
    );
  }
}
export default CBSNavigation;