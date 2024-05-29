import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, throwError } from 'rxjs';
import { error } from 'console';
import { TaskModel } from './TaskModel';
import { env } from 'process';
import { environment } from '../environments/environment.prod';

@Injectable({
  providedIn: 'root'
})
export class AppServiceService {
  baseURL: string;

  constructor(private http: HttpClient) {
    this.baseURL = environment.apiUrl
  }

  createNewTask(taskName: string, taskDescription: string){
    return this.http.post<TaskModel>(this.baseURL + 'createTask', {
      id: 0,
      dateCreated: null,
      taskName: taskName,
      taskDescription: taskDescription,
      taskStatus: false
    });
  }

  getAllTask(): Observable<any[]>{
    return this.http.get<any[]>(this.baseURL + 'tasks').pipe(
      catchError((error: any) => {
        console.error('An error occurred: ', error);
        return throwError(error);
      })
    );
  }

  deleteTask(taskId: number){
    return this.http.delete(this.baseURL + 'deleteTask/' + taskId);
  }
}
