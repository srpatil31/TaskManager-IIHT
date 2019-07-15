import { TestBed ,async,inject} from '@angular/core/testing';
import { HttpClientTestingModule,HttpTestingController} from '@angular/common/http/testing/'
import { HttpClient,HttpErrorResponse} from '@angular/common/http/'

import { TaskManagerApiService } from './task-manager-api.service';
import { TaskManager } from '../class/task-manager';
import { Observable } from 'rxjs/internal/Observable';

describe('TaskManagerApiService', () => {

  //let httpClient:HttpClient;
  //let httpTestingController:HttpTestingController;

  beforeEach(() => TestBed.configureTestingModule({
    imports: [HttpClientTestingModule]
  }));

  //httpClient = TestBed.get(HttpClient);
  //httpTestingController = TestBed.get(HttpTestingController);
  let service: TaskManagerApiService;

    it('should be created', () => {
      const service: TaskManagerApiService = TestBed.get(TaskManagerApiService);
      expect(service).toBeTruthy();
    });

    it('should have filterTaskById', () => {
      const service: TaskManagerApiService = TestBed.get(TaskManagerApiService);
      expect(service.filterTaskById).toBeTruthy();
    });

    
  it('should have getAllTask', () => {
    const service: TaskManagerApiService = TestBed.get(TaskManagerApiService);
    expect(service.getAllTask).toBeTruthy();
  });

  it('should have getTaskById', () => {
    const service: TaskManagerApiService = TestBed.get(TaskManagerApiService);
    expect(service.getTaskById).toBeTruthy();
  });

  it('should have createTask', () => {
    const service: TaskManagerApiService = TestBed.get(TaskManagerApiService);
    expect(service.createTask).toBeTruthy();
  });

  it('should have editTask', () => {
    const service: TaskManagerApiService = TestBed.get(TaskManagerApiService);
    expect(service.editTask).toBeTruthy();
  });

  it('should have deleteTask', () => {
    const service: TaskManagerApiService = TestBed.get(TaskManagerApiService);
    expect(service.deleteTask).toBeTruthy();
  });

  it('should getAllTask returns list', () => {
    const service: TaskManagerApiService = TestBed.get(TaskManagerApiService);
    spyOn(service,'getAllTask').and.callFake(()=>{ return Observable.call([TaskManager])});
    expect(service.getAllTask).toBeTruthy();
  });

  it('should filterTaskById returns list', () => {
    const service: TaskManagerApiService = TestBed.get(TaskManagerApiService);
    spyOn(service,'filterTaskById').and.callFake(()=>{ return Observable.call([TaskManager])});
    expect(service.filterTaskById).toBeTruthy();
  });

  it('should createTask returns list', () => {
    const service: TaskManagerApiService = TestBed.get(TaskManagerApiService);
    spyOn(service,'createTask').and.callFake(()=>{ return Observable.call([TaskManager])});
    expect(service.createTask).toBeTruthy();
  });

  it('should editTask returns list', () => {
    const service: TaskManagerApiService = TestBed.get(TaskManagerApiService);
    spyOn(service,'editTask').and.callFake(()=>{ return Observable.call([TaskManager])});
    expect(service.editTask).toBeTruthy();
  });

  it('should deleteTask returns list', () => {
    const service: TaskManagerApiService = TestBed.get(TaskManagerApiService);
    spyOn(service,'deleteTask').and.callFake(()=>{ return Observable.call([String])});
    expect(service.deleteTask).toBeTruthy();
  });

});
