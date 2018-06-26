import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { CompanyModel } from '../Company.Model';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import { resetFakeAsyncZone } from '@angular/core/testing';

@Injectable()
export class CompanyService {

    private actionUrl: string = "api/Company/";
    private actionGetUrl: string | undefined;
    private actionPostUrl: string | undefined;
    private actionPutUrl: string | undefined;
    private token: string = "";
    private username: string = "";
    private data: any;

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) { }

    public getAllCompanies = (): Observable<any> => {
        return this.http.get(this.baseUrl + this.actionUrl + 'GetAll').map((response: Response) => <any>response.json()).catch(response => {
            if (response.status == 401) {
                console.error(response);
            }
            return response;
        });
    }

    public addCompany(currentmodel: CompanyModel) {
        this.actionPostUrl = this.baseUrl + this.actionUrl;
        return this.http.post(this.actionPostUrl, currentmodel).map((response: Response) => response.json()).catch(response => {
            if (response.status == 401) {
                console.error(response);
            }
            return response;
        });
    }

    public editCompany(companyId: string) {
        this.actionGetUrl = this.baseUrl + this.actionUrl + companyId;
        return this.http.get(this.actionGetUrl).map((response: Response) => response.json()).catch(response => {
            if (response.status == 401) {
                console.error(response);
            }
            return response;
        });
    }

    public updateCompany(currentModel: CompanyModel) {
        this.actionPutUrl = this.baseUrl + this.actionUrl + currentModel.Id;
        return this.http.put(this.actionPutUrl, currentModel).map((response: Response) => response.json()).catch(response => {
            if (response.status == 401) {
                console.error(response);
            }
            return response;
        });
    }
}