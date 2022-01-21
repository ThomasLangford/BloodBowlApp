import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlayerTypeFormComponent } from './playertypeform.component';

describe('PlayertypeformComponent', () => {
  let component: PlayerTypeFormComponent;
  let fixture: ComponentFixture<PlayerTypeFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PlayerTypeFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PlayerTypeFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
