import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OwnerRejectedBookings } from './owner-rejected-bookings';

describe('OwnerRejectedBookings', () => {
  let component: OwnerRejectedBookings;
  let fixture: ComponentFixture<OwnerRejectedBookings>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [OwnerRejectedBookings],
    }).compileComponents();

    fixture = TestBed.createComponent(OwnerRejectedBookings);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
