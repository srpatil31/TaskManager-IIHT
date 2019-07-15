import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { TaskManager } from '../class/task-manager';
import { TaskManagerApiService } from '../service/task-manager-api.service';
import { FormBuilder, FormGroup, Validators} from "@angular/forms";
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-task',
  templateUrl: './add-task.component.html',
  styleUrls: []
})

export class AddTaskComponent implements OnInit {

  fromTaskManager: any;
  allTaskManager:Observable<TaskManager[]>;
  constructor(private formbulider: FormBuilder,private router: Router,private TaskManagerSrtviceApi:TaskManagerApiService) { }

  ngOnInit() {
    this.fromTaskManager = this.formbulider.group({
      End_Date: ['', [Validators.required]],
      Start_Date: ['', [Validators.required]],
      Parent_Id: ['', [Validators.required]],
      Priority: ['', [Validators.required]],
      Task_Id: ['', [Validators.required]],
      Task_Name: ['', [Validators.required]]
    });
  }

  Reset() {
    this.fromTaskManager.reset();
  }

  AddTask(TaskManager:TaskManager){
    this.TaskManagerSrtviceApi.createTask(TaskManager).subscribe(()=>{
      this.router.navigateByUrl('/viewTask/');
    });
  }

  goToPage() {
    this.router.navigateByUrl('/viewTask/');
  }

}
