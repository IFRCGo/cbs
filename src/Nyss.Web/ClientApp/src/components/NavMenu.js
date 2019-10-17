import React from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import './NavMenu.css';

export default class NavMenu extends React.Component {
  constructor (props) {
    super(props);

    this.toggle = this.toggle.bind(this);
    this.state = {
      isOpen: false
    };
  }
  toggle () {
    this.setState({
      isOpen: !this.state.isOpen
    });
  }
  render () {
    return (
      <header>
        <Navbar className="border-bottom box-shadow" light >
            <Container>
                    <img src="https://upload.wikimedia.org/wikipedia/commons/c/c9/IFRC_Logo.png" alt="Red Cross logo" width="80px"/>
          </Container>
        </Navbar>
      </header>
    );
  }
}
