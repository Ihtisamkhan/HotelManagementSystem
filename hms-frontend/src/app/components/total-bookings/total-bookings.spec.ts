import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TotalBookings } from './total-bookings';

describe('TotalBookings', () => {
  let component: TotalBookings;
  let fixture: ComponentFixture<TotalBookings>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TotalBookings],
    }).compileComponents();

    fixture = TestBed.createComponent(TotalBookings);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
