import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Subject } from '../models/subject';
 

@Injectable({
  providedIn: 'root'
})
export class SubjectService {
  private apiUrl = 'https://localhost:44398/subject';

  constructor(private http: HttpClient) { }

  getSubjects(): Observable<Subject[]> {
    return this.http.get<Subject[]>(this.apiUrl);
  }

  geSubjectById(id: string): Observable<Subject> {
    return this.http.get<Subject>(`${this.apiUrl}/${id}`);
  }

  deleteSubject(authorId: string): Observable<void> {
    const url = `${this.apiUrl}/${authorId}`;
    return this.http.delete<void>(url);
  }

  updateSubject(id: string, subject: Subject): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, subject);
  }


}