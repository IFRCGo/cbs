import './NavMenu.css'

import React from 'react'
import { Container, Navbar } from 'reactstrap'
import { Link } from 'react-router-dom'

export default class NavMenu extends React.Component {
  constructor(props) {
    super(props)

    this.toggle = this.toggle.bind(this)
    this.state = {
      isOpen: false,
    }
  }
  toggle() {
    this.setState({
      isOpen: !this.state.isOpen,
    })
  }
  render() {
    return (
      <header>
        <Navbar className='border-bottom box-shadow' light>
          <Container>
            <Link to='/'>
              <img
                src='https://upload.wikimedia.org/wikipedia/commons/c/c9/IFRC_Logo.png'
                alt='Red Cross logo'
                width='80px'
              />
            </Link>
            <Link to='/map'>MAP</Link>
            <Link to='/activity-history'>History Activity</Link>
            <Link to='/alert-history'>Alert Activity</Link>
          </Container>
        </Navbar>
      </header>
    )
  }
}
