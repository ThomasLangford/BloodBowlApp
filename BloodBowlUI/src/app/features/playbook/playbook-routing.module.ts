import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from '../home/home.component';

import { PlaybookComponent } from './playbook.component';
import { RulesetComponent } from './pages/ruleset/ruleset.component';
import { RulesetpickerComponent } from './pages/rulesetpicker/rulesetpicker.component';

const routes: Routes = [
  { 
    //path: '',
    //component: RulesetpickerComponent,
    path: '', redirectTo: '1', // pathMatch: 'full',
    children: [      
    ]  
  },
  {
    path: ':rulesetId',
    component: RulesetComponent,
    children: [
      {
        path: 'teams/:teamid',
        component: RulesetComponent,
      }  
    ]
  },  
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MaintenanceRoutingModule { }
