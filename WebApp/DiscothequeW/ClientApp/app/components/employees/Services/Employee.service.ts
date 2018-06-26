import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { EmployeeModel } from '../../employees/Employee.Model';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

@Injectable()
export class EmployeeService {

    private actionUrl: string = "api/Employee/";
    private actionGetUrl: string | undefined;
    private actionPostUrl: string | undefined;
    private actionPutUrl: string | undefined;
    private token: string = "";
    private username: string = "";
    private data: any;

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) { }

    public getAllEmployees = (): Observable<any> => {
        return this.http.get(this.baseUrl + this.actionUrl + 'GetAll').map((response: Response) => <any>response.json())
            .catch(response => {
                if (response.status === 401) {
                    //this._Route.navigate(['Login']);
                    console.error(response);
                }
                return response;
            });
    }

    public addEmployee(currentmodel: EmployeeModel) {
        this.actionPostUrl = this.baseUrl + this.actionUrl;
        return this.http.post(this.actionPostUrl, currentmodel).map((res: Response) => res.json()).catch(response => {
            if (response.status === 401) {
                //this._Route.navigate(['Login']);
                console.error(response);
            }
            return response;
        });
    }

    public editEmployee(employeeId: string) {
        this.actionGetUrl = this.baseUrl + this.actionUrl + employeeId;
        return this.http.get(this.actionGetUrl).map((res: Response) => <any>res.json()).catch(response => {
            if (response.status === 401) {
                //this._Route.navigate(['Login']);
                console.error(response);
            }
            return response;
        });
    }

    public updateEmployee(currentmodel: EmployeeModel) {
        this.actionPutUrl = this.baseUrl + this.actionUrl + currentmodel.Id;
        return this.http.put(this.actionPutUrl, currentmodel).map((res: Response) => res.json()).catch(response => {
            if (response.status === 401) {
                //this._Route.navigate(['Login']);
                console.error(response);
            }
            return response;
        });
    }
}