import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { Injector } from '@angular/core';
import { TestBed, async, inject } from '@angular/core/testing';

import { AppConfig, Patient } from '../models';
import { ConfigService } from './config.service';
import { PatientService } from './patient.service';

export const MockData = [
    {UniqueIdentifier: '1', Name: 'Name 1'} as Patient,
    {UniqueIdentifier: '2', Name: 'Name 2'} as Patient,
    {UniqueIdentifier: '3', Name: 'Name 3'} as Patient
];

const configServiceStub = {
    Config: new AppConfig(),
    GetApiUrl() {
        return '/patient';
    }
};

describe('PatientService', () => {
    let injector: Injector;
    let service: PatientService;
    let httpMock: HttpTestingController;

    beforeEach(() => {
        injector = TestBed.configureTestingModule({
            imports: [
                HttpClientTestingModule
            ],
            providers: [
                AppConfig,
                {
                    provide: ConfigService,
                    useValue: configServiceStub
                },
                Injector,
                PatientService
            ]
        });

        service = injector.get(PatientService);
        httpMock = injector.get(HttpTestingController);
    });

    afterEach(() => {
        httpMock.verify();
    });

    it('Should Create the Patient Service', inject([PatientService], (svc: PatientService) => {
        expect(svc).toBeTruthy();
    }));

    it('Should Get All the Patients', async(() => {
        service.GetAll().subscribe((patients) => {
            expect(patients.length).toBe(3);
            expect(patients).toEqual(MockData);
        });

        const req = httpMock.expectOne(`/patient/`);
        expect(req.request.method).toEqual('GET');
        req.flush(MockData);
    }));
});
