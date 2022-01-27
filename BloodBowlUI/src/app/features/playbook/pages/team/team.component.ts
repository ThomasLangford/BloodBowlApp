import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { combineLatest, combineLatestWith } from 'rxjs';
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

  public Form: FormGroup;

  public RenderDisabled: boolean;

  constructor(private _rulesetIdService: RulesetIdService, private _teamTypeService: TeamTypeService, private _skillCategoryService: SkillCategoryService, private _activatedRoute: ActivatedRoute, private _router: Router, private _formBuilder: FormBuilder) { 
    this.RenderDisabled = true;

    this.Form = this.initalizeForm()
    this.Form.disable();
  }

  get playerTypes() {
    return this.Form.controls.playerTypes as FormArray;
  }

  initalizeForm() {
    return this._formBuilder.group({
      id: [0, [Validators.pattern("^[0-9]*$")]],
      name: ['', [Validators.required, Validators.maxLength(255)]],
      rulesetId: ['', [Validators.required, Validators.pattern("^[0-9]*$"),]],
      rerollCost: ['', [Validators.required, Validators.pattern("^[0-9]*$")]],
      apothicary: [false],
      necromancer: [false],
      playerTypes: this._formBuilder.array([]),
    });
  }

  initalizePlayerTypeFormGroup(): FormGroup {
    return this._formBuilder.group({
      id: [0, [Validators.pattern("^[0-9]*$")]],
      name: ['', [Validators.required, Validators.maxLength(255)]],
      maximumAllowedOnTeam: ['', [Validators.required, Validators.pattern("^[0-9]*$"),]],
      cost: ['', [Validators.required, Validators.pattern("^[0-9]*$"),]],
      move: ['', [Validators.required, Validators.pattern("^[0-9]*$"),]],
      strength: ['', [Validators.required, Validators.pattern("^[0-9]*$"),]],
      agility: ['', [Validators.required, Validators.pattern("^[0-9]*$"),]],
      armourValue: ['', [Validators.required, Validators.pattern("^[0-9]*$"),]],
      startingSkills: this._formBuilder.control([]),
    });
  }

  addPlayerType() {
    if(this.RenderDisabled) {
      return;
    }
    
    this.addBlankPlayerTypeToForm();
  }

  private addBlankPlayerTypeToForm() {
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
      next: rulesetId => {
        this.Form.controls.rulesetId.setValue(rulesetId);
        const teamTypeId = this.getTeamTypeId();

        const skillCategories$ = this._skillCategoryService.getSkillCategories(rulesetId);
        
        if(teamTypeId && !isNaN(teamTypeId)) {
          const teamTypes$ = this._teamTypeService.getTeamType(rulesetId, teamTypeId);

          skillCategories$.pipe(combineLatestWith(teamTypes$)).subscribe({
            next: res => {
                this.SkillCategories = res[0];
                this.TeamType = res[1];

                // Map the skills into an array for faster search
                let skills: {[id: number]: Skill} = {};
                this.SkillCategories.forEach(sc => sc.skills.forEach(s => skills[s.id] = s));

                // Map the Player Skills onto the Original Skills so they are auto populated by the form
                // (They are objects and not primitives so the form checks by reference for equality)
                this.TeamType?.playerTypes?.forEach(pt => pt.startingSkills = pt.startingSkills.map(obj => skills[obj.id]));

                // Add the playertype form controls to the main form
                this.TeamType.playerTypes.forEach(_ => {
                  this.addBlankPlayerTypeToForm();
                });

                this.Form.patchValue(this.TeamType);   
                
                if(!this.RenderDisabled) {
                  this.Form.enable();
                } else {
                  this.Form.disable();
                }  
            }, 
            error: err => console.log(err)
          })           
        } else {
          this.TeamType = null;
          skillCategories$.subscribe({next: res => this.SkillCategories = res});
          
          if(!this.RenderDisabled) {
            this.Form.enable();
          } else {
            this.Form.disable();
          }          
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

  public submit() {
    if(this.RenderDisabled) {
      return;
    }

    this.updateTreeValidity(this.Form);

    if(this.Form.invalid) {
      this.Form.markAllAsTouched();
      return;
    }

    this.TeamType = <TeamType>this.Form.value;    

    if (this.TeamType !== null) {
      this._teamTypeService.postTeamType(this.TeamType).subscribe({
        next: res => {
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
