import { Component, OnInit } from '@angular/core';
import { EmployeeModel } from '../../employees/Employee.Model';
import { Router, ActivatedRoute } from '@angular/router'
import { EmployeeService } from '../../employees/Services/Employee.service';

@Component({
    selector: 'details-employee',
    templateUrl: './detailsEmployee.component.html',
    providers: [EmployeeService]
})
export class detailsEmployeeComponent implements OnInit {

    currentModel: EmployeeModel = new EmployeeModel();
    ID: string | undefined;
    private data: any;

    constructor(private employeeService: EmployeeService, private route: Router, private _routeParams: ActivatedRoute) {

    }

    ngOnInit(): void {
        this.ID = this._routeParams.snapshot.params['Id'];

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

} 