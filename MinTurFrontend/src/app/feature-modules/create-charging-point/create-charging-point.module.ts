import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateCharginPointComponent } from './create-charging-point.component';
import { UtilitiesModule } from 'src/app/shared/utilities/utilities.module';

@NgModule({
  imports: [CommonModule, UtilitiesModule],
  declarations: [CreateCharginPointComponent],
  exports: [CreateCharginPointComponent]
})
export class CreateCharginPointModule {}
