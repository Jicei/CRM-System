import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ActivityClientComponent } from './activity-client.component';

describe('ActivityClientComponent', () => {
  let component: ActivityClientComponent;
  let fixture: ComponentFixture<ActivityClientComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ActivityClientComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ActivityClientComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
