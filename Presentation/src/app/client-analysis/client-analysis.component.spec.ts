import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClientAnalysisComponent } from './client-analysis.component';

describe('ClientAnalysisComponent', () => {
  let component: ClientAnalysisComponent;
  let fixture: ComponentFixture<ClientAnalysisComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ClientAnalysisComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ClientAnalysisComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
