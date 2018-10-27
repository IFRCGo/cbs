import React from 'react';
import { Link } from 'react-router-dom'


export class Navbar extends React.Component{
    render() {
        return (
            <nav class="navbar navbar-default navbar-static-top">
                <div class="container">
                    <div id="navbar" class="navbar-collapse collapse">
                        <ul class="nav navbar-nav">
                            <li class="active">
                                <Link to="/project/list">Projects</Link>
                            </li>
                            <li>
                                <Link to="/healthrisk">Health risks</Link>
                            </li>
                        </ul>
                    </div>
                </div>
            </nav>
        );
    }
}
