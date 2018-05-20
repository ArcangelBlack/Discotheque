import { Http, Response, RequestOptions, ResponseContentType } from "@angular/http";
import { Injectable, Inject } from "@angular/core";
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';

@Injectable()
export class DocumentService {

    private actionUrl: string = "api/Document/";
    private actionGetUrl: string | undefined;

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) { }

    public getDocument = (): Observable<any> => {
        return this.http.get(this.baseUrl + this.actionUrl + 'GetAll').map((response: Response) => <any>response.json())
            .catch(response => {
                if (response.status == 401) {
                    alert('Error al descargar el documento')
                }
                return response;
            })
    }

    public getDocumentArray = (): any => {
        return this.http.get(this.baseUrl + this.actionUrl + 'GetAll').map((response: Response) => <any>response.json())
            .catch(response => {
                if (response.status == 401) {
                    alert('Error al descargar el documento')
                }
                return response.Data;
            })
    }

    public getDocumentBlod(): Observable<any> {
        let options = new RequestOptions({ responseType: ResponseContentType.Blob });
        return this.http.get(this.baseUrl + this.actionUrl + 'GetPdfFile', options)
            .map((response: Response) => <Blob>response.blob());
    }

    public getFile(): Observable<any> {
        let options = new RequestOptions({ responseType: ResponseContentType.ArrayBuffer });
        return this.http.get(this.baseUrl + this.actionUrl + 'GetPdfDownload', options)
            .map((response: Response) => <ArrayBuffer>response.arrayBuffer());
    }

    public getFile2(): Observable<any> {
        let options = new RequestOptions({ responseType: ResponseContentType.ArrayBuffer });
        return this.http.get(this.baseUrl + this.actionUrl + 'GetPdfDownload', options)
            .map((response: Response) => response);
    }

    public getFile3(): Observable<any> {
        let options = new RequestOptions({ responseType: ResponseContentType.ArrayBuffer });
        return this.http.get('http://twppdf.azurewebsites.net/api/values/4', options)
            .map((response: Response) => {
                if (response.status == 200) {
                    response
                }
            });
    }
}