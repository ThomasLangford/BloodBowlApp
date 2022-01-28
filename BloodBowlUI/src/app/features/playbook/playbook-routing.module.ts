import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from '../home/home.component';

import { PlaybookComponent } from './playbook.component';
import { RulesetComponent } from './pages/ruleset/ruleset.component';
import { RulesetpickerComponent } from './pages/ruleset-picker/ruleset-picker.component';
import { RulesetlandingComponent } from './pages/ruleset-landing/ruleset-landing.component';
import { SkillsComponent } from './pages/skills/skills.component';
import { TeamsComponent } from './pages/teams/teams.component';
import { TeamComponent } from './pages/team/team.component';

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
        path: '',
        component: RulesetlandingComponent
      },
      {
        path: 'skills',
        component: SkillsComponent,
      },
      {
        path: 'teams',
        component: TeamsComponent,
        // children: [     
        //   {
        //     path: ':teamId',
        //     component: TeamComponent,
        //   } 
        // ]
      },
      {
        path: 'teams/add',
        component: TeamComponent,
      },  
      {
        path: 'teams/:teamId',
        component: TeamComponent,
      }, 
    ]
  },  
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PlaybookRoutingModule { }
