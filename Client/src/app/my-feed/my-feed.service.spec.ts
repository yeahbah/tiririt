import { TestBed } from '@angular/core/testing';

import { MyFeedService } from './my-feed.service';

describe('MyFeedService', () => {
  let service: MyFeedService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MyFeedService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
