import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OwnerPendingBookings } from './owner-pending-bookings';

describe('OwnerPendingBookings', () => {
  let component: OwnerPendingBookings;
  let fixture: ComponentFixture<OwnerPendingBookings>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [OwnerPendingBookings],
    }).compileComponents();

    fixture = TestBed.createComponent(OwnerPendingBookings);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
