import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateReceptionist } from './create-receptionist';

describe('CreateReceptionist', () => {
  let component: CreateReceptionist;
  let fixture: ComponentFixture<CreateReceptionist>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CreateReceptionist],
    }).compileComponents();

    fixture = TestBed.createComponent(CreateReceptionist);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
