import { Component } from '@angular/core';
import { SubjectService } from '../../../services/subject.service';
import { Subject } from '../../../models/subject';
import { Router } from '@angular/router';

@Component({
  selector: 'app-list-subject',
  templateUrl: './list-subject.component.html',
  styleUrl: './list-subject.component.css'
})
export class ListSubjectComponent {
  subjects: Subject[] = [];

  constructor(private subjectService: SubjectService, private router: Router) {}

  ngOnInit(): void {
    this.loadSubjects();
  }

  loadSubjects(): void {
    this.subjectService.getSubjects().subscribe(
      (data: Subject[]) => {
        this.subjects = data;
      },
      error => {
        console.error('Erro ao carregar autores', error);
      }
    );
  }

 
 editSubject(subjectId: string): void {
  this.router.navigate(['/edit-subject', subjectId]);
}

detailsSubject(subjectId: string): void {
  this.router.navigate(['/detail-subject', subjectId]);
}

deleteSubject(subjectId: string): void {
  this.subjectService.deleteSubject(subjectId).subscribe(
    () => {
      // Atualiza a lista de autores após deletar
      this.subjects = this.subjects.filter(subject => subject.id !== subjectId);
      console.log('Autor excluído com sucesso');
    },
    error => {
      console.error('Erro ao excluir autor', error);
    }
  );
}
}
