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
            <img
              src='https://upload.wikimedia.org/wikipedia/commons/c/c9/IFRC_Logo.png'
              alt='Red Cross logo'
              width='80px'
            />
          </Container>
          <Link to='/activity-history'>History Activity</Link>
        </Navbar>
      </header>
    )
  }
}
