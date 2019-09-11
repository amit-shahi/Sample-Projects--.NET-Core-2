import { Component, OnInit } from '@angular/core';
import { ToDoService } from '../../services/todos.service';
import { Todo } from '../../model/Todo';

@Component({
  selector: 'todo-list-home',
  templateUrl: './todo-list.component.html',
  styleUrls: ['./todo-list.component.css'],
  providers: [ToDoService],
})
export class ToDoListComponent implements OnInit {  
 
  workTodo: string;
  todos: Todo[] = [];
  constructor(public _todoService: ToDoService) {
  }

  inEditMode: boolean = false;
  currentTodoId: number;
  currentTodoStateWorkTodo: string;
  currentTodoStateisCompleted : boolean;

  ngOnInit() {
      
    this.workTodo = '';
     
  }
 
    // Cancel Edit Mode
    cancelEdit() {
      if(this.inEditMode)
      {
        this.inEditMode = false;
        this.workTodo = '';
      }

    }
  
    // Add A ToDo

    addEditTodo(): void {
      
      if(this.workTodo.trim() === "") {  
        document.getElementById('workTodo').focus();
        return;
      }

      if(this.workTodo !== "" && this.inEditMode !== true)
      { 
         this._todoService.addTodo(this.workTodo); 
        
         this.workTodo = '';
      }

      if(this.workTodo !== "" && this.inEditMode === true && this.currentTodoStateWorkTodo !== this.workTodo)
      {
        const payload = {
            workTodo: this.workTodo,
            isCompleted: this.currentTodoStateisCompleted,
        };
 
        this._todoService.updateTodo(this.currentTodoId, payload);

        this.cancelEdit();
        
      }

    }
    
    // Edit A ToDo

    editTodo(todo: any) {

      console.log(todo);

      this.inEditMode = true;
      this.currentTodoId = todo.id;
      this.currentTodoStateWorkTodo = todo.workTodo;
      this.currentTodoStateisCompleted = todo.isCompleted;
      
      this.workTodo = todo.workTodo;
      document.getElementById('workTodo').focus();
    }

    // Delete A ToDo

    deleteTodo(todo:any, index): void {
       console.log(todo);
       console.log(index);
     

      this._todoService.deleteTodo(todo, index);
    }

   // Mark A Todo As Completed

    markAsCompleted(todo: any, e): void {
      // console.log(todo.id +" " + todo.isCompleted);
      if(todo != null)
      {
        this._todoService.markAsCompleted(todo, e.target.checked);
      }
    }

}
