import { Injectable } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { NavSidebarItem } from '../../models/navSidebarItem';

@Injectable({
  providedIn: 'root'
})
export class SidenavService {
  private sidenav: MatSidenav | undefined;

  public links: NavSidebarItem[] = [
    {
      Title: "Home", Url: "home"
    },
    {
      Title: "Leage", Url: "todo"
    },
    {
      Title: "My Teams", Url: "todo"
    },
    {
      Title: "Playbook", Url: "playbook"
    },
    {
      Title: "Account", Url: "todo"
    },
  ];

  public setSidenav(sidenav: MatSidenav | undefined) {
    this.sidenav = sidenav;
  }

  public open() {
    this.sidenav?.open();
  }


  public close() {
    this.sidenav?.close();
  }

  public toggle(): void {
    this.sidenav?.toggle();
  }
}