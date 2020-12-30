import { Injectable, Inject, Injector, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BAR_UNIDADE_CONFIG, BarUnidadeConfig } from './bar.config';

export function BarFactory(http: HttpClient, injector: Injector) {
    return new BarServices(http, injector.get(BAR_UNIDADE_CONFIG));
}

@Injectable()
export class BarServices {

    constructor(
        private http: HttpClient,
        @Inject(BAR_UNIDADE_CONFIG) private config: BarUnidadeConfig
    ) { }

    obterUnidade(): string {
        return 'Unidade ID: ' + this.config.unidadeId + 'Token: ' + this.config.unidadeToken;
    }

    obterBebidas(): string {
        return 'Bebidasss';
    }

    obterPorcoes(): string {
        return 'Porções';
    }

    obterRefeicoes(): string {
        return 'Refeições';
    }
}

export class BarServicesMock {

    constructor(private http: HttpClient) { }

    obterBebidas(): string {
        return 'Mock';
    }

    obterPorcoes(): string {
        return 'Mock';
    }

    obterRefeicoes(): string {
        return 'Mock';
    }
}

export abstract class BebidaService {
    obterBebida: () => string
}
