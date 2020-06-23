import { TestBed } from '@angular/core/testing';

import { TagFeedService } from './tag-feed.service';

describe('TagFeedService', () => {
  let service: TagFeedService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TagFeedService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
