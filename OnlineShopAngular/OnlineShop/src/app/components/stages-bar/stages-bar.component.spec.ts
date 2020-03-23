import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StagesBarComponent } from './stages-bar.component';

describe('StagesBarComponent', () => {
  let component: StagesBarComponent;
  let fixture: ComponentFixture<StagesBarComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StagesBarComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StagesBarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
