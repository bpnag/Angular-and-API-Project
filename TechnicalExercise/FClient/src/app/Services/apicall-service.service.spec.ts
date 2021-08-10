import { TestBed } from '@angular/core/testing';

import { APICallServiceService } from './apicall-service.service';

describe('APICallServiceService', () => {
  let service: APICallServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(APICallServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
