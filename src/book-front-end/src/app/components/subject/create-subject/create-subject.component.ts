
import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { SubjectService } from '../../../services/subject.service';
import { CreateSubjectRequest } from '../../../models/create-subject-request';



@Component({
  selector: 'app-create-subject',
  templateUrl: './create-subject.component.html',
  styleUrl: './create-subject.component.css'
})
export class CreateSubjectComponent {
  description: string = '';

  constructor(private http: HttpClient, private subjectService: SubjectService) {}

  onSubmit() {

    const createSubjectRequest: CreateSubjectRequest = {
      description: this.description,
    };

    this.http.post('https://localhost:44398/subject', createSubjectRequest)
    .subscribe(
      response => {
        console.log('Assunto criado com sucesso!', response);
        // Redirecionar ou mostrar mensagem de sucesso
      },
      error => {
        console.error('Erro ao criar assunto', error);
        // Mostrar mensagem de erro
      }
    );
    
  }
}