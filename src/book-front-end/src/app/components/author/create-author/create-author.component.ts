import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { AuthorService } from '../../../services/author.service';
import { CreateAuthorRequest } from '../../../models/create-author-request';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-author',
  templateUrl: './create-author.component.html',
  styleUrl: './create-author.component.css'
})
export class CreateAuthorComponent {
  name: string = '';

  constructor(private http: HttpClient, private authorService: AuthorService
    ,private router: Router
  ) {}

  onSubmit() {

    const createAuthorComponent: CreateAuthorRequest = {
      name: this.name,
    };

    this.authorService.createAuthor(createAuthorComponent).subscribe(
      (response) => {
        console.log('Assunto atualizado com sucesso:', response);
        this.router.navigate(['/list-author']);
      },
      (error) => {
        console.error('Erro ao atualizar o assunto:', error);
      }
    );
    
  }
}
