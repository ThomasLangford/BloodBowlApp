import { InputModalityDetector } from '@angular/cdk/a11y';
import { Component, OnInit, ChangeDetectionStrategy, Input, OnDestroy } from '@angular/core';
import { FormControl } from '@angular/forms';
import { ReplaySubject, Subject, takeUntil } from 'rxjs';
import { Skill } from 'src/app/core/models/skill';
import { SkillCategory } from 'src/app/core/models/skillCategory';

@Component({
  selector: 'app-skill-picker',
  templateUrl: './skill-picker.component.html',
  styleUrls: ['./skill-picker.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class SkillPickerComponent implements OnInit, OnDestroy {
  private unsubscribe: Subject<void> = new Subject<void>();

  @Input() skillCategories!: SkillCategory[];
  @Input() skillFormControl!: FormControl;
  
  @Input() label = "Skills";
  @Input() placeHolder = "Skills...";
  @Input() searchPlaceHolder = "Search...";
  @Input() noRecordsFoundMessage = "No Skills Found";

  public filteredSkillCategories: ReplaySubject<SkillCategory[]>
  public skillNameLookupFormControl: FormControl;

  constructor() { 
    this.skillNameLookupFormControl = new FormControl();
    this.filteredSkillCategories = new ReplaySubject<SkillCategory[]>();
  }

  ngOnInit(): void {
    this.filteredSkillCategories.next([...this.skillCategories]);

    this.skillNameLookupFormControl.valueChanges
      .pipe(takeUntil(this.unsubscribe))
      .subscribe(() => {this.filterSkills(this.skillNameLookupFormControl.value)});
  }

  ngOnDestroy(): void {
    this.unsubscribe.next();
    this.unsubscribe.complete();
  }

  removeSelectedSkill(skill: Skill): void {
    this.skillFormControl.setValue([...this.skillFormControl.value].filter(el => el.id !== skill.id));
    this.skillFormControl?.updateValueAndValidity();
  }

  protected filterSkills(skillName: string) {
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
}
