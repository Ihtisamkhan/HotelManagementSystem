import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OccupiedRooms } from './occupied-rooms';

describe('OccupiedRooms', () => {
  let component: OccupiedRooms;
  let fixture: ComponentFixture<OccupiedRooms>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [OccupiedRooms],
    }).compileComponents();

    fixture = TestBed.createComponent(OccupiedRooms);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
