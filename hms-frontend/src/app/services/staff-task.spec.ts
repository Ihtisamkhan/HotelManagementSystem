import { TestBed } from '@angular/core/testing';

import { StaffTask } from './staff-task';

describe('StaffTask', () => {
  let service: StaffTask;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(StaffTask);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
