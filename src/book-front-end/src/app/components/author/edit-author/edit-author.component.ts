import { Component, OnInit } from '@angular/core';
import { Author } from '../../../models/author';
import { AuthorService } from '../../../services/author.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-edit-author',
  templateUrl: './edit-author.component.html',
  styleUrl: './edit-author.component.css'
})
export class EditAuthorComponent implements OnInit {
  subject: Author | null = null;
  subjectId: string = '';

  constructor(
    private authorService: AuthorService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.subjectId = this.route.snapshot.paramMap.get('id')!;
    this.getSubjectById(this.subjectId);
  }

  getSubjectById(id: string): void {
    this.authorService.geAuthorById(id).subscribe(
      (data: Author) => {
        this.subject = data;
      },
      (error) => {
        console.error('Erro ao carregar o assunto:', error);
      }
    );
  }

  updateSubject(): void {
    if (this.subject) {
      this.authorService.updateAuthor(this.subjectId, this.subject).subscribe(
        (response) => {
          console.log('Assunto atualizado com sucesso:', response);
          this.router.navigate(['/list-author']); // Redireciona para a lista de assuntos após salvar
        },
        (error) => {
          console.error('Erro ao atualizar o assunto:', error);
        }
      );
    }
  }
}