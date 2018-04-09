import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';

import { ApiService } from './api.service';
import { HealthRisk } from '../shared/models/healthRisk.model';

@Injectable()
export class HealthRiskService {

    constructor(private apiService: ApiService) { }

    getHealthRisks(): Observable<Array<HealthRisk>> {
        return this.apiService
            .get('/api/healthRisk');
    }

    getHealthRisk(id: string): Observable<HealthRisk>{
        return this.apiService
            .get('/api/healthRisk/'+ id);
    }
    
    saveHealthRisk(item: HealthRisk): Observable<void> {
        return this.apiService
            .post('/api/healthRisk/addhealthrisk', item);
    }

    updateHealthRisk(item: HealthRisk) : Observable<void>{
        return this.apiService
            .post('api/healthRisk', item);
    }

    removeHealthRisk(id: string): Observable<void>{
        return this.apiService
            .delete('api/healthRisk/'+ id);
    }
}