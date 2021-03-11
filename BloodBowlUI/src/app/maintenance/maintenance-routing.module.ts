import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MaintenanceComponent } from './maintenance.component';
import { SkillFormComponent } from './skill-form/skill-form.component'

const routes: Routes = [
  { 
    path: '',
    component: MaintenanceComponent,
    children: [
      {
        path: 'skill', // child route path
        component: SkillFormComponent, // child route component that the router renders
      },
      
    ]
  
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MaintenanceRoutingModule { }
