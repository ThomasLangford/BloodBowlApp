import { Component, ViewChild } from '@angular/core';
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
export class AppComponent {
  title = 'BloodBowl UI';

  public LogoSrc = "assets/images/BBLogoIcon2018.png";

  @ViewChild('sidenav')
  public sidenav: MatSidenav | undefined;

  constructor(public _sidenavService: SidenavService) {
    console.log("Hello");
  }

  ngAfterViewInit(): void {
    this._sidenavService.setSidenav(this.sidenav);
  }

  ngAfterContentInit(): void {
  }
}
