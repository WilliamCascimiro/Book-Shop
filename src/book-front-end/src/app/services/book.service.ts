import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Author } from '../models/author';
import { Book } from '../models/book';
import { BookDetails } from '../models/book/book-details';
import { UpdateBookRequest } from '../models/book/update-book-request';
 

@Injectable({
  providedIn: 'root'
})
export class BookService {
  private apiUrl = 'https://localhost:44398/book';

  constructor(private http: HttpClient) { }

  getBooks(): Observable<Book[]> {
    return this.http.get<Book[]>(this.apiUrl);
  }

  geBookById(id: string): Observable<BookDetails> {
    return this.http.get<BookDetails>(`${this.apiUrl}/${id}`);
  }

  deleteBook(authorId: string): Observable<void> {
    const url = `${this.apiUrl}/${authorId}`;
    return this.http.delete<void>(url);
  }
  
  updateBook(id: string, book: UpdateBookRequest): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, book);
  }
}
