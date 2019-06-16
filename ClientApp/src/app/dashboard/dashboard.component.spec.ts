import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TableModule } from 'primeng/table';
import { of } from 'rxjs';

import { AppConfig } from '../models';
import { ConfigService, PatientService } from '../services';

import { DashboardComponent } from './dashboard.component';

describe('DashboardComponent', () => {
    let component: DashboardComponent;
    let fixture: ComponentFixture<DashboardComponent>;

    const configServiceStub = {
        Load() {
            return new AppConfig();
        }
    };

    const patientServiceStub = {
        GetAll() {
            return of([{id: 1}]);
        }
    };

    beforeEach(async(() => {
        TestBed.configureTestingModule({
            imports: [
                TableModule
            ],
            declarations: [
                DashboardComponent
            ],
            providers: [
                {provide: ConfigService, useValue: configServiceStub},
                {provide: PatientService, useValue: patientServiceStub}
            ]
        }).compileComponents();

        fixture = TestBed.createComponent(DashboardComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    }));

    it('Should Create the Dashboard Component', () => {
        expect(component).toBeTruthy();
    });

    it('Should Contain at Least 1 Record', () => {
        expect(component.patients.length).toBeGreaterThan(0);
    });

    it('Should Contain at Least 1 Element', () => {
        fixture.detectChanges();

        const element = fixture.debugElement.nativeElement;

        expect(element.querySelectorAll('.ui-table-tbody td').length).toBeGreaterThan(0);
    });
});
