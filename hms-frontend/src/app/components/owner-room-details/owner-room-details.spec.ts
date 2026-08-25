import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OwnerRoomDetails } from './owner-room-details';

describe('OwnerRoomDetails', () => {
  let component: OwnerRoomDetails;
  let fixture: ComponentFixture<OwnerRoomDetails>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [OwnerRoomDetails],
    }).compileComponents();

    fixture = TestBed.createComponent(OwnerRoomDetails);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
