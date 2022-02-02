import { Component, OnInit, ChangeDetectionStrategy, Input, Output, OnDestroy } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Subject, takeUntil } from 'rxjs';
import { AvailableSkillCategory } from 'src/app/core/models/availableSkillCategory';
import { SkillCategory } from 'src/app/core/models/skillCategory';

@Component({
  selector: 'app-available-skill-category-picker',
  templateUrl: './available-skill-category-picker.component.html',
  styleUrls: ['./available-skill-category-picker.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class AvailableSkillCategoryPickerComponent implements OnInit, OnDestroy {
  private unsubscribe: Subject<void> = new Subject<void>();
  
  @Input() availableSkillCategoryFormControl!: FormControl;
  @Input() skillCategories!: SkillCategory[];
  @Input() levelUpTypeId!: number;

  @Input() label = "Available Skill Categories";

  public skillCategoryLookupFormControl: FormControl;

  constructor() {
    this.skillCategoryLookupFormControl = new FormControl([]);
  }

  ngOnInit(): void {
    this.setAvailableSkillCateory();

    this.skillCategoryLookupFormControl.valueChanges
      .pipe(takeUntil(this.unsubscribe))
      .subscribe(() => {this.updateAvailableSkillCategory()});   
  }

  ngOnDestroy(): void {
    this.unsubscribe.next();
    this.unsubscribe.complete();
  }

  removeSkillCategory(skillCategory: SkillCategory) {
    this.skillCategoryLookupFormControl.setValue([...this.skillCategoryLookupFormControl.value].filter(el => el.id !== skillCategory.id));
    this.skillCategoryLookupFormControl.updateValueAndValidity();
  }

  setAvailableSkillCateory(){
    let skillCategories: SkillCategory[] = [];

    (<AvailableSkillCategory[]>this.availableSkillCategoryFormControl.value).forEach(availableSkillCategory => {
      const matchingSkillCategory = this.skillCategories.find(skillCategory => skillCategory.id === availableSkillCategory.skillCategoryId );

      if(matchingSkillCategory && availableSkillCategory.levelUpTypeId === this.levelUpTypeId) {
        skillCategories.push(matchingSkillCategory);
      }
    });

    this.skillCategoryLookupFormControl.setValue(skillCategories);
  }

  updateAvailableSkillCategory(){
    const selectedSkillCategories: SkillCategory[] = this.skillCategoryLookupFormControl.value;
    const selectedAvailableSkillCategories: AvailableSkillCategory[] = this.availableSkillCategoryFormControl.value

    let updatedAvailableSkillCategories = selectedAvailableSkillCategories
      .filter(asc => asc.levelUpTypeId !== this.levelUpTypeId || (asc.levelUpTypeId === this.levelUpTypeId && selectedSkillCategories.some(sc => asc.skillCategoryId === sc.id)))
      .concat(selectedSkillCategories
        .filter(sc => !selectedAvailableSkillCategories.some(asc => asc.levelUpTypeId === this.levelUpTypeId && asc.skillCategoryId === sc.id ))
        .map(sc => ({id: 0, levelUpTypeId: this.levelUpTypeId, skillCategoryId: sc.id}))
      )

    this.availableSkillCategoryFormControl.setValue(updatedAvailableSkillCategories);
  }
}
