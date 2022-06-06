import { CategoryBasicInfoModel } from './category-basic-info-model';
import { ImageBasicInfoModel } from './image-basic-info-model';
import { RegionBasicInfoModel } from './region-basic-info-model';

export interface ChargingPointBasicInfoModel {
  id: number;
  name: string;
  description: string;
  address: string;
  region: RegionBasicInfoModel;
}
