import { Component, OnInit } from '@angular/core';
import { UserModel } from '../User.Model';
import { Router, ActivatedRoute } from '@angular/router'
import { UserService } from '../Services/User.service';

@Component({
    selector: 'edit-user',
    templateUrl: './edituser.component.html',
    providers: [UserService]
})
export class editUserComponent implements OnInit {

    currentModel: UserModel = new UserModel();
    ID: string | undefined;
    private data: any;

    constructor(private userService: UserService, private route: Router, private _routeParams: ActivatedRoute) { }

    ngOnInit(): void {
        this.ID = this._routeParams.snapshot.params['Id'];

        if (this.ID != null) {
            this.userService.editUser(this.ID).subscribe(data => {
                this.currentModel = <UserModel>data;
            }, error => {
                if (error) {
                    alert("An Error has occured please try again after some time !");
                }
            })
        }
    }

    onSubmit() {
        var formData = this.currentModel;
        this.userService.updateUser(formData).subscribe(data => {
            if (data == true) {
                alert("Your Data Update Successfully ");
                this.route.navigate(['users']);
            }
        }, error => {
            if (error) {
                alert("An Error has occured please try again after some time !");
            }
        })
    }

}