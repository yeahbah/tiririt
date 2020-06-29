import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ResponseCommentsComponent } from './response-comments.component';

describe('ResponseCommentsComponent', () => {
  let component: ResponseCommentsComponent;
  let fixture: ComponentFixture<ResponseCommentsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ResponseCommentsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ResponseCommentsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
