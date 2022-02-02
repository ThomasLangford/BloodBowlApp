import { TestBed } from '@angular/core/testing';

import { RulesetIdService } from './rulesetid.service';

describe('RulesetidService', () => {
  let service: RulesetIdService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RulesetIdService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
