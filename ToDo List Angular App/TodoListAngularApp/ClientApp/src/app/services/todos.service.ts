
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

import { catchError } from 'rxjs/operators';
import { throwError as observableThrowError } from 'rxjs';

import { Todo } from '../model/Todo';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class ToDoService {

  lastId: number = 0;
  workTodo: string = '';
  todos: Todo[] = [];

  private readonly todosEndpoint:string = "/api/ToDoList/";

  constructor(private http:HttpClient) { 
     this.todos = this.getTodos();
  }

  private errorHandler(error: HttpErrorResponse) {
    return observableThrowError(error.message || 'Something went wrong!');
  }
 
  // Get Todo List
  public getTodos() : Todo[] {
		 
      this.http.get<Todo[]>(this.todosEndpoint + 'GetTodos')
      .pipe(catchError(this.errorHandler))
      .subscribe((response: any) => {
          this.todos = response;
      });
      return this.todos;
  }

  // Add A Todo
  public addTodo(workTodo:string): void  {  

      if(workTodo.trim() === "" && workTodo.trim().length === 0) {
        return;
      }
 
      const payload = {
        workTodo: workTodo,
        isCompleted: false
      };
 
      this.http.post(this.todosEndpoint+"AddTodo", payload, httpOptions).subscribe((response :any) => {
         
          this.todos.push({
              id: response,
              workTodo: workTodo,
              isCompleted: false,
          });
      
        });
  }

  // Update A Todo
  public updateTodo(id: number, todo: any): void  {  

    if(id <= 0 && todo.workTodo.trim() === "" && todo.workTodo.trim().length === 0) {
      return;
    }

    const payload = {
      workTodo: todo.workTodo,
      isCompleted: todo.isCompleted
    };

    this.http.put(this.todosEndpoint+"UpdateTodo/"+id, payload, httpOptions).subscribe((response :any) => {
       
       console.log(response);
      
      const index = this.todos.findIndex((e) => e.id === id);
 
      this.todos[index].workTodo = payload.workTodo;
   
      });
  }
 
  // Delete A Todo
  deleteTodo(todo: Todo, index): Promise<Object>  { 
    if(todo.id != 0)
    {
        this.todos.splice(index, 1);

        return new Promise((resolve) => {
          this.http.delete(this.todosEndpoint+"DeleteTodo/"+todo.id, httpOptions).subscribe(response => {

             resolve();
          });
      });

    } 
     
  }

  // Mark Todo As Completed
  markAsCompleted(todo: Todo, evnt): Promise<Object> {
 
    console.log(todo.id +" " + evnt);

    const payload = {
      IsCompleted: evnt
    };

    return new Promise((resolve) => {
        this.http.put(this.todosEndpoint+"MarkCompleted/"+todo.id+"/"+evnt, payload, httpOptions).subscribe(response => {
			  	 resolve();
        });
    });

  }

}
