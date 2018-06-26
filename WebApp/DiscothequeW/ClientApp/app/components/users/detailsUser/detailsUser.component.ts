import { Component, OnInit } from '@angular/core';
import { UserModel } from '../User.Model';
import { Router, ActivatedRoute } from '@angular/router'
import { UserService } from '../Services/User.service';

@Component({
    selector: 'details-user',
    templateUrl: './detailsuser.component.html',
    providers: [UserService]
})
export class detailsUserComponent implements OnInit {

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

}