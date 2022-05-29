import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { CategoryService } from 'src/app/core/http-services/category/category.service';
import { ChargingPointService } from 'src/app/core/http-services/charging-points/charging-point.service';
import { RegionService } from 'src/app/core/http-services/region/region.service';
import { TouristPointService } from 'src/app/core/http-services/tourist-point/tourist-point.service';
import { CategoryBasicInfoModel } from 'src/app/shared/models/out/category-basic-info-model';
import { ChargingPointModel } from 'src/app/shared/models/out/charging-point-model';
import { RegionBasicInfoModel } from 'src/app/shared/models/out/region-basic-info-model';

@Component({
  selector: 'app-create-charging-point',
  templateUrl: './create-charging-point.component.html',
  styleUrls: []
})
export class CreateCharginPointComponent implements OnInit {
  public explanationTitle: string;
  public explanationDescription: string;
  public justCreatedChargingPoint = false;
  public name: string;
  public description: string;
  public address: string;
  public image: string;
  public regionId: number;
  public categoriesIds: number[] = [];
  public displayError: boolean;
  public errorMessages: string[] = [];
  public imageName: string;
  public categories: CategoryBasicInfoModel[] = [];
  public regions: RegionBasicInfoModel[] = [];
  private chargingPointModel: ChargingPointModel;


  constructor(
    private chargingPointService: ChargingPointService,
    private categoryService: CategoryService,
    private regionService: RegionService
  ) {}

  ngOnInit(): void {
    this.getRegions();
    this.populateExplanationParams();
  }

  private getRegions(): void {
    this.regionService.allRegions().subscribe(
      (regions) => {
        this.loadRegions(regions);
      },
      (error) => this.showError(error)
    );
  }

  private loadRegions(regions: RegionBasicInfoModel[]): void {
    this.regions = regions;
  }

  public setName(name: string): void {
    this.name = name;
  }

  public setDescription(description: string): void {
    this.description = description;
  }

  public setAddress(address: string): void {
    this.address = address;
  }

  public selectRegion(regionId: number): void {
    this.regionId = regionId;
  }

  public loadFile(file: File): void {
    const reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onloadend = (): void => {
      this.image =
        typeof reader.result === 'string'
          ? reader.result.replace(/^data:.+;base64,/, '')
          : undefined;
    };
    this.imageName = file?.name;
  }

  public createTouristPoint(): void {
    this.validateInputs();

    if (!this.displayError) {
      this.chargingPointModel = {
        name: this.name,
        description: this.description,
        address: this.address,
        regionId: this.regionId
      };
      this.chargingPointService.createChargingPoint(this.chargingPointModel).subscribe(
        response => {this.justCreatedChargingPoint=true},
        error=> {this.showError(error)})
    } else {
      this.justCreatedChargingPoint = false;
    }
  }

  private validateInputs(): void {
    this.displayError = false;
    this.errorMessages = [];
    this.validateName();
    this.validateDescription();
    this.validateAddress();
    this.validateRegion();
  }

  private validateName(): void {
    if (!this.name?.trim()) {
      this.displayError = true;
      this.errorMessages.push(
        'Invalid or missing Name. Only up to 20 characters allowed'
      );
    }
  }

  private validateDescription(): void {
    if (!this.description?.trim()) {
      this.displayError = true;
      this.errorMessages.push(
        'Invalid or missing Description. Only up to 60 characters allowed'
      );
    }
  }

  private validateAddress(): void {
    if (!this.address?.trim()) {
      this.displayError = true;
      this.errorMessages.push(
        'Invalid or missing Address. Only up to 30 characters allowed'
      );
    }
  }

  private validateRegion(): void {
    if (!this.regionId) {
      this.displayError = true;
      this.errorMessages.push('Could not find specified region');
    }
  }

  private showError(error: HttpErrorResponse): void {
    console.log(error);
  }

  public closeError(): void {
    this.displayError = false;
  }

  private populateExplanationParams(): void {
    this.explanationTitle = 'Crear un punto de carga';
    this.explanationDescription = 'Aquí puedes crear un punto de carga!';
  }
}
