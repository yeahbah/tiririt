import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SubmitPostFormComponent } from './submit-post-form.component';

describe('SubmitPostFormComponent', () => {
  let component: SubmitPostFormComponent;
  let fixture: ComponentFixture<SubmitPostFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SubmitPostFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SubmitPostFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
