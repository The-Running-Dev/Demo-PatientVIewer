import { ApiUrls } from './api-urls.model';

export class AppConfig {
    public Version: string;

    public ProductionMode: boolean;

    public ReturnUrl: string;

    public AllowDiagnostics: boolean;

    public EnableDiagnostics: boolean;

    public ApiUrls: ApiUrls;

    constructor() {
        this.Version = '1.0.0';
        this.ReturnUrl = document.referrer;
        this.AllowDiagnostics = true;
        this.EnableDiagnostics = true;
        this.ApiUrls = new ApiUrls();
    }
}
