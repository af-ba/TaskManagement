import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TaskModel } from '../model/task-model';

@Injectable({
  providedIn: 'root'
})
export class TaskService {
  private apiUrl = 'https://localhost:7228/TaskManagement';

  constructor(private http: HttpClient) { }

  getTasks(): Observable<TaskModel[]> {
    return this.http.get<TaskModel[]>(this.apiUrl);
  }

  getTask(id: string): Observable<TaskModel> {
    return this.http.get<TaskModel>(`${this.apiUrl}/${id}`);
  }

  createTask(task: TaskModel): Observable<TaskModel[]> {
    return this.http.post<TaskModel[]>(this.apiUrl, task);
  }

  updateTask(id:string, task: TaskModel): Observable<TaskModel[]> {
    return this.http.put<TaskModel[]>(`${this.apiUrl}/${id}`, task);
  }

  deleteTask(id: string): Observable<TaskModel[]> {
    return this.http.delete<TaskModel[]>(`${this.apiUrl}/${id}`);
  }
}
