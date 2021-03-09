import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavSidebarComponent } from '../components/nav-sidebar/nav-sidebar.component';
import { NavTopbarComponent } from '../components/nav-topbar/nav-topbar.component';



@NgModule({
  declarations: [NavSidebarComponent, NavTopbarComponent],
  imports: [
    CommonModule
  ]
})
export class CoreModule { }
