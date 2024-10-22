import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Author } from '../models/author';
import { CreateAuthorRequest } from '../models/create-author-request';
 

@Injectable({
  providedIn: 'root'
})
export class AuthorService {
  private apiUrl = 'https://localhost:44398/author';

  constructor(private http: HttpClient) { }

  createAuthor(createAuthorComponent: CreateAuthorRequest): Observable<any> {
    return this.http.post<Author[]>(this.apiUrl, createAuthorComponent);
  }

  getAuthors(): Observable<Author[]> {
    return this.http.get<Author[]>(this.apiUrl);
  }

  geAuthorById(id: string): Observable<Author> {
    return this.http.get<Author>(`${this.apiUrl}/${id}`);
  }

  deleteAuthor(authorId: string): Observable<void> {
    const url = `${this.apiUrl}/${authorId}`;
    return this.http.delete<void>(url);
  }

  updateAuthor(id: string, subject: Author): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, subject);
  }
  

}
