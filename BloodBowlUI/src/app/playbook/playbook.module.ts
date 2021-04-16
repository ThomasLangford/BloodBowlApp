import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { MatTableModule } from '@angular/material/table';

import { MaintenanceRoutingModule } from './playbook-routing.module';
import { MaintenanceComponent } from './playbook.component';
import { SkillFormComponent } from './skill-form/skill-form.component';

@NgModule({
  declarations: [MaintenanceComponent, SkillFormComponent],
  imports: [
    CommonModule,
    RouterModule,
    MatTableModule,
    MaintenanceRoutingModule
  ]
})
export class MaintenanceModule { }
