import { Component, Inject } from '@angular/core';
import { TaskModel } from '../../model/task-model';
import { TaskService } from '../../service/task-service';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';


@Component({
  selector: 'app-task-list',
  templateUrl: './task-list.component.html',
  styleUrl: './task-list.component.css'
})
export class TaskListComponent {

  taskList: TaskModel[] = [];
  form: FormGroup;
  isUpdate =false;
  constructor(private taskService: TaskService, private router: Router, private fb: FormBuilder) {
    this.form = this.fb.group({
      id:[],
      title: ['', Validators.required],
      description: [''],
      dueDate: [],
      isCompleted: [false],
      userId: [],

    });
}


  ngOnInit(): void {
    this.loadTasks();
  }

  loadTasks(): void {
    this.taskService.getTasks().pipe().subscribe((data) => {
      this.taskList = data;
    });
  }

  deleteTask(id: number): void {
    this.taskService.deleteTask(id).subscribe(() => {
      this.loadTasks();
    });
  }


  showModal(task?: TaskModel) {
    if (task) {
      this.isUpdate = true;
      this.form.controls["id"].setValue(task.id)
      this.form.controls["title"].setValue(task.title);
      this.form.controls["description"].setValue(task.description);
      this.form.controls["dueDate"].setValue(task.dueDate);
      this.form.controls["isCompleted"].setValue(task.isCompleted);
      this.form.controls["userId"].setValue(task.userId);

    }
    else {
      this.form.controls["id"].setValue('')
      this.form.controls["title"].setValue('');
      this.form.controls["description"].setValue('');
      this.form.controls["dueDate"].setValue('');
      this.form.controls["isCompleted"].setValue('');
      this.form.controls["userId"].setValue('');
    }
  }
  OnSubmit(): void {
    if (this.form.valid) {
      if (!this.isUpdate) {
        this.taskService.createTask(this.form.value).subscribe(() => {
          this.loadTasks();

        });
      } else {
        this.taskService.updateTask(this.form.value).subscribe(() => {
          this.loadTasks();

        });
      }

    }

  }

}
