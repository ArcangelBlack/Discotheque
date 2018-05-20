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
    submitted: boolean = false;
    status: boolean | undefined;
    private username: string = "";
    private data: any;

    constructor(private employeeService: EmployeeService, private route: Router) {

    }

    onSumit() {

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