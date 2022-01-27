import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { combineLatest } from 'rxjs';
import { CombineLatestOperator } from 'rxjs/internal/observable/combineLatest';
import { Skill } from 'src/app/core/models/skill';
import { SkillCategory } from 'src/app/core/models/skillCategory';
import { TeamType } from 'src/app/core/models/teamType';
import { RulesetIdService } from '../../services/rulesetidservice/rulesetid.service';
import { SkillCategoryService } from '../../services/skillcategory/skillcategory.service';
import { TeamTypeService } from '../../services/teamType/teamType.service';

@Component({
  templateUrl: './team.component.html',
  styleUrls: ['./team.component.scss']
})
export class TeamComponent implements OnInit {
  public TeamType: TeamType|null = null;
  public SkillCategories: SkillCategory[] = [];

  public readonly Form: FormGroup;

  constructor(private _rulesetIdService: RulesetIdService, private _teamTypeService: TeamTypeService, private _skillCategoryService: SkillCategoryService, private _activatedRoute: ActivatedRoute, private _router: Router, private _formBuilder: FormBuilder) { 
   
    this.Form = this._formBuilder.group({
      name: ['', [Validators.required, Validators.maxLength(255)]],
      rulesetId: ['', [Validators.required, Validators.pattern("^[0-9]*$"),]],
      rerollCost: ['', [Validators.required, Validators.pattern("^[0-9]*$")]],
      apothicary: [false],
      necromancer: [false],
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
      startingSkills: this._formBuilder.control(['']),
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
        this._skillCategoryService.getSkillCategories(res).subscribe({
          next: res => {
            this.SkillCategories = res;
          }
        });

        this.Form.controls.rulesetId.setValue(res);

        const teamTypeIdFromRequest = this.getTeamTypeId();

        if(teamTypeIdFromRequest && !isNaN(teamTypeIdFromRequest)) {
          this.getTeamType(res, teamTypeIdFromRequest);  
        } else {
          this.TeamType = null;
        }
      }
    });
  }

  private getTeamTypeId(): number | null{
    const teamTypeIdFromRequest = this._activatedRoute.snapshot.paramMap.get('teamId');
    if (teamTypeIdFromRequest !== null && !isNaN(parseInt(teamTypeIdFromRequest))) {
      return parseInt(teamTypeIdFromRequest);          
    }
    
    return null;
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
        
        console.log(res);
        console.log(this.Form);
      },
      error: err => console.log(err)
    })
  }

  public submit() {
    this.updateTreeValidity(this.Form);

    console.log(this.Form);

    if(this.Form.invalid) {
      console.log("invalid");
      this.Form.markAllAsTouched();
      return;
    }

    this.TeamType = <TeamType>this.Form.value;    

    console.log(this.TeamType);

    if (this.TeamType !== null) {
      this._teamTypeService.postTeamType(this.TeamType).subscribe({
        next: res => {
          console.log(res);

          if(res) {
            this._router.navigate([`../${res.id}`], {relativeTo: this._activatedRoute});
          }
        }
      })
    }  
  }

  updateTreeValidity(group: FormGroup | FormArray): void {
    Object.keys(group.controls).forEach((key: string) => {
      const abstractControl = group.get(key);

      if (abstractControl instanceof FormGroup || abstractControl instanceof FormArray) {
        this.updateTreeValidity(abstractControl);          
      } else if(abstractControl) {
         abstractControl.updateValueAndValidity();
      }
    });
  }
}
