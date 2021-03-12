import { TestBed } from '@angular/core/testing';

import { SkillcategoryService } from './skillcategory.service';

describe('SkillcategoryService', () => {
  let service: SkillcategoryService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SkillcategoryService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
