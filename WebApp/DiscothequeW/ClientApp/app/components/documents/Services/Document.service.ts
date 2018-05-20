import { Http, Response } from "@angular/http";
import { Injectable, Inject } from "@angular/core";
import { Observable } from "rxjs/Observable";

export class DocumentService {

    private actionUrl: string = "api/Document/";
    private actionGetUrl: string | undefined;

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) { }

    public getDocument = (): Observable<any> => {
        return this.http.get(this.baseUrl + this.actionGetUrl).map((response: Response) => <any>response.arrayBuffer()).catch(response => {
            if (response.status == 401) {
                alert('Error al descargar el documento')
            }
            return response;
        })
    }

}