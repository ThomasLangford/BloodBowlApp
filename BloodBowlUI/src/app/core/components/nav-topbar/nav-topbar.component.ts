import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav-topbar',
  templateUrl: './nav-topbar.component.html',
  styleUrls: ['./nav-topbar.component.scss']
})
export class NavTopbarComponent{
  public readonly LogoSrc = "assets/images/BBLogoIcon2018.png";
  public readonly GitHubSrc = "https://github.com/ThomasLangford/BloodBowlApp";
  constructor() { }
}
