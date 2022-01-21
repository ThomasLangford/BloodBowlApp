import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { TeamType } from 'src/app/core/models/teamType';
import { RulesetIdService } from '../../services/rulesetidservice/rulesetid.service';
import { TeamTypeService } from '../../services/teamType/teamType.service';

@Component({
  templateUrl: './team.component.html',
  styleUrls: ['./team.component.scss']
})
export class TeamComponent implements OnInit {
  public TeamType: TeamType|null = null;

  public readonly Form: FormGroup;

  constructor(private _rulesetIdService: RulesetIdService, private _teamTypeService: TeamTypeService, private _activatedRoute: ActivatedRoute, private _router: Router, private _formBuilder: FormBuilder) { 
   
    this.Form = this._formBuilder.group({
      name: ['', [Validators.required, Validators.maxLength(255)]],
      rulesetId: ['', [Validators.required, Validators.pattern("^[0-9]*$"),]],
      rerollCost: ['', [Validators.required, Validators.pattern("^[0-9]*$")]],
      apothicary: ['', [Validators.required]],
      necromancer: ['', [Validators.required]],
      playerTypes: this._formBuilder.array([]),
    });
  }

  get playerTypes() {
    return this.Form.controls.playerTypes as FormArray;
  }

  initalizePlayerTypeFormGroup(): FormGroup {
    return this._formBuilder.group({
      name: ['', [Validators.required, Validators.maxLength(255)]],
      maximumAllowedOnTeam: ['', [Validators.required, Validators.pattern("^[0-9]*$"),]],
      cost: ['', [Validators.required, Validators.pattern("^[0-9]*$"),]],
      move: ['', [Validators.required, Validators.pattern("^[0-9]*$"),]],
      strength: ['', [Validators.required, Validators.pattern("^[0-9]*$"),]],
      agility: ['', [Validators.required, Validators.pattern("^[0-9]*$"),]],
      armourValue: ['', [Validators.required, Validators.pattern("^[0-9]*$"),]],
    });
  }

  addPlayerType() {
    const control = this.playerTypes;
    control.push(this.initalizePlayerTypeFormGroup());
}

getPlayerTypeByIndex(index: number): FormGroup {
  return this.playerTypes.at(index) as FormGroup;
}

  ngOnInit(): void {
    this.setupForm();
  }

  private setupForm() {
    this._rulesetIdService.getRulesetIdFromPath(this._activatedRoute).subscribe({
      next: res => {
        this.Form.controls.rulesetId.setValue(res);

        const teamTypeIdFromRequest = this._activatedRoute.snapshot.paramMap.get('teamId');
        if (teamTypeIdFromRequest !== null && !isNaN(parseInt(teamTypeIdFromRequest))) {
          this.getTeamType(res, parseInt(teamTypeIdFromRequest));          
        } else {
          this.TeamType = null;
        }
      }
    });
  }

  private getTeamType(rulesetId: number, teamTypeId: number) {
    this._teamTypeService.getTeamType(rulesetId, teamTypeId).subscribe({
      next: res => {
        this.TeamType = res;        
        
        //Add a form control for each child
        res.playerTypes.forEach(_ => {
          this.addPlayerType();
        });

        this.Form.patchValue(res);        
      },
      error: err => console.log(err)
    })
  }

  public submit() {
    this.TeamType = this.Form.value;    

    console.log(this.TeamType);

    if (this.TeamType !== null) {
      this._teamTypeService.postTeamType(this.TeamType).subscribe({
        next: res => console.log(res)
      })
    }    
  }
}
