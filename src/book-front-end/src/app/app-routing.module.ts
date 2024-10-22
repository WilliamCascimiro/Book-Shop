import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateBookComponent } from './components/book/create-book/create-book.component';
import { CreateSubjectComponent } from './components/subject/create-subject/create-subject.component';
import { CreateAuthorComponent } from './components/author/create-author/create-author.component';
import { ListAuthorComponent } from './components/author/list-author/list-author.component';
import { ListSubjectComponent } from './components/subject/list-subject/list-subject.component';
import { ListBookComponent } from './components/book/list-book/list-book.component';
import { DetailsBookComponent } from './components/book/details-book/details-book.component';
import { DetailsAuthorComponent } from './components/author/details-author/details-author.component';
import { DetailsSubjectComponent } from './components/subject/details-subject/details-subject.component';
import { EditBookComponent } from './components/book/edit-book/edit-book.component';
import { EditAuthorComponent } from './components/author/edit-author/edit-author.component';
import { EditSubjectComponent } from './components/subject/edit-subject/edit-subject.component';

const routes: Routes = [
  { path: 'create-book', component: CreateBookComponent }, // Rota para o componente de criação de livro
  { path: 'create-subject', component: CreateSubjectComponent }, // Rota para o componente de criação de livro
  { path: 'create-author', component: CreateAuthorComponent }, // Rota para o componente de criação de livro
  { path: 'list-author', component: ListAuthorComponent }, // Rota para o componente de criação de livro
  { path: 'list-subject', component: ListSubjectComponent }, // Rota para o componente de criação de livro
  { path: 'list-book', component: ListBookComponent }, // Rota para o componente de criação de livro
  { path: 'detail-book/:id', component: DetailsBookComponent }, // Rota para o componente de criação de livro
  { path: 'detail-author/:id', component: DetailsAuthorComponent }, // Rota para o componente de criação de livro
  { path: 'detail-subject/:id', component: DetailsSubjectComponent }, // Rota para o componente de criação de livro
  { path: 'edit-subject/:id', component: EditSubjectComponent }, // Rota para o componente de criação de livro
  { path: 'edit-author/:id', component: EditAuthorComponent }, // Rota para o componente de criação de livro
  { path: 'edit-book/:id', component: EditBookComponent }, // Rota para o componente de criação de livro
  { path: '', redirectTo: '/create-book', pathMatch: 'full' }, // Redireciona a raiz para create-book
  { path: '**', redirectTo: '/create-book' } // Redireciona qualquer rota não encontrada para create-book
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
