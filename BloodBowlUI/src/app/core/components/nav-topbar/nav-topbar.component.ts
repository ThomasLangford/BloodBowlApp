import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav-topbar',
  templateUrl: './nav-topbar.component.html',
  styleUrls: ['./nav-topbar.component.scss']
})
export class NavTopbarComponent implements OnInit {
  public LogoSrc = "assets/images/BBLogoIcon2018.png";

  constructor() { }

  ngOnInit(): void {
  }

}
