import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SideNavCollapsedComponent } from './side-nav-collapsed.component';

describe('SideNavCollapsedComponent', () => {
  let component: SideNavCollapsedComponent;
  let fixture: ComponentFixture<SideNavCollapsedComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SideNavCollapsedComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SideNavCollapsedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
