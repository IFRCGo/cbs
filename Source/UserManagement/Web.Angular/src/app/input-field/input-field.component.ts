import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'cbs-input-field',
  templateUrl: 'input-field.html',
  styles: []
})
export class InputFieldComponent implements OnInit {
  @Input() placeHolder;
  @Input() formGroup;
  @Input() formControlName;

  constructor() { }

  ngOnInit() {
  }

}
