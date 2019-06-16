import { HttpClientModule } from '@angular/common/http';
import { APP_INITIALIZER } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { TableModule } from 'primeng/table';

import { ApiErrorService, ConfigService, ConfigServiceFactory, PatientService } from './services';
import { AppComponent } from './app.component';
import { AppConfig } from './models';
import { AppHeaderComponent, AppSidebarComponent } from './layout-components/';
import { AppRoutingModule } from './app-routing.module';
import { DashboardComponent } from './dashboard/dashboard.component';

const APP_SERVICES = [
    ConfigService,
    PatientService,
    ApiErrorService
];

const APP_COMPONENTS = [
    AppComponent,
    AppHeaderComponent,
    AppSidebarComponent,
    DashboardComponent
];

@NgModule({
    declarations: [
        AppComponent,
        ...APP_COMPONENTS,
    ],
    imports: [
        AppRoutingModule,
        BrowserModule,
        HttpClientModule,
        TableModule,
    ],
    providers: [
        AppConfig,
        {
            provide: APP_INITIALIZER,
            useFactory: ConfigServiceFactory,
            deps: [ConfigService],
            multi: true
        },
        ...APP_SERVICES
    ],
    bootstrap: [AppComponent]
})
export class AppModule {
}
