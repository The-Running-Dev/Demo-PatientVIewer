import { Injector, Injectable } from '@angular/core';

import { Observable } from 'rxjs';

import { HttpService } from './http.service';
import { Patient } from '../models/';

@Injectable()
export class PatientService extends HttpService {
    constructor(private injector: Injector) {
        super(injector);
    }

    public GetAll(): Observable<Patient[]> {
        return super.Get(`${this.ApiUrls.Patient}`);
    }

    public GetById(id: number): Observable<Patient> {
        return super.Get(`${this.ApiUrls.Patient}/${id}`);
    }
}
