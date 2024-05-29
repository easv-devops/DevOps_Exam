import { Component, OnInit } from '@angular/core';
import { AppServiceService } from './app-service.service';
import { response } from 'express';
import { error } from 'console';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit{
  title = 'client';

  allTasks: any[] = [];
  taskName: string = '';
  taskDescription: string = '';
  taskModel : any;
  constructor(private appService: AppServiceService){}


  ngOnInit(): void {
    this.getAllTasks();
  }

  createNewTask() {
    this.appService.createNewTask(this.taskName, this.taskDescription).subscribe(
      (response : any) => {
        this.taskModel = response.responseData;
        console.log('Here is the created task:', this.taskModel);
        this.getAllTasks();
      },
      (error) => {
        console.error('Error creating new task:', error);
      }
    );
  }

  deleteTask(taskId: number) {
    this.appService.deleteTask(taskId).subscribe(
      (response: any) => {
        console.log('Task deleted successfully:', response);
        this.getAllTasks();
      },
      (error: any) => {
        console.error('Error deleting task:', error);
      }
    );
  }
  

  getAllTasks() {
    this.appService.getAllTask().subscribe(
      (response: any) => {
        this.allTasks = response.responseData;
        console.log('Here are all the tasks: ', this.allTasks)
      },
      (error: any) => {
        console.error('Error with getting all the tasks:', error)
      }
    );
  }


}
