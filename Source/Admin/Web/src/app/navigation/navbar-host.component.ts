import React, { createElement } from 'react';
import ReactDOM, { render } from 'react-dom';
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
        this.renderNavigationComponent();
      });
    }

    renderNavigationComponent() {
      render(createElement(CBSNavigation, {activeMenuItem: 'admin', username: this.username, baseUrl: NavbarHostComponent.apiBaseUrl }), document.getElementById("top-navbar"));
    }
}