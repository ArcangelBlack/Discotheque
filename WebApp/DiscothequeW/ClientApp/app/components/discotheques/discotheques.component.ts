import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';


@Component({
    selector: 'discotheques',
    templateUrl: './discotheques.component.html'
})
export class discothequesComponent {
    public DiscothequesList = []; 

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get(baseUrl + 'api/Discotheque/GetAvailables').subscribe(result => {
            this.DiscothequesList = result.json();
        }, error => console.error(error));
    }
} 