import React from 'react'
import { NavLink } from 'react-router-dom';

const Nav = () => {
    return (
        <nav>
            <NavLink to='/projects'>Projects</NavLink>
            <NavLink to='/healthrisks'>Heath Risks</NavLink>
            <NavLink to='/userManagement'>User Management</NavLink>
        </nav>
    )
};

export default Nav;
