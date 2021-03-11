import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { MatDividerModule } from "@angular/material/divider";
import { MatListModule } from "@angular/material/list";
import { MatButtonModule } from "@angular/material/button";
import { MatIconModule } from "@angular/material/icon";
import { MatExpansionModule } from "@angular/material/expansion";
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatSidenavModule } from '@angular/material/sidenav';

import { NavSidebarComponent } from './components/nav-sidebar/nav-sidebar.component';
import { NavTopbarComponent } from './components/nav-topbar/nav-topbar.component';

@NgModule({
  declarations: [NavSidebarComponent, NavTopbarComponent],
  imports: [
    CommonModule,
    MatDividerModule,
    MatListModule,
    MatButtonModule,
    MatIconModule,
    MatExpansionModule,
    MatToolbarModule,
    MatSidenavModule,
    RouterModule
  ],
  exports: [
    NavSidebarComponent,
    NavTopbarComponent
  ]
})
export class CoreModule { }
