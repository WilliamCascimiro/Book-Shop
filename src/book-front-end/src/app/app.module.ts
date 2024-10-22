import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CreateBookComponent } from './components/book/create-book/create-book.component';
import { provideHttpClient, withInterceptorsFromDi } from '@angular/common/http';
import { CreateAuthorComponent } from './components/author/create-author/create-author.component';
import { CreateSubjectComponent } from './components/subject/create-subject/create-subject.component';
import { ListSubjectComponent } from './components/subject/list-subject/list-subject.component';
import { ListAuthorComponent } from './components/author/list-author/list-author.component';
import { ListBookComponent } from './components/book/list-book/list-book.component';
import { DetailsAuthorComponent } from './components/author/details-author/details-author.component';
import { DetailsSubjectComponent } from './components/subject/details-subject/details-subject.component';
import { DetailsBookComponent } from './components/book/details-book/details-book.component';
import { EditAuthorComponent } from './components/author/edit-author/edit-author.component';
import { EditSubjectComponent } from './components/subject/edit-subject/edit-subject.component';
import { EditBookComponent } from './components/book/edit-book/edit-book.component';


@NgModule({
  declarations: [
    AppComponent,
    CreateBookComponent,
    CreateAuthorComponent,
    CreateSubjectComponent,
    ListSubjectComponent,
    ListAuthorComponent,
    ListBookComponent,
    DetailsAuthorComponent,
    DetailsSubjectComponent,
    DetailsBookComponent,
    EditAuthorComponent,
    EditSubjectComponent,
    EditBookComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [provideHttpClient(withInterceptorsFromDi())],
  bootstrap: [AppComponent]
})
export class AppModule { }
