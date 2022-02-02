import { AfterContentInit, ChangeDetectorRef, Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Ruleset } from 'src/app/core/models/ruleset';
import { RulesetService } from '../../services/ruleset/ruleset.service';
import { NavSidebarComponent } from 'src/app/core/components/nav-sidebar/nav-sidebar.component';
import { NavSidebarItem } from 'src/app/core/models/navSidebarItem';
import { SidenavService } from 'src/app/core/Services/Sidenav/sidenav.service';
import { MatSidenav } from '@angular/material/sidenav';
import { RulesetIdService } from '../../services/rulesetidservice/rulesetid.service';

@Component({
  templateUrl: './ruleset.component.html',
  styleUrls: ['./ruleset.component.scss']
})
export class RulesetComponent implements OnInit {
  @ViewChild('sidenav')
  private sidenav: MatSidenav | undefined;

  constructor(private _sidenavService: SidenavService, private _activatedRoute: ActivatedRoute, private _rulesetIdService: RulesetIdService) { }

  ngOnInit(): void {
    this._sidenavService.setSidenav(this.sidenav);
    this.setLinks();
  }

  private setLinks() {     
    this._rulesetIdService.getRulesetIdFromPath(this._activatedRoute).subscribe({
      next: res => {
        this._sidenavService.setLinks(this.buildLinks(res))
        this._sidenavService.open();
      }
    });
  }

  private buildLinks(currentRulesetId: Number) {
    return [
      {
        Title: "Skills", Url: `playbook/${currentRulesetId}/skills`
      },
      {
        Title: "Teams", Url: `playbook/${currentRulesetId}/teams`
      }
    ];
  }
}
