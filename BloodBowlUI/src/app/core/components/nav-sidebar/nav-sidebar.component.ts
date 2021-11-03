import { Component, Input, OnInit } from '@angular/core';
import { NavSidebarItem } from '../../models/navSidebarItem';
import { SidenavService } from '../../Services/Sidenav/sidenav.service';

@Component({
  selector: 'app-nav-sidebar',
  templateUrl: './nav-sidebar.component.html',
  styleUrls: ['./nav-sidebar.component.scss']
})
export class NavSidebarComponent implements OnInit {
  constructor(public _sidenavService: SidenavService) { }
  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }
}
