import { Component, ViewChild } from '@angular/core';
import { FeedContainerComponent } from '../feed-container/feed-container.component';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css']
})
export class HomeComponent {

    @ViewChild(FeedContainerComponent)
    feedContainer: FeedContainerComponent;

    onScroll() {
        switch(this.feedContainer.mainTabGroup.selectedIndex) {
            case 0:
                this.feedContainer.myFeedComponent.loadNextPage();
                break;
            
            case 1: 
                this.feedContainer.trendingFeedComponent.loadNextPage();
                break;
        }
    }

}
