import { Component, OnInit, ChangeDetectionStrategy, Input } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatChipInputEvent } from '@angular/material/chips';
import { TeamType } from 'src/app/core/models/teamType';
import {COMMA, ENTER} from '@angular/cdk/keycodes';
import { Skill } from 'src/app/core/models/skill';
import { SkillCategory } from 'src/app/core/models/skillCategory';

@Component({
  selector: 'app-playertypeform',
  templateUrl: './playertypeform.component.html',
  styleUrls: ['./playertypeform.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class PlayerTypeFormComponent implements OnInit {
  
  @Input() formGroup!: FormGroup;
  @Input() skillCategories!: SkillCategory[];

  private skills: Skill[] = [];

  readonly separatorKeysCodes: number[] = [ENTER, COMMA];

  constructor(private _formBuilder: FormBuilder) {

   }

  ngOnInit(): void {

    console.log(this.formGroup);
    console.log(this.skillCategories);
  }

  get startingSkills() {
    return this.formGroup.get('startingSkills');
  }

  get startingSkillsArray() {
    const skills = this.startingSkills?.value;

    if(!skills) {
      return []
    }
    return <Skill[]>skills;
  }

  add(event: MatChipInputEvent): void {
    const value = <Skill>JSON.parse(event.value);
    console.log(value);

    // Add our fruit
    if (value) {
      this.startingSkills?.setValue([...this.startingSkills.value, value]);
      this.startingSkills?.updateValueAndValidity();
    }

    console.log(this.startingSkills);

    // Reset the input value
    event.chipInput?.clear();
  }

  remove(skill: Skill): void {
    const index = this.startingSkillsArray.findIndex(el => el.id === skill.id)

    if (index >= 0) {
      this.startingSkills?.value.splice(index, 1);
      this.startingSkills?.updateValueAndValidity();
    }
  }
}
