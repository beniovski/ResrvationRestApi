import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { error } from 'protractor';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  title = 'app23';

  getUrl = 'https://localhost:44377/api/UsersContoller';

  content: any;

  Users: ApiUserResponse[];

  constructor(private http: HttpClient) { }


  get() {
    this.content = this.http.get<ApiUserResponse>(this.getUrl)
      .subscribe(
      data => {
        this.Users = data['result'];
        console.log(this.Users);
        },
      );
  }
}
interface GetData {
  obj: Object;
}


interface GetPost {
  Id: number;
  Title: string;
}
interface ApiUserResponse {

  Id: number;
  Name: string; 
  LastName: string;  
  Phone: number;
  Email: string;
  ReservationDate: Array<Date>;
}
