import React from 'react';
import {Link} from 'react-router-dom';

export default () => (
  <header className="navigation-header">
    <figure className="logo">
      <svg xmlns="http://www.w3.org/2000/svg" width="700" height="400" viewBox="0 0 175 100">
        <rect width="175" height="100" fill="#fff" />
        <path d="M20,50h66m-33,-33v66" fill="none" stroke="#c00" strokeWidth="20" />
        <circle cx="132" cy="50" r="34" fill="#c00" />
        <circle cx="142" cy="50" r="28" fill="#fff" />
        <path d="M7,7H168V93H7z" fill="none" stroke="#c00" strokeWidth="3" />
      </svg>
    </figure>

    <nav>
      <Link to="/">Project administration</Link>
      <Link to="/users">User management</Link>
      <Link to="/reporting/all">Reporting</Link>
      <Link to="/alerts">Alerts</Link>
      <Link to="/analytics">Analytics</Link>
    </nav>

    <div className="login-status">
      <div className="logged-in">
        <p>
          Logged in as:
        </p>
        <p>DEV-USER</p>
      </div>
    </div>
  </header>
);
