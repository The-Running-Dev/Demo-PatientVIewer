import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { Injector } from '@angular/core';
import { TestBed, inject } from '@angular/core/testing';

import { ApiErrorService } from './api-error.service';

describe('ApiErrorService', () => {
    let injector: Injector;
    let service: ApiErrorService;
    let httpMock: HttpTestingController;

    beforeEach(() => {
        injector = TestBed.configureTestingModule({
            imports: [
                HttpClientTestingModule
            ],
            providers: [
                ApiErrorService
            ]
        });

        service = injector.get(ApiErrorService);
        httpMock = injector.get(HttpTestingController);
    });

    afterEach(() => {
        httpMock.verify();
    });

    it('Should Create the Api Error Service', inject([ApiErrorService], (svc: ApiErrorService) => {
        expect(svc).toBeTruthy();
    }));
});
