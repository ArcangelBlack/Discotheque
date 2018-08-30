import { Component, OnInit } from '@angular/core';
import { EmployeeModel } from '../../employees/Employee.Model';
import { EmployeeService } from '../../employees/Services/Employee.service';
import { Router, ActivatedRoute } from '@angular/router'

@Component({
    selector: 'new-employee',
    templateUrl: './newEmployee.component.html',
    providers: [EmployeeService]
})
export class newEmployeeComponent {

    currentModel: EmployeeModel = new EmployeeModel();
    ID: string | undefined;
    private data: any;

    constructor(private employeeService: EmployeeService, private route: Router, private _routeParams: ActivatedRoute) {    }

    onSumit() {
        alert("Yhi");
        var formdata = this.currentModel;
        this.employeeService.addEmployee(formdata).subscribe(data => {
            if (data == true) {
                alert("Your Data Update Successfully ");
                this.route.navigate(['employees']);
            } else {
                alert("Problem While Adding model");
            }
        }, error => {
            if (error) {
                alert("An Error has occured please try again after some time !");
            }
        })
    }
} 