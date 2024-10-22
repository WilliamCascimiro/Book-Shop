import { Component, OnInit } from '@angular/core';
import { BookService } from '../../../services/book.service';
import { AuthorService } from '../../../services/author.service';
import { SubjectService } from '../../../services/subject.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Author } from '../../../models/author';
import { Subject } from '../../../models/subject';
import { BookDetails } from '../../../models/book/book-details';
import { UpdateBookRequest } from '../../../models/book/update-book-request';

@Component({
  selector: 'app-edit-book',
  templateUrl: './edit-book.component.html',
  styleUrl: './edit-book.component.css'
})
export class EditBookComponent implements OnInit {
  bookDetails: BookDetails | null = null;
  bookId: string = '';
  allAuthors: Author[] = [];
  allSubjects: Subject[] = [];
  isSubmitting: boolean = false;

  constructor(
    private bookService: BookService,
    private authorService: AuthorService,
    private subjectService: SubjectService,
    private activatedRoute: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.bookId = this.activatedRoute.snapshot.paramMap.get('id')!;
    this.getBookById(this.bookId);
    this.loadAllAuthors();
    this.loadAllSubjects();
  }

  getBookById(id: string): void {
    this.bookService.geBookById(id).subscribe(
      (data: BookDetails) => {
        this.bookDetails = data;
        this.updateCheckedAuthors();
        this.updateCheckedSubjects();
      },
      (error) => {
        console.error('Error fetching book:', error);
      }
    );
  }

  loadAllAuthors(): void {
    this.authorService.getAuthors().subscribe(
      (data: Author[]) => {
        this.allAuthors = data;
        this.allAuthors.forEach(author => {
          if(this.bookDetails?.authorDetails.some(s => s.id === author.id)){
            author.isChecked = true;
          }
        });
      },
      (error) => {
        console.error('Error fetching authors:', error);
      }
    );
  }

  loadAllSubjects(): void {
    this.subjectService.getSubjects().subscribe(
      (data: Subject[]) => {
        this.allSubjects = data;
        this.allSubjects.forEach(subject => {
          if(this.bookDetails?.subjectDetails.some(s => s.id === subject.id)){
            subject.isChecked = true;
          }
        });
      },
      (error) => {
        console.error('Error fetching subjects:', error);
      }
    );
  }

  updateCheckedAuthors(): void {
    if (this.bookDetails) {
      this.allAuthors.forEach(author => {
        author.isChecked = this.bookDetails!.authorDetails.some(a => a.id === author.id);
      });
    }
  }

  updateCheckedSubjects(): void {
    if (this.bookDetails) {
      this.allSubjects.forEach(subject => {
        subject.isChecked = this.bookDetails!.subjectDetails.some(s => s.id === subject.id);
      });
    }
  }

  onSubmit(): void {
    if (this.bookDetails) {
      this.isSubmitting = true;
      const updatedBook: UpdateBookRequest = {
        id: this.bookDetails.id,
        title: this.bookDetails.title,
        value: this.bookDetails.value,
        purchaseForm: this.bookDetails.purchaseForm,
        authorUpdateList: this.allAuthors.filter(a => a.isChecked).map(a => a.id),
        subjectUpdateList: this.allSubjects.filter(s => s.isChecked).map(s => s.id),
      };

      this.bookService.updateBook(this.bookId, updatedBook).subscribe(
        () => {
          this.isSubmitting = false;
          this.router.navigate(['/list-book']);
        },
        (error) => {
          console.error('Error updating book:', error);
          this.isSubmitting = false;
        }
      );
    }
  }

}
