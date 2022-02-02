import { ComponentFixture, TestBed } from '@angular/core/testing';
import { PlaybookComponent } from 'src/app/features/playbook/playbook.component';

import { NavTopbarComponent } from './nav-topbar.component';

describe('NavTopbarComponent', () => {
  let component: NavTopbarComponent;
  let fixture: ComponentFixture<NavTopbarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NavTopbarComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NavTopbarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeDefined();
  });

  it('should use LogoSrc for image logo src', () => {
    const navTopbarElement: HTMLElement = fixture.nativeElement; 
    const img: HTMLElement | null = navTopbarElement.querySelector("#nav-topbar-logo-img"); 
    expect(img).toBeTruthy;
    if (img) {
      expect(img.getAttribute('src')).toEqual(component.LogoSrc);
    }    
  })

  it('should use GitHubSrc for GitHub Link Href', () => {
    const navTopbarElement: HTMLElement = fixture.nativeElement; 
    const gitHubLink: HTMLElement | null = navTopbarElement.querySelector("#nav-topbar-link-github"); 
    expect(gitHubLink).toBeTruthy;
    if (gitHubLink) {
      expect(gitHubLink.getAttribute('href')).toEqual(component.GitHubSrc);
    }    
  })
});
