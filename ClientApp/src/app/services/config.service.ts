import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { AppConfig } from '../models';
import { environment } from '../../environments/environment';

@Injectable()
export class ConfigService {
    constructor(
        public Config: AppConfig,
        private http: HttpClient
    ) {
    }

    public GetApiUrl(endPointUrl: string): string {
        return `${environment.apiUrl}/${endPointUrl}`;
    }

    public Load(): Promise<AppConfig> {
        return new Promise((resolve) => {
            this.http.get('config/config.json')
                .subscribe((config: AppConfig) => {
                    this.Config = config;

                    resolve(this.Config);
                }, (error: any) => {
                    this.Config = new AppConfig();

                    resolve(this.Config);
                });
        });
    }
}

export function ConfigServiceFactory(config: ConfigService) {
    return () => config.Load();
}
