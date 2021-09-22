import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { MatTableModule } from '@angular/material/table';

import { MaintenanceRoutingModule } from './playbook-routing.module';
import { PlaybookComponent } from './playbook.component';
import { RulesetComponent } from './pages/ruleset/ruleset.component';
import { TeamsComponent } from './pages/teams/teams/teams.component';

@NgModule({
  declarations: [PlaybookComponent, RulesetComponent, TeamsComponent],
  imports: [
    CommonModule,
    RouterModule,
    MatTableModule,
    MaintenanceRoutingModule
  ]
})
export class MaintenanceModule { }