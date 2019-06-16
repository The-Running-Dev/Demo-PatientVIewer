import { Injectable } from '@angular/core';
import { Observable, Observer, throwError } from 'rxjs';

@Injectable()
export class ApiErrorService {
    protected errorObserver: Observer<any>;

    public apiErrors: Observable<any>;

    constructor() {
        this.apiErrors = new Observable<any>(observer => {
            this.errorObserver = observer;
        });
    }

    public HandleError(error: any): Observable<any> {
        this.errorObserver.next(error);

        return throwError(error);
    }
}
