import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { firstValueFrom } from 'rxjs';
import { environment } from '../config';

@Component({
  selector: 'app-root',
  templateUrl: './todo.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'todoapp';
  readonly APIUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  todoList: any = [];
  newTodoDescription = '';            
  ngOnInit() {
    this.refreshTodoList();
  }

  refreshTodoList() {
    this.http.get<any[]>(this.APIUrl + 'GetTodoItems')              //Calling getTodoItems endpoint 
      .subscribe({
        next: (data) => {
          this.todoList = data;
        },
        error: (error) => {
          console.error('Failed to fetch todo list:', error);
        }
      });
  }

  async addTodoItem() {
    if (this.newTodoDescription.trim() === '') {
      alert('Description cannot be empty');
      return;
    }
    const body = { description: this.newTodoDescription };
    try {
      const response = await firstValueFrom(this.http.post(this.APIUrl + 'AddTodoItem', body, { responseType: 'text' })); //Calling AddTodoItem endpoint 
      this.refreshTodoList(); // Refresh the todo list
      this.newTodoDescription = '';
    } catch (error) {
      console.error('Failed to add todo item:', error);
    }
  }

  
  confirmDelete(id: number) {
    if (confirm('Are you sure you want to delete this item?')) {
      this.deleteTodoItem(id);
    }
  }

  async deleteTodoItem(id: number) {
    try {
      const response = await firstValueFrom(this.http.delete(this.APIUrl + 'DeleteTodoItem?id=' + id, { responseType: 'text' }));   //Calling DeleteTodoItem endpoint 
      this.refreshTodoList(); // Refresh the todo list
    } catch (error) {
      console.error('Failed to delete todo item:', error);
    }
  }
}
