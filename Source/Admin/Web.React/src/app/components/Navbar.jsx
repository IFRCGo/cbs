import React from 'react';
import { Link } from 'react-router-dom'


class Navbar extends React.Component{
    render() {
        return (
            <nav className="navbar navbar-default navbar-static-top">
                <div className="container">
                    <div id="navbar" className="navbar-collapse collapse">
                        <ul className="nav navbar-nav">
                            <li className="active">
                                <Link to="/project/list">Projects</Link>
                            </li>
                            <li>
                                <Link to="/healthrisk/list">Health risks</Link>
                            </li>
                        </ul>
                    </div>
                </div>
            </nav>
        );
    }
}

export default Navbar;