import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NewsRss } from './news-rss';
// import * as xml2js from "xml2js";
// import { NewsRss } from './news-rss';

@Component({
  selector: 'app-news-feed',
  templateUrl: './news-feed.component.html',
  styleUrls: ['./news-feed.component.css']
})
export class NewsFeedComponent implements OnInit {

  rssData: NewsRss;
  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getRssFeedData();
  }

  getRssFeedData() {
  
    this.http
      .get<NewsRss>("./assets/news-feed.json")
      .subscribe(data => {          
        this.rssData = data;
        // if (this.rssData) {
        //   for(let i = 0; i < this.rssData.rss.channel.item.length; i++) {
        //     this.rssData.rss.channel.item[i].description = this.rssData.rss.channel.item[i].description.replace(/(<([^>]+)>|&#\d+;)/ig, "");
        //   }
        // }
      });
  }

}
