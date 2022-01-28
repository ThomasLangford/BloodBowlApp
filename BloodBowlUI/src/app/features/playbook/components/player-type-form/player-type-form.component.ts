import { Component, OnInit, ChangeDetectionStrategy, Input, OnDestroy } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatChipInputEvent } from '@angular/material/chips';
import {COMMA, ENTER} from '@angular/cdk/keycodes';
import { Skill } from 'src/app/core/models/skill';
import { SkillCategory } from 'src/app/core/models/skillCategory';
import { ReplaySubject, Subject, takeUntil } from 'rxjs';
import { LevelUpType } from 'src/app/core/models/levelUpType';
import { AvailableSkillCategory } from 'src/app/core/models/availableSkillCategory';

@Component({
  selector: 'app-playertypeform',
  templateUrl: './player-type-form.component.html',
  styleUrls: ['./player-type-form.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class PlayerTypeFormComponent implements OnInit, OnDestroy {
  private unsubscribe: Subject<void> = new Subject<void>();

  @Input() formGroup!: FormGroup;
  @Input() skillCategories!: SkillCategory[];
  
  constructor() {
   }

  ngOnInit(): void {
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
}
