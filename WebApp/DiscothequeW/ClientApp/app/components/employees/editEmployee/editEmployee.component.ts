import { Component, OnInit } from '@angular/core';
import { EmployeeModel } from '../../employees/Employee.Model';
import { EmployeeService } from '../../employees/Services/Employee.service';
import { Router, ActivatedRoute } from '@angular/router'

@Component({
    selector: 'edit-employee',
    templateUrl: './editEmployee.component.html',
    providers: [EmployeeService]
})
export class editEmployeeComponent implements OnInit {

    currentModel: EmployeeModel = new EmployeeModel();
    ID: string | undefined;
    private data: any;

    constructor(private employeeService: EmployeeService, private route: Router, private _routeParams: ActivatedRoute) {

    }

    ngOnInit(): void {
        this.ID = this._routeParams.snapshot.params['ID'];

        if (this.ID != null) {
            this.employeeService.editEmployee(this.ID).subscribe(data => {
                this.currentModel = <EmployeeModel>data;
            }, error => {
                if (error) {
                    alert("An Error has occured please try again after some time !");
                }
            })
        }
    }

    onSubmit() {
        var formData = this.currentModel;
        this.employeeService.updateEmployee(formData).subscribe(data => {
            if (data == true) {
                alert("Your Data Update Successfully ");
                this.route.navigate(['employees']);
            }else {
                alert("Problem While Adding Cars");
            }
        }, error => {
            if (error) {
                alert("An Error has occured please try again after some time !");
            }
        });
    }

} 