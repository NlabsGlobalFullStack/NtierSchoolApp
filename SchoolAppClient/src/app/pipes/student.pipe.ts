import { Pipe, PipeTransform } from '@angular/core';
import { StudentModel } from '../models/student.model';

@Pipe({
  name: 'student',
  standalone: true
})
export class StudentPipe implements PipeTransform {

  transform(value: StudentModel[],filter: string): StudentModel[] {
    if(filter === "")
      return value;

    const result = value.filter(p=> 
      p.firstName.toLocaleLowerCase().includes(filter.toLocaleLowerCase()) ||
      p.lastName.toLocaleLowerCase().includes(filter.toLocaleLowerCase()) ||
      p.fullName.toLocaleLowerCase().includes(filter.toLocaleLowerCase()));
     
    return result;
  }

}
