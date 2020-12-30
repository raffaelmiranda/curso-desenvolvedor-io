import { Component, OnInit, Inject, Injector, NgZone } from '@angular/core';
import { BarServices, BarServicesMock, BarFactory, BebidaService } from './bar.service';
import { BarUnidadeConfig, BAR_UNIDADE_CONFIG } from './bar.config';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-bar',
  templateUrl: './bar.component.html',
  providers: [
    //{ provide: BarServices, useClass: BarServices },
    {
      provide: BarServices, useFactory: BarFactory,
      deps: [
        HttpClient,
        Injector
      ]
    },
    { provide: BebidaService, useExisting: BarServices }
  ]
})
export class BarComponent implements OnInit {
  ConfigManual: BarUnidadeConfig
  Config: BarUnidadeConfig
  barbebida1: String;
  dadosUnidade: string;

  barbebida2: String;

  constructor(
    private barServices: BarServices,
    @Inject('ConfigManualUnidade') private ApiConfigManual: BarUnidadeConfig,
    @Inject(BAR_UNIDADE_CONFIG) private ApiConfig: BarUnidadeConfig,
    private bebidaService: BebidaService,
    private ngZOne: NgZone
  ) { }

  ngOnInit() {
    this.barbebida1 = this.barServices.obterBebidas();
    this.ConfigManual = this.ApiConfigManual
    this.Config = this.ApiConfig
    this.dadosUnidade = this.barServices.obterUnidade();

    this.barbebida2 = this.bebidaService.obterBebida();
  }

  public progress: number = 0;
  public label: string;

  processWithinAngularZone() {
    this.label = 'dentro';
    this.progress = 0;
    this._increaseProgress(() => console.log('Finalizado por dentro do Angular!'));
  }

  processOutsideOfAngularZone() {
    this.label = 'fora';
    this.progress = 0;
    this.ngZOne.runOutsideAngular(() => {
      this._increaseProgress(() => {
        this.ngZOne.run(() => { console.log('Finalizado fora !'); });
      })
    })
  }

  _increaseProgress(doneCallBack: () => void) {
    this.progress += 1;
    console.log(`Progresso atual: ${this.progress}%`);

    if (this.progress < 100) {
      window.setTimeout(() => this._increaseProgress(doneCallBack), 10);
    } else {
      doneCallBack();
    }
  }

}
