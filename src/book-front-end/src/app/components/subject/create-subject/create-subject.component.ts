
import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { SubjectService } from '../../../services/subject.service';
import { CreateSubjectRequest } from '../../../models/create-subject-request';
import { Router } from '@angular/router';



@Component({
  selector: 'app-create-subject',
  templateUrl: './create-subject.component.html',
  styleUrl: './create-subject.component.css'
})
export class CreateSubjectComponent {
  description: string = '';

  constructor(private http: HttpClient, private subjectService: SubjectService, private router: Router) {}

  onSubmit() {

    const createSubjectRequest: CreateSubjectRequest = {
      description: this.description,
    };

    this.subjectService.createSubject(createSubjectRequest).subscribe(
      (response) => {
        console.log('Assunto atualizado com sucesso:', response);
        this.router.navigate(['/list-subject']);
      },
      (error) => {
        console.error('Erro ao criar o assunto:', error);
      }
    );
    
  }
}