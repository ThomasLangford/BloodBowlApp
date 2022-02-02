import { TestBed } from '@angular/core/testing';

import { SkillCategoryService } from './skillcategory.service';

describe('SkillcategoryService', () => {
  let service: SkillCategoryService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SkillCategoryService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
