import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';


@Component({
    selector: 'employees',
    templateUrl: './employees.component.html'
})
export class employeesComponent {
    public EmployeeList = []; 

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get(baseUrl + 'api/Employee/Get').subscribe(result => {
            this.EmployeeList = result.json();
        }, error => console.error(error));
    }
} 