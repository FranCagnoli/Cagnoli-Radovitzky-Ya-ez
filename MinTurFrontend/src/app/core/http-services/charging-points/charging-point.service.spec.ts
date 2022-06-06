import { TestBed } from '@angular/core/testing';

import { ChargingPointService } from './charging-point.service';

describe('ChargingPointService', () => {
  let service: ChargingPointService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ChargingPointService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
