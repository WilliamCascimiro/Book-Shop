import { Component } from '@angular/core';
import { AuthorService } from '../../../services/author.service';
import { Author } from '../../../models/author';
import { Router } from '@angular/router';

@Component({
  selector: 'app-list-author',
  templateUrl: './list-author.component.html',
  styleUrl: './list-author.component.css'
})
export class ListAuthorComponent {
  authors: Author[] = [];

  constructor(private authorService: AuthorService, private router: Router) {}

  ngOnInit(): void {
    this.loadAuthors();
  }

  loadAuthors(): void {
    this.authorService.getAuthors().subscribe(
      (data: Author[]) => {
        this.authors = data;
      },
      error => {
        console.error('Erro ao carregar autores', error);
      }
    );
  }

 
  editAuthor(authorId: string): void {
    this.router.navigate(['/edit-author', authorId]);
  }

  detailsAuthor(authorId: string): void {
    this.router.navigate(['/detail-author', authorId]);
  }

deleteAuthor(authorId: string): void {
  this.authorService.deleteAuthor(authorId).subscribe(
    () => {
      // Atualiza a lista de autores após deletar
      this.authors = this.authors.filter(author => author.id !== authorId);
      console.log('Autor excluído com sucesso');
    },
    error => {
      console.error('Erro ao excluir autor', error);
    }
  );
}

}
