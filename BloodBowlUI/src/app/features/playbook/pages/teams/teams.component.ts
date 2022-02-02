import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TeamType } from 'src/app/core/models/teamType';
import { RulesetIdService } from '../../services/rulesetidservice/rulesetid.service';
import { TeamTypeService } from '../../services/teamType/teamType.service';

@Component({
  templateUrl: './teams.component.html',
  styleUrls: ['./teams.component.scss']
})
export class TeamsComponent implements OnInit {
  public TeamTypes: TeamType[] = [];

  constructor(private _rulesetIdService: RulesetIdService, private _teamTypeService: TeamTypeService, private _activatedRoute: ActivatedRoute, private _router: Router) { }

  ngOnInit(): void {
    this.getTeamTypes();
  }

  public getTeamUrl(teamTypeId: number): string {
    return `${this._router.url}/${teamTypeId}`;
  }

  public getNewTeamUrl(): string {
    return `${this._router.url}/new`;
  }

  private getTeamTypes() {
    this._rulesetIdService.getRulesetIdFromPath(this._activatedRoute).subscribe({
      next: res => {
        this._teamTypeService.getTeamTypes(res).subscribe({
          next: res => { this.TeamTypes = res; }
        });
      }
    });
  }
  
  public deleteTeamType(teamTypeId: number) {
    this._rulesetIdService.getRulesetIdFromPath(this._activatedRoute).subscribe({
      next: res => {
        this._teamTypeService.deleteTeamType(res, teamTypeId).subscribe({
          next: res => { 
              if(res) {
                this.TeamTypes.forEach((item, index) => {
                  if(res.id === item.id) this.TeamTypes.splice(index,1);
                });
              }
            }
        });
      }
    });
  }
}
