import { Component } from '@angular/core';
import { Book } from '../../../models/book';
import { BookService } from '../../../services/book.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-list-book',
  templateUrl: './list-book.component.html',
  styleUrl: './list-book.component.css'
})
export class ListBookComponent {
  books: Book[] = [];

  constructor(private bookService: BookService, private router: Router) {}

  ngOnInit(): void {
    this.loadBooks();
  }

  loadBooks(): void {
    this.bookService.getBooks().subscribe(
      (data: Book[]) => {
        this.books = data;
      },
      error => {
        console.error('Erro ao carregar autores', error);
      }
    );
  }

 editBook(bookId: string): void {
  this.router.navigate(['/edit-book', bookId]);
}

detailsBook(bookId: string): void {
  this.router.navigate(['/detail-book', bookId]);
}



deleteBook(bookId: string): void {
  this.bookService.deleteBook(bookId).subscribe(
    () => {
      // Atualiza a lista de autores após deletar
      this.books = this.books.filter(book => book.id !== bookId);
      console.log('Autor excluído com sucesso');
    },
    error => {
      console.error('Erro ao excluir autor', error);
    }
  );
}
}
