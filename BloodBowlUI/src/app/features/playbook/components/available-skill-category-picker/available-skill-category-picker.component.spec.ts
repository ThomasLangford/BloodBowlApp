import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AvailableSkillCategoryPickerComponent } from './available-skill-category-picker.component';

describe('AvailableSkillCategoryPickerComponent', () => {
  let component: AvailableSkillCategoryPickerComponent;
  let fixture: ComponentFixture<AvailableSkillCategoryPickerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AvailableSkillCategoryPickerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AvailableSkillCategoryPickerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
