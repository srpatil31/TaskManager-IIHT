import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {HttpHeaders} from '@angular/common/http';
import { Observable } from 'rxjs';
import { TaskManager } from '../class/task-manager';

@Injectable({
  providedIn: 'root'
})

export class TaskManagerApiService {

  Url = 'http://localhost:50960//api';

  constructor(private http:HttpClient) { }

  getAllTask():Observable<TaskManager[]> {
    return this.http.get<TaskManager[]>(this.Url + '/TaskManager');
  }

  getTaskById(id:String):Observable<TaskManager> {
    return this.http.get<TaskManager>(this.Url + '/TaskManager/GetTaskById/?Id=' + id);
  }

  filterTaskById(task:String,parentTask:String,priorityFrom:String,priorityTo:String,dateFrom:String,dateTo:String):Observable<TaskManager[]> {
    return this.http.get<TaskManager[]>(this.Url + '/FilterTask/?task=' + task + "&parentTask=" + parentTask + "&priorityFrom"+priorityFrom+"&priorityTo"+priorityTo+"&dateFrom"+dateFrom+"&dateTo"+dateTo);
  }

  createTask(OutletVM:TaskManager):Observable<TaskManager[]> {
   const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.post<TaskManager[]>(this.Url + '/TaskManager/AddTask', OutletVM, httpOptions)
  }

  editTask(OutletVM:TaskManager):Observable<TaskManager[]> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
     return this.http.put<TaskManager[]>(this.Url + '/TaskManager/EditTask', OutletVM, httpOptions)
   }

  deleteTask(id:String):Observable<String> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.delete<String>(this.Url + '/TaskManager/DeleteTask/?Id=' + id);
   }
}
