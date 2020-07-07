import { Component, OnInit, Inject } from '@angular/core';
import { BarServices, BarServicesMock } from './bar.service';
import { BarUnidadeConfig, BAR_UNIDADE_CONFIG } from './bar.config';

@Component({
  selector: 'app-bar',
  templateUrl: './bar.component.html',
  providers: [
    { provide: BarServices, useClass: BarServices }
  ]
})
export class BarComponent implements OnInit {
  ConfigManual: BarUnidadeConfig
  Config: BarUnidadeConfig
  barbebida1: String;

  constructor(
    private barServices: BarServices,
    @Inject('ConfigManualUnidade') private ApiConfigManual: BarUnidadeConfig,
    @Inject(BAR_UNIDADE_CONFIG) private ApiConfig: BarUnidadeConfig
  ) { }

  ngOnInit() {
    this.barbebida1 = this.barServices.obterBebidas();
    this.ConfigManual = this.ApiConfigManual
    this.Config = this.ApiConfig
  }

}
