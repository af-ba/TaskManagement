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
  selectedTask: TaskModel = new TaskModel();
  constructor(private taskService: TaskService, private router: Router, private fb: FormBuilder) {
    this.form = this.fb.group({
      title: ['', Validators.required],
      description: [''],
      dueDate: [],
      isCompleted: [false],

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

  deleteTask(id: string): void {
    this.taskService.deleteTask(id).subscribe(() => {
      this.loadTasks();
    });
  }


  showModal(task?: TaskModel) {
    if (task) {
      this.selectedTask = task;
      this.form.controls["title"].setValue(task.title);
      this.form.controls["description"].setValue(task.description);
      this.form.controls["dueDate"].setValue(task.dueDate);
      this.form.controls["isCompleted"].setValue(task.isCompleted);

    }
    else {
      this.form.controls["title"].setValue('');
      this.form.controls["description"].setValue('');
      this.form.controls["dueDate"].setValue('');
      this.form.controls["isCompleted"].setValue(false);
    }
  }
  OnSubmit(): void {
    this.form.updateValueAndValidity();
    if (this.form.valid) {
      if (this.selectedTask.id == '') {
        this.taskService.createTask(this.form.value).pipe().subscribe(()=> {
          this.loadTasks();

        });
      } else {
        this.taskService.updateTask(this.selectedTask.id, this.form.value).pipe().subscribe(() => {
          this.loadTasks();

        });
      }
      document.getElementById("closeModal")?.click();
      this.form.reset();
      this.form.clearValidators();

    }
  }

}
