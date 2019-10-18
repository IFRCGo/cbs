import React, { Component } from 'react'

export class List extends Component {
  render() {
    const { data } = this.props
    console.log(data)
    return (
      <div className='d-flex flex-column overflow-auto'>
        <div className='d-flex flex-row justify-content-between max-wdith '>
          <div className='mx-2'>val1</div>
          <div className='mx-2'>val2</div>
          <div className='mx-2'>val3</div>
          <div className='mx-2'>val4</div>
          <div className='mx-2'>val5</div>
          <div className='mx-2'>val6</div>
          <div className='mx-2'>val7</div>
          <div className='mx-2'>val8</div>
          <div className='mx-2'>val9</div>
          <div className='mx-2'>val10</div>
          <div className='mx-2'>val11</div>
          <div className='mx-2'>val11</div>
          <div className='mx-2'>val11</div>
          <div className='mx-2'>val11</div>
          <div className='mx-2'>val11</div>
          <div className='mx-2'>val11</div>
          <div className='mx-2'>val11</div>
          <div className='mx-2'>val11</div>
          <div className='mx-2'>val11</div>
          <div className='mx-2'>val11</div>
          <div className='mx-2'>val11</div>
          <div className='mx-2'>val11</div>
        </div>
        <div className='d-flex flex-row justify-content-between'>
          <div>azezaeze</div>
          <div>azeiozeo</div>
        </div>
        <div className='d-flex flex-row justify-content-between'>
          <div>azezaeze</div>
          <div>azeiozeo</div>
        </div>
        <div className='d-flex flex-row justify-content-between'>
          <div>azezaeze</div>
          <div>azeiozeo</div>
        </div>
        <div className='d-flex flex-row justify-content-between'>
          <div>azezaeze</div>
          <div>azeiozeo</div>
        </div>
        <div className='d-flex flex-row justify-content-between'>
          <div>azezaeze</div>
          <div>azeiozeo</div>
        </div>
        <div className='d-flex flex-row justify-content-between'>
          <div>azezaeze</div>
          <div>azeiozeo</div>
        </div>
      </div>
    )
  }
}
