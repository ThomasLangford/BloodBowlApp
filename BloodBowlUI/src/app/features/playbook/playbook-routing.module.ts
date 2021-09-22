import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from '../home/home.component';

import { PlaybookComponent } from './playbook.component';
import { RulesetComponent } from './pages/ruleset/ruleset.component';

const routes: Routes = [
  { 
    path: '',
    component: PlaybookComponent,
    // path: '', redirectTo: '1', // pathMatch: 'full',
    children: [
      {
        path: ':rulesetId',
        component: RulesetComponent,
        children: [
          {
            path: 'test',
            component: RulesetComponent,
          }  
        ]
      },        
    ]  
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MaintenanceRoutingModule { }
