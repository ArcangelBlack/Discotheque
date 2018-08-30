import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { UserModel } from '../User.Model';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

@Injectable()
export class UserService {

    private actionUrl: string = "api/User/";
    private actionGetUrl: string | undefined;
    private actionPostUrl: string | undefined;
    private actionPutUrl: string | undefined;
    private token: string = "";
    private username: string = "";
    private data: any;

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) { }

    public getAllUsers = (): Observable<any> => {
        return this.http.get(this.baseUrl + this.actionUrl + 'GetAll').map((response: Response) => <any>response.json()).catch(response => {
            if (response.status == 401) {
                console.error(response);
            }
            return response;
        });
    }

    public addUser(currentmodel: UserModel) {
        this.actionPostUrl = this.baseUrl + this.actionUrl;
        return this.http.post(this.actionPostUrl, currentmodel).map((response: Response) => response.json()).catch(response => {
            if (response.status == 401) {
                console.error(response);
            }
            return response;
        });
    }

    public editUser(userId: string) {
        this.actionGetUrl = this.baseUrl + this.actionUrl + userId;
        return this.http.get(this.actionGetUrl).map((response: Response) => response.json()).catch(response => {
            if (response.status == 401) {
                console.error(response);
            }
            return response;
        });
    }

    public updateUser(currentmodel: UserModel) {
        this.actionPutUrl = this.baseUrl + this.actionUrl + currentmodel.Id;
        return this.http.put(this.actionPutUrl, currentmodel).map((response: Response) => response.json()).catch(response => {
            if (response.status == 401) {
                console.error(response);
            }
            return response;
        });
    }
}