import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';

@Injectable()
export class LogService {
    log(payload: any): void {
      if (!environment.production) {
        window.console.log(payload);
      }
    }

    logError(payload: any): void {
      window.console.log(payload);
    }
}
