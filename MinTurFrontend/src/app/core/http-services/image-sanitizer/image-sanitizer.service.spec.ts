/* eslint-disable @typescript-eslint/no-unused-vars */

import { TestBed, async, inject } from '@angular/core/testing';
import { ImageSanitizerService } from './image-sanitizer.service';

describe('Service: ImageSanitizer', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ImageSanitizerService]
    });
  });

  it('should ...', inject([ImageSanitizerService], (service: ImageSanitizerService) => {
    expect(service).toBeTruthy();
  }));
});
