import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-main-nav',
  templateUrl: './main-nav.component.html',
  styleUrls: ['./main-nav.component.css']
})
export class MainNavComponent implements OnInit {
  isExpanded: boolean;
  mode: string
  expandedWidth = '220px';
  collapsedWidth = '60px';

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches)
    );

  @Output() 
  public sidenavToggle = new EventEmitter();

  public onToggleSidenav = () => {
    this.sidenavToggle.emit();
  }

  constructor(private breakpointObserver: BreakpointObserver) { }

  ngOnInit(): void {
    this.isExpanded = false;
    this.mode = 'side';
  }

  onHideClick() {
    this.isExpanded = !this.isExpanded;
    //this.mode = this.isExpanded ? 'over' : 'side';
  }
}
