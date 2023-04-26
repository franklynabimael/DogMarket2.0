import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-body-sidebar',
  templateUrl: './body-sidebar.component.html',
  styleUrls: ['./body-sidebar.component.css'],
})
export class BodySidebarComponent {
  @Input() collapsed = false;
  @Input() screenWidth = 0;

  getBodyClass(): string {
    let styleclass = '';
    if (this.collapsed && this.screenWidth > 768) {
      styleclass = 'body-trimmed';
    } else if (
      this.collapsed &&
      this.screenWidth <= 768 &&
      this.screenWidth > 0
    ) {
      styleclass = 'body-md-screen';
    }
    return styleclass;
  }
}
