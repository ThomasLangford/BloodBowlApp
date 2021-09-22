import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RulesetpickerComponent } from './rulesetpicker.component';

describe('RulesetpickerComponent', () => {
  let component: RulesetpickerComponent;
  let fixture: ComponentFixture<RulesetpickerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RulesetpickerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RulesetpickerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
