import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MaintenanceRooms } from './maintenance-rooms';

describe('MaintenanceRooms', () => {
  let component: MaintenanceRooms;
  let fixture: ComponentFixture<MaintenanceRooms>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MaintenanceRooms],
    }).compileComponents();

    fixture = TestBed.createComponent(MaintenanceRooms);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
