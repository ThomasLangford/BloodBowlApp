import { TestBed } from '@angular/core/testing';

import { LevelUpTypeService } from './levelUpType.service';

describe('LevelUpTypeService', () => {
  let service: LevelUpTypeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LevelUpTypeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
