import React from 'react';
import './Navigation.css';


export class Navigation extends React.Component{
        
    constructor(props) {
        super(props);

        this.name = "TEST"; 
    }

    render() {
        return (
            <header class="navigation-header">
                <figure class="logo">
                    <svg xmlns="http://www.w3.org/2000/svg" width="700" height="400" viewBox="0 0 175 100">
                        <rect width="175" height="100" fill="#fff" />
                        <path d="M20,50h66m-33,-33v66" fill="none" stroke="#c00" stroke-width="20" />
                        <circle cx="132" cy="50" r="34" fill="#c00" />
                        <circle cx="142" cy="50" r="28" fill="#fff" />
                        <path d="M7,7H168V93H7z" fill="none" stroke="#c00" stroke-width="3" />
                    </svg>
                </figure>
                <nav>
                    <a href="/">Project administration</a>
                    <a href="/users">User management</a>
                    <a href="/reporting">Volunteer reporting</a>
                    <a href="/alerts">Alerts</a>
                    <a href="/analytics">Analytics</a>
                </nav>

                <div class="login-status">
                    <div class="logged-in">
                        <p>
                            Logged in as:
                        </p>
                        <p>{this.name}</p>
                    </div>
                </div>
            </header>
        );
    }
}