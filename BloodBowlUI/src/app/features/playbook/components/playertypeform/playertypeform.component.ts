import { Component, OnInit, ChangeDetectionStrategy, Input, OnDestroy } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatChipInputEvent } from '@angular/material/chips';
import {COMMA, ENTER} from '@angular/cdk/keycodes';
import { Skill } from 'src/app/core/models/skill';
import { SkillCategory } from 'src/app/core/models/skillCategory';
import { ReplaySubject, Subject, takeUntil } from 'rxjs';
import { LevelUpType } from 'src/app/core/models/levelUpType';
import { AvailableSkillCategory } from 'src/app/core/models/AvailableSkillCategory';

@Component({
  selector: 'app-playertypeform',
  templateUrl: './playertypeform.component.html',
  styleUrls: ['./playertypeform.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class PlayerTypeFormComponent implements OnInit, OnDestroy {
  private unsubscribe: Subject<void> = new Subject<void>();

  @Input() formGroup!: FormGroup;
  @Input() skillCategories!: SkillCategory[];

  public filteredSkillCategories: ReplaySubject<SkillCategory[]>

  public skillNameLookupFormControl: FormControl;

  public skillNormalsFormControl: FormControl;
  public skillDoublesFormControl: FormControl;
  
  constructor() {
    this.skillNameLookupFormControl = new FormControl();
    this.filteredSkillCategories = new ReplaySubject<SkillCategory[]>();

    this.skillNormalsFormControl = new FormControl([]);
    this.skillDoublesFormControl = new FormControl([]);
   }

  ngOnInit(): void {
    this.filteredSkillCategories.next([...this.skillCategories]);

    this.skillNameLookupFormControl.valueChanges
      .pipe(takeUntil(this.unsubscribe))
      .subscribe(() => {this.filterSkills(this.skillNameLookupFormControl.value)});

    this.skillNormalsFormControl.valueChanges
      .pipe(takeUntil(this.unsubscribe))
      .subscribe(() => {this.updateAvailableSkillCategory()});   

    this.skillDoublesFormControl.valueChanges
      .pipe(takeUntil(this.unsubscribe))
      .subscribe(() => {this.updateAvailableSkillCategory()});    
      
    this.setAvailableSkillCateory();
  }

  ngOnDestroy(): void {
    this.unsubscribe.next();
    this.unsubscribe.complete();
  }

  get startingSkills(): FormControl {
    return this.formGroup.get('startingSkills') as FormControl;
  }

  get availableSkillCategories(): FormControl {
    return this.formGroup.get('availableSkillCategories') as FormControl;
  }

  // add(event: MatChipInputEvent): void {
  //   const value = <Skill>JSON.parse(event.value);

  //   if (value) {
  //     this.startingSkills?.setValue([...this.startingSkills.value, value]);
  //     this.startingSkills?.updateValueAndValidity();
  //   }

  //   // Reset the input value
  //   event.chipInput?.clear();
  // }

  remove(skill: Skill): void {
    this.startingSkills.setValue([...this.startingSkills.value].filter(el => el.id !== skill.id));
    this.startingSkills?.updateValueAndValidity();
  }

  protected filterSkills(skillName: string) {
    console.log("skillname" + skillName);

    console.log(this.skillCategories);

    if (!this.skillCategories) {
      return;
    }

    // get the search keyword
    if (!skillName) {
      this.filteredSkillCategories.next([...this.skillCategories]);
      return;
    } else {
      skillName = skillName.toLowerCase();
    }
    // filter the banks

    let copiedSkillCategories: SkillCategory[] = [];

    this.skillCategories.forEach(sc => {
      let copiedCategory = {...sc};
      copiedCategory.skills = copiedCategory.skills.filter(s => s.name.toLowerCase().indexOf(skillName) > -1);

      if(copiedCategory.skills.length > 0) {
        copiedSkillCategories.push(copiedCategory);
      }
    })

    this.filteredSkillCategories.next(
      copiedSkillCategories
    );
  }

  removeNormalSkillCategory(skillCategory: SkillCategory) {
    this.skillNormalsFormControl.setValue([...this.skillNormalsFormControl.value].filter(el => el.id !== skillCategory.id));
    this.skillNormalsFormControl.updateValueAndValidity();
  }

  removeDoubleSkillCategory(skillCategory: SkillCategory) {
    this.skillDoublesFormControl.setValue([...this.skillDoublesFormControl.value].filter(el => el.id !== skillCategory.id));
    this.skillDoublesFormControl.updateValueAndValidity();
  }

  setAvailableSkillCateory(){
    console.log(this.availableSkillCategories);

    let normalSkillCategories: SkillCategory[] = [];
    let doubleSkillCategories: SkillCategory[] = [];

    (<AvailableSkillCategory[]>this.availableSkillCategories.value).forEach(asc => {
      const skillCategory: SkillCategory | undefined = this.skillCategories.find(sc => sc.id === asc.skillCategoryId );

      if(skillCategory) {
        if(asc.levelUpTypeId === 1) {
          normalSkillCategories.push(skillCategory);
        } else {
          doubleSkillCategories.push(skillCategory);
        }
      }
    });

    this.skillNormalsFormControl.setValue(normalSkillCategories);
    this.skillDoublesFormControl.setValue(doubleSkillCategories);
  }

  updateAvailableSkillCategory(){
    let normalsSkillCategories: AvailableSkillCategory[] = (<SkillCategory[]>this.skillNormalsFormControl.value).map(sc => ({id: 0, levelUpTypeId: 1, skillCategoryId: sc.id}));

    let doubleSkillCategories: AvailableSkillCategory[] = (<SkillCategory[]>this.skillDoublesFormControl.value).map(sc => ({id: 0, levelUpTypeId: 2, skillCategoryId: sc.id}));

    let combinedSkillCategories: AvailableSkillCategory[] = normalsSkillCategories.concat(doubleSkillCategories);

    combinedSkillCategories.forEach(el => {
      let asc = (<AvailableSkillCategory[]>this.availableSkillCategories.value).find(asc => asc.skillCategoryId === el.levelUpTypeId && asc.levelUpTypeId === el.levelUpTypeId && asc.id > 0);

      if(asc) {
        el.id = asc.id;
      }
    });

    this.availableSkillCategories.setValue(combinedSkillCategories);
  }
}
