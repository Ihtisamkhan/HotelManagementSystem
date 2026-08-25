import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateManager } from './create-manager';

describe('CreateManager', () => {
  let component: CreateManager;
  let fixture: ComponentFixture<CreateManager>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CreateManager],
    }).compileComponents();

    fixture = TestBed.createComponent(CreateManager);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
