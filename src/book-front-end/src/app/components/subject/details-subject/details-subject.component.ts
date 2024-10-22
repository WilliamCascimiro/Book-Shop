import { Component } from '@angular/core';

import { SubjectService } from '../../../services/subject.service';
import { ActivatedRoute } from '@angular/router';
import { Subject } from '../../../models/subject';

@Component({
  selector: 'app-details-subject',
  templateUrl: './details-subject.component.html',
  styleUrl: './details-subject.component.css'
})
export class DetailsSubjectComponent {
  subject: Subject | null = null;
  bookId: string = '';

  constructor(private subjectService: SubjectService, private route: ActivatedRoute) {}

  ngOnInit(): void {
    // Obtém o ID da rota
    this.bookId = this.route.snapshot.paramMap.get('id')!;
    this.getBookById(this.bookId);
  }

  getBookById(id: string): void {
    this.subjectService.geSubjectById(id).subscribe(
      (data: Subject) => {
        this.subject = data;
      },
      (error) => {
        console.error('Error fetching book:', error);
      }
    );
  }
}
