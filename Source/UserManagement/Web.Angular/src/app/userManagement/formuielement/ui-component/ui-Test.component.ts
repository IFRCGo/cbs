import { Component, OnInit } from '@angular/core';
import { NationalSociety } from './nationSociety.model';
import { DistrictSociety } from './disctrictSociety.model'
import { FormElementServiceService } from './form-element-service.service';

@Component({
  selector: 'cbs-ui-component',
  templateUrl: './ui-component.html',
  providers: [FormElementServiceService],
  styles: []
})
export class UiTestComponent implements OnInit {

  nations: NationalSociety[];
  districtsOrig: DistrictSociety[];
  districts: DistrictSociety[];
  location = {};
  selectedCountryCode: number;
  constructor(
    private formElementServiceService: FormElementServiceService
  ) { }

  ngOnInit() {
    this.getNations();
    this.getDistricts();
  }
  public getNations() {
    this.formElementServiceService.getNationalSocities().
      subscribe(
      result => {
        this.nations = result
      },
      err => {
        console.log('error');
      }
      );
  }


  public getDistricts() {
    console.log('hei');
    this.formElementServiceService.getDistrictSocities().
      subscribe(
      result => {
        this.districtsOrig = result
      },
      err => {
        console.log('error');
      }
      );
  }

  public sortDistricts() {
    this.districts = this.districtsOrig.filter(district => district.countryCode == this.selectedCountryCode);
  }
  public setPosition(position) {
    this.location = position.coords;
  }
  public getPosition() {
    if (navigator.geolocation) {
      navigator.geolocation.getCurrentPosition(this.setPosition.bind(this));
    };
  }
}
