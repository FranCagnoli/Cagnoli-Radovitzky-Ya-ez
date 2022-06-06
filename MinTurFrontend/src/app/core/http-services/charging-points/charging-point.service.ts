import { ChargingPointBasicInfoModel } from 'src/app/shared/models/out/charging-point-basic-model';
import { ChargingPointEndpoints } from '../endpoints';
import { ChargingPointModel } from 'src/app/shared/models/out/charging-point-model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { format } from 'util';

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
  public getAll(): Observable<ChargingPointBasicInfoModel[]> {
    return this.http.get<ChargingPointBasicInfoModel[]>(
      ChargingPointEndpoints.CREATE_CHARGING_POINTS
    );
  }

  public delete(id: number): Observable<void> {
    return this.http.delete<void>(
      format(ChargingPointEndpoints.CREATE_CHARGING_POINTS + '/' + id)
    );
  }
}
