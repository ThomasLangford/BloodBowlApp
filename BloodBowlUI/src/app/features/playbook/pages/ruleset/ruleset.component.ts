import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Ruleset } from 'src/app/core/models/ruleset';
import { RulesetService } from '../../services/ruleset/ruleset.service';
import { NavSidebarComponent } from 'src/app/core/components/nav-sidebar/nav-sidebar.component';
import { NavSidebarItem } from 'src/app/core/models/navSidebarItem';
import { SidenavService } from 'src/app/core/Services/Sidenav/sidenav.service';
import { MatSidenav } from '@angular/material/sidenav';

@Component({
  templateUrl: './ruleset.component.html',
  styleUrls: ['./ruleset.component.scss']
})
export class RulesetComponent implements OnInit {
  private rulesets: Ruleset[] = [];
  
public links : NavSidebarItem[] = [{
  Title: "Test", Url: "link"
}
];

@ViewChild('sidenav')
public sidenav: MatSidenav | undefined;


  constructor(public _sidenavService: SidenavService) { }


  ngAfterViewInit(): void {
    this._sidenavService.setSidenav(this.sidenav);
    this._sidenavService.links = this.links;
  }

  ngOnInit(): void {
    
  }

}
