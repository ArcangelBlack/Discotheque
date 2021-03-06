﻿import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { CategoryModel } from '../Category.Model';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import { resetFakeAsyncZone } from '@angular/core/testing';

@Injectable()
export class CategoryService {

    private actionUrl: string = "api/Category/";
    private actionGetUrl: string | undefined;
    private actionPostUrl: string | undefined;
    private actionPutUrl: string | undefined;
    private token: string = "";
    private username: string = "";
    private data: any;

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) { }

    public getAllCategories = (): Observable<any> => {
        return this.http.get(this.baseUrl + this.actionUrl + 'GetAll').map((response: Response) => <any>response.json()).catch(response => {
            if (response.status == 401) {
                console.error(response);
            }
            return response;
        });
    }

    public addCategory(currentmodel: CategoryModel) {
        this.actionPostUrl = this.baseUrl + this.actionUrl;
        return this.http.post(this.actionPostUrl, currentmodel).map((response: Response) => response.json()).catch(response => {
            if (response == 401) {
                console.error(response);
            }
            return response;
        });
    }

    public editCategory(categoryId: string) {
        this.actionGetUrl = this.baseUrl + this.actionUrl + categoryId;
        return this.http.get(this.actionGetUrl).map((response: Response) => response.json()).catch(response => {
            if (response == 401) {
                console.error(response);
            }
            return response;
        });
    }

    public updateCategory(currentModel: CategoryModel) {
        this.actionPutUrl = this.baseUrl + this.actionUrl + currentModel.Id;
        return this.http.put(this.actionPutUrl, currentModel).map((response: Response) => response.json()).catch(response => {
            if (response == 401) {
                console.error(response);
            }
            return response;
        });
    }
}