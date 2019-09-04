import ReactDOM from 'react-dom';
import React from 'react';
import {Component, OnInit, ViewEncapsulation} from '@angular/core';
import CBSNavigation from 'navigation';

@Component({
  selector: 'navbar-host',
  templateUrl:'./navbar-host.component.html',
  styleUrls: ['../../../node_modules/navigation/lib/cbs-navigation.scss'],
  encapsulation: ViewEncapsulation.None
})

export class NavbarHostComponent implements OnInit {
    static apiBaseUrl: string;
    username: string;  

    constructor() {
      this.username = 'Unknown';
    }

    ngOnInit(){
      fetch(`${NavbarHostComponent.apiBaseUrl}/identity`).then(async response => {
        this.username = await response.text();
        this.renderMenu();
      }).catch(err => {
        this.renderMenu();
      });
    }

    renderMenu(){
        ReactDOM.render(React.createElement(CBSNavigation, {activeMenuItem: 'reporting/case-reports', username: this.username}), document.getElementById("navbar"));
    }
}