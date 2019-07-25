import ReactDOM from 'react-dom';
import React from 'react';
import {Component, AfterContentInit, ViewEncapsulation} from '@angular/core';
import CBSNavigation from '../../../node_modules/navigation/';

@Component({
  selector: 'navbar-host',
  templateUrl:'./navbar-host.component.html',
  styleUrls: ['../../../node_modules/navigation/lib/cbs-navigation-v1.scss'],
  encapsulation: ViewEncapsulation.None
})

export class NavbarHostComponent implements AfterContentInit{
    ngAfterContentInit(){
        ReactDOM.render(React.createElement(CBSNavigation, {activeMenuItem: 'reporting/case-reports'}), document.getElementById("navbar"));
    }
}