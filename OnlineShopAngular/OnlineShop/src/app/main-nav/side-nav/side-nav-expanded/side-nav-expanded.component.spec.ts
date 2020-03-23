import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SideNavExpandedComponent } from './side-nav-expanded.component';

describe('SideNavExpandedComponent', () => {
  let component: SideNavExpandedComponent;
  let fixture: ComponentFixture<SideNavExpandedComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SideNavExpandedComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SideNavExpandedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
