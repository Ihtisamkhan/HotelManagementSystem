import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OwnerAcceptedBookings } from './owner-accepted-bookings';

describe('OwnerAcceptedBookings', () => {
  let component: OwnerAcceptedBookings;
  let fixture: ComponentFixture<OwnerAcceptedBookings>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [OwnerAcceptedBookings],
    }).compileComponents();

    fixture = TestBed.createComponent(OwnerAcceptedBookings);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
