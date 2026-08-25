import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RoomsManagement } from './rooms-management';

describe('RoomsManagement', () => {
  let component: RoomsManagement;
  let fixture: ComponentFixture<RoomsManagement>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RoomsManagement],
    }).compileComponents();

    fixture = TestBed.createComponent(RoomsManagement);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
