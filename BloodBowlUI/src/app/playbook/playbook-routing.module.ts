import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { PlaybookComponent } from './playbook.component';
import { RulesetComponent } from './ruleset/ruleset/ruleset.component';

const routes: Routes = [
  { 
    path: '',
    component: PlaybookComponent,
    children: [
      {
        path: ':rulesetId',
        component: RulesetComponent
      }      
    ]  
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MaintenanceRoutingModule { }
