import { Component, Inject, ElementRef, ViewChild } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';

@Component({
  selector: 'strtoimg',
  templateUrl: './str-to-img.component.html'
})
export class StrToImgComponent {

  @ViewChild('input')
  private input: ElementRef;

  @ViewChild('output')
  private output: ElementRef;

  str: string;
  http: HttpClient;
  baseUrl: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;
  }

  onGetImageButtonClick() {
    let httpParams = new HttpParams()
      .set('str', this.input.nativeElement.value.toString());
    this.http.get(this.baseUrl + 'api/StrToImg/GetImage').subscribe(result => {
      this.output.nativeElement.value = result;
    }, error => console.error(error));
  }
}
