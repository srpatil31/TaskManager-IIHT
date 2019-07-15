import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { TaskManager } from '../class/task-manager';
import { TaskManagerApiService } from '../service/task-manager-api.service';
import { FormBuilder, FormGroup, Validators} from "@angular/forms";
import { Router } from '@angular/router';

@Component({
  selector: 'app-view-task',
  templateUrl: './view-task.component.html',
  styles: []
})
export class ViewTaskComponent implements OnInit {

  task:String = "";
  parentTask:String = "";
  priorityFrom:String = "";
  priorityTo:String = "";
  dateFrom:String = "";
  dateTo:String = "";
  fromTaskManager: any;
  allTaskManager:Observable<TaskManager[]>;
  constructor(private formbulider: FormBuilder,private router: Router,private TaskManagerSrtviceApi:TaskManagerApiService) {   
  }

  ngOnInit(): void {
  this.GetAllTaskManager();
  }
  
  GetAllTaskManager( ){
    this.allTaskManager = this.TaskManagerSrtviceApi.getAllTask();
  }

  FilterTaskManager(){
    this.allTaskManager = this.TaskManagerSrtviceApi.filterTaskById(this.task,this.parentTask,this.priorityFrom,this.priorityTo,this.dateFrom,this.dateTo);
  }

  DeleteTask(id:String){
    if(confirm("Are You Sure To delete this task?"))
    {
      this.TaskManagerSrtviceApi.deleteTask(id).subscribe(()=>{
        this.GetAllTaskManager();
      });
    }
  }

  goToPage(parameter:string) {
    this.router.navigateByUrl('/editTask?id='+parameter);
  }
}
