import { Component, OnInit } from '@angular/core';
import { AdminSpecificRoutes, ChargingPoints } from 'src/app/core/routes';
import { ChargingPointBasicInfoModel } from 'src/app/shared/models/out/charging-point-basic-model';
import { ChargingPointService } from 'src/app/core/http-services/charging-points/charging-point.service';
import { HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-charging-point-list',
  templateUrl: './charging-point-list.component.html',
  styleUrls: []
})
export class ChargingPointListComponent implements OnInit {
  public chargingPoints: ChargingPointBasicInfoModel[];
  public ownEmail: string;

  constructor(
    private chargingPointService: ChargingPointService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.ownEmail =
      JSON.parse(localStorage.getItem('userInfo'))?.email ?? 'administrador';
    this.getChargingPoints();
  }

  private getChargingPoints(): void {
    this.chargingPointService.getAll().subscribe(
      (response) => this.loadChargingPoints(response),
      (error: HttpErrorResponse) => this.showError(error)
    );
  }

  private loadChargingPoints(
    chargingPoints: ChargingPointBasicInfoModel[]
  ): void {
    this.chargingPoints = chargingPoints;
  }

  public deleteChargingPoint(chargingPointId: number): void {
    this.chargingPointService.delete(chargingPointId).subscribe(
      (response) => this.getChargingPoints(),
      (error: HttpErrorResponse) => this.showError(error)
    );
  }

  public isItMe(email: string): boolean {
    return this.ownEmail === email;
  }

  public goToChargingPointCreate(): void {
    this.router.navigate([ChargingPoints.CHARGING_POINT_CREATE], {
      replaceUrl: true
    });
  }

  private showError(error: HttpErrorResponse): void {
    console.log(error);
  }
}
