import { HttpClient } from '@angular/common/http';
import { Injectable, Injector } from '@angular/core';

import { catchError } from 'rxjs/operators';

import { ApiErrorService } from './api-error.service';
import { ApiUrls } from '../models/api-urls.model';
import { ConfigService } from './config.service';
import { HttpRestParams } from '../models';
import { Observable } from 'rxjs';

@Injectable()
export class HttpService {
    protected ApiUrls: ApiUrls;

    protected configService: ConfigService;

    protected apiErrorService: ApiErrorService;

    private http: HttpClient;

    constructor(
        injector: Injector
    ) {
        this.configService = injector.get(ConfigService);
        this.http = injector.get(HttpClient);
        this.ApiUrls = this.configService.Config.ApiUrls;
    }

    public Get(url: string, params?: HttpRestParams): Observable<any> {
        const paramsAsString = params ? params.toString() : '';

        return this.http.get(`${this.configService.GetApiUrl(url)}/${paramsAsString}`).pipe(
            catchError(error => this.apiErrorService.HandleError(error)));
    }
}
