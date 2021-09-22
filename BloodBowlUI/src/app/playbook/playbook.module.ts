import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { MatTableModule } from '@angular/material/table';

import { MaintenanceRoutingModule } from './playbook-routing.module';
import { PlaybookComponent } from './playbook.component';
import { RulesetComponent } from './ruleset/ruleset/ruleset.component';

@NgModule({
  declarations: [PlaybookComponent, RulesetComponent],
  imports: [
    CommonModule,
    RouterModule,
    MatTableModule,
    MaintenanceRoutingModule
  ]
})
export class MaintenanceModule { }
