import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ViewTaskComponent } from './view-task/view-task.component';
import { AddTaskComponent } from './add-task/add-task.component';
import { EditTaskComponent } from './edit-task/edit-task.component';

const routes: Routes = [
  {path:'viewTask',component: ViewTaskComponent},
  {path:'addTask',component: AddTaskComponent},
  {path:'editTask',component:EditTaskComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
export const routingComponents = [ViewTaskComponent,AddTaskComponent,EditTaskComponent]
