import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.css']
})
export class BooksComponent {
  public books: Book[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    console.log('books');
    http.get<Book[]>(baseUrl + 'api/Books/GetAllBooks').subscribe(result => {
      this.books = result;
    }, error => console.error(error));
  }

  coloredRowIndex: number = 1;

  onChangeButtonColorClick() {
    this.coloredRowIndex = ++this.coloredRowIndex % this.books.length;
  }

  isRowColored(book: Book) {
    // Shouldve used book.id, but since db is not configured using title
    return book.title === this.books[this.coloredRowIndex].title;
  }

}

class Book {
  title: string;
  publishedOn: Date;
  autor: Author;
}

class Author {
  id: number;
  firstName: string;
  lastName: string;
}
