import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { Injector } from '@angular/core';
import { TestBed, async, inject } from '@angular/core/testing';
import { environment } from '../../environments/environment';

import { AppConfig } from '../models';
import { ConfigService } from './config.service';

const mockConfig = {
    Version: '1.0',
    ProductionMode: false,
    ApiUrls: {
        Patient: 'Patient'
    }
} as AppConfig;


describe('ConfigService', () => {
    let injector: Injector;
    let service: ConfigService;
    let httpMock: HttpTestingController;

    beforeEach(() => {
        injector = TestBed.configureTestingModule({
            imports: [
                HttpClientTestingModule
            ],
            providers: [
                AppConfig,
                Injector,
                ConfigService
            ]
        });

        service = injector.get(ConfigService);
        httpMock = injector.get(HttpTestingController);
    });

    afterEach(() => {
        httpMock.verify();
    });

    it('Should Create the Config Service', inject([ConfigService], (svc: ConfigService) => {
        expect(svc).toBeTruthy();
    }));

    it('Should Load the Default Configuration', async(() => {
        service.Load().then((data) => {
            expect(data).toBeDefined();
            expect(data).toEqual(mockConfig);
        });

        const req = httpMock.expectOne(`config/config.json`);
        expect(req.request.method).toEqual('GET');
        req.flush(mockConfig);
    }));

    it('Should Get a Api Url by Its Key', async(() => {
        service.Load().then((data) => {
            expect(service.GetApiUrl('Patient')).toEqual(`${environment.apiUrl}/${mockConfig.ApiUrls.Patient}`);
        });

        const req = httpMock.expectOne(`config/config.json`);
        req.flush(mockConfig);
    }));
});
