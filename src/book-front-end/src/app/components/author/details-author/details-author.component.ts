import { Component } from '@angular/core';
import { Author } from '../../../models/author';
import { AuthorService } from '../../../services/author.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-details-author',
  templateUrl: './details-author.component.html',
  styleUrl: './details-author.component.css'
})
export class DetailsAuthorComponent {
  author: Author | null = null;
  authorId: string = '';

  constructor(private authorService: AuthorService, private route: ActivatedRoute) {}

  ngOnInit(): void {
    // Obtém o ID da rota
    this.authorId = this.route.snapshot.paramMap.get('id')!;
    this.getAuthorById(this.authorId);
  }

  getAuthorById(id: string): void {
    this.authorService.geAuthorById(id).subscribe(
      (data: Author) => {
        this.author = data;
      },
      (error) => {
        console.error('Error fetching book:', error);
      }
    );
  }
}
