export class TaskModel {
  id: string ='';
  title: string ='';
  description: string = '';
  dueDate: Date | undefined;
  isCompleted: boolean = false;
  userId: string = '';
}
