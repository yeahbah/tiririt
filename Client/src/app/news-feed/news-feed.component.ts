import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
// import * as xml2js from "xml2js";
// import { NewsRss } from './news-rss';

@Component({
  selector: 'app-news-feed',
  templateUrl: './news-feed.component.html',
  styleUrls: ['./news-feed.component.css']
})
export class NewsFeedComponent implements OnInit {

  // rssData: NewsRss;
  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    // this.getRssFeedData();
  }

  // getRssFeedData() {
  //   const requestOptions: Object = {
  //     observe: "body",
  //     responseType: "text"
  //   };
  //   this.http
  //     .get<any>("https://investing.einnews.com/rss/dh5LoBFONe1cJ1s0", requestOptions)
  //     .subscribe(data => {
  //       console.log(data);
  //       let parseString = xml2js.parseString;
  //       parseString(data, (err, result: NewsRss) => {
  //         this.rssData = result;
  //       });
  //     });
  // }

}
