import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { ChargingPointBasicInfoModel } from 'src/app/shared/models/out/charging-point-basic-model';
import { ChargingPointModel } from 'src/app/shared/models/out/charging-point-model';
import { ChargingPointEndpoints } from '../endpoints';

@Injectable({
  providedIn: 'root'
})
export class ChargingPointService {
  constructor(private http: HttpClient) {}

  public createChargingPoint(
    newChargingtPoint: ChargingPointModel
  ): Observable<ChargingPointBasicInfoModel[]> {
    return this.http.post<ChargingPointBasicInfoModel[]>(
      ChargingPointEndpoints.CREATE_CHARGING_POINTS,
      newChargingtPoint
    );
  }
}
