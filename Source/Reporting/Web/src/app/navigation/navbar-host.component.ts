import ReactDOM from 'react-dom';
import React from 'react';
import {Component, ViewChild,ElementRef,AfterContentInit, ViewEncapsulation} from '@angular/core';
import CBSNavigation from './test';

@Component({
  selector: 'navbar-host',
  templateUrl:'./navbar-host.component.html',
  styleUrls: ['./navbar-host.component.scss'],
  encapsulation: ViewEncapsulation.None
})

export class NavbarHostComponent implements AfterContentInit{

    @ViewChild('testing', {static: false}) CBSNavigation: ElementRef;

    ngOnInit(){
       ReactDOM.render(React.createElement(CBSNavigation), document.getElementById("testing"));
       //CBSNavigation.initialize(this.CBSNavigation.nativeElement);
    }

    ngAfterContentInit(){
        ReactDOM.render(React.createElement(CBSNavigation), document.getElementById("testing"));
        //ReactDOM.render(CBSNavigation, document.getElementById("testing"));
        //CBSNavigation.initialize(this.CBSNavigation.nativeElement);
    }
}