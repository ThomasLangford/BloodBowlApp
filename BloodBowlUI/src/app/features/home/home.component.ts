import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { SidenavService } from 'src/app/core/Services/Sidenav/sidenav.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit, AfterViewInit {

  @ViewChild('sidenav')
  private sidenav: MatSidenav | undefined;

  constructor(private _sidenavService: SidenavService) { }

  ngOnInit(): void {
    this._sidenavService.setSidenav(this.sidenav);
    
    this.sidenav?.toggle();
  }

  ngAfterViewInit(): void {
    this._sidenavService.close();
    this.sidenav?.toggle();
    console.log(this.sidenav);
  }
}
