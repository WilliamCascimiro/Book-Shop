import { Component, OnInit } from '@angular/core';
import { Subject } from '../../../models/subject';
import { ActivatedRoute, Router } from '@angular/router';
import { SubjectService } from '../../../services/subject.service';

@Component({
  selector: 'app-edit-subject',
  templateUrl: './edit-subject.component.html',
  styleUrl: './edit-subject.component.css'
})
export class EditSubjectComponent implements OnInit {
  subject: Subject | null = null;
  subjectId: string = '';

  constructor(
    private subjectService: SubjectService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.subjectId = this.route.snapshot.paramMap.get('id')!;
    this.getSubjectById(this.subjectId);
  }

  getSubjectById(id: string): void {
    this.subjectService.geSubjectById(id).subscribe(
      (data: Subject) => {
        this.subject = data;
      },
      (error) => {
        console.error('Erro ao carregar o assunto:', error);
      }
    );
  }

  updateSubject(): void {
    if (this.subject) {
      this.subjectService.updateSubject(this.subjectId, this.subject).subscribe(
        (response) => {
          console.log('Assunto atualizado com sucesso:', response);
          this.router.navigate(['/list-subject']); // Redireciona para a lista de assuntos após salvar
        },
        (error) => {
          console.error('Erro ao atualizar o assunto:', error);
        }
      );
    }
  }
}
