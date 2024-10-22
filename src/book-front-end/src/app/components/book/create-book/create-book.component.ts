// create-book/create-book.component.ts
import { Component, OnInit } from '@angular/core';
import { Author } from '../../../models/author';
import { Subject } from '../../../models/subject';
import { CreateBookRequest } from '../../../models/create-book-request';
import { HttpClient } from '@angular/common/http';
import { BookService } from '../../../services/book.service';
import { AuthorService } from '../../../services/author.service';
import { SubjectService } from '../../../services/subject.service';
import { Router } from '@angular/router';



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

  constructor(private http: HttpClient, private bookService: BookService, private authorService: AuthorService, private subjectService: SubjectService, private router: Router) {}

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

    this.bookService.createBook(createBookRequest).subscribe(
      (response) => {
        console.log('Assunto atualizado com sucesso:', response);
        this.router.navigate(['/list-book']);
      },
      (error) => {
        console.error('Erro ao atualizar o assunto:', error);
      }
    );    
  }
}