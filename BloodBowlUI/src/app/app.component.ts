import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
// import { SkillService } from './services/skill.service';
// import { catchError, map, tap } from 'rxjs/operators';

import { Routes, RouterModule } from '@angular/router';
import { SidenavService } from './core/Services/Sidenav/sidenav.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements AfterViewInit {
  @ViewChild('sidenav')
  public sidenav: MatSidenav | undefined;

  constructor(public _sidenavService: SidenavService) { }

  ngAfterViewInit(): void {
    this._sidenavService.setSidenav(this.sidenav);
  }
}
