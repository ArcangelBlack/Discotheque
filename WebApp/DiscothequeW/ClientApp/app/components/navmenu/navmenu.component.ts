import { Component } from '@angular/core';
import { MENU_ITEMS } from './pages-menu';

//@Component({
//    selector: 'nav-menu',
//    templateUrl: './navmenu.component.html',
//    styleUrls: ['./navmenu.component.css']
//})

@Component({
    selector: 'nav-menu',
    template: `
    <ngx-sample-layout>
      <nb-menu [items]="menu"></nb-menu>
      <router-outlet></router-outlet>
    </ngx-sample-layout>
  `,
})

export class NavMenuComponent {
    menu = MENU_ITEMS;
}
