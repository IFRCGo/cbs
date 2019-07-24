import ReactDOM from 'react-dom';
import React from 'react';
import {Component, AfterContentInit, ViewEncapsulation} from '@angular/core';
import CBSNavigation from './test';

@Component({
  selector: 'navbar-host',
  templateUrl:'./navbar-host.component.html',
  styleUrls: ['./navbar-host.component.scss'],
  encapsulation: ViewEncapsulation.None
})

export class NavbarHostComponent implements AfterContentInit{
    ngAfterContentInit(){
        ReactDOM.render(React.createElement(CBSNavigation), document.getElementById("navbar"));
    }
}