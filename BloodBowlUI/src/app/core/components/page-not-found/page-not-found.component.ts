import { Component, OnInit, ViewChild } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { SidenavService } from '../../Services/Sidenav/sidenav.service';

@Component({
  templateUrl: './page-not-found.component.html',
  styleUrls: ['./page-not-found.component.scss']
})
export class PageNotFoundComponent implements OnInit {
  @ViewChild('sidenav')
  private sidenav: MatSidenav | undefined;

  constructor(private _sidenavService: SidenavService) { }

  ngOnInit(): void {
    this._sidenavService.setSidenav(this.sidenav);
    this._sidenavService.close();
    this.sidenav?.toggle();
  }

}
