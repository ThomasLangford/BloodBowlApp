import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RulesetlandingComponent } from './ruleset-landing.component';

describe('RulesetlandingComponent', () => {
  let component: RulesetlandingComponent;
  let fixture: ComponentFixture<RulesetlandingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RulesetlandingComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RulesetlandingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
