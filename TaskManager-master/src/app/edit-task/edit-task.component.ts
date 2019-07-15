import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { TaskManager } from '../class/task-manager';
import { TaskManagerApiService } from '../service/task-manager-api.service';
import { FormBuilder, FormGroup, Validators} from "@angular/forms";
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-edit-task',
  templateUrl: './edit-task.component.html',
  styles: []
})
export class EditTaskComponent implements OnInit {

  taskId:string;
  fromTaskManager: any;
  constructor(private formbulider: FormBuilder,private route: ActivatedRoute,private router: Router,private TaskManagerSrtviceApi:TaskManagerApiService) { 
    this.route.queryParams.subscribe(params => {
      this.taskId = params['id'];
  });
  }

  ngOnInit() {
    this.fromTaskManager = this.formbulider.group({
      End_Date: ['', [Validators.required]],
      Start_Date: ['', [Validators.required]],
      Parent_Id: ['', [Validators.required]],
      Priority: ['', [Validators.required]],
      Task_Id: ['', [Validators.required]],
      Task_Name: ['', [Validators.required]]
    });

    this.GetTaskById(this.taskId);
  }

  Reset() {
    this.fromTaskManager.reset();
    this.GetTaskById(this.taskId);
  }

  GetTaskById(id:string){
    this.TaskManagerSrtviceApi.getTaskById(id).subscribe(Response => {
        this.taskId = Response.Task_Id;
        console.info(id + Response.End_Date);
        this.fromTaskManager.controls['End_Date'].setValue(Response.End_Date);
        this.fromTaskManager.controls['Start_Date'].setValue(Response.Start_Date);
        this.fromTaskManager.controls['Parent_Id'].setValue(Response.Parent_Id);
        this.fromTaskManager.controls['Priority'].setValue(Response.Priority);
        this.fromTaskManager.controls['Task_Name'].setValue(Response.Task_Name);
        this.fromTaskManager.controls['Task_Id'].setValue(Response.Task_Id);
    });
  }

  EditTask(TaskManager:TaskManager){
    console.info("Hi"+this.fromTaskManager.value.id +" "+ this.fromTaskManager)
    this.TaskManagerSrtviceApi.editTask(TaskManager).subscribe(()=>{
      this.router.navigateByUrl('/viewTask/');
    });
  }

}
