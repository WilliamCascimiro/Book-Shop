// create-book/create-book.component.ts
import { Component, OnInit } from '@angular/core';
import { Author } from '../../../models/author';
import { Subject } from '../../../models/subject';
import { CreateBookRequest } from '../../../models/create-book-request';
import { HttpClient } from '@angular/common/http';
import { BookService } from '../../../services/book.service';
import { AuthorService } from '../../../services/author.service';
import { SubjectService } from '../../../services/subject.service';



@Component({
  selector: 'app-create-book',
  templateUrl: './create-book.component.html',
  styleUrls: ['./create-book.component.css']
})
export class CreateBookComponent implements OnInit {
  title: string = '';
  value: number = 0;
  purchaseForm: string = '';
  authorIds: string[] = [];
  subjectIds: string[] = [];

  authors: Author[] = [];

  subjects: Subject[] = [];

  constructor(private http: HttpClient, private authorService: AuthorService, private subjectService: SubjectService) {}

  ngOnInit(): void {
    this.loadAuthors();
    this.loadSubjects();
  }

  loadAuthors(): void {
    this.authorService.getAuthors().subscribe(
      (data: Author[]) => {
        this.authors = data.map(author => ({
          ...author,
          isChecked: false
        }));
      },
      error => {
        console.error('Erro ao carregar autores', error);
      }
    );
  }

  loadSubjects(): void {
    this.subjectService.getSubjects().subscribe(
      (data: Subject[]) => {
        this.subjects = data.map(author => ({
          ...author,
          isChecked: false
        }));
      },
      error => {
        console.error('Erro ao carregar autores', error);
      }
    );
  }

  onAuthorChange(author: Author) {
    author.isChecked = !author.isChecked; // Alterna o estado do checkbox
    if (author.isChecked) {
      this.authorIds.push(author.id); // Adiciona o ID se marcado
    } else {
      this.authorIds = this.authorIds.filter(id => id !== author.id); // Remove se desmarcado
    }
  }

  onSubjectChange(subject: Subject) {
    subject.isChecked = !subject.isChecked; // Alterna o estado do checkbox
    if (subject.isChecked) {
      this.subjectIds.push(subject.id); // Adiciona o ID se marcado
    } else {
      this.subjectIds = this.subjectIds.filter(id => id !== subject.id); // Remove se desmarcado
    }
  }

  onSubmit() {
    const createBookRequest: CreateBookRequest = {
      title: this.title,
      value: this.value,
      purchaseForm: this.purchaseForm,
      authorIds: this.authorIds,
      subjectIds: this.subjectIds
    };

    console.log(createBookRequest);

    this.http.post('https://localhost:44398/book', createBookRequest)
    .subscribe(
      response => {
        console.log('Livro criado com sucesso!', response);
        // Redirecionar ou mostrar mensagem de sucesso
      },
      error => {
        console.error('Erro ao criar livro', error);
        // Mostrar mensagem de erro
      }
    );
    
  }
}