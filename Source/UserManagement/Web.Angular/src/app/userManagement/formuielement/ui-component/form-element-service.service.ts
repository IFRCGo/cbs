import { Injectable } from '@angular/core';
import {Observable} from 'rxjs/Observable';

import 'rxjs/add/observable/of';

@Injectable()
export class FormElementServiceService {

  nationalSocieties = [{'country': 'Norway', 'countryCode': 200}, {'country': 'Macedonia', 'countryCode': 201},
  {'country': 'Iran', 'countryCode': 202}, {'country': 'Pakistan', 'countryCode': 203}];

  districtSocieties = [{'place': 'Oslo', 'countryCode': 200}, {'place': 'Bergen', 'countryCode': 200},
  {'place': 'Tehran', 'countryCode': 202}, {'place': 'Tabriz', 'countryCode': 202},
  {'place': 'Skopje', 'countryCode': 201}, {'place': 'Tetovo', 'countryCode': 201},
  {'place': 'Islamabad', 'countryCode': 203}, {'place': 'Lahore', 'countryCode': 203}
];

  constructor(  ) { }

  getNationalSocities(): Observable<any> {
      return Observable.of(this.nationalSocieties);
  }
  getDistrictSocities(): Observable<any> {
    return Observable.of(this.districtSocieties);
  }
}
