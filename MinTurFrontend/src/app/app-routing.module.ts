import { ResortCreateModule } from './feature-modules/resort-create/resort-create.module';
import { ResortCreateComponent } from './feature-modules/resort-create/resort-create.component';
import { ResortListModule } from './feature-modules/resort-list/resort-list.module';
import { ResortListComponent } from './feature-modules/resort-list/resort-list.component';
import { UpdateReservationStateModule } from './feature-modules/update-reservation-state/update-reservation-state.module';
import { UpdateReservationStateComponent } from './feature-modules/update-reservation-state/update-reservation-state.component';
import { UpdateResortAvailabilityModule } from './feature-modules/update-resort-availability/update-resort-availability.module';
import { UpdateResortAvailabilityComponent } from './feature-modules/update-resort-availability/update-resort-availability.component';
import { CreateTouristPointModule } from './feature-modules/create-tourist-point/create-tourist-point.module';
import { CreateTouristPointComponent } from './feature-modules/create-tourist-point/create-tourist-point.component';
import { AdminCreateModule } from './feature-modules/admin-create/admin-create.module';
import { AdminCreateComponent } from './feature-modules/admin-create/admin-create.component';
import { AdminDetailModule } from './feature-modules/admin-detail/admin-detail.module';
import { AdminDetailComponent } from './feature-modules/admin-detail/admin-detail.component';
import { AdminListModule } from './feature-modules/admin-list/admin-list.module';
import { AdminListComponent } from './feature-modules/admin-list/admin-list.component';
import { LoginModule } from './feature-modules/login/login.module';
import { LoginComponent } from './feature-modules/login/login.component';
import { CheckReservationComponent } from './feature-modules/check-reservation/check-reservation.component';
import { CheckReservationModule } from './feature-modules/check-reservation/check-reservation.module';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ExploreOneResortComponent } from './feature-modules/explore-one-resort/explore-one-resort.component';
import { ExploreOneResortModule } from './feature-modules/explore-one-resort/explore-one-resort.module';
import { ExploreRegionsComponent } from './feature-modules/explore-regions/explore-regions.component';
import { ExploreRegionsModule } from './feature-modules/explore-regions/explore-regions.module';
import { ExploreResortsComponent } from './feature-modules/explore-resorts/explore-resorts.component';
import { ExploreResortsModule } from './feature-modules/explore-resorts/explore-resorts.module';
import { ExploreTouristPointsComponent } from './feature-modules/explore-tourist-points/explore-tourist-points.component';
import { ExploreTouristPointsModule } from './feature-modules/explore-tourist-points/explore-tourist-points.module';
import { SubmitReviewComponent } from './feature-modules/submit-review/submit-review.component';
import { SubmitReviewModule } from './feature-modules/submit-review/submit-review.module';
import { AuthGuard } from './core/guards/auth-guard';
import { ReservationReportComponent } from './feature-modules/reservation-report/reservation-report.component';
import { ReservationReportModule } from './feature-modules/reservation-report/reservation-report.module';
import { ImportingComponent } from './feature-modules/importing/importing.component';
import { ImportingModule } from './feature-modules/importing/importing.module';
import { CreateChargingPointComponent } from './feature-modules/create-charging-point/create-charging-point.component';
import { CreateChargingPointModule } from './feature-modules/create-charging-point/create-charging-point.module';
import { ChargingPointListModule } from './feature-modules/charging-pont-list/charging-point-list.module';
import { ChargingPointListComponent } from './feature-modules/charging-pont-list/charging-point.component';
import {
  AdminSpecificRoutes,
  ChargingPoints,
  ImporterRoutes,
  RegionRoutes,
  ReservationRoutes,
  ResortRoutes,
  ReviewRoutes,
  SessionRoutes,
  TouristPointRoutes
} from './core/routes';

const routes: Routes = [
  { path: '', redirectTo: RegionRoutes.REGIONS, pathMatch: 'full' },
  {
    path: RegionRoutes.DEFAULT,
    redirectTo: RegionRoutes.REGIONS,
    pathMatch: 'full',
    canActivate: [AuthGuard],
    data: { isAdminAllowed: false }
  },
  {
    path: RegionRoutes.REGIONS,
    component: ExploreRegionsComponent,
    canActivate: [AuthGuard],
    data: { isAdminAllowed: false }
  },
  {
    path: ReservationRoutes.CHECK_RESERVATION,
    component: CheckReservationComponent,
    canActivate: [AuthGuard],
    data: { isAdminAllowed: false }
  },
  {
    path: TouristPointRoutes.TOURIST_POINTS,
    component: ExploreTouristPointsComponent,
    canActivate: [AuthGuard],
    data: { isAdminAllowed: false }
  },
  {
    path: ResortRoutes.RESORTS,
    component: ExploreResortsComponent,
    canActivate: [AuthGuard],
    data: { isAdminAllowed: false }
  },
  { path: ResortRoutes.RESORT_DETAIL, component: ExploreOneResortComponent },
  {
    path: ReviewRoutes.REVIEW,
    component: SubmitReviewComponent,
    canActivate: [AuthGuard],
    data: { isAdminAllowed: false }
  },
  { path: SessionRoutes.LOGIN, component: LoginComponent },
  {
    path: AdminSpecificRoutes.ADMIN_LIST,
    component: AdminListComponent,
    canActivate: [AuthGuard],
    data: { isAdminAllowed: true }
  },
  {
    path: `${AdminSpecificRoutes.ADMIN_DETAIL}/:administratorId`,
    component: AdminDetailComponent,
    canActivate: [AuthGuard],
    data: { isAdminAllowed: true }
  },
  {
    path: AdminSpecificRoutes.ADMIN_CREATE,
    component: AdminCreateComponent,
    canActivate: [AuthGuard],
    data: { isAdminAllowed: true }
  },
  {
    path: TouristPointRoutes.TOURIST_POINT_CREATE,
    component: CreateTouristPointComponent,
    canActivate: [AuthGuard],
    data: { isAdminAllowed: true }
  },
  {
    path: ChargingPoints.CHARGING_POINT_CREATE,
    component: CreateChargingPointComponent,
    canActivate: [AuthGuard],
    data: { isAdminAllowed: true }
  },
  {
    path: ChargingPoints.CHARGING_POINTS,
    component: ChargingPointListComponent,
    canActivate: [AuthGuard],
    data: { isAdminAllowed: true }
  },
  {
    path: ResortRoutes.UPDATE_AVAILABILITY,
    component: UpdateResortAvailabilityComponent,
    canActivate: [AuthGuard],
    data: { isAdminAllowed: true }
  },
  {
    path: ReservationRoutes.UPDATE_STATE,
    component: UpdateReservationStateComponent,
    canActivate: [AuthGuard],
    data: { isAdminAllowed: true }
  },
  {
    path: ReservationRoutes.REPORT,
    component: ReservationReportComponent,
    canActivate: [AuthGuard],
    data: { isAdminAllowed: true }
  },
  {
    path: ImporterRoutes.IMPORT,
    component: ImportingComponent,
    canActivate: [AuthGuard],
    data: { isAdminAllowed: true }
  },
  {
    path: ResortRoutes.RESORT_LIST,
    component: ResortListComponent,
    canActivate: [AuthGuard],
    data: { isAdminAllowed: true }
  },
  {
    path: ResortRoutes.RESORT_CREATE,
    component: ResortCreateComponent,
    canActivate: [AuthGuard],
    data: { isAdminAllowed: true }
  },
  { path: '**', redirectTo: RegionRoutes.REGIONS, pathMatch: 'full' }
];

@NgModule({
  imports: [
    ExploreRegionsModule,
    ExploreTouristPointsModule,
    ExploreResortsModule,
    ExploreOneResortModule,
    SubmitReviewModule,
    CheckReservationModule,
    LoginModule,
    AdminListModule,
    AdminDetailModule,
    AdminCreateModule,
    CreateTouristPointModule,
    UpdateResortAvailabilityModule,
    UpdateReservationStateModule,
    ReservationReportModule,
    ImportingModule,
    ResortListModule,
    ResortCreateModule,
    RouterModule.forRoot(routes),
    CreateChargingPointModule,
    ChargingPointListModule
  ],
  exports: [RouterModule]
})
export class AppRoutingModule {}
