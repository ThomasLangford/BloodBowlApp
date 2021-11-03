import { Injectable } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { NavSidebarItem } from '../../models/navSidebarItem';

@Injectable({
  providedIn: 'root'
})
export class SidenavService {
  private sidenav: MatSidenav | undefined;


  public links: NavSidebarItem[] = [];

  public opened = false;

  public setSidenav(sidenav: MatSidenav | undefined) {
    this.sidenav = sidenav;
  }

  public open() {
    setTimeout(() => {
      this.sidenav?.open();
      this.opened = true;
    });    
  }


  public close() {
    setTimeout(() => {
      this.sidenav?.close();
      this.opened = false;
    });
  }

  public toggle(): void {
    setTimeout(() => {
      this.sidenav?.toggle();
      this.opened = !this.opened;
    });
  }

  public setLinks(links: NavSidebarItem[]) {
    setTimeout(() => {
      this.links = links;
    });
  }
}