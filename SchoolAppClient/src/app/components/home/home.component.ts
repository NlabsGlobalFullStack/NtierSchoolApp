import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { ClassRoomModel } from '../../models/class-room.model';
import { CommonModule } from '@angular/common';
import { StudentModel } from '../../models/student.model';
import { StudentPipe } from "../../pipes/student.pipe";
import { NgxPaginationModule } from 'ngx-pagination';
import { FormsModule } from '@angular/forms';

@Component({
    selector: 'app-home',
    standalone: true,
    templateUrl: './home.component.html',
    styleUrl: './home.component.css',
    imports: [FormsModule, CommonModule, StudentPipe, NgxPaginationModule]
})
export class HomeComponent {
  classRooms: ClassRoomModel[] = [];
  students:StudentModel[] = [];

  selectedRoomId: string = "";
search: string="";

p: number = 1;

constructor(
  private http: HttpClient,
  private auth: AuthService
){
  this.getAllClassRooms();
}

getAllClassRooms(){
  this.http.get("https://localhost:7086/api/ClassRooms/GetAll", {
    headers: {
      "Authorization": "Bearer " + this.auth.token
    }
  }).subscribe({
    next: (res:any)=> {
      this.classRooms = res;

      if(this.classRooms.length > 0){
        this.getAllStudentsByClassRoomId(this.classRooms[0].id);
      }
    },
    error: (err: HttpErrorResponse)=> {
      console.log(err);      
    }
  })
}

getAllStudentsByClassRoomId(roomId: string){
  this.selectedRoomId = roomId;

  this.http.get("https://localhost:7086/api/Students/GetAllByClassRoomId?classRoomId=" + this.selectedRoomId, {
    headers: {
      "Authorization": "Bearer " + this.auth.token
    }
  }).subscribe({
    next: (res:any)=> {
      this.students = res;
    },
    error: (err: HttpErrorResponse)=> {
      console.log(err);      
    }
  })
}
}
