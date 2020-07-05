import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SideNavMenu2Component } from './side-nav-menu2.component';

describe('SideNavMenu2Component', () => {
  let component: SideNavMenu2Component;
  let fixture: ComponentFixture<SideNavMenu2Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SideNavMenu2Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SideNavMenu2Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
