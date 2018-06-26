import { Component, OnInit } from '@angular/core';
import { UserModel } from '../User.Model';
import { Router, ActivatedRoute } from '@angular/router'
import { UserService } from '../Services/User.service';

@Component({
    selector: 'new-user',
    templateUrl: './newuser.component.html',
    providers: [UserService]
})
export class newUserComponent {

    currentModel: UserModel = new UserModel();
    ID: string | undefined;
    private data: any;

    constructor(private userService: UserService, private route: Router, private _routeParams: ActivatedRoute) { }

    onSubmit() {
        var formData = this.currentModel;
        this.userService.addUser(formData).subscribe(data => {
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