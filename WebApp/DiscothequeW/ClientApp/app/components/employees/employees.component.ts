import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { EmployeeModel } from '../employees/Employee.Model';

@Component({
    selector: 'employees',
    templateUrl: './employees.component.html'
})
export class employeesComponent {
    public EmployeeList: EmployeeModel[]; 

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get(baseUrl + 'api/Employee/GetAll').subscribe(result => {
            this.EmployeeList = result.json();
        }, error => console.error(error));
    }
} 