import { Component, OnInit } from '@angular/core';
import { BookService } from '../../../services/book.service';
import { ActivatedRoute } from '@angular/router';
import { Book } from '../../../models/book';
import { BookDetails } from '../../../models/book/book-details';

@Component({
  selector: 'app-details-book',
  templateUrl: './details-book.component.html',
  styleUrl: './details-book.component.css'
})
export class DetailsBookComponent implements OnInit {
  bookDetails: BookDetails | null = null;
  bookId: string = '';

  constructor(private bookService: BookService, private route: ActivatedRoute) {}

  ngOnInit(): void {
    // Obtém o ID da rota
    this.bookId = this.route.snapshot.paramMap.get('id')!;
    this.getBookById(this.bookId);
  }

  getBookById(id: string): void {
    this.bookService.geBookById(id).subscribe(
      (data: BookDetails) => {
        this.bookDetails = data;
      },
      (error) => {
        console.error('Error fetching book:', error);
      }
    );
  }
}
