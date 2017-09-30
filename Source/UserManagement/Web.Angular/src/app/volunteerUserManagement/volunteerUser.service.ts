import { Volunteer } from './../domain/volunteer';
import 'rxjs/add/operator/toPromise';

import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';


@Injectable()
export class VolunteerService {
  private headers = new Headers({ 'Content-Type': 'application/json' });

  constructor(private http: Http) { }

  saveVolunteer(volunteer: Volunteer): Promise<void> {
    const url = `http://localhost:5000/api/usermanagement/volunteeruser`;

    return this.http
      .post(url, JSON.stringify(volunteer), { headers: this.headers })
      .toPromise()
      .then(() => { console.log('Volunteer user added successfully'); })
      .catch((error) => console.error(error));
  }

  getAllVolunteers(): Promise<void> {
    const url = 'http://localhost:5000/api/usermanagement/volunteerusers';

    return this.http
      .get(url, { headers: this.headers })
      .toPromise()
      .then((users) => { console.log(users); })
      .catch((error) => console.error(error));
  }
}
